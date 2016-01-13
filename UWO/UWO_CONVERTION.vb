'Revision By: Alayna Duval
'Date: April 8 2014
'Revisions made: 
'Added variable UserTimeLapse, Try & Catch for reading in timeTextBox, Changed source and directory to H drive(as of now
'no access to Z drive), Added cancel button to stop & close program immediately 
'Date: April 9 2014
'Revisions made:
'Added combox-loaded values in design view, Added selected index code

Imports System.IO
Imports System.Threading
Imports System.Windows.Forms

Public Class UWO_CONVERTION

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Width = UWO_MAIN.Width - 13
        L_convert.Width = Me.Width
        Dim p As Point
        p.X = 0
        p.Y = 0
        Me.Location = p
        Me.Show()
    End Sub

    'Default value is 1 second
    Dim UserTimeLapse As Double = 1.0

    Private Sub startButton_Click(sender As System.Object, e As System.EventArgs) Handles startButton.Click
        Dim Source As String = "W:\PUBLIC\Delta\Graphics"
        Dim Destination As String = "Z:\Graphics"

        Try
            UserTimeLapse = timeTextBox.Text

            If UserTimeLapse > 0 Then
                UserTimeLapse = UserTimeLapse * 1000
            Else
                MessageBox.Show("Amount must be greater than zero", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
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
                If Not String.Compare(dir.Name, "archive", True) = 0 And _
                   Not String.Compare(dir.Name, "bmp", True) = 0 And _
                   Not String.Compare(dir.Name, "help files", True) = 0 And _
                   Not String.Compare(dir.Name, "temp", True) = 0 Then
                    If Directory.Exists(Dest) Then
                        Directory.Delete(Dest, True)
                    End If
                    Directory.CreateDirectory(Dest)
                    AppActivate("ORCAView")
                    SendKeys.SendWait("%t")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{DOWN}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{DOWN}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{DOWN}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{DOWN}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    'SendKeys.SendWait("{DOWN}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{RIGHT}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{DOWN}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{ENTER}") 'graphics to webpage
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{TAB}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{TAB}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{TAB}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{TAB}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{TAB}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{TAB}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{ENTER}") ' Add button
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait(d)
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{ENTER}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{TAB}") 'too many tabs if folder location is already open
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{TAB}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{TAB}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{TAB}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{TAB}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{TAB}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("^a")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{ENTER}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{TAB}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{TAB}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{TAB}")
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait(Dest)
                    Threading.Thread.Sleep(UserTimeLapse)
                    SendKeys.SendWait("{ENTER}")
                    Dim wait As Integer = My.Computer.FileSystem.GetFiles(dir.FullName).Count * 200
                    If wait < 10000 Then
                        wait = 10000
                    End If
                    Threading.Thread.Sleep(wait)
                    SendKeys.SendWait("{ENTER}")
                    Threading.Thread.Sleep(10)
                End If
            Next
            L_convert.Text = "Convertion Complete"
        Catch
            MessageBox.Show("Make Sure to login to ORCAView", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UWO_CONVERTION_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged
        Dim p As Point
        p.X = 0
        p.Y = 0
        Me.Location = p
    End Sub

    Private Sub stopButton_Click(sender As System.Object, e As System.EventArgs) Handles stopButton.Click
        End
    End Sub
End Class


