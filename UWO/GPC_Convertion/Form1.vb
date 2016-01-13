Imports System.IO

Public Class Form1
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Hide()
        Try
            Dim Source As String = "W:\PUBLIC\Delta\Graphics"
            Dim Destination As String = "Z:\Graphics"

            If Not Directory.Exists(Source) Then
                MessageBox.Show("Make Sure You Have Access To The W Drive", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Try
            End If
            If Not Directory.Exists(Destination) Then
                MessageBox.Show("Make Sure You Have Access To The Z Drive", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Try
            End If

            For Each d As String In My.Computer.FileSystem.GetDirectories(Source)
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
                    Sleep(10)
                    SendKeys.SendWait("{DOWN}")
                    Sleep(10)
                    SendKeys.SendWait("{DOWN}")
                    Sleep(10)
                    SendKeys.SendWait("{DOWN}")
                    Sleep(10)
                    SendKeys.SendWait("{DOWN}")
                    Sleep(10)
                    SendKeys.SendWait("{RIGHT}")
                    Sleep(10)
                    SendKeys.SendWait("{DOWN}")
                    Sleep(10)
                    SendKeys.SendWait("{ENTER}")
                    Sleep(10)
                    SendKeys.SendWait("{TAB}")
                    Sleep(10)
                    SendKeys.SendWait("{TAB}")
                    Sleep(10)
                    SendKeys.SendWait("{TAB}")
                    Sleep(10)
                    SendKeys.SendWait("{TAB}")
                    Sleep(10)
                    SendKeys.SendWait("{TAB}")
                    Sleep(10)
                    SendKeys.SendWait("{TAB}")
                    Sleep(10)
                    SendKeys.SendWait("{ENTER}")
                    Sleep(10)
                    SendKeys.SendWait(d)
                    Sleep(10)
                    SendKeys.SendWait("{ENTER}")
                    Sleep(10)
                    SendKeys.SendWait("{TAB}")
                    Sleep(10)
                    SendKeys.SendWait("{TAB}")
                    Sleep(10)
                    SendKeys.SendWait("{TAB}")
                    Sleep(10)
                    SendKeys.SendWait("{TAB}")
                    Sleep(10)
                    SendKeys.SendWait("{TAB}")
                    Sleep(10)
                    SendKeys.SendWait("{TAB}")
                    Sleep(10)
                    SendKeys.SendWait("^a")
                    Sleep(10)
                    SendKeys.SendWait("{ENTER}")
                    Sleep(10)
                    SendKeys.SendWait("{TAB}")
                    Sleep(10)
                    SendKeys.SendWait("{TAB}")
                    Sleep(10)
                    SendKeys.SendWait("{TAB}")
                    Sleep(10)
                    SendKeys.SendWait(Dest)
                    Sleep(10)
                    SendKeys.SendWait("{ENTER}")
                    Dim wait As Integer = My.Computer.FileSystem.GetFiles(dir.FullName).Count * 200
                    If wait < 10000 Then
                        wait = 10000
                    End If
                    Sleep(wait)
                    SendKeys.SendWait("{ENTER}")
                    Sleep(10)
                End If
            Next
            MessageBox.Show("Convertion Complete", "Convertion", MessageBoxButtons.OK, MessageBoxIcon.None)
        Catch
            MessageBox.Show("Make Sure to login to ORCAView", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Close()
        End Try
    End Sub
End Class
