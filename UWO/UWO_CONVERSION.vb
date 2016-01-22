﻿'Revision By: Alayna Duval
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
		DriveComboBox.SelectedIndex = 1
	End Sub

    'Default value is 1 second
    Dim UserTimeLapse As Double = 1.0
	Dim cancel As Boolean = False
	Private Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As Long, ByVal lpString As String, ByVal cch As Long) As Long
	Private Declare Function GetWindowTextLength Lib "user32" Alias "GetWindowTextLengthA" (ByVal hwnd As Long) As Long
	Private Declare Function GetForegroundWindow Lib "user32" () As Long
	Private MyStr As String, theHwnd As Long


	Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
		Dim Source As String = "W:\PUBLIC\Delta\Graphics"
		'Dim Source As String = "C:\Users\lwestel\Desktop"
		Dim Destination As String = "Y:\Graphics"
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
			Return
		End If
			If Not Directory.Exists(Destination) Then
				MessageBox.Show("Make sure you have access to " + Destination, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
				'Exit Try
			End If
		For Each d As String In My.Computer.FileSystem.GetDirectories(Source)
			Try
				Debug.WriteLine(d)
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
			   Not String.Compare(dir.Name, "CPS", True) = 0 And
			   Not String.Compare(dir.Name, "backup", True) = 0 And
			   Not String.Compare(dir.Name, "ICFAR", True) = 0 And
			   Not String.Compare(dir.Name, "temp", True) = 0 Then
					Dim fileExists As Boolean = False
					Dim fileBrackets As Boolean = False
					Dim extraEnters As Integer = 0
					If Directory.Exists(Dest) Then
						Directory.Delete(Dest, True)
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

					Thread.Sleep(300)
					SendKeys.SendWait("{DOWN}")
					Thread.Sleep(300)
					SendKeys.SendWait("{DOWN}")
					Thread.Sleep(300)
					SendKeys.SendWait("{DOWN}")
					Thread.Sleep(300)
					SendKeys.SendWait("{DOWN}")
					If (cancel = True) Then
						Return
					End If
					Thread.Sleep(300)
					SendKeys.SendWait("{RIGHT}")
					Thread.Sleep(300)
					SendKeys.SendWait("{DOWN}")
					Thread.Sleep(300)
					SendKeys.SendWait("{ENTER}")            'graphics to webpage
					Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(UserTimeLapse)
					SendKeys.SendWait("{TAB}")
					If (cancel = True) Then                 ' checks to see if the macro should be cancelled (theres more throughout the code)
						Return
					End If
					Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(300)
					SendKeys.SendWait("{ENTER}")            ' Add button
					Thread.Sleep(2000)
					'Debug.WriteLine(d)
					SendKeys.SendWait(d)
					Thread.Sleep(300)
					SendKeys.SendWait("{ENTER}")
					Thread.Sleep(300)
					SendKeys.SendWait("+{TAB}")
					Thread.Sleep(300)
					SendKeys.SendWait("^a")                 '^ is for CRTL, so this line means CTRL+A, selects all files that are to be added
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(300)
					Thread.Sleep(UserTimeLapse)
					If (cancel = True) Then
						Return
					End If
					SendKeys.SendWait("{ENTER}")
					Thread.Sleep(2000)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(400)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(400)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(2000)
					SendKeys.SendWait(Dest)
					'Debug.WriteLine(Dest)
					Thread.Sleep(400)
					Thread.Sleep(UserTimeLapse)
					SendKeys.SendWait("{ENTER}")
					Thread.Sleep(1000)
					'Check to see when conversion is done (popup will appear, wait for that to be active window)
					theHwnd = GetForegroundWindow()
					length = GetWindowTextLength(theHwnd) + 1
					buf = Space$(length)
					length = GetWindowText(theHwnd, buf, length)
					var = buf.Substring(0, length)
					Dim int As Integer = 0
					If var <> "Convert Graphics to Web Page" Then
						While (var <> "Convert Graphics to Web Page")
							Thread.Sleep(1000)
							int += 1
							Debug.WriteLine(var & int)
							theHwnd = GetForegroundWindow()
							length = GetWindowTextLength(theHwnd) + 1
							buf = Space$(length)
							length = GetWindowText(theHwnd, buf, length)
							var = buf.Substring(0, length)
							If var = "Incorrect Version" Then   'check to see if incorrect verison window pops up (rare, but does happen and would cause program to wait here forever)
								SendKeys.SendWait("{ENTER}")
							End If
						End While
					End If
					SendKeys.SendWait("{ENTER}")
					'Conversion done
					Thread.Sleep(UserTimeLapse)
				End If
			Catch ex As UnauthorizedAccessException
				MessageBox.Show("Error accessing destination folder" & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Continue For

			End Try
		Next
		If (cancel <> True) Then
				L_convert.Text = "Conversion Complete"
			Else
				L_convert.Text = "Conversion Cancelled!"
			End If
    End Sub

	Private Sub stopButton_Click(sender As Object, e As EventArgs) Handles stopButton.Click
		cancel = True       'Cancel the progression of the conversion macro (NOT the actual conversion itself, that cannot be cancelled)
		MessageBox.Show("Conversion cancelled!", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning)
	End Sub

End Class