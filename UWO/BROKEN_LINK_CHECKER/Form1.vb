Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Runtime.InteropServices

Public Class Form1
    Private Sub TB_Directory_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Directory.DoubleClick
        FBD_Directory.SelectedPath = "W:\PUBLIC\Delta\Graphics"

        FBD_Directory.ShowDialog()
        TB_Directory.Text = FBD_Directory.SelectedPath
    End Sub

    Private Sub TB_Directory_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TB_Directory.KeyUp
        If e.KeyCode = Keys.Enter Then
            B_Search_Click(sender, e)
        End If
    End Sub

    Private Sub TB_Directory_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Directory.TextChanged
        Dim DirSearch As String = TB_Directory.Text
        If Directory.Exists(TB_Directory.Text) Then
            TB_Directory.ForeColor = Color.Black
        Else
            TB_Directory.ForeColor = Color.Red
        End If
    End Sub

    Private Sub B_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Search.Click
        B_Search.Enabled = False
        LV_BrokenList.Items.Clear()
        getfile(TB_Directory.Text)
        If LV_BrokenList.Items.Count = 0 Then
            LV_BrokenList.Items.Add("There are no broken links in this folder")
        Else
            LV_BrokenList.Items.RemoveAt(LV_BrokenList.Items.Count - 1)
            LV_BrokenList.Items.RemoveAt(LV_BrokenList.Items.Count - 1)
        End If
        B_Search.Enabled = True
    End Sub

    Private Sub FindStr(ByVal fname As String)
        Try
            Dim testTxt As New StreamReader(fname)
            Dim allRead As String = testTxt.ReadToEnd()
            testTxt.Close()
            Dim txtLength As Integer = allRead.Length
            Dim x As Integer = 0
            Dim found As Boolean = False
            LV_BrokenList.Items.Add(fname.Substring(TB_Directory.Text.Length + 1))
            LV_BrokenList.Items.Add("===============================================================================")
            While x < txtLength
                If allRead(x) = "(" Then
                    If String.Compare(allRead.Substring(x - 7, 8), "replace(", True) = 0 Or _
                       String.Compare(allRead.Substring(x - 4, 5), "goto(", True) = 0 Then
                        Dim link As String = ""
                        x += 1
                        While x < txtLength
                            If allRead(x) <> ")" Then
                                link = link + allRead(x)
                            Else
                                Exit While
                            End If
                            If String.Compare(link, "BAC", True) = 0 Or _
                               String.Compare(link, "V2", True) = 0 Then
                                link = ""
                                Exit While
                            End If
                            x += 1
                        End While
                        If link <> "" And link.EndsWith(".gpc") = True Then
                            Dim FileTest As String = My.Computer.FileSystem.GetFileInfo(fname).Directory.ToString + "\" + link
                            Dim it As ListViewItem = New ListViewItem("-------> " + link)
                            If File.Exists(FileTest) = False Then
                                it.ForeColor = Color.Red
                                LV_BrokenList.Items.Add(it)
                                found = True
                            End If
                        End If
                    End If
                End If
                x += 1
            End While            
            If found = False Then
                LV_BrokenList.Items.RemoveAt(LV_BrokenList.Items.Count - 1)
                LV_BrokenList.Items.RemoveAt(LV_BrokenList.Items.Count - 1)
            Else
                LV_BrokenList.Items.Add("-------------------------------------------------------------------------------------------------------------------------------------------------------------")
                LV_BrokenList.Items.Add("")
            End If
        Catch
        End Try
    End Sub

    Private Sub getfile(ByVal dir As String)
        Dim a As String = My.Computer.FileSystem.GetDirectoryInfo(dir).Name.ToString
        If Not String.Compare(a, "Temp", True) = 0 And _
           Not String.Compare(a, "bmp", True) = 0 And _
           Not String.Compare(a, "archive", True) = 0 And _
           Not String.Compare(a, "help files", True) = 0 Then
            For Each files As String In My.Computer.FileSystem.GetFiles(dir)
                If String.Compare(files.Split(".").Last, "gpc", True) = 0 Then
                    FindStr(files)
                End If
            Next
            For Each root As String In My.Computer.FileSystem.GetDirectories(dir)
                getfile(root)
            Next
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TB_Directory.Text = "W:\PUBLIC\Delta\Graphics"
    End Sub

    Private Sub LV_BrokenList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LV_BrokenList.DoubleClick
        For Each it As Integer In New ReverseIterator(LV_BrokenList.SelectedIndices)            
            If LV_BrokenList.Items(it).Text.StartsWith("------->") Then
                Dim last As Boolean
                If LV_BrokenList.Items(it - 1).Text = "===============================================================================" And _
                   it = LV_BrokenList.Items.Count - 1 Then
                    last = True
                ElseIf it = LV_BrokenList.Items.Count - 1 Then
                    last = False
                ElseIf LV_BrokenList.Items(it - 1).Text = "===============================================================================" And _
                    LV_BrokenList.Items(it + 1).Text = "-------------------------------------------------------------------------------------------------------------------------------------------------------------" Then
                    last = True
                Else
                    last = False
                End If
                If last = True Then
                    If it + 2 < LV_BrokenList.Items.Count Then
                        LV_BrokenList.Items.RemoveAt(it + 2)
                    End If
                    If it + 1 < LV_BrokenList.Items.Count Then
                        LV_BrokenList.Items.RemoveAt(it + 1)
                    End If
                    LV_BrokenList.Items.RemoveAt(it)
                    LV_BrokenList.Items.RemoveAt(it - 1)
                    LV_BrokenList.Items.RemoveAt(it - 2)
                Else
                    LV_BrokenList.Items.RemoveAt(it)
                End If
            ElseIf (Not LV_BrokenList.Items(it).Text.StartsWith("=")) And (Not LV_BrokenList.Items(it).Text.StartsWith("-")) Then
                Try
                    AppActivate("ORCAView")
                    Threading.Thread.Sleep(5)
                    SendKeys.SendWait("%F")
                    Threading.Thread.Sleep(5)
                    SendKeys.SendWait("{DOWN}")
                    Threading.Thread.Sleep(5)
                    SendKeys.SendWait("{DOWN}")
                    Threading.Thread.Sleep(5)
                    SendKeys.SendWait("{ENTER}")
                    Threading.Thread.Sleep(5)
                    Dim tem As String = TB_Directory.Text + "\" + LV_BrokenList.Items(it).Text
                    SendKeys.SendWait(tem)
                    Threading.Thread.Sleep(5)
                    SendKeys.SendWait("{ENTER}")
                Catch
                End Try
            End If
        Next
    End Sub
End Class

Class ReverseIterator
    Implements IEnumerable

    ' a low-overhead ArrayList to store references
    Dim items As New ArrayList()

    Sub New(ByVal collection As IEnumerable)
        ' load all the items in the ArrayList, but in reverse order
        Dim o As Object
        For Each o In collection
            items.Insert(0, o)
        Next
    End Sub

    Public Function GetEnumerator() As System.Collections.IEnumerator _
        Implements System.Collections.IEnumerable.GetEnumerator
        ' return the enumerator of the inner ArrayList
        Return items.GetEnumerator()
    End Function
End Class
