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
		Me.MenuStrip1.BackColor = System.Drawing.Color.Purple
		Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuAddPrefix, Me.MenuCompare, Me.UPPERCASEToolStripMenuItem, Me.CONVERTToolStripMenuItem, Me.CHECKLINKSToolStripMenuItem, Me.REPLACELINKSToolStripMenuItem, Me.LINKEDINToolStripMenuItem, Me.NOTLINKEDToolStripMenuItem})
		Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.MenuStrip1.Name = "MenuStrip1"
		Me.MenuStrip1.Size = New System.Drawing.Size(825, 24)
		Me.MenuStrip1.TabIndex = 0
		Me.MenuStrip1.Text = "MainMenu"
		'
		'MenuAddPrefix
		'
		Me.MenuAddPrefix.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
		Me.MenuAddPrefix.ForeColor = System.Drawing.Color.White
		Me.MenuAddPrefix.Name = "MenuAddPrefix"
		Me.MenuAddPrefix.Size = New System.Drawing.Size(87, 20)
		Me.MenuAddPrefix.Text = "ADD PREFIX"
		'
		'MenuCompare
		'
		Me.MenuCompare.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
		Me.MenuCompare.ForeColor = System.Drawing.Color.White
		Me.MenuCompare.Name = "MenuCompare"
		Me.MenuCompare.Size = New System.Drawing.Size(75, 20)
		Me.MenuCompare.Text = "COMPARE"
		'
		'UPPERCASEToolStripMenuItem
		'
		Me.UPPERCASEToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
		Me.UPPERCASEToolStripMenuItem.ForeColor = System.Drawing.Color.White
		Me.UPPERCASEToolStripMenuItem.Name = "UPPERCASEToolStripMenuItem"
		Me.UPPERCASEToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
		Me.UPPERCASEToolStripMenuItem.Text = "UPPERCASE"
		'
		'CONVERTToolStripMenuItem
		'
		Me.CONVERTToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
		Me.CONVERTToolStripMenuItem.ForeColor = System.Drawing.Color.White
		Me.CONVERTToolStripMenuItem.Name = "CONVERTToolStripMenuItem"
		Me.CONVERTToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
		Me.CONVERTToolStripMenuItem.Text = "CONVERT"
		'
		'CHECKLINKSToolStripMenuItem
		'
		Me.CHECKLINKSToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
		Me.CHECKLINKSToolStripMenuItem.ForeColor = System.Drawing.Color.White
		Me.CHECKLINKSToolStripMenuItem.Name = "CHECKLINKSToolStripMenuItem"
		Me.CHECKLINKSToolStripMenuItem.Size = New System.Drawing.Size(93, 20)
		Me.CHECKLINKSToolStripMenuItem.Text = "CHECK LINKS"
		'
		'REPLACELINKSToolStripMenuItem
		'
		Me.REPLACELINKSToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
		Me.REPLACELINKSToolStripMenuItem.ForeColor = System.Drawing.Color.White
		Me.REPLACELINKSToolStripMenuItem.Name = "REPLACELINKSToolStripMenuItem"
		Me.REPLACELINKSToolStripMenuItem.Size = New System.Drawing.Size(104, 20)
		Me.REPLACELINKSToolStripMenuItem.Text = "REPLACE LINKS"
		'
		'LINKEDINToolStripMenuItem
		'
		Me.LINKEDINToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
		Me.LINKEDINToolStripMenuItem.ForeColor = System.Drawing.Color.White
		Me.LINKEDINToolStripMenuItem.Name = "LINKEDINToolStripMenuItem"
		Me.LINKEDINToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
		Me.LINKEDINToolStripMenuItem.Text = "LINKED IN"
		'
		'NOTLINKEDToolStripMenuItem
		'
		Me.NOTLINKEDToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
		Me.NOTLINKEDToolStripMenuItem.ForeColor = System.Drawing.Color.White
		Me.NOTLINKEDToolStripMenuItem.Name = "NOTLINKEDToolStripMenuItem"
		Me.NOTLINKEDToolStripMenuItem.Size = New System.Drawing.Size(89, 20)
		Me.NOTLINKEDToolStripMenuItem.Text = "NOT LINKED"
		'
		'WebBrowser1
		'
		Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.WebBrowser1.Location = New System.Drawing.Point(0, 24)
		Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
		Me.WebBrowser1.Name = "WebBrowser1"
		Me.WebBrowser1.Size = New System.Drawing.Size(825, 498)
		Me.WebBrowser1.TabIndex = 2
		Me.WebBrowser1.Url = New System.Uri("http://WWW.GOOGLE.COM", System.UriKind.Absolute)
		Me.WebBrowser1.Visible = False
		'
		'UWO_MAIN
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.Silver
		Me.ClientSize = New System.Drawing.Size(825, 522)
		Me.Controls.Add(Me.WebBrowser1)
		Me.Controls.Add(Me.MenuStrip1)
		Me.IsMdiContainer = True
		Me.MainMenuStrip = Me.MenuStrip1
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
