<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UWO_FINDSTR
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
		Me.TB_Dir = New System.Windows.Forms.TextBox()
		Me.LV_Files = New System.Windows.Forms.ListView()
		Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
		Me.B_Ok = New System.Windows.Forms.Button()
		Me.Browser = New System.Windows.Forms.FolderBrowserDialog()
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(8, 15)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(52, 13)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Directory:"
		'
		'TB_Dir
		'
		Me.TB_Dir.Location = New System.Drawing.Point(66, 12)
		Me.TB_Dir.Name = "TB_Dir"
		Me.TB_Dir.Size = New System.Drawing.Size(427, 20)
		Me.TB_Dir.TabIndex = 1
		'
		'LV_Files
		'
		Me.LV_Files.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
		Me.LV_Files.Dock = System.Windows.Forms.DockStyle.Fill
		Me.LV_Files.Location = New System.Drawing.Point(0, 0)
		Me.LV_Files.Name = "LV_Files"
		Me.LV_Files.Size = New System.Drawing.Size(534, 320)
		Me.LV_Files.TabIndex = 2
		Me.LV_Files.UseCompatibleStateImageBehavior = False
		Me.LV_Files.View = System.Windows.Forms.View.Details
		'
		'ColumnHeader1
		'
		Me.ColumnHeader1.Text = "Files"
		Me.ColumnHeader1.Width = 510
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
		Me.SplitContainer1.Panel1.Controls.Add(Me.B_Ok)
		Me.SplitContainer1.Panel1.Controls.Add(Me.TB_Dir)
		Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.LV_Files)
		Me.SplitContainer1.Size = New System.Drawing.Size(534, 366)
		Me.SplitContainer1.SplitterDistance = 42
		Me.SplitContainer1.TabIndex = 3
		'
		'B_Ok
		'
		Me.B_Ok.Enabled = False
		Me.B_Ok.Location = New System.Drawing.Point(497, 10)
		Me.B_Ok.Name = "B_Ok"
		Me.B_Ok.Size = New System.Drawing.Size(37, 23)
		Me.B_Ok.TabIndex = 2
		Me.B_Ok.Text = "OK"
		Me.B_Ok.UseVisualStyleBackColor = True
		'
		'UWO_FINDSTR
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(534, 366)
		Me.Controls.Add(Me.SplitContainer1)
		Me.MaximumSize = New System.Drawing.Size(550, 20000)
		Me.MinimumSize = New System.Drawing.Size(550, 400)
		Me.Name = "UWO_FINDSTR"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Find String"
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel1.PerformLayout()
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		Me.SplitContainer1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TB_Dir As System.Windows.Forms.TextBox
    Friend WithEvents LV_Files As System.Windows.Forms.ListView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Browser As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents B_Ok As System.Windows.Forms.Button
End Class
