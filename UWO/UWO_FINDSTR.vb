'Revision By: Luke Westelaken
'Date: January 13, 2016
'Revisions made: added github source control at https://github.com/ilgontae/UWO_SOLUTION
' all revisions will be made and recorded there

Imports System.Text.RegularExpressions
Imports System.IO

Public Class UWO_FINDSTR
	Dim count As Integer

	Private Sub TB_Dir_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TB_Dir.DoubleClick
		Browser.ShowDialog()
		TB_Dir.Text = Browser.SelectedPath
	End Sub

	Private Sub B_Ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles B_Ok.Click
		LV_Files.Items.Clear()
		B_Ok.Enabled = False
		listFiles(TB_Dir.Text)
		B_Ok.Enabled = True
	End Sub

	Private Sub TB_Dir_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TB_Dir.KeyUp
		If e.KeyCode = Keys.Enter Then
			B_Ok_Click(sender, e)
		End If
	End Sub

	Private Sub TB_Dir_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TB_Dir.TextChanged
		If Not TB_Dir.Text = "" Then
			If Directory.Exists(TB_Dir.Text) Then
				B_Ok.Enabled = True
				TB_Dir.ForeColor = Color.Black
			Else
				B_Ok.Enabled = False
				TB_Dir.ForeColor = Color.Red
			End If
		Else
			B_Ok.Enabled = False
		End If
	End Sub

	Private Sub listFiles(ByVal dir As String)
		For Each files As String In My.Computer.FileSystem.GetFiles(dir)
			Dim info As FileInfo = My.Computer.FileSystem.GetFileInfo(files)
			count = 0
			LV_Files.Items.Add(files.ToString)
			LV_Files.Items.Add("==================================================================================")
			getfile(dir, info.Name)
			LV_Files.Items.Add("")
			LV_Files.Items.Add("------> Found in " + count.ToString + " Files <------")
			LV_Files.Items.Add("__________________________________________________________________________________")
		Next
		For Each root As String In My.Computer.FileSystem.GetDirectories(dir)
			listFiles(root)
		Next
		LV_Files.Items.RemoveAt(LV_Files.Items.Count - 1)
	End Sub

	Private Sub FindStr(ByVal fname As String, ByVal regMatch As String)
		Try
			Dim testTxt As New StreamReader(fname)
			Dim allRead As String = testTxt.ReadToEnd()
			testTxt.Close()

			If Regex.IsMatch(allRead, regMatch, RegexOptions.IgnoreCase) Then
				Dim SP As String = fname.Remove(0, TB_Dir.Text.Length + 1)
				LV_Files.Items.Add(SP)
				LV_Files.Update()
				LV_Files.EnsureVisible(LV_Files.Items.Count - 1)
				count += 1
			End If
		Catch
		End Try
	End Sub

	Private Sub getfile(ByVal dir As String, ByVal searchfor As String)
		Dim a As String = My.Computer.FileSystem.GetDirectoryInfo(dir).Name.ToString
		If Not String.Compare(a, "Temp", True) = 0 And
		   Not String.Compare(a, "bmp", True) = 0 And
		   Not String.Compare(a, "archive", True) = 0 And
		   Not String.Compare(a, "help files", True) = 0 Then
			For Each files As String In My.Computer.FileSystem.GetFiles(dir)
				FindStr(files, searchfor)
			Next
			For Each root As String In My.Computer.FileSystem.GetDirectories(dir)
				getfile(root, searchfor)
			Next
		End If
	End Sub

	Private Sub Main_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
		TB_Dir.Text = "W:\PUBLIC\Delta\Graphics"
	End Sub
End Class