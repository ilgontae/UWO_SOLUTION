'Revision By: Alayna Duval
'Date: April 8 2014
'Revisions made: 
'Added variable UserTimeLapse, Try & Catch for reading in timeTextBox, Changed source and directory to H drive(as of now
'no access to Z drive), Added cancel button to stop & close program immediately 
'Date: April 9 2014
'Revisions made:
'Added combox-loaded values in design view, Added selected index code

'Revision By: Luke Westelaken
'Date: January 14, 2016
'Revisions made:
'Created github repo at https://github.com/ilgontae/UWO_SOLUTION
'Continuing revision history on there

Imports System.IO
Imports System.Threading

Public Class UWO_conversion

	Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
		Width = UWO_MAIN.Width - 20
		L_convert.Width = Width
		Dim p As Point
		p.X = 0
		p.Y = 0
		Location = p
		Show()
		DriveComboBox.SelectedIndex = 0
	End Sub

    'Default value is 1 second
    Dim UserTimeLapse As Double = 1.0
	Dim cancel As Boolean = False
	Private Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As Long, ByVal lpString As String, ByVal cch As Long) As Long
	Private Declare Function GetWindowTextLength Lib "user32" Alias "GetWindowTextLengthA" (ByVal hwnd As Long) As Long
	Private Declare Function GetForegroundWindow Lib "user32" () As Long
	Private MyStr As String, theHwnd As Long


	Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
		'Dim Source As String = "W:\PUBLIC\Delta\Graphics"
		Dim Source As String = "C:\Users\lwestel\Desktop"
		'Dim Destination As String = "Z:\Graphics"
		Dim Destination As String = "C:\Users\lwestel\Documents"
		UserTimeLapse = 1000
		Dim containsGPC As Boolean = False

		Try
			If (timeTextBox.Enabled = True) Then
				UserTimeLapse = timeTextBox.Text
				If UserTimeLapse > 0 Then
					UserTimeLapse = UserTimeLapse * 1000
				Else
					MessageBox.Show("Amount must be greater than zero", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
					Return
				End If
			End If

		Catch ex As Exception
			MessageBox.Show("Amount incorrect", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)            'should never happen, but you never know
			Return
		End Try

		Try
			If DriveComboBox.SelectedIndex = 0 Then
				Destination = "Z:\Graphics"
			ElseIf DriveComboBox.SelectedIndex = 1 Then
				Destination = "Y:\UWO\Graphics"
			ElseIf DriveComboBox.SelectedIndex = 2 Then
				Destination = "H:\Graphics"
			ElseIf DriveComboBox.SelectedIndex = 3 Then
				Destination = "C:\Users\lwestel\Documents"
			Else
				MessageBox.Show("No drive selected", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)   ' should never happen, but you never know
				Return
			End If

			If Not Directory.Exists(Source) Then
				MessageBox.Show("Make sure you have access to the source drive.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Try
			End If
			If Not Directory.Exists(Destination) Then
				MessageBox.Show("Make sure you have access to " + Destination, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Try
			End If
			For Each d As String In My.Computer.FileSystem.GetDirectories(Source)                           ' checking if folder has brackets, as my system cannot handle the brackets
				If d.Contains("(") Or
						d.Contains(")") Then
					MessageBox.Show("Please remove brackets from folder names", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
					Exit Try
				End If
			Next
			For Each d As String In My.Computer.FileSystem.GetDirectories(Source)
				containsGPC = False
				L_convert.Text = "Converting --> " + d
				If (cancel = True) Then
					Exit For
				End If
				L_convert.Update()
				Thread.Sleep(100)
				Dim dir As DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(d)
				For Each File In My.Computer.FileSystem.GetFiles(d)                 ' check to make sure the folders even contain .gpc files
					If (File.Contains(".gpc")) Then
						containsGPC = True
					End If
				Next
				Dim Dest = Destination + "\" + dir.Name                             'ignore unnecessary folders that do not have files that need to be converted
				If Not String.Compare(dir.Name, "archive", True) = 0 And
				   Not String.Compare(dir.Name, "bmp", True) = 0 And
				   Not String.Compare(dir.Name, "help files", True) = 0 And
				   Not String.Compare(dir.Name, "temp", True) = 0 Then
					Dim fileExists As Boolean = False
					Dim fileBrackets As Boolean = False
					Dim extraEnters As Integer = 0
					Dim numC As Integer
					If Directory.Exists(Dest) Then
						'skip if folder is empty
						If (My.Computer.FileSystem.GetFiles(dir.FullName).Count = 0) Then
							Continue For
							L_convert.Text = "Folder skipped, no files"
							Thread.Sleep(1000)
						End If
						'If destination folder already exists, concat the date on the end
						Dim todaysdate As String = String.Format("{0:dd-MM-yyyy}", DateTime.Now)
						Dim containsCopy As Boolean
						containsCopy = False
						For Each file In My.Computer.FileSystem.GetDirectories(Destination)
							'find if folder has the word "copy" in its name
							If file.Contains("Copy") Then
								If Not (file.Contains("(")) Then
									containsCopy = True
									fileExists = True
									numC = ((file.Length - file.IndexOf("Copy") + 1) / 5)   ' getting the count of the number of times "copy" is in the name. This is so that it can replicate it
								Else
								End If
							ElseIf file.Contains(todaysdate) Then
								fileExists = True
							End If
						Next
						If Not (fileExists) Then        ' if the folder already exists, append the date to the new folder
							Dest &= " " & todaysdate
						ElseIf (containsCopy) Then      ' if the folder already exists and already has "copy" on it, add more "copy" words to the end, based on the number of original words
							Dest &= " " & todaysdate
							For i As Integer = 0 To (numC)
								Dest &= " Copy"
							Next
							extraEnters += 1
						Else                            ' if the folder already exists with the date appended but NOT the word "copy", append "copy"
							Dest &= " " & todaysdate & " Copy"
							extraEnters += 1
						End If
					End If
					If (My.Computer.FileSystem.GetFiles(dir.FullName).Count = 0) Then
						Continue For
						L_convert.Text = "Folder skipped, no files"                             ' Check if folder is empty
						Thread.Sleep(500)
					ElseIf Not (containsGPC) Then
						Continue For
						L_convert.Text = "Folder skipped, does not contain graphics files"      ' Check if folder even contains gpc files
						Thread.Sleep(1000)
					End If
					Directory.CreateDirectory(Dest)                                             ' create destination folder
					AppActivate("ORCAView")
					SendKeys.SendWait("%t")                 ' % = alt, so this line means ALT+T\

					'Check to see if ORCAview is the front program, as sometimes it activates the wrong portion of orcaview (e.g. activated my orcaview splash screen thing, not the actual application)
					theHwnd = GetForegroundWindow()
					Dim length As Integer
					length = GetWindowTextLength(theHwnd) + 1
					Dim buf As String = Space$(length)
					length = GetWindowText(theHwnd, buf, length)
					Dim var As String = buf.Substring(0, length)
					'if ORCAview is not the foreground window, exit the loop, as continuing the macro is silly
					If (var.Contains("ORCAview") <> True) And (var <> "ORCAview Products") Then
						SendKeys.SendWait("{ESC}")
						MessageBox.Show("Make sure you are logged in to ORCAview", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
						Exit For
					End If

					Thread.Sleep(100)
					SendKeys.SendWait("{DOWN}")
					Thread.Sleep(100)
					SendKeys.SendWait("{DOWN}")
					Thread.Sleep(100)
					SendKeys.SendWait("{DOWN}")
					Thread.Sleep(100)
					SendKeys.SendWait("{DOWN}")
					If (cancel = True) Then
						Return
					End If
					Thread.Sleep(100)
					SendKeys.SendWait("{RIGHT}")
					Thread.Sleep(100)
					SendKeys.SendWait("{DOWN}")
					Thread.Sleep(100)
					SendKeys.SendWait("{ENTER}")            'graphics to webpage
					Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")

					'Check to see if orcaview is still the foreground window
					theHwnd = GetForegroundWindow()
					length = GetWindowTextLength(theHwnd) + 1
					buf = Space$(length)
					length = GetWindowText(theHwnd, buf, length)
					var = buf.Substring(0, length)
					'if orcaview is not the foreground window, exit the loop, as continuing the macro is silly
					If (var <> "Convert Graphics to Web Page") Then
						SendKeys.SendWait("{ESC}")
						MessageBox.Show("Make sure you are logged in to ORCAView", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
						Return
					End If

					Thread.Sleep(100)
					SendKeys.SendWait("{TAB}")
					If (cancel = True) Then                 ' checks to see if the macro should be cancelled (theres more throughout the code)
						Return
					End If
					Thread.Sleep(100)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(100)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(100)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(100)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(100)
					SendKeys.SendWait("{ENTER}")            ' Add button
					Thread.Sleep(UserTimeLapse)
					SendKeys.SendWait(d)
					Thread.Sleep(UserTimeLapse)
					SendKeys.SendWait("{ENTER}")
					Thread.Sleep(UserTimeLapse)
					SendKeys.SendWait("+{TAB}")
					Thread.Sleep(UserTimeLapse)
					SendKeys.SendWait("^a")                 '^ is for CRTL, so this line means CTRL+A, selects all files that are to be added
					Thread.Sleep(100)
					If (cancel = True) Then
						Return
					End If
					SendKeys.SendWait("{ENTER}")
					Thread.Sleep(UserTimeLapse)
					SendKeys.SendWait("{ENTER}")
					Thread.Sleep(100)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(100)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(100)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(100)
					SendKeys.SendWait(Dest)
					Thread.Sleep(UserTimeLapse)
					'Extra enters required if the destination folder does not exist
					For i As Integer = 0 To extraEnters
						Thread.Sleep(100)
						SendKeys.SendWait("{ENTER}")
					Next

					SendKeys.SendWait("{ENTER}")
					Thread.Sleep(10000)
					SendKeys.SendWait("{ENTER}")
					'Conversion done
					Thread.Sleep(100)
				End If
			Next
			If (cancel <> True) Then
				L_convert.Text = "Conversion Complete"
			Else
				L_convert.Text = "Conversion Cancelled!"
			End If
		Catch ex As UnauthorizedAccessException
			MessageBox.Show("Error accessing destination folder", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Catch       ' Catch error if ORCAview is not even running
			MessageBox.Show("Make sure you are logged in to ORCAView", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub stopButton_Click(sender As Object, e As EventArgs) Handles stopButton.Click
		cancel = True       'Cancel the progression of the conversion macro (NOT the actual conversion itself, that cannot be cancelled)
		MessageBox.Show("Conversion cancelled!", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning)
	End Sub

End Class