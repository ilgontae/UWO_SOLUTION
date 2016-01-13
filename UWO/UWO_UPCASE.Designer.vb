<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UWO_UPCASE
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
        Me.TB_Directory = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.B_OK = New System.Windows.Forms.Button
        Me.FBD_DIR = New System.Windows.Forms.FolderBrowserDialog
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.SuspendLayout()
        '
        'TB_Directory
        '
        Me.TB_Directory.Location = New System.Drawing.Point(15, 25)
        Me.TB_Directory.Name = "TB_Directory"
        Me.TB_Directory.Size = New System.Drawing.Size(389, 20)
        Me.TB_Directory.TabIndex = 0
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
        'B_OK
        '
        Me.B_OK.Location = New System.Drawing.Point(410, 25)
        Me.B_OK.Name = "B_OK"
        Me.B_OK.Size = New System.Drawing.Size(36, 20)
        Me.B_OK.TabIndex = 2
        Me.B_OK.Text = "OK"
        Me.B_OK.UseVisualStyleBackColor = True
        '
        'UWO_UPCASE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 70)
        Me.Controls.Add(Me.B_OK)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TB_Directory)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "UWO_UPCASE"
        Me.Text = "Names To UpperCase"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TB_Directory As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents B_OK As System.Windows.Forms.Button
    Friend WithEvents FBD_DIR As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
