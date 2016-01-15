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

	'#Disable Warning BC42303 ' XML comment cannot appear within a method or a property   was getting an error even though the error was in a comment, so this supressed that error

	Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
		'Dim Source As String = "W:\PUBLIC\Delta\Graphics"
		Dim Source As String = "C:\Users\lwestel\Desktop"
		Dim Destination As String = "Z:\Graphics"
		UserTimeLapse = 1000

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
			MessageBox.Show("Amount incorrect", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
				Destination = "C:\Users\lwestel\Desktop"
			Else
				MessageBox.Show("Choose a drive", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Return
			End If

			If Not Directory.Exists(Source) Then
				MessageBox.Show("Make Sure You Have Access To The Source Drive", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Try
			End If
			If Not Directory.Exists(Destination) Then
				MessageBox.Show("Make Sure You Have Access To " + Destination, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Try
			End If

			For Each d As String In My.Computer.FileSystem.GetDirectories(Source)
				L_convert.Text = "Converting --> " + d
				If (cancel = True) Then
					Exit For
				End If
				L_convert.Update()
				Thread.Sleep(100)
				Dim dir As DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(d)
				Dim Dest = Destination + "\" + dir.Name
				If Not String.Compare(dir.Name, "archive", True) = 0 And
				   Not String.Compare(dir.Name, "bmp", True) = 0 And
				   Not String.Compare(dir.Name, "help files", True) = 0 And
				   Not String.Compare(dir.Name, "temp", True) = 0 Then
					If Directory.Exists(Dest) Then
						'Directory.Delete(Dest, True)		' this ruined things, as it deleted all the contents of the folder as well
					End If
					Directory.CreateDirectory(Dest)
					If (My.Computer.FileSystem.GetFiles(dir.FullName).Count = 0) Then
						SendKeys.SendWait("{ESC}")
						Continue For
					End If
					AppActivate("ORCAView")
					SendKeys.SendWait("%t")                 ' % = alt, so this line means ALT+T\
					'Check to see if ORCAView is the front program, as sometimes it activates the wrong portion of orcaview (e.g. activated my orcaview splash screen thing, not the actual application)
					theHwnd = GetForegroundWindow()
					Dim length As Integer
					length = GetWindowTextLength(theHwnd) + 1
					Dim buf As String = Space$(length)
					length = GetWindowText(theHwnd, buf, length)
					Dim var As String = buf.Substring(0, length)
					Debug.WriteLine(var)
					'if orcaview is not the foreground window, exit the loop, as continuing the macro is silly
					If (var.Contains("ORCAview") <> True) And (var <> "ORCAview Products") Then
						SendKeys.SendWait("{ESC}")
						MessageBox.Show("Make Sure to login to ORCAView", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
						Exit For
					End If
					Thread.Sleep(200)
					SendKeys.SendWait("{DOWN}")
					Thread.Sleep(200)
					SendKeys.SendWait("{DOWN}")
					Thread.Sleep(200)
					SendKeys.SendWait("{DOWN}")
					Thread.Sleep(200)
					SendKeys.SendWait("{DOWN}")
					If (cancel = True) Then
						Exit For
					End If
					Thread.Sleep(200)
					Thread.Sleep(200)
					SendKeys.SendWait("{RIGHT}")
					Thread.Sleep(200)
					SendKeys.SendWait("{DOWN}")
					Thread.Sleep(200)
					SendKeys.SendWait("{ENTER}")            'graphics to webpage
					Thread.Sleep(200)
					SendKeys.SendWait("{TAB}")

					'Check to see if orcaview is the foreground window
					theHwnd = GetForegroundWindow()
					length = GetWindowTextLength(theHwnd) + 1
					buf = Space$(length)
					length = GetWindowText(theHwnd, buf, length)
					var = buf.Substring(0, length)
					'if orcaview is not the foreground window, exit the loop, as continuing the macro is silly
					If (var <> "Convert Graphics to Web Page") Then
						SendKeys.SendWait("{ESC}")
						MessageBox.Show("Make Sure to login to ORCAView", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
						Exit For
					End If

					Thread.Sleep(200)
					SendKeys.SendWait("{TAB}")
					If (cancel = True) Then
						Exit For
					End If
					Thread.Sleep(200)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(200)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(200)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(200)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(200)
					SendKeys.SendWait("{ENTER}")            ' Add button
					Thread.Sleep(UserTimeLapse)
					SendKeys.SendWait(d)
					Thread.Sleep(UserTimeLapse)
					SendKeys.SendWait("{ENTER}")
					Thread.Sleep(UserTimeLapse)

					'Leaving the following for now, as it was once needed and not sure if it will be needed again
					'SendKeys.SendWait("{TAB}")               'too many tabs if folder location is already open
					'Threading.Thread.Sleep(UserTimeLapse)
					'SendKeys.SendWait("{TAB}")
					'Threading.Thread.Sleep(UserTimeLapse)
					'SendKeys.SendWait("{TAB}")				'These were not necessary, and were breaking things
					'Threading.Thread.Sleep(UserTimeLapse)
					'SendKeys.SendWait("{TAB}")
					'Threading.Thread.Sleep(UserTimeLapse)
					'SendKeys.SendWait("{TAB}")
					'Threading.Thread.Sleep(UserTimeLapse)
					'SendKeys.SendWait("{TAB}")
					'Threading.Thread.Sleep(UserTimeLapse)

					SendKeys.SendWait("+{TAB}")
					Thread.Sleep(UserTimeLapse)
					SendKeys.SendWait("^a")                 '^ is for CRTL, so this line means CTRL+A
					Thread.Sleep(UserTimeLapse)
					If (cancel = True) Then
						Exit For
					End If
					SendKeys.SendWait("{ENTER}")
					Thread.Sleep(UserTimeLapse)
					SendKeys.SendWait("{ENTER}")
					Thread.Sleep(200)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(200)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(200)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(200)
					SendKeys.SendWait(Dest)
					Thread.Sleep(UserTimeLapse)
					SendKeys.SendWait("{ENTER}")
					'Dim wait As Integer = My.Computer.FileSystem.GetFiles(dir.FullName).Count * 200
					'If wait < 10000 Then
					'	wait = 10000
					'End If
					'Thread.Sleep(wait)
					Thread.Sleep(1000)
					SendKeys.SendWait("{ENTER}")
					Thread.Sleep(10)
				End If
			Next
			L_convert.Text = "Conversion Complete"
		Catch
			MessageBox.Show("Make Sure to login to ORCAView", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub stopButton_Click(sender As Object, e As EventArgs) Handles stopButton.Click
		cancel = True
	End Sub

	Private Sub DriveComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DriveComboBox.SelectedIndexChanged

	End Sub
End Class


