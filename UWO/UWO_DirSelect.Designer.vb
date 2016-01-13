<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UWO_DirSelect
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
        Me.TB_Dir1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.B_Dir1 = New System.Windows.Forms.Button
        Me.B_Dir2 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.TB_Dir2 = New System.Windows.Forms.TextBox
        Me.B_Compare = New System.Windows.Forms.Button
        Me.B_Cancel = New System.Windows.Forms.Button
        Me.FED_Dir1 = New System.Windows.Forms.FolderBrowserDialog
        Me.FED_Dir2 = New System.Windows.Forms.FolderBrowserDialog
        Me.SuspendLayout()
        '
        'TB_Dir1
        '
        Me.TB_Dir1.Location = New System.Drawing.Point(79, 17)
        Me.TB_Dir1.Name = "TB_Dir1"
        Me.TB_Dir1.Size = New System.Drawing.Size(333, 20)
        Me.TB_Dir1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Directory 1:"
        '
        'B_Dir1
        '
        Me.B_Dir1.Location = New System.Drawing.Point(438, 15)
        Me.B_Dir1.Name = "B_Dir1"
        Me.B_Dir1.Size = New System.Drawing.Size(75, 23)
        Me.B_Dir1.TabIndex = 1
        Me.B_Dir1.Text = "Browse"
        Me.B_Dir1.UseVisualStyleBackColor = True
        '
        'B_Dir2
        '
        Me.B_Dir2.Location = New System.Drawing.Point(438, 52)
        Me.B_Dir2.Name = "B_Dir2"
        Me.B_Dir2.Size = New System.Drawing.Size(75, 23)
        Me.B_Dir2.TabIndex = 3
        Me.B_Dir2.Text = "Browse"
        Me.B_Dir2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Directory 2:"
        '
        'TB_Dir2
        '
        Me.TB_Dir2.Location = New System.Drawing.Point(79, 54)
        Me.TB_Dir2.Name = "TB_Dir2"
        Me.TB_Dir2.Size = New System.Drawing.Size(333, 20)
        Me.TB_Dir2.TabIndex = 2
        '
        'B_Compare
        '
        Me.B_Compare.Enabled = False
        Me.B_Compare.Location = New System.Drawing.Point(132, 89)
        Me.B_Compare.Name = "B_Compare"
        Me.B_Compare.Size = New System.Drawing.Size(75, 23)
        Me.B_Compare.TabIndex = 4
        Me.B_Compare.Text = "Compare"
        Me.B_Compare.UseVisualStyleBackColor = True
        '
        'B_Cancel
        '
        Me.B_Cancel.Location = New System.Drawing.Point(321, 88)
        Me.B_Cancel.Name = "B_Cancel"
        Me.B_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.B_Cancel.TabIndex = 5
        Me.B_Cancel.Text = "Cancel"
        Me.B_Cancel.UseVisualStyleBackColor = True
        '
        'UWO_DirSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 126)
        Me.Controls.Add(Me.B_Cancel)
        Me.Controls.Add(Me.B_Compare)
        Me.Controls.Add(Me.B_Dir2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TB_Dir2)
        Me.Controls.Add(Me.B_Dir1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TB_Dir1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "UWO_DirSelect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Directory Select"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TB_Dir1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents B_Dir1 As System.Windows.Forms.Button
    Friend WithEvents B_Dir2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_Dir2 As System.Windows.Forms.TextBox
    Friend WithEvents B_Compare As System.Windows.Forms.Button
    Friend WithEvents B_Cancel As System.Windows.Forms.Button
    Friend WithEvents FED_Dir1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents FED_Dir2 As System.Windows.Forms.FolderBrowserDialog
End Class
