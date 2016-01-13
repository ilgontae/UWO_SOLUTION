Imports System.IO

Public Class UWO_Rename
    Private Dir As String
    Private Prefix As String
    Private Ext As String
    Private DirFiles As New List(Of ItemList)
    Private Structure ItemList
        Dim FName As String
        Dim FPath As String
        Dim FSize As Integer
        Dim FDate As Date
        Dim FExt As String
    End Structure

    Private Sub TB_Directory_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Directory.TextChanged
        Dir = TB_Directory.Text
        If Directory.Exists(Dir) Then
            TB_Directory.ForeColor = Color.Black
        Else
            TB_Directory.ForeColor = Color.Red
        End If
        GetFiles()
    End Sub

    Private Function ListFill(ByVal fill As ItemList) As ListViewItem
        Dim temp As ListViewItem = New ListViewItem(fill.FName)
        temp.SubItems.Add(fill.FSize)
        temp.SubItems.Add(fill.FDate)
        Return temp
    End Function

    Private Sub TB_Extension_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Extension.TextChanged
        If TB_Extension.Text.StartsWith(".") Then
            Ext = TB_Extension.Text
        ElseIf TB_Extension.Text = "" Then
            Ext = ""
        Else
            Ext = "." + TB_Extension.Text
        End If
        GetFiles()
    End Sub

    Private Sub TB_Prefix_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Prefix.TextChanged
        If TB_Prefix.Text = "" Then
            B_Rename.Enabled = False
            Prefix = ""
        Else
            B_Rename.Enabled = True
            Prefix = TB_Prefix.Text
        End If
        GetFiles()
    End Sub

    Private Sub GetFiles()
        DirFiles.Clear()
        FileList.Items.Clear()
        If Directory.Exists(Dir) Then
            For Each Files As String In Directory.GetFiles(Dir)
                Dim Temp As FileInfo = My.Computer.FileSystem.GetFileInfo(Files)
                Dim TempList As ItemList
                If TB_Extension.Text = "" Then
                    If Prefix = "" Then
                        TempList.FDate = Temp.LastWriteTime
                        TempList.FSize = Temp.Length
                        TempList.FName = Temp.Name
                        TempList.FPath = Temp.FullName
                        TempList.FExt = Temp.Extension
                        DirFiles.Add(TempList)
                    ElseIf Not String.Compare(Temp.Name.Split("_").First, Prefix, True) = 0 Then
                        TempList.FDate = Temp.LastWriteTime
                        TempList.FSize = Temp.Length
                        TempList.FName = Temp.Name
                        TempList.FPath = Temp.FullName
                        TempList.FExt = Temp.Extension
                        DirFiles.Add(TempList)
                    End If
                ElseIf String.Compare(Temp.Extension, Ext, True) = 0 Then
                    If Prefix = "" Then
                        TempList.FDate = Temp.LastWriteTime
                        TempList.FSize = Temp.Length
                        TempList.FName = Temp.Name
                        TempList.FPath = Temp.FullName
                        TempList.FExt = Temp.Extension
                        DirFiles.Add(TempList)
                    ElseIf Not Temp.Name = Prefix Then
                        TempList.FDate = Temp.LastWriteTime
                        TempList.FSize = Temp.Length
                        TempList.FName = Temp.Name
                        TempList.FPath = Temp.FullName
                        TempList.FExt = Temp.Extension
                        DirFiles.Add(TempList)
                    End If
                End If
            Next
            For Each Fill As ItemList In DirFiles
                FileList.Items.Add(ListFill(Fill))
            Next
        End If
    End Sub

    Private Sub B_Rename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Rename.Click
        For Each temp As ItemList In DirFiles
            Dim t As String = Prefix + "_" + temp.FName
            If CB_UpperCase.Checked = True Then
                t = t.ToUpper
            End If
            If CB_UnderScore.Checked = True Then
                t = Replace(t, " ", "_")
            End If
            My.Computer.FileSystem.RenameFile(temp.FPath, t)
        Next
        TB_Prefix.Text = ""
        TB_Extension.Text = ""
        GetFiles()
    End Sub

    Private Sub FileList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles FileList.DoubleClick
        If B_Rename.Enabled = True Then
            Dim a As String = FileList.SelectedItems(0).Text
            For Each temp As ItemList In DirFiles
                If a = temp.FName Then
                    Dim t As String = Prefix + "_" + temp.FName
                    If CB_UpperCase.Checked = True Then
                        t = t.ToUpper
                    End If
                    If CB_UnderScore.Checked = True Then
                        t = Replace(t, " ", "_")
                    End If
                    My.Computer.FileSystem.RenameFile(temp.FPath, t)
                End If
            Next
            TB_Prefix.Text = ""
            TB_Extension.Text = ""
            GetFiles()
        End If
    End Sub

    Private Sub B_Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Browse.Click
        FBD_Dir.ShowDialog()
        TB_Directory.Text = FBD_Dir.SelectedPath
    End Sub
End Class