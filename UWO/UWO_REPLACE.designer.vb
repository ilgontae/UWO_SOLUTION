<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UWO_REPLACE
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.TB_Find = New System.Windows.Forms.TextBox()
		Me.TB_Replace = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.TB_Directory = New System.Windows.Forms.TextBox()
		Me.FBD_Directory = New System.Windows.Forms.FolderBrowserDialog()
		Me.B_Find = New System.Windows.Forms.Button()
		Me.ListView1 = New System.Windows.Forms.ListView()
		Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
		Me.Wildcard = New System.Windows.Forms.Button()
		Me.L_Left = New System.Windows.Forms.Label()
		Me.B_Remove = New System.Windows.Forms.Button()
		Me.B_Save = New System.Windows.Forms.Button()
		Me.L_Matches = New System.Windows.Forms.Label()
		Me.TB_Ext = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.B_Replace = New System.Windows.Forms.Button()
		Me.SFD_SaveList = New System.Windows.Forms.SaveFileDialog()
		Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(12, 48)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(30, 13)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Find:"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(12, 87)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(50, 13)
		Me.Label2.TabIndex = 1
		Me.Label2.Text = "Replace:"
		'
		'TB_Find
		'
		Me.TB_Find.Location = New System.Drawing.Point(15, 64)
		Me.TB_Find.Name = "TB_Find"
		Me.TB_Find.Size = New System.Drawing.Size(222, 20)
		Me.TB_Find.TabIndex = 2
		'
		'TB_Replace
		'
		Me.TB_Replace.Location = New System.Drawing.Point(15, 103)
		Me.TB_Replace.Name = "TB_Replace"
		Me.TB_Replace.Size = New System.Drawing.Size(222, 20)
		Me.TB_Replace.TabIndex = 3
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(12, 9)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(52, 13)
		Me.Label3.TabIndex = 4
		Me.Label3.Text = "Directory:"
		'
		'TB_Directory
		'
		Me.TB_Directory.Location = New System.Drawing.Point(15, 25)
		Me.TB_Directory.Name = "TB_Directory"
		Me.TB_Directory.Size = New System.Drawing.Size(427, 20)
		Me.TB_Directory.TabIndex = 5
		'
		'B_Find
		'
		Me.B_Find.Cursor = System.Windows.Forms.Cursors.Hand
		Me.B_Find.Enabled = False
		Me.B_Find.Location = New System.Drawing.Point(243, 64)
		Me.B_Find.Name = "B_Find"
		Me.B_Find.Size = New System.Drawing.Size(75, 20)
		Me.B_Find.TabIndex = 6
		Me.B_Find.Text = "Find"
		Me.B_Find.UseVisualStyleBackColor = True
		'
		'ListView1
		'
		Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
		Me.ListView1.FullRowSelect = True
		Me.ListView1.Location = New System.Drawing.Point(0, 17)
		Me.ListView1.Name = "ListView1"
		Me.ListView1.Size = New System.Drawing.Size(529, 313)
		Me.ListView1.TabIndex = 7
		Me.ListView1.UseCompatibleStateImageBehavior = False
		Me.ListView1.View = System.Windows.Forms.View.Details
		'
		'ColumnHeader1
		'
		Me.ColumnHeader1.Width = 493
		'
		'SplitContainer1
		'
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.IsSplitterFixed = True
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainer1.Name = "SplitContainer1"
		Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.Wildcard)
		Me.SplitContainer1.Panel1.Controls.Add(Me.L_Left)
		Me.SplitContainer1.Panel1.Controls.Add(Me.B_Remove)
		Me.SplitContainer1.Panel1.Controls.Add(Me.B_Save)
		Me.SplitContainer1.Panel1.Controls.Add(Me.L_Matches)
		Me.SplitContainer1.Panel1.Controls.Add(Me.TB_Ext)
		Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
		Me.SplitContainer1.Panel1.Controls.Add(Me.B_Replace)
		Me.SplitContainer1.Panel1.Controls.Add(Me.TB_Find)
		Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
		Me.SplitContainer1.Panel1.Controls.Add(Me.B_Find)
		Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
		Me.SplitContainer1.Panel1.Controls.Add(Me.TB_Directory)
		Me.SplitContainer1.Panel1.Controls.Add(Me.TB_Replace)
		Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.ListView1)
		Me.SplitContainer1.Size = New System.Drawing.Size(524, 477)
		Me.SplitContainer1.SplitterDistance = 142
		Me.SplitContainer1.TabIndex = 8
		'
		'Wildcard
		'
		Me.Wildcard.Cursor = System.Windows.Forms.Cursors.Hand
		Me.Wildcard.Enabled = False
		Me.Wildcard.Location = New System.Drawing.Point(358, 63)
		Me.Wildcard.Name = "Wildcard"
		Me.Wildcard.Size = New System.Drawing.Size(121, 20)
		Me.Wildcard.TabIndex = 16
		Me.Wildcard.Text = "Enable WildCard"
		Me.Wildcard.UseVisualStyleBackColor = True
		'
		'L_Left
		'
		Me.L_Left.AutoSize = True
		Me.L_Left.Location = New System.Drawing.Point(378, 86)
		Me.L_Left.Name = "L_Left"
		Me.L_Left.Size = New System.Drawing.Size(25, 13)
		Me.L_Left.TabIndex = 15
		Me.L_Left.Text = "Left"
		Me.L_Left.Visible = False
		'
		'B_Remove
		'
		Me.B_Remove.Enabled = False
		Me.B_Remove.Location = New System.Drawing.Point(328, 103)
		Me.B_Remove.Name = "B_Remove"
		Me.B_Remove.Size = New System.Drawing.Size(75, 20)
		Me.B_Remove.TabIndex = 14
		Me.B_Remove.Text = "Remove"
		Me.B_Remove.UseVisualStyleBackColor = True
		'
		'B_Save
		'
		Me.B_Save.Cursor = System.Windows.Forms.Cursors.Hand
		Me.B_Save.Enabled = False
		Me.B_Save.Location = New System.Drawing.Point(443, 103)
		Me.B_Save.Name = "B_Save"
		Me.B_Save.Size = New System.Drawing.Size(75, 20)
		Me.B_Save.TabIndex = 13
		Me.B_Save.Text = "Save List"
		Me.B_Save.UseVisualStyleBackColor = True
		'
		'L_Matches
		'
		Me.L_Matches.AutoSize = True
		Me.L_Matches.Location = New System.Drawing.Point(243, 87)
		Me.L_Matches.Name = "L_Matches"
		Me.L_Matches.Size = New System.Drawing.Size(27, 13)
		Me.L_Matches.TabIndex = 12
		Me.L_Matches.Text = "total"
		Me.L_Matches.Visible = False
		'
		'TB_Ext
		'
		Me.TB_Ext.Location = New System.Drawing.Point(449, 24)
		Me.TB_Ext.Name = "TB_Ext"
		Me.TB_Ext.Size = New System.Drawing.Size(69, 20)
		Me.TB_Ext.TabIndex = 11
		Me.TB_Ext.Text = "gpc"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(446, 8)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(56, 13)
		Me.Label4.TabIndex = 10
		Me.Label4.Text = "Extension:"
		'
		'B_Replace
		'
		Me.B_Replace.Cursor = System.Windows.Forms.Cursors.Hand
		Me.B_Replace.Enabled = False
		Me.B_Replace.Location = New System.Drawing.Point(243, 103)
		Me.B_Replace.Name = "B_Replace"
		Me.B_Replace.Size = New System.Drawing.Size(75, 20)
		Me.B_Replace.TabIndex = 9
		Me.B_Replace.Text = "Replace"
		Me.B_Replace.UseVisualStyleBackColor = True
		'
		'SFD_SaveList
		'
		'
		'UWO_REPLACE
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(524, 477)
		Me.Controls.Add(Me.SplitContainer1)
		Me.MaximumSize = New System.Drawing.Size(540, 100001)
		Me.MinimumSize = New System.Drawing.Size(540, 500)
		Me.Name = "UWO_REPLACE"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "DataLink Replacer"
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel1.PerformLayout()
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_Find As System.Windows.Forms.TextBox
    Friend WithEvents TB_Replace As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TB_Directory As System.Windows.Forms.TextBox
    Friend WithEvents FBD_Directory As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents B_Find As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents B_Replace As System.Windows.Forms.Button
    Friend WithEvents TB_Ext As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents L_Matches As System.Windows.Forms.Label
    Friend WithEvents B_Save As System.Windows.Forms.Button
    Friend WithEvents SFD_SaveList As System.Windows.Forms.SaveFileDialog
    Friend WithEvents B_Remove As System.Windows.Forms.Button
    Friend WithEvents L_Left As System.Windows.Forms.Label
    Public WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Wildcard As System.Windows.Forms.Button
	Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
