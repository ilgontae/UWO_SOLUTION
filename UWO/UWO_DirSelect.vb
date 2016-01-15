'Revision By: Luke Westelaken
'Date: January 13, 2016
'Revisions made: added github source control at https://github.com/ilgontae/UWO_SOLUTION
' all revisions will be made and recorded there

Imports System.IO

Public Class UWO_DirSelect

    Private Sub B_Compare_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B_Compare.Click
        If TB_Dir1.Text = Nothing Or TB_Dir2.Text = Nothing Then
            MessageBox.Show("You Must Input Two Directorys To Compare", "INVALID INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf TB_Dir1.Text = TB_Dir2.Text Then
            MessageBox.Show("You Must Pick Two Different Directorys", "INVALID INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If Not My.Computer.FileSystem.DirectoryExists(TB_Dir1.Text) Then
                MessageBox.Show(TB_Dir1.Text + " -> Does Not Exist", "DIRECTORY ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf Not My.Computer.FileSystem.DirectoryExists(TB_Dir2.Text) Then
                MessageBox.Show(TB_Dir2.Text + " -> Does Not Exist", "DIRECTORY ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim Comp As New UWO_Compare
                Comp.Text = My.Computer.FileSystem.GetDirectoryInfo(TB_Dir1.Text).Name + " <-> " + My.Computer.FileSystem.GetDirectoryInfo(TB_Dir2.Text).Name
                Comp.MdiParent = UWO_MAIN
                Comp.Dir1 = TB_Dir1.Text
                Comp.Dir2 = TB_Dir2.Text
                Comp.Show()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub B_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B_Cancel.Click
        Me.Close()
    End Sub

    Private Sub B_Dir1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Dir1.Click
        FED_Dir1.ShowDialog()
        TB_Dir1.Text = FED_Dir1.SelectedPath
    End Sub

    Private Sub B_Dir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Dir2.Click
        FED_Dir2.ShowDialog()
        TB_Dir2.Text = FED_Dir2.SelectedPath
    End Sub

    Private Sub UWO_DirSelect_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Private Sub TB_Dir1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Dir1.TextChanged
        If Directory.Exists(TB_Dir1.Text) Then
            B_Compare.Enabled = True
            TB_Dir1.ForeColor = Color.Black
        Else
            B_Compare.Enabled = False
            TB_Dir1.ForeColor = Color.Red
        End If
    End Sub

    Private Sub TB_Dir2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Dir2.TextChanged
        If Directory.Exists(TB_Dir2.Text) Then
            B_Compare.Enabled = True
            TB_Dir2.ForeColor = Color.Black
        Else
            B_Compare.Enabled = False
            TB_Dir2.ForeColor = Color.Red
        End If
    End Sub
End Class