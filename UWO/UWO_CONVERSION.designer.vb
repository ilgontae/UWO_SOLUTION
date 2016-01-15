<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UWO_conversion
	Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Dim DesinationDrive As System.Windows.Forms.Label
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UWO_conversion))
		Me.L_convert = New System.Windows.Forms.Label()
		Me.timeTextBox = New System.Windows.Forms.TextBox()
		Me.EnterTimeLapseLabel = New System.Windows.Forms.Label()
		Me.stopButton = New System.Windows.Forms.Button()
		Me.startButton = New System.Windows.Forms.Button()
		Me.DriveComboBox = New System.Windows.Forms.ComboBox()
		DesinationDrive = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'DesinationDrive
		'
		DesinationDrive.Anchor = System.Windows.Forms.AnchorStyles.Left
		DesinationDrive.AutoSize = True
		DesinationDrive.Location = New System.Drawing.Point(144, 1)
		DesinationDrive.Name = "DesinationDrive"
		DesinationDrive.Size = New System.Drawing.Size(127, 13)
		DesinationDrive.TabIndex = 6
		DesinationDrive.Text = "Choose Destination Drive"
		'
		'L_convert
		'
		Me.L_convert.Dock = System.Windows.Forms.DockStyle.Fill
		Me.L_convert.Location = New System.Drawing.Point(0, 0)
		Me.L_convert.Name = "L_convert"
		Me.L_convert.Size = New System.Drawing.Size(691, 31)
		Me.L_convert.TabIndex = 0
		Me.L_convert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'timeTextBox
		'
		Me.timeTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left
		Me.timeTextBox.Enabled = False
		Me.timeTextBox.Location = New System.Drawing.Point(2, 16)
		Me.timeTextBox.MaxLength = 5
		Me.timeTextBox.Name = "timeTextBox"
		Me.timeTextBox.Size = New System.Drawing.Size(100, 20)
		Me.timeTextBox.TabIndex = 1
		Me.timeTextBox.Text = "1"
		'
		'EnterTimeLapseLabel
		'
		Me.EnterTimeLapseLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
		Me.EnterTimeLapseLabel.AutoSize = True
		Me.EnterTimeLapseLabel.Location = New System.Drawing.Point(-1, 0)
		Me.EnterTimeLapseLabel.Name = "EnterTimeLapseLabel"
		Me.EnterTimeLapseLabel.Size = New System.Drawing.Size(136, 13)
		Me.EnterTimeLapseLabel.TabIndex = 2
		Me.EnterTimeLapseLabel.Text = "Enter time lapse in seconds"
		'
		'stopButton
		'
		Me.stopButton.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.stopButton.AutoSize = True
		Me.stopButton.Location = New System.Drawing.Point(576, 8)
		Me.stopButton.Name = "stopButton"
		Me.stopButton.Size = New System.Drawing.Size(104, 23)
		Me.stopButton.TabIndex = 3
		Me.stopButton.Text = "Stop Conversion"
		Me.stopButton.UseVisualStyleBackColor = True
		'
		'startButton
		'
		Me.startButton.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.startButton.Location = New System.Drawing.Point(495, 8)
		Me.startButton.Name = "startButton"
		Me.startButton.Size = New System.Drawing.Size(75, 23)
		Me.startButton.TabIndex = 4
		Me.startButton.Text = "Start"
		Me.startButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		Me.startButton.UseVisualStyleBackColor = True
		'
		'DriveComboBox
		'
		Me.DriveComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left
		Me.DriveComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.DriveComboBox.FormattingEnabled = True
		Me.DriveComboBox.Items.AddRange(New Object() {"Z:\Graphics", "Y:\UWO\Graphics", "H:\Graphics", "Desktop"})
		Me.DriveComboBox.Location = New System.Drawing.Point(147, 16)
		Me.DriveComboBox.Name = "DriveComboBox"
		Me.DriveComboBox.Size = New System.Drawing.Size(121, 21)
		Me.DriveComboBox.TabIndex = 5
		'
		'UWO_conversion
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
		Me.ClientSize = New System.Drawing.Size(691, 31)
		Me.Controls.Add(DesinationDrive)
		Me.Controls.Add(Me.DriveComboBox)
		Me.Controls.Add(Me.startButton)
		Me.Controls.Add(Me.stopButton)
		Me.Controls.Add(Me.EnterTimeLapseLabel)
		Me.Controls.Add(Me.timeTextBox)
		Me.Controls.Add(Me.L_convert)
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MaximumSize = New System.Drawing.Size(10000, 65)
		Me.MinimizeBox = False
		Me.MinimumSize = New System.Drawing.Size(20, 65)
		Me.Name = "UWO_conversion"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Graphic Conversion"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents L_convert As System.Windows.Forms.Label
	Friend WithEvents timeTextBox As System.Windows.Forms.TextBox
	Friend WithEvents EnterTimeLapseLabel As System.Windows.Forms.Label
	Friend WithEvents stopButton As System.Windows.Forms.Button
	Friend WithEvents startButton As System.Windows.Forms.Button
	Friend WithEvents DriveComboBox As System.Windows.Forms.ComboBox
End Class
