<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UWO_Rename
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
        Me.TB_Prefix = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TB_Directory = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TB_Extension = New System.Windows.Forms.TextBox
        Me.FileList = New System.Windows.Forms.ListView
        Me.FName = New System.Windows.Forms.ColumnHeader
        Me.FSize = New System.Windows.Forms.ColumnHeader
        Me.FDate = New System.Windows.Forms.ColumnHeader
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.CB_UnderScore = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CB_UpperCase = New System.Windows.Forms.CheckBox
        Me.B_Rename = New System.Windows.Forms.Button
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.Label5 = New System.Windows.Forms.Label
        Me.B_Browse = New System.Windows.Forms.Button
        Me.FBD_Dir = New System.Windows.Forms.FolderBrowserDialog
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TB_Prefix
        '
        Me.TB_Prefix.Location = New System.Drawing.Point(23, 31)
        Me.TB_Prefix.Name = "TB_Prefix"
        Me.TB_Prefix.Size = New System.Drawing.Size(47, 20)
        Me.TB_Prefix.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Prefix:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Directory:"
        '
        'TB_Directory
        '
        Me.TB_Directory.Location = New System.Drawing.Point(23, 68)
        Me.TB_Directory.Name = "TB_Directory"
        Me.TB_Directory.Size = New System.Drawing.Size(327, 20)
        Me.TB_Directory.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(108, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Extension:"
        '
        'TB_Extension
        '
        Me.TB_Extension.Location = New System.Drawing.Point(111, 31)
        Me.TB_Extension.Name = "TB_Extension"
        Me.TB_Extension.Size = New System.Drawing.Size(53, 20)
        Me.TB_Extension.TabIndex = 1
        '
        'FileList
        '
        Me.FileList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.FName, Me.FSize, Me.FDate})
        Me.FileList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FileList.Location = New System.Drawing.Point(0, 0)
        Me.FileList.Name = "FileList"
        Me.FileList.Size = New System.Drawing.Size(400, 200)
        Me.FileList.TabIndex = 0
        Me.FileList.UseCompatibleStateImageBehavior = False
        Me.FileList.View = System.Windows.Forms.View.Details
        '
        'FName
        '
        Me.FName.Text = "Name"
        Me.FName.Width = 180
        '
        'FSize
        '
        Me.FSize.Text = "Size"
        Me.FSize.Width = 99
        '
        'FDate
        '
        Me.FDate.Text = "Date"
        Me.FDate.Width = 99
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.B_Browse)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CB_UnderScore)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CB_UpperCase)
        Me.SplitContainer1.Panel1.Controls.Add(Me.B_Rename)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_Extension)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_Prefix)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_Directory)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(400, 366)
        Me.SplitContainer1.SplitterDistance = 145
        Me.SplitContainer1.TabIndex = 0
        '
        'CB_UnderScore
        '
        Me.CB_UnderScore.AutoSize = True
        Me.CB_UnderScore.Checked = True
        Me.CB_UnderScore.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CB_UnderScore.Location = New System.Drawing.Point(23, 117)
        Me.CB_UnderScore.Name = "CB_UnderScore"
        Me.CB_UnderScore.Size = New System.Drawing.Size(149, 17)
        Me.CB_UnderScore.TabIndex = 4
        Me.CB_UnderScore.Text = "Make spaces under score"
        Me.CB_UnderScore.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(190, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(198, 50)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Will only display files with inputed extension and that does not have the inputed" & _
            " prefix."
        '
        'CB_UpperCase
        '
        Me.CB_UpperCase.AutoSize = True
        Me.CB_UpperCase.Checked = True
        Me.CB_UpperCase.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CB_UpperCase.Location = New System.Drawing.Point(23, 94)
        Me.CB_UpperCase.Name = "CB_UpperCase"
        Me.CB_UpperCase.Size = New System.Drawing.Size(109, 17)
        Me.CB_UpperCase.TabIndex = 3
        Me.CB_UpperCase.Text = "Make UpperCase"
        Me.CB_UpperCase.UseVisualStyleBackColor = True
        '
        'B_Rename
        '
        Me.B_Rename.Enabled = False
        Me.B_Rename.Location = New System.Drawing.Point(245, 111)
        Me.B_Rename.Name = "B_Rename"
        Me.B_Rename.Size = New System.Drawing.Size(135, 23)
        Me.B_Rename.TabIndex = 5
        Me.B_Rename.Text = "Rename Files"
        Me.B_Rename.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.FileList)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel2MinSize = 10
        Me.SplitContainer2.Size = New System.Drawing.Size(400, 217)
        Me.SplitContainer2.SplitterDistance = 200
        Me.SplitContainer2.SplitterWidth = 1
        Me.SplitContainer2.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(108, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(171, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Double click to rename a single file"
        '
        'B_Browse
        '
        Me.B_Browse.Location = New System.Drawing.Point(354, 68)
        Me.B_Browse.Margin = New System.Windows.Forms.Padding(1)
        Me.B_Browse.Name = "B_Browse"
        Me.B_Browse.Size = New System.Drawing.Size(26, 20)
        Me.B_Browse.TabIndex = 6
        Me.B_Browse.Text = "..."
        Me.B_Browse.UseVisualStyleBackColor = True
        '
        'UWO_Rename
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 366)
        Me.Controls.Add(Me.SplitContainer1)
        Me.MaximumSize = New System.Drawing.Size(408, 100000)
        Me.MinimumSize = New System.Drawing.Size(408, 400)
        Me.Name = "UWO_Rename"
        Me.Text = "Prefix"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TB_Prefix As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_Directory As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TB_Extension As System.Windows.Forms.TextBox
    Friend WithEvents FileList As System.Windows.Forms.ListView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents FName As System.Windows.Forms.ColumnHeader
    Friend WithEvents FDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents FSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents B_Rename As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CB_UnderScore As System.Windows.Forms.CheckBox
    Friend WithEvents CB_UpperCase As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents B_Browse As System.Windows.Forms.Button
    Friend WithEvents FBD_Dir As System.Windows.Forms.FolderBrowserDialog
End Class
