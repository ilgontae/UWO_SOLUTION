<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UWO_BROKEN_LINK
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
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
		Me.TB_Directory = New System.Windows.Forms.TextBox()
		Me.B_Search = New System.Windows.Forms.Button()
		Me.LV_BrokenList = New System.Windows.Forms.ListView()
		Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.FBD_Directory = New System.Windows.Forms.FolderBrowserDialog()
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(12, 9)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(52, 13)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Directory:"
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
		Me.SplitContainer1.Panel1.Controls.Add(Me.TB_Directory)
		Me.SplitContainer1.Panel1.Controls.Add(Me.B_Search)
		Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.LV_BrokenList)
		Me.SplitContainer1.Size = New System.Drawing.Size(518, 434)
		Me.SplitContainer1.SplitterDistance = 60
		Me.SplitContainer1.TabIndex = 2
		'
		'TB_Directory
		'
		Me.TB_Directory.Location = New System.Drawing.Point(15, 25)
		Me.TB_Directory.Name = "TB_Directory"
		Me.TB_Directory.Size = New System.Drawing.Size(426, 20)
		Me.TB_Directory.TabIndex = 4
		'
		'B_Search
		'
		Me.B_Search.Location = New System.Drawing.Point(447, 23)
		Me.B_Search.Name = "B_Search"
		Me.B_Search.Size = New System.Drawing.Size(59, 23)
		Me.B_Search.TabIndex = 3
		Me.B_Search.Text = "Search"
		Me.B_Search.UseVisualStyleBackColor = True
		'
		'LV_BrokenList
		'
		Me.LV_BrokenList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
		Me.LV_BrokenList.Dock = System.Windows.Forms.DockStyle.Fill
		Me.LV_BrokenList.Location = New System.Drawing.Point(0, 0)
		Me.LV_BrokenList.Name = "LV_BrokenList"
		Me.LV_BrokenList.Size = New System.Drawing.Size(518, 370)
		Me.LV_BrokenList.TabIndex = 0
		Me.LV_BrokenList.UseCompatibleStateImageBehavior = False
		Me.LV_BrokenList.View = System.Windows.Forms.View.Details
		'
		'ColumnHeader1
		'
		Me.ColumnHeader1.Text = "Details"
		Me.ColumnHeader1.Width = 489
		'
		'UWO_BROKEN_LINK
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(518, 434)
		Me.Controls.Add(Me.SplitContainer1)
		Me.Name = "UWO_BROKEN_LINK"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Checks Graphic Links"
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel1.PerformLayout()
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents B_Search As System.Windows.Forms.Button
    Friend WithEvents TB_Directory As System.Windows.Forms.TextBox
    Friend WithEvents FBD_Directory As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents LV_BrokenList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader

End Class
