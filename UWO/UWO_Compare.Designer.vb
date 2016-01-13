<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UWO_Compare
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
        Me.components = New System.ComponentModel.Container
        Me.Panels = New System.Windows.Forms.SplitContainer
        Me.LeftBar = New System.Windows.Forms.VScrollBar
        Me.LeftList = New System.Windows.Forms.ListView
        Me.LName = New System.Windows.Forms.ColumnHeader
        Me.LSize = New System.Windows.Forms.ColumnHeader
        Me.LDate = New System.Windows.Forms.ColumnHeader
        Me.LStatus = New System.Windows.Forms.ColumnHeader
        Me.RightBar = New System.Windows.Forms.VScrollBar
        Me.RightList = New System.Windows.Forms.ListView
        Me.RName = New System.Windows.Forms.ColumnHeader
        Me.RSize = New System.Windows.Forms.ColumnHeader
        Me.RDate = New System.Windows.Forms.ColumnHeader
        Me.RStatus = New System.Windows.Forms.ColumnHeader
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panels.Panel1.SuspendLayout()
        Me.Panels.Panel2.SuspendLayout()
        Me.Panels.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panels
        '
        Me.Panels.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panels.Location = New System.Drawing.Point(0, 0)
        Me.Panels.Name = "Panels"
        '
        'Panels.Panel1
        '
        Me.Panels.Panel1.Controls.Add(Me.LeftBar)
        Me.Panels.Panel1.Controls.Add(Me.LeftList)
        Me.Panels.Panel1MinSize = 0
        '
        'Panels.Panel2
        '
        Me.Panels.Panel2.Controls.Add(Me.RightBar)
        Me.Panels.Panel2.Controls.Add(Me.RightList)
        Me.Panels.Panel2MinSize = 0
        Me.Panels.Size = New System.Drawing.Size(634, 393)
        Me.Panels.SplitterDistance = 301
        Me.Panels.TabIndex = 0
        '
        'LeftBar
        '
        Me.LeftBar.Dock = System.Windows.Forms.DockStyle.Right
        Me.LeftBar.Location = New System.Drawing.Point(278, 0)
        Me.LeftBar.Name = "LeftBar"
        Me.LeftBar.Size = New System.Drawing.Size(23, 393)
        Me.LeftBar.TabIndex = 1
        '
        'LeftList
        '
        Me.LeftList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.LName, Me.LSize, Me.LDate, Me.LStatus})
        Me.LeftList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LeftList.FullRowSelect = True
        Me.LeftList.Location = New System.Drawing.Point(0, 0)
        Me.LeftList.Name = "LeftList"
        Me.LeftList.Size = New System.Drawing.Size(301, 393)
        Me.LeftList.TabIndex = 0
        Me.LeftList.UseCompatibleStateImageBehavior = False
        Me.LeftList.View = System.Windows.Forms.View.Details
        '
        'LName
        '
        Me.LName.Text = "Name"
        '
        'LSize
        '
        Me.LSize.Text = "Size"
        '
        'LDate
        '
        Me.LDate.Text = "Date"
        '
        'LStatus
        '
        Me.LStatus.Text = "Status"
        '
        'RightBar
        '
        Me.RightBar.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightBar.Location = New System.Drawing.Point(306, 0)
        Me.RightBar.Name = "RightBar"
        Me.RightBar.Size = New System.Drawing.Size(23, 393)
        Me.RightBar.TabIndex = 2
        '
        'RightList
        '
        Me.RightList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.RName, Me.RSize, Me.RDate, Me.RStatus})
        Me.RightList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RightList.FullRowSelect = True
        Me.RightList.Location = New System.Drawing.Point(0, 0)
        Me.RightList.Name = "RightList"
        Me.RightList.Size = New System.Drawing.Size(329, 393)
        Me.RightList.TabIndex = 1
        Me.RightList.UseCompatibleStateImageBehavior = False
        Me.RightList.View = System.Windows.Forms.View.Details
        '
        'RName
        '
        Me.RName.Text = "Name"
        '
        'RSize
        '
        Me.RSize.Text = "Size"
        '
        'RDate
        '
        Me.RDate.Text = "Date"
        '
        'RStatus
        '
        Me.RStatus.Text = "Status"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 300000
        '
        'UWO_Compare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(634, 393)
        Me.Controls.Add(Me.Panels)
        Me.Name = "UWO_Compare"
        Me.ShowIcon = False
        Me.Text = "UWO_Compare"
        Me.Panels.Panel1.ResumeLayout(False)
        Me.Panels.Panel2.ResumeLayout(False)
        Me.Panels.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panels As System.Windows.Forms.SplitContainer
    Friend WithEvents LeftList As System.Windows.Forms.ListView
    Friend WithEvents LName As System.Windows.Forms.ColumnHeader
    Friend WithEvents LSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents LDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents LStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents RightList As System.Windows.Forms.ListView
    Friend WithEvents RName As System.Windows.Forms.ColumnHeader
    Friend WithEvents RSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents RDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents RStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents LeftBar As System.Windows.Forms.VScrollBar
    Friend WithEvents RightBar As System.Windows.Forms.VScrollBar
End Class
