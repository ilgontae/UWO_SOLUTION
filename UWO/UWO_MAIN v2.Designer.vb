<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UWO_MAIN
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuAddPrefix = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuCompare = New System.Windows.Forms.ToolStripMenuItem()
        Me.UPPERCASEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CONVERTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CHECKLINKSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.REPLACELINKSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LINKEDINToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NOTLINKEDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuAddPrefix, Me.MenuCompare, Me.UPPERCASEToolStripMenuItem, Me.CONVERTToolStripMenuItem, Me.CHECKLINKSToolStripMenuItem, Me.REPLACELINKSToolStripMenuItem, Me.LINKEDINToolStripMenuItem, Me.NOTLINKEDToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1100, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MainMenu"
        '
        'MenuAddPrefix
        '
        Me.MenuAddPrefix.ForeColor = System.Drawing.Color.Red
        Me.MenuAddPrefix.Name = "MenuAddPrefix"
        Me.MenuAddPrefix.Size = New System.Drawing.Size(102, 24)
        Me.MenuAddPrefix.Text = "ADD PREFIX"
        '
        'MenuCompare
        '
        Me.MenuCompare.ForeColor = System.Drawing.Color.Red
        Me.MenuCompare.Name = "MenuCompare"
        Me.MenuCompare.Size = New System.Drawing.Size(89, 24)
        Me.MenuCompare.Text = "COMPARE"
        '
        'UPPERCASEToolStripMenuItem
        '
        Me.UPPERCASEToolStripMenuItem.ForeColor = System.Drawing.Color.Red
        Me.UPPERCASEToolStripMenuItem.Name = "UPPERCASEToolStripMenuItem"
        Me.UPPERCASEToolStripMenuItem.Size = New System.Drawing.Size(99, 24)
        Me.UPPERCASEToolStripMenuItem.Text = "UPPERCASE"
        '
        'CONVERTToolStripMenuItem
        '
        Me.CONVERTToolStripMenuItem.ForeColor = System.Drawing.Color.Red
        Me.CONVERTToolStripMenuItem.Name = "CONVERTToolStripMenuItem"
        Me.CONVERTToolStripMenuItem.Size = New System.Drawing.Size(86, 24)
        Me.CONVERTToolStripMenuItem.Text = "CONVERT"
        '
        'CHECKLINKSToolStripMenuItem
        '
        Me.CHECKLINKSToolStripMenuItem.ForeColor = System.Drawing.Color.Red
        Me.CHECKLINKSToolStripMenuItem.Name = "CHECKLINKSToolStripMenuItem"
        Me.CHECKLINKSToolStripMenuItem.Size = New System.Drawing.Size(110, 24)
        Me.CHECKLINKSToolStripMenuItem.Text = "CHECK LINKS"
        '
        'REPLACELINKSToolStripMenuItem
        '
        Me.REPLACELINKSToolStripMenuItem.ForeColor = System.Drawing.Color.Red
        Me.REPLACELINKSToolStripMenuItem.Name = "REPLACELINKSToolStripMenuItem"
        Me.REPLACELINKSToolStripMenuItem.Size = New System.Drawing.Size(123, 24)
        Me.REPLACELINKSToolStripMenuItem.Text = "REPLACE LINKS"
        '
        'LINKEDINToolStripMenuItem
        '
        Me.LINKEDINToolStripMenuItem.ForeColor = System.Drawing.Color.Red
        Me.LINKEDINToolStripMenuItem.Name = "LINKEDINToolStripMenuItem"
        Me.LINKEDINToolStripMenuItem.Size = New System.Drawing.Size(90, 24)
        Me.LINKEDINToolStripMenuItem.Text = "LINKED IN"
        '
        'NOTLINKEDToolStripMenuItem
        '
        Me.NOTLINKEDToolStripMenuItem.ForeColor = System.Drawing.Color.Red
        Me.NOTLINKEDToolStripMenuItem.Name = "NOTLINKEDToolStripMenuItem"
        Me.NOTLINKEDToolStripMenuItem.Size = New System.Drawing.Size(105, 24)
        Me.NOTLINKEDToolStripMenuItem.Text = "NOT LINKED"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 28)
        Me.WebBrowser1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(27, 25)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(1100, 614)
        Me.WebBrowser1.TabIndex = 2
        Me.WebBrowser1.Url = New System.Uri("http://WWW.GOOGLE.COM", System.UriKind.Absolute)
        Me.WebBrowser1.Visible = False
        '
        'UWO_MAIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1100, 642)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "UWO_MAIN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WES CONTROL"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuCompare As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAddPrefix As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UPPERCASEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CONVERTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CHECKLINKSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents REPLACELINKSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LINKEDINToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents NOTLINKEDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
