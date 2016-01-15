'Revision By: Luke Westelaken
'Date: January 13, 2016
'Revisions made: added github source control at https://github.com/ilgontae/UWO_SOLUTION
' all revisions will be made and recorded there

Imports System.IO

Public Class UWO_UPCASE

    Private Sub TB_Directory_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Directory.DoubleClick
        FBD_DIR.SelectedPath = "W:\PUBLIC\Delta\Graphics"
        FBD_DIR.ShowNewFolderButton = False
        FBD_DIR.ShowDialog()
        TB_Directory.Text = FBD_DIR.SelectedPath
    End Sub

    Private Sub TB_Directory_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Directory.TextChanged
        Dim DirSearch As String = TB_Directory.Text
        If Directory.Exists(TB_Directory.Text) Then
            TB_Directory.ForeColor = Color.Black
        Else
            TB_Directory.ForeColor = Color.Red
        End If
    End Sub

    Private Sub B_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_OK.Click
        Me.Enabled = False
        BackgroundWorker1.RunWorkerAsync()
        B_OK.Enabled = True
    End Sub

    Sub ren(ByVal dir As String)
        For Each files As String In Directory.GetFiles(dir)
            Dim temp As FileInfo = My.Computer.FileSystem.GetFileInfo(files)
            Dim f As String = temp.DirectoryName + "\" + temp.Name.ToUpper
            FileSystem.Rename(files, f)
        Next
        For Each d As String In Directory.GetDirectories(dir)
            ren(d)
        Next
    End Sub

    Private Sub UWO_UPCASE_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TB_Directory.Text = "W:\PUBLIC\Delta\Graphics"
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        ren(TB_Directory.Text)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Me.Enabled = True
    End Sub
End Class