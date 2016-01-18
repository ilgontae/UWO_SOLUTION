'Revision By: Luke Westelaken
'Date: January 13, 2016
'Revisions made: added github source control at https://github.com/ilgontae/UWO_SOLUTION
' all revisions will be made and recorded there

Imports System.IO

Public Class UWO_Compare
    Public Dir1 As String
    Public Dir2 As String
    Private Dir1Folders As New List(Of ItemList)
    Private Dir1Files As New List(Of ItemList)
    Private Dir2Folders As New List(Of ItemList)
    Private Dir2Files As New List(Of ItemList)
    Private SameFol As Boolean
    Private SameFil As Boolean

    Private Structure ItemList
        Dim FName As String
        Dim FDirectory As String
        Dim FPath As String
        Dim FExtension As String
        Dim FStatus As String
        Dim FType As String
        Dim FSize As Integer
        Dim FDate As Date        
    End Structure

    Private Sub UWO_Compare_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        For Each Folders As String In Directory.GetDirectories(Dir1)
            Dir1Folders.Add(FolderFill(Folders))
        Next
        For Each Folders As String In Directory.GetDirectories(Dir2)
            Dir2Folders.Add(FolderFill(Folders))
        Next
        For Each Files As String In Directory.GetFiles(Dir1)
            Dir1Files.Add(FileFill(Files))
        Next
        For Each Files As String In Directory.GetFiles(Dir2)
            Dir2Files.Add(FileFill(Files))
        Next
        FolderCompare()
        FileCompare()
        For Each Fill As ItemList In Dir1Folders
            LeftList.Items.Add(ListFill(Fill))
        Next
        For Each Fill As ItemList In Dir2Folders
            RightList.Items.Add(ListFill(Fill))
        Next
        Filler()
        For Each Fill As ItemList In Dir1Files
            LeftList.Items.Add(ListFill(Fill))
        Next
        For Each Fill As ItemList In Dir2Files
            RightList.Items.Add(ListFill(Fill))
        Next
        Filler()
        If SameFil = True And SameFol = True Then
            Directory.SetLastWriteTime(Dir1, Directory.GetLastWriteTime(Dir2))
        End If
        LeftBar.Maximum = LeftList.Items.Count
        RightBar.Maximum = RightList.Items.Count
    End Sub

    Private Sub Filler()
        If LeftList.Items.Count > RightList.Items.Count Then
            For t = 1 To (LeftList.Items.Count - RightList.Items.Count)
                RightList.Items.Add("")
            Next
        ElseIf RightList.Items.Count > LeftList.Items.Count Then
            For t = 1 To (RightList.Items.Count - LeftList.Items.Count)
                LeftList.Items.Add("")
            Next
        End If
    End Sub

    Private Sub FileCompare()
        Dim Count As Integer
        Dim iter As Integer = 0
        Dim temp As ItemList = Nothing
        temp.FType = "EMPTY"
        SameFil = True

        If Dir1Files.Count > Dir2Files.Count Then
            Count = Dir1Files.Count
        Else
            Count = Dir2Files.Count
        End If

        While iter <> Count
            If iter >= Dir1Files.Count Or iter >= Dir2Files.Count Then
                Exit While
            End If
            Dim Dir1Item As ItemList = Dir1Files(iter)
            Dim Dir2Item As ItemList = Dir2Files(iter)
            Dim Com As Integer = String.Compare(Dir1Item.FName, Dir2Item.FName)
            If Com > 0 Then
                Dir1Files.Insert(iter, temp)
            ElseIf Com < 0 Then
                Dir2Files.Insert(iter, temp)
            Else
                If Dir1Files(iter).FDate > Dir2Files(iter).FDate Then
                    Dim a As ItemList = Dir1Files(iter)
                    a.FStatus = "Newer"
                    Dir1Files(iter) = a
                    Dim b As ItemList = Dir2Files(iter)
                    b.FStatus = "Older"
                    Dir2Files(iter) = b
                    SameFil = False
                ElseIf Dir2Files(iter).FDate > Dir1Files(iter).FDate Then
                    Dim a As ItemList = Dir2Files(iter)
                    a.FStatus = "Newer"
                    Dir2Files(iter) = a
                    Dim b As ItemList = Dir1Files(iter)
                    b.FStatus = "Older"
                    Dir1Files(iter) = b
                    SameFil = False
                Else
                    Dim a As ItemList = Dir1Files(iter)
                    a.FStatus = "Same"
                    Dir1Files(iter) = a
                    Dim b As ItemList = Dir2Files(iter)
                    b.FStatus = "Same"
                    Dir2Files(iter) = b
                End If
            End If
            If Dir1Files.Count > Count Then
                Count = Dir1Files.Count
            ElseIf Dir2Files.Count > Count Then
                Count = Dir2Files.Count
            End If
            iter += 1
        End While
    End Sub

    Private Sub FolderCompare()
        Dim Count As Integer
        Dim iter As Integer = 0
        Dim temp As ItemList = Nothing
        temp.FType = "EMPTY"
        SameFol = True

        If Dir1Folders.Count > Dir2Folders.Count Then
            Count = Dir1Folders.Count
        Else
            Count = Dir2Folders.Count
        End If

        While iter <> Count
            If iter >= Dir1Folders.Count Or iter >= Dir2Folders.Count Then                
                Exit While
            End If
            Dim Dir1Item As ItemList = Dir1Folders(iter)
            Dim Dir2Item As ItemList = Dir2Folders(iter)
            Dim Com As Integer = String.Compare(Dir1Item.FName, Dir2Item.FName)
            If Com > 0 Then
                Dir1Folders.Insert(iter, temp)
            ElseIf Com < 0 Then
                Dir2Folders.Insert(iter, temp)
            Else
                If Dir1Folders(iter).FDate > Dir2Folders(iter).FDate Then
                    Dim a As ItemList = Dir1Folders(iter)
                    a.FStatus = "Newer"
                    Dir1Folders(iter) = a
                    Dim b As ItemList = Dir2Folders(iter)
                    b.FStatus = "Older"
                    Dir2Folders(iter) = b
                    SameFol = False
                ElseIf Dir2Folders(iter).FDate > Dir1Folders(iter).FDate Then
                    Dim a As ItemList = Dir2Folders(iter)
                    a.FStatus = "Newer"
                    Dir2Folders(iter) = a
                    Dim b As ItemList = Dir1Folders(iter)
                    b.FStatus = "Older"
                    Dir1Folders(iter) = b
                    SameFol = False
                Else
                    Dim a As ItemList = Dir1Folders(iter)
                    a.FStatus = "Same"
                    Dir1Folders(iter) = a
                    Dim b As ItemList = Dir2Folders(iter)
                    b.FStatus = "Same"
                    Dir2Folders(iter) = b
                End If
            End If
            If Dir1Folders.Count > Count Then
                Count = Dir1Folders.Count
            ElseIf Dir2Folders.Count > Count Then
                Count = Dir2Folders.Count
            End If
            iter += 1
        End While

    End Sub

    Private Function ListFill(ByVal fill As ItemList) As ListViewItem
        Dim temp As ListViewItem
        If (fill.FType = "File") Then
            temp = New ListViewItem(fill.FName.ToUpper)
            temp.SubItems.Add(fill.FSize)
            temp.SubItems.Add(fill.FDate)
            temp.SubItems.Add(fill.FStatus)
            If fill.FStatus = "Newer" Then
                temp.BackColor = Color.DarkBlue
                temp.ForeColor = Color.White
            ElseIf fill.FStatus = "Older" Then
                temp.BackColor = Color.DarkRed
                temp.ForeColor = Color.White
            End If
        ElseIf fill.FType = "EMPTY" Then
            temp = New ListViewItem("")
        Else
            temp = New ListViewItem(fill.FName.ToUpper)
            temp.SubItems.Add("")
            temp.SubItems.Add(fill.FDate)
            temp.SubItems.Add(fill.FStatus)
            If fill.FStatus = "Newer" Then
                temp.BackColor = Color.DarkBlue
                temp.ForeColor = Color.White
            ElseIf fill.FStatus = "Older" Then
                temp.BackColor = Color.DarkRed
                temp.ForeColor = Color.White
            End If
        End If
        Return temp
    End Function

    Private Function FileFill(ByVal Files As String) As ItemList
        Dim Temp As FileInfo = My.Computer.FileSystem.GetFileInfo(Files)
        Dim TempList As ItemList
        TempList.FDate = Temp.LastWriteTime
        TempList.FDirectory = Temp.DirectoryName.ToUpper
        TempList.FExtension = Temp.Extension.ToString.ToUpper
        TempList.FSize = Temp.Length
        TempList.FStatus = Nothing
        TempList.FName = Temp.Name.ToUpper
        TempList.FPath = Temp.FullName.ToUpper
        TempList.FType = "File"
        Return TempList
    End Function

    Private Function FolderFill(ByVal Folder As String) As ItemList
        Dim Temp As DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(Folder)
        Dim TempList As ItemList
        TempList.FDate = Temp.LastWriteTime
        TempList.FDirectory = Nothing
        TempList.FExtension = Nothing
        TempList.FSize = Nothing
        TempList.FStatus = Nothing
        TempList.FName = Temp.Name.ToUpper
        TempList.FPath = Temp.FullName.ToUpper
        TempList.FType = "Folder"
        Return TempList
    End Function

    Private Sub UWO_Compare_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
        If Panels.Width / 2 > 0 Then
            Panels.SplitterDistance = Panels.Width / 2
        End If
    End Sub

    Private Sub LeftList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LeftList.Click

        RightList.Items.Item(LeftList.SelectedItems(0).Index).EnsureVisible()

    End Sub

    Private Sub RightList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RightList.Click
        LeftList.Items.Item(RightList.SelectedItems(0).Index).EnsureVisible()
    End Sub

    Private Sub LeftList_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles LeftList.Resize
        LName.Width = (LeftList.Width - 25) / 4
        LSize.Width = (LeftList.Width - 25) / 4
        LDate.Width = (LeftList.Width - 25) / 4
        LStatus.Width = (LeftList.Width - 25) / 4
    End Sub

    Private Sub RightList_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles RightList.Resize
        RName.Width = (RightList.Width - 25) / 4
        RSize.Width = (RightList.Width - 25) / 4
        RDate.Width = (RightList.Width - 25) / 4
        RStatus.Width = (RightList.Width - 25) / 4
    End Sub

    Private Sub LeftList_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles LeftList.DoubleClick
        Dim ItemSel As Integer = LeftList.SelectedItems(0).Index
        Dim Num As Integer
        If Dir1Folders.Count >= Dir2Folders.Count Then
            Num = Dir1Folders.Count
        ElseIf Dir2Folders.Count > Dir1Folders.Count Then
            Num = Dir2Folders.Count
        End If
        If (ItemSel + 1) > Num Then
            ItemSel -= Num
            If ItemSel >= Dir1Files.Count Then
                Dim Source As String = Dir2Files(ItemSel).FPath
                DeleteFile(Source)
            ElseIf Dir1Files(ItemSel).FType = "EMPTY" Then
                Dim Source As String = Dir2Files(ItemSel).FPath
                DeleteFile(Source)
            Else
                If Not Dir1Files(ItemSel).FStatus = "Same" Then
                    Dim Source As String = Dir1Files(ItemSel).FPath
                    Dim Dest As String = Dir2 + "\" + Dir1Files(ItemSel).FName
                    CopyFile(Source, Dest)
                End If
            End If
        Else
            If ItemSel < Dir1Folders.Count And ItemSel < Dir2Folders.Count Then
                If Dir1Folders(ItemSel).FName = Dir2Folders(ItemSel).FName Then
                    Dim Comp As New UWO_Compare
                    Comp.Text = Dir1Folders(ItemSel).FName + " <-> " + Dir2Folders(ItemSel).FName
                    Comp.MdiParent = UWO_MAIN
                    Comp.Dir1 = Dir1Folders(ItemSel).FPath
                    Comp.Dir2 = Dir2Folders(ItemSel).FPath
                    Comp.Show()
                    Timer1_Tick(sender, e)
                Else
                    If ItemSel >= Dir1Folders.Count Then
                        Dim Source As String = Dir2Folders(ItemSel).FPath
                        DeleteDir(Source)
                    ElseIf Dir1Folders(ItemSel).FType = "EMPTY" Then
                        Dim Source As String = Dir2Folders(ItemSel).FPath
                        DeleteDir(Source)
                    Else
                        If Not Dir1Folders(ItemSel).FStatus = "Same" Then
                            Dim Source As String = Dir1Folders(ItemSel).FPath
                            Dim Dest As String = Dir2 + "\" + Dir1Folders(ItemSel).FName
                            CopyDir(Source, Dest)
                        End If
                    End If
                End If
            Else
                If ItemSel >= Dir1Folders.Count Then
                    Dim Source As String = Dir2Folders(ItemSel).FPath
                    DeleteDir(Source)
                ElseIf Dir1Folders(ItemSel).FType = "EMPTY" Then
                    Dim Source As String = Dir2Folders(ItemSel).FPath
                    DeleteDir(Source)
                Else
                    If Not Dir1Folders(ItemSel).FStatus = "Same" Then
                        Dim Source As String = Dir1Folders(ItemSel).FPath
                        Dim Dest As String = Dir2 + "\" + Dir1Folders(ItemSel).FName
                        CopyDir(Source, Dest)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub RightList_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles RightList.DoubleClick
        Dim ItemSel As Integer = RightList.SelectedItems(0).Index
        Dim Num As Integer
        If Dir1Folders.Count >= Dir2Folders.Count Then
            Num = Dir1Folders.Count
        ElseIf Dir2Folders.Count > Dir1Folders.Count Then
            Num = Dir2Folders.Count
        End If
        If (ItemSel + 1) > Num Then
            ItemSel -= Num
            If ItemSel >= Dir2Files.Count Then
                Dim Source As String = Dir1Files(ItemSel).FPath
                DeleteFile(Source)
            ElseIf Dir2Files(ItemSel).FType = "EMPTY" Then
                Dim Source As String = Dir1Files(ItemSel).FPath
                DeleteFile(Source)
            Else
                If Not Dir2Files(ItemSel).FStatus = "Same" Then
                    Dim Source As String = Dir2Files(ItemSel).FPath
                    Dim Dest As String = Dir1 + "\" + Dir2Files(ItemSel).FName
                    CopyFile(Source, Dest)
                End If
            End If
        Else
            If ItemSel < Dir2Folders.Count And ItemSel < Dir1Folders.Count Then
                If Dir1Folders(ItemSel).FName = Dir2Folders(ItemSel).FName Then
                    Dim Comp As New UWO_Compare
                    Comp.Text = Dir1Folders(ItemSel).FName + " <-> " + Dir2Folders(ItemSel).FName
                    Comp.MdiParent = UWO_MAIN
                    Comp.Dir1 = Dir1Folders(ItemSel).FPath
                    Comp.Dir2 = Dir2Folders(ItemSel).FPath
                    Comp.Show()
                    Timer1_Tick(sender, e)
                Else
                    If ItemSel >= Dir2Folders.Count Then
                        Dim Source As String = Dir1Folders(ItemSel).FPath
                        DeleteDir(Source)
                    ElseIf Dir2Folders(ItemSel).FType = "EMPTY" Then
                        Dim Source As String = Dir1Folders(ItemSel).FPath
                        DeleteDir(Source)
                    Else
                        If Not Dir2Folders(ItemSel).FStatus = "Same" Then
                            Dim Source As String = Dir2Folders(ItemSel).FPath
                            Dim Dest As String = Dir1 + "\" + Dir2Folders(ItemSel).FName
                            CopyDir(Source, Dest)
                        End If
                    End If
                End If
            Else
                If ItemSel >= Dir2Folders.Count Then
                    Dim Source As String = Dir1Folders(ItemSel).FPath
                    DeleteDir(Source)
                ElseIf Dir2Folders(ItemSel).FType = "EMPTY" Then
                    Dim Source As String = Dir1Folders(ItemSel).FPath
                    DeleteDir(Source)
                Else
                    If Not Dir2Folders(ItemSel).FStatus = "Same" Then
                        Dim Source As String = Dir2Folders(ItemSel).FPath
                        Dim Dest As String = Dir1 + "\" + Dir2Folders(ItemSel).FName
                        CopyDir(Source, Dest)
                    End If
                End If
            End If
        End If
    End Sub

    Sub DeleteDir(ByVal Source As String)
        Try
            If Directory.Exists(Source) Then
                My.Computer.FileSystem.DeleteDirectory(Source, FileIO.DeleteDirectoryOption.DeleteAllContents)
                Dim a As Object = Nothing
                Dim b As EventArgs = Nothing
                Timer1_Tick(a, b)
            Else
                MsgBox(Source + " does not exist!", vbExclamation, "Source File Missing")
            End If
        Catch E As Exception
            MessageBox.Show(E.ToString, "Delete ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CopyDir(ByVal Source As String, ByVal Dest As String)
        Try
            If Directory.Exists(Source) Then
                My.Computer.FileSystem.CopyDirectory(Source, Dest)
                Directory.SetLastWriteTime(Dest, Directory.GetLastWriteTime(Source))
                Dim a As Object = Nothing
                Dim b As EventArgs = Nothing
                Timer1_Tick(a, b)
            Else
                MsgBox(Source + " does not exist!", vbExclamation, "Source File Missing")
            End If
        Catch E As Exception
            MessageBox.Show("Error Occured During Copy", "COPY ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub DeleteFile(ByVal Source As String)
        Try
            If File.Exists(Source) Then
                File.Delete(Source)
                Dim a As Object = Nothing
                Dim b As EventArgs = Nothing
                Timer1_Tick(a, b)
            Else
                MsgBox(Source + " does not exist!", vbExclamation, "Source File Missing")
            End If
        Catch E As Exception
            MessageBox.Show("Error Occured During Delete", "Delete ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CopyFile(ByVal Source As String, ByVal Dest As String)
        Try
            If File.Exists(Source) Then
                FileCopy(Source, Dest)
                Dim a As Object = Nothing
                Dim b As EventArgs = Nothing
                Timer1_Tick(a, b)
            Else
                MsgBox(Source + " does not exist!", vbExclamation, "Source File Missing")
            End If
        Catch E As Exception
            MessageBox.Show("Error Occured During Copy", "COPY ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        LeftList.Items.Clear()
        RightList.Items.Clear()
        Dir1Folders.Clear()
        Dir2Folders.Clear()
        Dir1Files.Clear()
        Dir2Files.Clear()
        UWO_Compare_Load(sender, e)
    End Sub

    Private Sub LeftBar_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LeftBar.ValueChanged
        RightBar.Value = LeftBar.Value
        LeftList.TopItem = LeftList.Items(LeftBar.Value)
        RightList.TopItem = RightList.Items(LeftBar.Value)
    End Sub

    Private Sub RightBar_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RightBar.ValueChanged
        LeftBar.Value = RightBar.Value
        LeftList.TopItem = LeftList.Items(RightBar.Value)
        RightList.TopItem = RightList.Items(RightBar.Value)
    End Sub

    Private Sub LeftList_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LeftList.MouseWheel
        If e.Delta > 0 Then
            If LeftBar.Value - 2 > LeftBar.Minimum Then
                LeftBar.Value = LeftBar.Value - 2
            End If
        ElseIf e.Delta < 0 Then
            If LeftBar.Value + 2 < LeftBar.Maximum Then
                LeftBar.Value = LeftBar.Value + 2
            End If
        End If
    End Sub

    Private Sub RightList_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RightList.MouseWheel
        If e.Delta > 0 Then
            If RightBar.Value - 2 > LeftBar.Minimum Then
                RightBar.Value = RightBar.Value - 2
            End If
        ElseIf e.Delta < 0 Then
            If RightBar.Value + 2 < RightBar.Maximum Then
                RightBar.Value = RightBar.Value + 2
            End If
        End If
    End Sub
End Class