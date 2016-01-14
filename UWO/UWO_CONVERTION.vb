'Revision By: Alayna Duval
'Date: April 8 2014
'Revisions made: 
'Added variable UserTimeLapse, Try & Catch for reading in timeTextBox, Changed source and directory to H drive(as of now
'no access to Z drive), Added cancel button to stop & close program immediately 
'Date: April 9 2014
'Revisions made:
'Added combox-loaded values in design view, Added selected index code

Imports System.IO
Imports System
Imports System.Threading
Imports System.Windows.Forms

Public Class UWO_conversion

	Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Me.Width = UWO_MAIN.Width - 20
		L_convert.Width = Me.Width
		Dim p As Point
		p.X = 0
		p.Y = 0
		Me.Location = p
		Me.Show()
		DriveComboBox.SelectedIndex = 0
	End Sub

    'Default value is 1 second
    Dim UserTimeLapse As Double = 1.0

	Private Sub startButton_Click(sender As System.Object, e As System.EventArgs) Handles startButton.Click
		'Dim Source As String = "W:\PUBLIC\Delta\Graphics"
		Dim Source As String = "C:\Users\wescontrol\Desktop"
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
				Destination = "C:\Users\wescontrol\Desktop"
			Else
				MessageBox.Show("Choose a drive", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Return
			End If

			If Not Directory.Exists(Source) Then
				MessageBox.Show("Make Sure You Have Access To The W Drive", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Try
			End If
			If Not Directory.Exists(Destination) Then
				MessageBox.Show("Make Sure You Have Access To " + Destination, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Try
			End If

			For Each d As String In My.Computer.FileSystem.GetDirectories(Source)
				L_convert.Text = "Converting --> " + d

				L_convert.Update()
				Threading.Thread.Sleep(100)
				Dim dir As DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(d)
				Dim Dest = Destination + "\" + dir.Name
				If Not String.Compare(dir.Name, "archive", True) = 0 And
				   Not String.Compare(dir.Name, "bmp", True) = 0 And
				   Not String.Compare(dir.Name, "help files", True) = 0 And
				   Not String.Compare(dir.Name, "temp", True) = 0 Then
					If Directory.Exists(Dest) Then
						'Directory.Delete(Dest, True)
					End If
					Directory.CreateDirectory(Dest)
					AppActivate("ORCAView")
					SendKeys.SendWait("%t")                 ' % = alt, so this line means ALT+T\
					Debug.WriteLine("%t")
					Threading.Thread.Sleep(300)
					SendKeys.SendWait("{DOWN}")
					Debug.WriteLine("DOWN")
					Threading.Thread.Sleep(300)
					SendKeys.SendWait("{DOWN}")
					Debug.WriteLine("DOWN")
					Threading.Thread.Sleep(300)
					SendKeys.SendWait("{DOWN}")
					Debug.WriteLine("DOWN")
					Threading.Thread.Sleep(300)
					SendKeys.SendWait("{DOWN}")
					Debug.WriteLine("DOWN")
					Threading.Thread.Sleep(300)
                    'SendKeys.SendWait("{DOWN}")
                    Threading.Thread.Sleep(300)
					SendKeys.SendWait("{RIGHT}")
					Debug.WriteLine("RIGHT")
					Threading.Thread.Sleep(300)
					SendKeys.SendWait("{DOWN}")
					Debug.WriteLine("DOWN")
					Threading.Thread.Sleep(300)
					SendKeys.SendWait("{ENTER}")            'graphics to webpage
					Debug.WriteLine("ENTER")
					Threading.Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Debug.WriteLine("TAB")
					Threading.Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Debug.WriteLine("TAB")
					Threading.Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Debug.WriteLine("TAB")
					Threading.Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Debug.WriteLine("TAB")
					Threading.Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Debug.WriteLine("TAB")
					Threading.Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Debug.WriteLine("TAB")
					Threading.Thread.Sleep(300)
					SendKeys.SendWait("{ENTER}")            ' Add button
					Debug.WriteLine("ENTER")
					Threading.Thread.Sleep(UserTimeLapse)
					SendKeys.SendWait(d)
					Debug.WriteLine("SOURCE")
					Threading.Thread.Sleep(UserTimeLapse)
					SendKeys.SendWait("{ENTER}")
					Debug.WriteLine("ENTER")
					Threading.Thread.Sleep(UserTimeLapse)
					'SendKeys.SendWait("{TAB}")               'too many tabs if folder location is already open
					' ISSUES START HERE
					'Debug.WriteLine("TAB")
					'Threading.Thread.Sleep(UserTimeLapse)
					'SendKeys.SendWait("{TAB}")
					'Debug.WriteLine("TAB")
					'Threading.Thread.Sleep(UserTimeLapse)
					'SendKeys.SendWait("{TAB}")
					'Debug.WriteLine("TAB")
					'Threading.Thread.Sleep(UserTimeLapse)
					'SendKeys.SendWait("{TAB}")
					'Debug.WriteLine("TAB")
					'Threading.Thread.Sleep(UserTimeLapse)
					'SendKeys.SendWait("{TAB}")
					'Debug.WriteLine("TAB")
					'Threading.Thread.Sleep(UserTimeLapse)
					'SendKeys.SendWait("{TAB}")
					'Debug.WriteLine("TAB")
					'Threading.Thread.Sleep(UserTimeLapse)
					'-------
					SendKeys.SendWait("+{TAB}")
					Threading.Thread.Sleep(UserTimeLapse)
					'-------
					SendKeys.SendWait("^a")                 '^ is for CRTL, so this line means CTRL+A
					Debug.WriteLine("CTRL A")
					Threading.Thread.Sleep(UserTimeLapse)
					SendKeys.SendWait("{ENTER}")
					Debug.WriteLine("ENTER")
					'---
					Threading.Thread.Sleep(UserTimeLapse)
					SendKeys.SendWait("{ENTER}")
					'---
					Threading.Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Debug.WriteLine("TAB")
					Threading.Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Debug.WriteLine("TAB")
					Threading.Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Debug.WriteLine("TAB")
					Threading.Thread.Sleep(300)
					SendKeys.SendWait(Dest)
					Debug.WriteLine("DESTINATION")
					Threading.Thread.Sleep(UserTimeLapse)
					SendKeys.SendWait("{ENTER}")
					Debug.WriteLine("ENTER")
					Dim wait As Integer = My.Computer.FileSystem.GetFiles(dir.FullName).Count * 200
					If wait < 10000 Then
						wait = 10000
					End If
					Threading.Thread.Sleep(wait)
					SendKeys.SendWait("{ENTER}")
					Threading.Thread.Sleep(10)
				End If
			Next
			L_convert.Text = "Conversion Complete"
		Catch
			MessageBox.Show("Make Sure to login to ORCAView", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub UWO_conversion_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged
		Dim p As Point
		p.X = 0
		p.Y = 0
		Me.Location = p
	End Sub

	Private Sub stopButton_Click(sender As System.Object, e As System.EventArgs) Handles stopButton.Click
		End
	End Sub

	Private Sub DriveComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DriveComboBox.SelectedIndexChanged

	End Sub
End Class


