'Revision By: Alayna Duval
'Date: April 8 2014
'Revisions made: Added two default values in IF statment + Else statement added to CONVERTToolStripMenuItem_Click
'Called PerformClick() located in UWO_conversion 

'Revision By: Luke Westelaken
'Date: January 13, 2016
'Revisions made: added github source control at https://github.com/ilgontae/UWO_SOLUTION
'				 all revisions will be made and recorded there

Public Class UWO_MAIN

	Private Sub MenuCompare_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MenuCompare.Click
		If UWO_DirSelect.Visible = True Then
			UWO_DirSelect.BringToFront()
		Else
			UWO_DirSelect.MdiParent = Me
			UWO_DirSelect.Show()
		End If
	End Sub

	Private Sub MenuAddPrefix_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MenuAddPrefix.Click
		If UWO_Rename.Visible = True Then
			UWO_Rename.BringToFront()
		Else
			UWO_Rename.MdiParent = Me
			UWO_Rename.Show()
		End If
	End Sub

	Private Sub UPPERCASEToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles UPPERCASEToolStripMenuItem.Click
		If UWO_UPCASE.Visible = True Then
			UWO_UPCASE.BringToFront()
		Else
			UWO_UPCASE.MdiParent = Me
			UWO_UPCASE.Show()
		End If
	End Sub

	Private Sub CONVERTToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CONVERTToolStripMenuItem.Click
		If UWO_conversion.Visible = True Then
			UWO_conversion.BringToFront()
		Else
			Dim answer As DialogResult
			answer = MessageBox.Show("Would you like to convert" + vbCrLf + "your graphic to web pages?" + vbCrLf + "Click No for more options", "conversion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
			If answer = DialogResult.Yes Then
				UWO_conversion.MdiParent = Me
				UWO_conversion.Show()
				UWO_conversion.timeTextBox.Text = 1
				UWO_conversion.startButton.PerformClick()
			Else
				UWO_conversion.Show()
				UWO_conversion.MdiParent = Me
			End If
		End If
	End Sub

	Private Sub CHECKLINKSToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CHECKLINKSToolStripMenuItem.Click
		If UWO_BROKEN_LINK.Visible = True Then
			UWO_BROKEN_LINK.BringToFront()
		Else
			UWO_BROKEN_LINK.MdiParent = Me
			UWO_BROKEN_LINK.Show()
		End If
	End Sub

	Private Sub REPLACELINKSToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles REPLACELINKSToolStripMenuItem.Click
		If UWO_REPLACE.Visible = True Then
			UWO_REPLACE.BringToFront()
		Else
			UWO_REPLACE.MdiParent = Me
			UWO_REPLACE.Show()
		End If
	End Sub

	Private Sub LINKEDINToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LINKEDINToolStripMenuItem.Click
		If UWO_FINDSTR.Visible = True Then
			UWO_FINDSTR.BringToFront()
		Else
			UWO_FINDSTR.MdiParent = Me
			UWO_FINDSTR.Show()
		End If
	End Sub

	Private Sub UWO_MAIN_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
		If UWO_conversion.Visible = True Then
			UWO_conversion.Width = Me.Width - 13
			UWO_conversion.L_convert.Width = UWO_conversion.Width
			Dim p As Point
			p.X = 0
			p.Y = 0
			UWO_conversion.Location = p
		End If
	End Sub

	Private Sub NOTLINKEDToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles NOTLINKEDToolStripMenuItem.Click
		If UWO_No_links.Visible = True Then
			UWO_No_links.BringToFront()
		Else
			UWO_No_links.MdiParent = Me
			UWO_No_links.Show()
		End If
	End Sub

	Private Sub UWO_MAIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load

	End Sub
End Class
