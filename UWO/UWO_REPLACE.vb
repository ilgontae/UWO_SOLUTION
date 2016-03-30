'Revision By: Luke Westelaken
'Date: January 13, 2016
'Revisions made: added github source control at https://github.com/ilgontae/UWO_SOLUTION
' all revisions will be made and recorded there

Imports System.Text.RegularExpressions
Imports System.IO
Imports System.ComponentModel
Imports System.Threading
Imports System
Imports System.Text

Public Class UWO_REPLACE
	Private bw As BackgroundWorker = New BackgroundWorker
	Private FileList As New List(Of String)
	Private Ext As String
	Private WildcardEnable As Boolean = False
	Private boolUpgrade As Boolean = False
	Dim countFiles As Integer
	Dim counter As Integer = 0
	Dim max As Integer = 10
	Dim conflictList As New List(Of String)
	Dim objList As New List(Of inObj)
	Dim writeString As String = "Log" & vbCrLf & "-------"

	Private Structure inObj
		Dim type As String
		Dim numOrig As Integer
		Dim numNew As Integer
		Public Overrides Function toString() As String
			Return (type & numOrig & " --> " & type & numNew)
		End Function
	End Structure

	Private Sub FindAllObj(ByVal fname As String)
		objList.Clear()
		Dim panelNum As String = ParseDigits(TB_Find.Text)
		Dim testTxt As New StreamReader(fname)
		Dim allRead As String = testTxt.ReadToEnd()
		testTxt.Close()
		Dim regMatch As String
		regMatch = "[(.]" & panelNum & "\.(?i)(AI|BI|AO|BO)\d{1,3}"
		Dim rgx As New Regex(regMatch)
		Dim tempStr As String
		'Dim tempArr(2) As String
		Dim tempNum As Integer
		For Each match As Match In rgx.Matches(allRead)
			tempStr = match.Value
			tempStr = tempStr.Substring(tempStr.LastIndexOf(".") + 1)
			tempNum = ParseDigits(tempStr)
			Dim o As inObj
			o.numOrig = tempNum
			If tempNum <= 99 Then
				tempNum = translateTwoDigit(tempNum)
			Else
				tempNum = translateThreeDigits(tempNum)
			End If
			o.type = tempStr.Substring(0, 2)
			o.numNew = tempNum
			If objList.Count = 0 Then
				objList.Add(o)
			ElseIf Not (objList(objList.Count - 1).type = o.type And objList(objList.Count - 1).numOrig = o.numOrig) Then
				objList.Add(o)
			End If
		Next
	End Sub

	Private Sub FindStr(ByVal fname As String)
		Try
			Dim panelNum As String = ParseDigits(TB_Find.Text)
			Dim testTxt As New StreamReader(fname)
			Dim allRead As String = testTxt.ReadToEnd()
			testTxt.Close()
			Dim regMatch As String
			If WildcardEnable = False And Not boolUpgrade Then
				regMatch = Regex.Escape(TB_Find.Text)
			ElseIf boolUpgrade Then
				regMatch = "[(.]" & panelNum & "\.((AI|BI|AO|BO)\d{1,3})"
			Else
				regMatch = TB_Find.Text
			End If


			If Regex.IsMatch(allRead, regMatch, RegexOptions.IgnoreCase) Then
				Dim SP As String = fname.Remove(0, TB_Directory.Text.Length + 1)
				SP = SP.ToUpper
				If (boolUpgrade) Then
					Dim conflictFlag As Boolean = False
					Dim rgx As New Regex(regMatch)
					For Each match As Match In rgx.Matches(allRead)
						regMatch = "[(.]\d+" & panelNum & "\." & match.Groups(1).Value & "\."
						Dim rgx2 As New Regex(regMatch)
						If Regex.IsMatch(allRead, regMatch, RegexOptions.IgnoreCase) Then
							conflictFlag = True
							Exit For
						End If
					Next
					If Not conflictFlag Then
						FileList.Add(fname)
						ListView1.Items.Add(New ListViewItem(New String() {fname, ""}))
					Else
						conflictList.Add(fname)
						ListView1.Items.Add(New ListViewItem(New String() {fname, "Conflict"}))
					End If
				Else
					FileList.Add(fname)
					ListView1.Items.Add(New ListViewItem(New String() {fname, ""}))
				End If
				ListView1.Update()
				ListView1.EnsureVisible(ListView1.Items.Count - 1)
			End If

		Catch
		End Try
	End Sub
	Function ParseDigits(ByVal strRawValue As String) As String
		Dim strDigits As String = ""
		If strRawValue = Nothing Then Return strDigits
		For Each c As Char In strRawValue.ToCharArray()
			If Char.IsDigit(c) Then
				strDigits &= c
			End If
		Next c
		Return strDigits
	End Function
	Private Sub getfile(ByVal dir As String)
		Dim a As String = My.Computer.FileSystem.GetDirectoryInfo(dir).Name.ToString
		'BackgroundWorker1.ReportProgress(counter / countFiles)
		If Not String.Compare(a, "Temp", True) = 0 And
		   Not String.Compare(a, "bmp", True) = 0 And
		   Not String.Compare(a, "archive", True) = 0 And
		   Not String.Compare(a, "backup", True) = 0 And
		   Not String.Compare(a, "help files", True) = 0 Then


			For Each files As String In My.Computer.FileSystem.GetFiles(dir)
				counter += 1
				If Ext = "" Or (String.Compare(Ext, files.Split(".").Last, True) = 0) Then
					'counter += 1
					FindStr(files)
					'BackgroundWorker1.ReportProgress(counter / countFiles)
				End If
			Next
			For Each root As String In My.Computer.FileSystem.GetDirectories(dir)
				getfile(root)
			Next
		Else
			counter += 1
		End If
	End Sub

	Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object,
		ByVal e As System.ComponentModel.ProgressChangedEventArgs) _
		Handles BackgroundWorker1.ProgressChanged
		'ProgressBar1.Value = e.ProgressPercentage
	End Sub
	Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object,
	ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) _
	Handles BackgroundWorker1.RunWorkerCompleted
		ProgressBar1.Value = ProgressBar1.Maximum
		endSearch()
	End Sub
	Private Sub FindCheck()
		If Not TB_Find.Text = "" And
		   Not TB_Directory.Text = "" Then
			If Directory.Exists(TB_Directory.Text) Then
				B_Find.Enabled = True
				TB_Directory.ForeColor = Color.Black
			Else
				B_Find.Enabled = False
				TB_Directory.ForeColor = Color.Red
			End If
		Else
			B_Find.Enabled = False
		End If
	End Sub
	Sub DirSearch(ByVal sDir As String)
		Dim d = My.Computer.FileSystem.GetDirectoryInfo(sDir).Name.ToString
		Dim f As String

		Try
			If String.Compare(d, "Temp", True) = 1 And
				 String.Compare(d, "bmp", True) = 1 And
				 String.Compare(d, "archive", True) = 1 And
				 String.Compare(d, "backup", True) = 1 And
				 String.Compare(d, "help files", True) = 1 Then
				For Each d In Directory.GetDirectories(sDir)
					For Each f In Directory.GetFiles(d)
						countFiles += 1
					Next
					DirSearch(d)
				Next
			End If
		Catch excpt As System.Exception
			Debug.WriteLine(excpt.Message)
		End Try
	End Sub
	Private Sub ReplaceCheck()
		If boolUpgrade Then
			B_Replace.Enabled = True
		ElseIf Not TB_Replace.Text = "" And Ext = "gpc" Then
			B_Replace.Enabled = True
		Else
			B_Replace.Enabled = False
		End If
	End Sub

	Private Sub TB_Find_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TB_Find.TextChanged
		FindCheck()
	End Sub

	Private Sub TB_Directory_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TB_Directory.TextChanged
		FindCheck()
	End Sub

	Private Sub TB_Replace_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TB_Replace.TextChanged
		ReplaceCheck()
	End Sub

	Private Sub TB_Ext_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TB_Ext.TextChanged
		Try
			If TB_Ext.Text(0) = "." Then
				Ext = TB_Ext.Text.Remove(0, 1)
			Else
				Ext = TB_Ext.Text
			End If
		Catch
			Ext = ""
		End Try
		ReplaceCheck()
	End Sub


	Private Sub ListView1_ItemSelectionChanged(ByVal sender As Object, ByVal e As ListViewItemSelectionChangedEventArgs) Handles ListView1.ItemSelectionChanged
		B_Remove.Enabled = True
	End Sub

	Private Sub Main_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
		TB_Find.CharacterCasing = CharacterCasing.Upper
		TB_Replace.CharacterCasing = CharacterCasing.Upper
		TB_Directory.Text = "W:\PUBLIC\Delta\Graphics"
		Wildcard.Enabled = True
	End Sub

	Private Sub B_Find_Click(ByVal sender As Object, ByVal e As EventArgs) Handles B_Find.Click
		BackgroundWorker1.RunWorkerAsync()
	End Sub

	Private Sub B_Save_Click(ByVal sender As Object, ByVal e As EventArgs) Handles B_Save.Click
		SFD_SaveList.DefaultExt = ".txt"
		SFD_SaveList.FileName = "DLR_"
		SFD_SaveList.Filter = "Text Files (*.txt)|*.txt|Excel Files (*.xls)|*.xls"
		SFD_SaveList.InitialDirectory = "C:\temp"
		SFD_SaveList.ShowDialog()
	End Sub

	Private Sub B_Remove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles B_Remove.Click
		For Each it As Integer In New ReverseIterator(ListView1.SelectedIndices)
			ListView1.Items.Remove(ListView1.Items(it))
			FileList.RemoveAt(it)
		Next
		L_Matches.Text = "Total Matches Found: " + FileList.Count.ToString
		L_Matches.Visible = True
	End Sub

	Private Function translateTwoDigit(ByVal num As Integer)
		If num <= 4 Then
			Return (1100 + num)
		ElseIf num <= 8 Then
			Return (1200 + (num - 4))
		ElseIf num <= 12 Then
			Return (2100 + (num - 8))
		ElseIf num <= 16 Then
			Return (2200 + (num - 12))
		Else Return -1
		End If
	End Function

	Private Function translateThreeDigits(ByVal num As Integer)
		Dim leadingInt = (CInt(num / 100)) * 1000
		Dim trailingInt = num - (leadingInt / 10)
		Dim returnInt As Integer
		If trailingInt <= 8 Then
			returnInt = (1000 + leadingInt + (translateTwoDigit(trailingInt)))
		ElseIf trailingInt <= 16 Then
			returnInt = (leadingInt + 200 + (translateTwoDigit(trailingInt)))
		Else
			Select Case trailingInt
				Case 17
					returnInt = (2000 + leadingInt) + 107
				Case 18
					returnInt = (2000 + leadingInt) + 108
				Case 19
					returnInt = (2000 + leadingInt) + 105
				Case 20
					returnInt = (2000 + leadingInt) + 106
				Case 21
					returnInt = (2000 + leadingInt) + 207
				Case 22
					returnInt = (2000 + leadingInt) + 208
				Case 23
					returnInt = (2000 + leadingInt) + 205
				Case 24
					returnInt = (2000 + leadingInt) + 206
				Case 25
					returnInt = (2000 + leadingInt) + 307
				Case 26
					returnInt = (2000 + leadingInt) + 308
				Case 27
					returnInt = (2000 + leadingInt) + 305
				Case 28
					returnInt = (2000 + leadingInt) + 306
				Case 29
					returnInt = (2000 + leadingInt) + 407
				Case 30
					returnInt = (2000 + leadingInt) + 408
				Case 31
					returnInt = (2000 + leadingInt) + 405
				Case 32
					returnInt = (2000 + leadingInt) + 406
			End Select
		End If
		Return returnInt
	End Function


	Private Sub B_Replace_Click(ByVal sender As Object, ByVal e As EventArgs) Handles B_Replace.Click
		Try
			If boolUpgrade Then
				Dim desktopPath = My.Computer.FileSystem.SpecialDirectories.Desktop
				Dim filePath = desktopPath & "\" & ParseDigits(TB_Find.Text)
				If Not Directory.Exists(filePath) Then
					My.Computer.FileSystem.CreateDirectory(filePath)
				End If
				If Not Directory.Exists(filePath & "\Conflicts") Then
					My.Computer.FileSystem.CreateDirectory(filePath & "\Conflicts")
				End If
				If Not Directory.Exists(filePath & "\Backups") Then
					My.Computer.FileSystem.CreateDirectory(filePath & "\Backups")
				End If
				Dim newPath As String
				For Each files As String In FileList
					Dim tempArr = Split(files, "\")
					'newPath = filePath & "\" & Path.GetFileName(files)
					newPath = filePath & "\" & tempArr(tempArr.Count - 2)
					If Not Directory.Exists(newPath) Then
						My.Computer.FileSystem.CreateDirectory(newPath)
					End If
					newPath &= "\" & Path.GetFileName(files)
					My.Computer.FileSystem.CopyFile(files, filePath & "\Backups\" & newPath.Split("\").Last, True)
					My.Computer.FileSystem.CopyFile(files, newPath, True)
					FindAllObj(newPath)             ' find all the objects that need to be updated --------------
					writeString &= vbCrLf & "** " & tempArr(tempArr.Count - 2) & "\" & newPath.Split("\").Last & " **" & vbCrLf
					AppActivate("ORCAView")
					Threading.Thread.Sleep(500)
					SendKeys.SendWait("%F")
					Threading.Thread.Sleep(5)
					SendKeys.SendWait("{DOWN}")
					Threading.Thread.Sleep(5)
					SendKeys.SendWait("{DOWN}")
					Threading.Thread.Sleep(5)


					SendKeys.SendWait("{ENTER}")
					Threading.Thread.Sleep(1000)
					SendKeys.SendWait(newPath.ToUpper)

					Threading.Thread.Sleep(5)
					SendKeys.SendWait("{ENTER}")
					Threading.Thread.Sleep(2000)

					'Opens the find and replace 
					AppActivate("ORCAview")
					Threading.Thread.Sleep(200)
					SendKeys.SendWait("%S")
					Threading.Thread.Sleep(100)
					SendKeys.SendWait("{DOWN}")
					Threading.Thread.Sleep(100)
					SendKeys.SendWait("{DOWN}")
					Threading.Thread.Sleep(100)

					SendKeys.SendWait("{DOWN}")
					Threading.Thread.Sleep(100)
					SendKeys.SendWait("{ENTER}")
					Threading.Thread.Sleep(1000)
					Dim count As Integer = 1
					For Each o In objList
						Debug.WriteLine(o.toString)
						writeString &= vbCrLf & o.toString
						SendKeys.SendWait(ParseDigits(TB_Find.Text) & "." & o.type & o.numOrig & ".") '*********************
						Threading.Thread.Sleep(50)
						SendKeys.SendWait("{TAB}")
						Threading.Thread.Sleep(50)
						SendKeys.SendWait(ParseDigits(TB_Find.Text) & "." & o.type & o.numNew & ".") '*****************************
						Threading.Thread.Sleep(50)
						SendKeys.SendWait("{TAB}")

						Threading.Thread.Sleep(50)
						SendKeys.SendWait("{TAB}")
						Threading.Thread.Sleep(50)

						SendKeys.SendWait("{ENTER}")
						Threading.Thread.Sleep(50)
						SendKeys.SendWait("{ENTER}")
						If count < objList.Count Then
							Threading.Thread.Sleep(50)
							SendKeys.SendWait("{TAB}")
							Threading.Thread.Sleep(50)
							SendKeys.SendWait("{TAB}")
							Threading.Thread.Sleep(50)
							count += 1
						End If
					Next
					Threading.Thread.Sleep(50)
					SendKeys.SendWait("{TAB}")
					Threading.Thread.Sleep(50)
					SendKeys.SendWait("{ENTER}")
					Threading.Thread.Sleep(50)
					SendKeys.SendWait("{TAB}")
					Threading.Thread.Sleep(50)
					SendKeys.SendWait("{ENTER}")
					Threading.Thread.Sleep(1000)

					'Closes the file
					AppActivate("<" + newPath.Split("\").Last + ">")
					Threading.Thread.Sleep(50)
					SendKeys.SendWait("%{F4}")
					Threading.Thread.Sleep(50)
					SendKeys.SendWait("{ENTER}")
					Threading.Thread.Sleep(1000)
					writeString &= vbCrLf
				Next
				Dim fs As FileStream = File.Create(filePath & "\LOG.txt")
				Dim info As Byte() = New UTF8Encoding(True).GetBytes(writeString)
				fs.Write(info, 0, info.Length)
				fs.Close()
				For Each files As String In conflictList
					Dim tempArr = Split(files, "\")
					newPath = filePath & "\Conflicts\" & tempArr(tempArr.Count - 2)
					If Not Directory.Exists(newPath) Then
						My.Computer.FileSystem.CreateDirectory(newPath)
					End If
					newPath &= "\" & Path.GetFileName(files)
					My.Computer.FileSystem.CopyFile(files, newPath, True)
					My.Computer.FileSystem.CopyFile(files, filePath & "\Backups\" & newPath.Split("\").Last, True)
				Next
				MessageBox.Show("COMPLETE" & vbCrLf & "Remember to manually update the" & vbCrLf & "files that have conflicts", "LINKS UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information)
			Else
				L_Left.Visible = True
				If Not Directory.Exists(TB_Directory.Text) Then
					MessageBox.Show("You Need Access to W Drive", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
					Exit Sub
				End If
				Dim num As Integer = 1
				For Each files As String In FileList
					'Opens the file in orcaview
					AppActivate("ORCAView")
					Threading.Thread.Sleep(500)
					SendKeys.SendWait("%F")
					Threading.Thread.Sleep(5)
					SendKeys.SendWait("{DOWN}")
					Threading.Thread.Sleep(5)
					SendKeys.SendWait("{DOWN}")
					Threading.Thread.Sleep(5)


					SendKeys.SendWait("{ENTER}")
					Threading.Thread.Sleep(1000)
					SendKeys.SendWait(files.ToUpper)

					Threading.Thread.Sleep(5)
					SendKeys.SendWait("{ENTER}")
					Threading.Thread.Sleep(2000)

					'Opens the find and replace 
					AppActivate("ORCAview")
					Threading.Thread.Sleep(50)
					SendKeys.SendWait("%S")
					Threading.Thread.Sleep(50)
					SendKeys.SendWait("{DOWN}")
					Threading.Thread.Sleep(50)
					SendKeys.SendWait("{DOWN}")
					Threading.Thread.Sleep(50)

					SendKeys.SendWait("{DOWN}")
					Threading.Thread.Sleep(50)
					SendKeys.SendWait("{ENTER}")
					Threading.Thread.Sleep(50)
					SendKeys.SendWait(TB_Find.Text.ToUpper)
					Threading.Thread.Sleep(50)
					SendKeys.SendWait("{TAB}")
					Threading.Thread.Sleep(50)
					SendKeys.SendWait(TB_Replace.Text.ToUpper)
					Threading.Thread.Sleep(50)
					SendKeys.SendWait("{TAB}")

					Threading.Thread.Sleep(50)
					SendKeys.SendWait("{TAB}")
					Threading.Thread.Sleep(50)

					SendKeys.SendWait("{ENTER}")
					Threading.Thread.Sleep(50)
					SendKeys.SendWait("{TAB}")
					Threading.Thread.Sleep(50)
					SendKeys.SendWait("{ENTER}")
					Threading.Thread.Sleep(50)
					SendKeys.SendWait("{TAB}")
					Threading.Thread.Sleep(50)
					SendKeys.SendWait("{ENTER}")
					Threading.Thread.Sleep(1000)

					'Closes the file
					AppActivate("<" + files.Split("\").Last + ">")
					Threading.Thread.Sleep(50)
					SendKeys.SendWait("%{F4}")
					Threading.Thread.Sleep(50)
					SendKeys.SendWait("{ENTER}")
					Threading.Thread.Sleep(1000)
					L_Left.Text = "Number Left:  " + (FileList.Count - num).ToString
					num += 1
				Next
				MessageBox.Show("COMPLETE" + vbCrLf & "Remember to manually do the" & vbCrLf & "files that had conflicts", "LINKS REPLACED", MessageBoxButtons.OK, MessageBoxIcon.Information)
			End If
		Catch ex As Exception
			MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub SFD_SaveList_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SFD_SaveList.FileOk
		Dim sav As String = SFD_SaveList.FileName
		My.Computer.FileSystem.WriteAllText(SFD_SaveList.FileName, "           -------------------------" + vbCrLf, False)
		My.Computer.FileSystem.WriteAllText(SFD_SaveList.FileName, "           |   DataLink Replacer   |" + vbCrLf, True)
		My.Computer.FileSystem.WriteAllText(SFD_SaveList.FileName, "           -------------------------" + vbCrLf + vbCrLf, True)
		My.Computer.FileSystem.WriteAllText(SFD_SaveList.FileName, "Searched For " + TB_Find.Text + vbCrLf, True)
		If Ext = "" Then
			My.Computer.FileSystem.WriteAllText(SFD_SaveList.FileName, "Searched ALL Extensions" + vbCrLf, True)
		Else
			My.Computer.FileSystem.WriteAllText(SFD_SaveList.FileName, "Searched ." + Ext + " Extensions" + vbCrLf, True)
		End If
		My.Computer.FileSystem.WriteAllText(SFD_SaveList.FileName, "Total Found " + FileList.Count.ToString + vbCrLf, True)
		My.Computer.FileSystem.WriteAllText(SFD_SaveList.FileName, "Date Searched " + DateTime.Now.ToLongDateString + " " + DateTime.Now.ToLongTimeString + vbCrLf + vbCrLf, True)

		For Each fi As String In FileList
			My.Computer.FileSystem.WriteAllText(SFD_SaveList.FileName, fi + vbCrLf, True)
		Next
	End Sub

	Private Sub TB_Directory_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TB_Directory.DoubleClick
		FBD_Directory.ShowDialog()
		TB_Directory.Text = FBD_Directory.SelectedPath
	End Sub

	Private Sub Wildcard_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Wildcard.Click
		If WildcardEnable = False Then
			WildcardEnable = True
			Wildcard.Text = "Wildcard Enabled"
		Else
			WildcardEnable = False
			Wildcard.Text = "Wildcard Disabled"
		End If

	End Sub

	Public Sub BackgroundWorker1_DoWork(ByVal sender As System.Object,
		ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
		Control.CheckForIllegalCrossThreadCalls = False
		B_Find.Enabled = False
		chk_Upgrade.Enabled = False
		Wildcard.Enabled = False
		B_Save.Enabled = False
		L_Matches.Visible = False
		L_Left.Visible = False
		B_Remove.Enabled = False
		chk_Upgrade.Enabled = False
		FileList.Clear()
		ListView1.Items.Clear()
		DirSearch(TB_Directory.Text)
		'ProgressBar1.Maximum = countFiles
		getfile(TB_Directory.Text)
		B_Replace.Enabled = True
		L_Matches.Visible = True
		B_Save.Enabled = True
		B_Find.Enabled = True
		'chk_Upgrade.Enabled = True
		Wildcard.Enabled = True
		Try
			ListView1.EnsureVisible(0)
		Catch
		End Try
		'SetLabelText_ThreadSafe(Me.L_Matches, ("Total Matches Found: " + FileList.Count.ToString))
	End Sub
	Public Sub endSearch()
		L_Matches.Text = "Total Matches Found: " + FileList.Count.ToString
		L_Matches.Visible = True
	End Sub
	' The delegate
	Delegate Sub SetLabelText_Delegate(ByVal [Label] As Label, ByVal [text] As String)

	' The delegates subroutine.
	Private Sub SetLabelText_ThreadSafe(ByVal [Label] As Label, ByVal [text] As String)
		' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.
		' If these threads are different, it returns true.
		If [Label].InvokeRequired Then
			Dim MyDelegate As New SetLabelText_Delegate(AddressOf SetLabelText_ThreadSafe)
			Me.Invoke(MyDelegate, New Object() {[Label], [text]})
		Else
			[Label].Text = [text]
		End If
	End Sub

	Private Sub chk_Upgrade_CheckedChanged(sender As Object, e As EventArgs) Handles chk_Upgrade.CheckedChanged
		If boolUpgrade Then
			boolUpgrade = False
			'ReplaceCheck()
			TB_Replace.Enabled = True
			Wildcard.Enabled = True
		Else
			boolUpgrade = True
			TB_Replace.Enabled = False
			'ReplaceCheck()
			Wildcard.Enabled = False
		End If
	End Sub
End Class
