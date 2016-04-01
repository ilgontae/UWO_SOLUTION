'Revision By: Luke Westelaken
'Date: January 13, 2016
'Revisions made: added github source control at https://github.com/ilgontae/UWO_SOLUTION
' all revisions will be made and recorded there

' Imports
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Class UWO_REPLACE
	' Variables
	Private bw As BackgroundWorker = New BackgroundWorker   ' used to do background work on other threads
	Private FileList As New List(Of String)                 ' a list of all the files to have points replaced
	Private Ext As String                                   ' stores the file extension to look for
	Private WildcardEnable As Boolean = False               ' boolean for if the Wildcard button has been pressed (should be checkbox, but that wasn't up to me)
	Private boolUpgrade As Boolean = False                  ' boolean for if the 'DCU to enteliBUS' checkbox has been selected
	Dim countFiles As Integer                               ' count of all files to be checked (not currently in use)
	Dim counter As Integer = 0                              ' count of files already checked (not in use)
	Dim max As Integer = 10                                 ' max for the progress bar (not in use)
	Dim conflictList As New List(Of String)                 ' list of all the files that have a conflict in them
	Dim objList As New List(Of inObj)                       ' list of inObj objects, which stores the data to be replaced
	Dim writeString As String = "Log" & vbCrLf & "-------"  ' a string that will be written to a log file

	' Data type for storing the datapoint data to be replaced 
	Private Structure inObj
		Dim type As String          ' datapoint type (AI, BI, AO, BO)
		Dim numOrig As Integer      ' datapoint original number
		Dim numNew As Integer       ' datapoint new number that will be the end result
		' to string method to easily add the points to the log (and output to console)
		Public Overrides Function toString() As String
			Return (type & numOrig & " --> " & type & numNew)
		End Function
	End Structure

	' Name: FindAllObj
	' Parameters: name of the file to open As String
	' Returns: Nothing
	' Purpose: finds all the objects that need to be updated and adds them to the list
	Private Sub FindAllObj(ByVal fname As String)
		objList.Clear()             ' clear the list every time
		Dim panelNum As String = ParseDigits(TB_Find.Text)          ' get the panel number
		Dim testTxt As New StreamReader(fname)                      ' create a streamreader (to read the contents of a file as text)
		Dim allRead As String = testTxt.ReadToEnd()                 ' store the text from the file in a string
		testTxt.Close()                                             ' close the stream read
		Dim regMatch As String
		regMatch = "[(.]" & panelNum & "\.(?i)(AI|BI|AO|BO)\d{1,3}" ' build a regex string that will capture the correct objects
		Dim rgx As New Regex(regMatch)
		Dim tempStr As String
		Dim tempNum As Integer
		For Each match As Match In rgx.Matches(allRead)                 ' find all matches of the regex string
			tempStr = match.Value                                       ' store the value of the match
			tempStr = tempStr.Substring(tempStr.LastIndexOf(".") + 1)   ' get the data after the last period, which is the ending portion of the datapoint with the type and number
			tempNum = ParseDigits(tempStr)                              ' get the digits from the ending portion, so just the datapoint number
			Dim o As inObj                                              ' create an inObj object (which will be added to the list)
			o.numOrig = tempNum                                         ' give that object the old datapoint number
			If tempNum <= 99 Then
				tempNum = translateTwoDigit(tempNum)                    ' if the datapoint number is only 1 or 2 digits
			Else
				tempNum = translateThreeDigits(tempNum)                 ' if the datapoint number is 3 digits
			End If
			o.type = tempStr.Substring(0, 2)                            ' get the datapoint type and store in the inObj object
			o.numNew = tempNum                                          ' store the updated number in the object
			If objList.Count = 0 Then
				objList.Add(o)                                          ' add the point to the list to be updated
			ElseIf Not (objList(objList.Count - 1).type = o.type And objList(objList.Count - 1).numOrig = o.numOrig) Then
				objList.Add(o)                                          ' if the last point added is the same, do not add it again
			End If
		Next
	End Sub

	' Name: FindStr
	' Accepts: name of a file as a string
	' Returns: Nothing
	' Purpose: Finds if inputted data into the text box is found and adds it to a list. 
	Private Sub FindStr(ByVal fname As String)
		Try
			Dim panelNum As String = ParseDigits(TB_Find.Text)              ' get panel number
			Dim testTxt As New StreamReader(fname)                          ' open the file
			Dim allRead As String = testTxt.ReadToEnd()                     ' store contents of file in string
			testTxt.Close()
			Dim regMatch As String
			If WildcardEnable = False And Not boolUpgrade Then
				regMatch = Regex.Escape(TB_Find.Text)
			ElseIf boolUpgrade Then
				regMatch = "[(.]" & panelNum & "\.((AI|BI|AO|BO)\d{1,3})"   'regex string is used to find all data types that need to be updated for a DCU to enteliBUS upgrade
			Else
				regMatch = TB_Find.Text
			End If


			If Regex.IsMatch(allRead, regMatch, RegexOptions.IgnoreCase) Then
				Dim SP As String = fname.Remove(0, TB_Directory.Text.Length + 1)
				SP = SP.ToUpper
				If (boolUpgrade) Then
					Dim conflictFlag As Boolean = False                     ' reset conflict flag
					Dim rgx As New Regex(regMatch)
					For Each match As Match In rgx.Matches(allRead)
						regMatch = "[(.]\d+" & panelNum & "\." & match.Groups(1).Value & "\."   ' check if there are any conflicts in that file with leading numbers
						Dim rgx2 As New Regex(regMatch)
						If Regex.IsMatch(allRead, regMatch, RegexOptions.IgnoreCase) Then
							conflictFlag = True                                                 ' set conflict flag if there is a conflict
							Exit For
						End If
					Next
					If Not conflictFlag Then
						FileList.Add(fname)                                 ' if conflict flag not set, add the file to the file list
						ListView1.Items.Add(New ListViewItem(New String() {fname, ""}))     ' also add the file to the list view
					Else
						conflictList.Add(fname)                             ' if conflict flag is set, add the file to the conflict list
						ListView1.Items.Add(New ListViewItem(New String() {fname, "Conflict"})) ' also include it in the list view with the word "conflict" next to it
					End If
				Else
					FileList.Add(fname)                                     ' if not DCU upgrade, just add it to the list
					ListView1.Items.Add(New ListViewItem(New String() {fname, ""}))
				End If
				ListView1.Update()                                          ' update list view
				ListView1.EnsureVisible(ListView1.Items.Count - 1)
			End If

		Catch
		End Try
	End Sub

	' Name: ParseDigits
	' Accepts: String to extract digits from
	' Returns: A string containing just the digits from the original string 
	Function ParseDigits(ByVal strRawValue As String) As String
		Dim strDigits As String = ""
		If strRawValue = Nothing Then Return strDigits  ' if string is empty, no point in doing anything with it
		For Each c As Char In strRawValue.ToCharArray() ' iterate through string
			If Char.IsDigit(c) Then                     ' if current character is a digit
				strDigits &= c                          ' add it to a strign to be returned
			End If
		Next c
		Return strDigits                                ' return the resulting string
	End Function

	' Name: getfile
	' Accepts: the directory to search in, as a string
	' Returns: Nothing
	' Purpose: iterates through all the files within a directory (recursively) to then call the FindStr Sub
	Private Sub getfile(ByVal dir As String)
		Dim a As String = My.Computer.FileSystem.GetDirectoryInfo(dir).Name.ToString
		'BackgroundWorker1.ReportProgress(counter / countFiles)
		If Not String.Compare(a, "Temp", True) = 0 And              ' exclude unnecessary folders
		   Not String.Compare(a, "bmp", True) = 0 And
		   Not String.Compare(a, "archive", True) = 0 And
		   Not String.Compare(a, "backup", True) = 0 And
		   Not String.Compare(a, "help files", True) = 0 Then


			For Each files As String In My.Computer.FileSystem.GetFiles(dir)
				counter += 1
				If Ext = "" Or (String.Compare(Ext, files.Split(".").Last, True) = 0) Then      ' find only files with correct extension
					'counter += 1
					FindStr(files)                                                              ' call the sub to find if the correct string occurs in the file
					'BackgroundWorker1.ReportProgress(counter / countFiles)
				End If
			Next
			For Each root As String In My.Computer.FileSystem.GetDirectories(dir)
				getfile(root)                                                                   ' recursively call the sub to get all files in all directories
			Next
		Else
			counter += 1
		End If
	End Sub
	' Does not work at the moment
	Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object,
		ByVal e As System.ComponentModel.ProgressChangedEventArgs) _
		Handles BackgroundWorker1.ProgressChanged
		ProgressBar1.Value = e.ProgressPercentage
	End Sub

	' When the background worker has completed running
	Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object,
	ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) _
	Handles BackgroundWorker1.RunWorkerCompleted
		ProgressBar1.Value = ProgressBar1.Maximum
		B_Replace.Enabled = True
		endSearch()
	End Sub

	' I have no idea
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

	' Name: DirSearch
	' Accepts: the directory path as a string
	' Returns: Nothing
	' Purpose: get count of all directories to be scanned
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

	' Name: ReplaceCheck
	' Accepts: Nothing
	' Returns: Nothing
	' Purpose: Checks whether the "replace" button should be enabled
	Private Sub ReplaceCheck()
		If boolUpgrade Then
			B_Replace.Enabled = True
		ElseIf Not TB_Replace.Text = "" And Ext = "gpc" Then
			B_Replace.Enabled = True
		Else
			B_Replace.Enabled = False
		End If
	End Sub

	' Events for the buttons
	Private Sub TB_Find_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TB_Find.TextChanged
		FindCheck()
	End Sub

	Private Sub TB_Directory_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TB_Directory.TextChanged
		FindCheck()
	End Sub

	Private Sub TB_Replace_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TB_Replace.TextChanged
		ReplaceCheck()
	End Sub

	'
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

	' On load, make things uppercase for some reason?
	Private Sub Main_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
		TB_Find.CharacterCasing = CharacterCasing.Upper
		TB_Replace.CharacterCasing = CharacterCasing.Upper
		TB_Directory.Text = "W:\PUBLIC\Delta\Graphics"
		Wildcard.Enabled = True
	End Sub

	' Event handler for the Find button, which activates a background worker
	Private Sub B_Find_Click(ByVal sender As Object, ByVal e As EventArgs) Handles B_Find.Click
		BackgroundWorker1.RunWorkerAsync()
	End Sub

	' used to save the listview list
	Private Sub B_Save_Click(ByVal sender As Object, ByVal e As EventArgs) Handles B_Save.Click
		SFD_SaveList.DefaultExt = ".txt"
		SFD_SaveList.FileName = "DLR_"
		SFD_SaveList.Filter = "Text Files (*.txt)|*.txt|Excel Files (*.xls)|*.xls"
		SFD_SaveList.InitialDirectory = "C:\temp"
		SFD_SaveList.ShowDialog()
	End Sub

	' Remove a file from the listview list
	Private Sub B_Remove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles B_Remove.Click
		For Each it As Integer In New ReverseIterator(ListView1.SelectedIndices)
			ListView1.Items.Remove(ListView1.Items(it))
			FileList.RemoveAt(it)
		Next
		L_Matches.Text = "Total Matches Found: " + FileList.Count.ToString
		L_Matches.Visible = True
	End Sub

	' Name: translateTwoDigit
	' Accepts: a number as an integer
	' Returns: a new integer
	' Purpose: translates a one or two digit number into the new one for a DCU to enteliBUS upgrade, see wiki for details
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

	' Name: translateThreeDigits
	' Accepts: a number as an integer
	' Returns: Nothing
	' Purpose: translates a three-digit number into the new one for a DCU to enteliBUS upgrade, see wiki for details
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

	'Event for running the replace macros
	Private Sub B_Replace_Click(ByVal sender As Object, ByVal e As EventArgs) Handles B_Replace.Click
		Try
			If boolUpgrade Then     ' for if this is for a DCU to enteliBUS upgrade
				Dim desktopPath = My.Computer.FileSystem.SpecialDirectories.Desktop                 ' get the user's desktop path
				Dim filePath = desktopPath & "\" & ParseDigits(TB_Find.Text)                        ' create a string that will be C:\pathtodesktop\panel
				If Not Directory.Exists(filePath) Then                                              ' check if that directory already exists. If it does not, create it
					My.Computer.FileSystem.CreateDirectory(filePath)
				End If
				If conflictList.Count > 0 And Not Directory.Exists(filePath & "\Conflicts") Then    ' check if the conflicts folder needs to be created
					My.Computer.FileSystem.CreateDirectory(filePath & "\Conflicts")
				End If
				If Not Directory.Exists(filePath & "\Backups") Then                                 ' check if a backup folder already exists. If not, create it
					My.Computer.FileSystem.CreateDirectory(filePath & "\Backups")
				End If
				Dim newPath As String
				For Each files As String In FileList                                ' iterate through each file in the FileList that needs updating
					Dim tempArr = Split(files, "\")                                 ' split the path to the file into an array
					newPath = filePath & "\" & tempArr(tempArr.Count - 2)           ' get the file's folder
					If Not Directory.Exists(newPath) Then                           ' if that folder does not already exist in the new folder on desktop
						My.Computer.FileSystem.CreateDirectory(newPath)             ' create it
					End If
					newPath &= "\" & Path.GetFileName(files)                        ' get the file's name and add it to the path's string
					My.Computer.FileSystem.CopyFile(files, filePath & "\Backups\" & newPath.Split("\").Last, True)      ' copy the file to the backups folder
					My.Computer.FileSystem.CopyFile(files, newPath, True)                                               ' copy the file to the new folder
					FindAllObj(newPath)                                             ' find all the objects that need to be updated 
					writeString &= vbCrLf & "** " & tempArr(tempArr.Count - 2) & "\" & newPath.Split("\").Last & " **" & vbCrLf     ' add file name to log file
					AppActivate("ORCAView")                                         ' Launch ORCAview
					Threading.Thread.Sleep(500)
					SendKeys.SendWait("%F")
					Threading.Thread.Sleep(5)
					SendKeys.SendWait("{DOWN}")
					Threading.Thread.Sleep(5)
					SendKeys.SendWait("{DOWN}")
					Threading.Thread.Sleep(5)


					SendKeys.SendWait("{ENTER}")
					Threading.Thread.Sleep(1000)
					SendKeys.SendWait(newPath.ToUpper)                              ' enter new path to folder

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
					For Each o In objList                           ' iterate through all the objects that need to be updated
						Debug.WriteLine(o.toString)
						writeString &= vbCrLf & o.toString          ' add object information to the log
						SendKeys.SendWait(ParseDigits(TB_Find.Text) & "." & o.type & o.numOrig & ".")       ' get the panel name, plus the object's original number
						Threading.Thread.Sleep(50)
						SendKeys.SendWait("{TAB}")
						Threading.Thread.Sleep(50)
						SendKeys.SendWait(ParseDigits(TB_Find.Text) & "." & o.type & o.numNew & ".")        ' get the panel name, plus the object's new number
						Threading.Thread.Sleep(50)
						SendKeys.SendWait("{TAB}")

						Threading.Thread.Sleep(50)
						SendKeys.SendWait("{TAB}")
						Threading.Thread.Sleep(50)

						SendKeys.SendWait("{ENTER}")
						Threading.Thread.Sleep(50)
						SendKeys.SendWait("{ENTER}")
						If count < objList.Count Then               ' for if you need to run through more than one object
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
					AppActivate("<" + newPath.Split("\").Last + ">")                    ' activate the program with the file's name as the title
					Threading.Thread.Sleep(50)
					SendKeys.SendWait("%{F4}")
					Threading.Thread.Sleep(50)
					SendKeys.SendWait("{ENTER}")
					Threading.Thread.Sleep(1000)
					writeString &= vbCrLf
				Next
				Dim fs As FileStream = File.Create(filePath & "\LOG.txt")
				Dim info As Byte() = New UTF8Encoding(True).GetBytes(writeString)       ' write the log file
				fs.Write(info, 0, info.Length)
				fs.Close()
				For Each files As String In conflictList                                ' iterate through all the conflict files
					Dim tempArr = Split(files, "\")
					newPath = filePath & "\Conflicts\" & tempArr(tempArr.Count - 2)     ' get the path for the new folder for the conflict files
					If Not Directory.Exists(newPath) Then                               ' create the folder within the conflicts folder if it does not already exist
						My.Computer.FileSystem.CreateDirectory(newPath)
					End If
					newPath &= "\" & Path.GetFileName(files)
					My.Computer.FileSystem.CopyFile(files, newPath, True)               ' copy the file to the new folder
					My.Computer.FileSystem.CopyFile(files, filePath & "\Backups\" & newPath.Split("\").Last, True)  ' copy the file to the backups folder
				Next
				MessageBox.Show("COMPLETE" & vbCrLf & "Remember to manually update the" & vbCrLf & "files that have conflicts", "LINKS UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information)
			Else                                    ' original macro, good for replacing any single link
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

	' Save a copy of the file list to be updated (only useful for the original program, not the DCU to enteliBUS portion)
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

	' Display the Directory Selector if the text box is double clicked
	Private Sub TB_Directory_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TB_Directory.DoubleClick
		FBD_Directory.ShowDialog()
		TB_Directory.Text = FBD_Directory.SelectedPath
	End Sub

	' Event to change the boolean flag for if the wildcard button is pressed (should be check box, but that isn't up to me anymore)
	Private Sub Wildcard_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Wildcard.Click
		If WildcardEnable = False Then
			WildcardEnable = True
			Wildcard.Text = "Wildcard Enabled"
		Else
			WildcardEnable = False
			Wildcard.Text = "Wildcard Disabled"
		End If

	End Sub

	'This is the backgroundworkers main sub
	'Everything is run from here
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

	' Was supposed to update the label to display the total number of files scanned, but doesn't seem to want to
	Public Sub endSearch()
		L_Matches.Text = "Total Matches Found: " + FileList.Count.ToString
		L_Matches.Visible = True
	End Sub

	' The delegate
	Delegate Sub SetLabelText_Delegate(ByVal [Label] As Label, ByVal [text] As String)

	' The delegates subroutine.
	' was an attempt to make the total file count display again, but I cannot seem to get it to work. Darn cross thread calls
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

	' Event to change the boolean flag for if the DCU to enteliBUS checkbox is checked/unchecked
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
