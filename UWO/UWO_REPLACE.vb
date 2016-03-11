'Revision By: Luke Westelaken
'Date: January 13, 2016
'Revisions made: added github source control at https://github.com/ilgontae/UWO_SOLUTION
' all revisions will be made and recorded there

Imports System.Text.RegularExpressions
Imports System.IO
Imports System.ComponentModel
Imports System.Threading

Public Class UWO_REPLACE
	Private bw As BackgroundWorker = New BackgroundWorker
	Private FileList As New List(Of String)
	Private Ext As String
	Private WildcardEnable As Boolean = False
	Private boolUpgrade As Boolean = False
	Dim countFiles As Integer
	Dim counter As Integer = 0
	Dim max As Integer = 10

	Private Sub FindStr(ByVal fname As String)
		Try
			Dim testTxt As New StreamReader(fname)
			Dim allRead As String = testTxt.ReadToEnd()
			testTxt.Close()
			Dim regMatch As String
			If WildcardEnable = False And Not boolUpgrade Then
				regMatch = Regex.Escape(TB_Find.Text)
			ElseIf boolUpgrade Then
				regMatch = "[(.]" & TB_Find.Text & ".(AI|BI|AO|BO)"
			Else
				regMatch = TB_Find.Text
			End If


			If Regex.IsMatch(allRead, regMatch, RegexOptions.IgnoreCase) Then
				FileList.Add(fname)
				Dim SP As String = fname.Remove(0, TB_Directory.Text.Length + 1)
				SP = SP.ToUpper
				ListView1.Items.Add(SP)
				ListView1.Update()
				ListView1.EnsureVisible(ListView1.Items.Count - 1)
			End If
		Catch
		End Try
	End Sub

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
		'ProgressBar1.Value = ProgressBar1.Maximum
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
		If Not TB_Replace.Text = "" And Ext = "gpc" Then
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
	End Sub



	Private Sub B_Replace_Click(ByVal sender As Object, ByVal e As EventArgs) Handles B_Replace.Click
		Try
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
				L_Left.Text = "Number Left: " + (FileList.Count - num).ToString
				num += 1
			Next
			MessageBox.Show("COMPLETE" + vbCrLf +
							"It Is Recommended To Save The list" + vbCrLf +
							"If You Have Not Already Done So.", "LINKS REPLACED", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
		L_Matches.Visible = True
		B_Save.Enabled = True
		B_Find.Enabled = True
		chk_Upgrade.Enabled = True
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
		Else
			boolUpgrade = True
		End If
	End Sub
End Class
