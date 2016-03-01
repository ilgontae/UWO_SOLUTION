﻿'Revision By: Alayna Duval
'Date: April 8 2014
'Revisions made: 
'Added variable UserTimeLapse, Try & Catch for reading in timeTextBox, Changed source and directory to H drive(as of now
'no access to Z drive), Added cancel button to stop & close program immediately 
'Date: April 9 2014
'Revisions made:
'Added combox-loaded values in design view, Added selected index code

'Revision By: Luke Westelaken
'Date: January 14, 2016
'Revisions made:
'Created github repo at https://github.com/ilgontae/UWO_SOLUTION
'Continuing revision history on there

Imports System.ComponentModel
Imports System.IO
Imports System.Threading

Public Class UWO_conversion
	Private bw As BackgroundWorker = New BackgroundWorker
	Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
		Width = UWO_MAIN.Width - 20
		L_convert.Width = Width
		Dim p As Point
		p.X = 0
		p.Y = 0
		Location = p
		Show()
		DriveComboBox.SelectedIndex = 1
	End Sub

    'Default value is 1 second
    Dim UserTimeLapse As Double = 1.0
	Dim cancel As Boolean = False
	Private Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As Long, ByVal lpString As String, ByVal cch As Long) As Long
	Private Declare Function GetWindowTextLength Lib "user32" Alias "GetWindowTextLengthA" (ByVal hwnd As Long) As Long
	Private Declare Function GetForegroundWindow Lib "user32" () As Long
	Private MyStr As String, theHwnd As Long
	Dim length As Integer
	Dim buf, var As String
	Dim server As Boolean = False
	'AddHandler bw.DoWork, AddressOf bw_DoWork


	Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
		BackgroundWorker1.RunWorkerAsync()
	End Sub

	Private Sub stopButton_Click(sender As Object, e As EventArgs) Handles stopButton.Click
		cancel = True       'Cancel the progression of the conversion macro (NOT the actual conversion itself, that cannot be cancelled)
		MessageBox.Show("Conversion cancelled!", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning)
	End Sub

	Private Sub custKeypress(ByVal key As String, ByVal time As Integer)
		'C:\Program Files {(}x86{)}
		Thread.Sleep(time)
		If Not server Then
			SendKeys.SendWait(key)
		Else
			SendKeys.SendWait("C:\Program Files ")
			SendKeys.SendWait("{(}")
			SendKeys.SendWait("x86")
			SendKeys.SendWait("{)}")
			If key.IndexOf("(") <> -1 Or
					key.IndexOf(")") <> -1 Then
				Dim arr1() As String = key.Split("(")
				SendKeys.SendWait(arr1(0))
				SendKeys.SendWait("{(}")
				Dim arr2() As String = arr1(1).Split(")")
				SendKeys.SendWait(arr2(0))
				SendKeys.SendWait("{)}")
			End If
		End If
	End Sub

	Private Sub custKeypress(ByVal key As String, ByVal time As Integer, ByVal time2 As Integer)
		custKeypress(key, time)
		Thread.Sleep(time2)

	End Sub
	Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object,
		ByVal e As System.ComponentModel.DoWorkEventArgs) _
		Handles BackgroundWorker1.DoWork
		'For I = 0 To 200 'Telling the program to count from 0 - 200
		'          TextBox1.Text = I 'Telling the program to show the integer I in TextBox1
		'          BackgroundWorker1.ReportProgress(I) report the progress done by the ReportProgress
		'          System.Threading.Thread.Sleep(1000) Stop after advancing one Integer For 1 second.
		'      Next
		Dim Source As String = "W:\PPDwes\PUBLIC\Delta\Graphics"
		Dim Destination As String = "C:\Program Files (x86)\Delta Controls\enteliWEB\website\public\svggraphics\graphics\UWO\Graphics"
		UserTimeLapse = 1000
		Dim containsGPC As Boolean = False

		Try
			If (timeTextBox.Enabled = True) Then
				UserTimeLapse = timeTextBox.Text
				If UserTimeLapse > 0 Then
					UserTimeLapse = UserTimeLapse * 1000
				Else
					MessageBox.Show("Amount must be greater than zero", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
					Return
				End If
			End If

		Catch ex As Exception
			MessageBox.Show("Amount incorrect", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)            'should never happen, but you never know
			Return
		End Try

		If DriveComboBox.SelectedIndex = 0 Then
			Destination = "C:\Users\lwestel\Documents"
		ElseIf DriveComboBox.SelectedIndex = 1 Then
			Destination = "\Delta Controls\enteliWEB\website\public\svggraphics\graphics\UWO\Graphics"
			'C:\Program Files {(}x86{)}
			server = True
		ElseIf DriveComboBox.SelectedIndex = 2 Then
			Destination = "H:\Graphics"
		ElseIf DriveComboBox.SelectedIndex = 3 Then
			Destination = "C:\Users\lwestel\Documents"
		Else
			MessageBox.Show("No drive selected", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)   ' should never happen, but you never know
			Return
		End If

		If Not Directory.Exists(Source) Then
			MessageBox.Show("Make sure you have access to the source drive.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return
		End If
		If Not Directory.Exists(Destination) Then
			MessageBox.Show("Make sure you have access to " + Destination, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If
		For Each d As String In My.Computer.FileSystem.GetDirectories(Source)
Line1:
			Try
				Debug.WriteLine(d)
				containsGPC = False
				L_convert.Text = "Converting --> " + d
				If (cancel = True) Then
					Exit For
				End If
				L_convert.Update()
				Thread.Sleep(100)
				Dim dir As DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(d)
				For Each File In My.Computer.FileSystem.GetFiles(d)                      ' check to make sure the folders even contain .gpc files
					If (File.Contains(".gpc")) Then
						containsGPC = True
					End If
				Next
				Dim Dest = Destination + "\" + dir.Name                                  'ignore unnecessary folders that do not have files that need to be converted
				If Not String.Compare(dir.Name, "archive", True) = 0 And
			   Not String.Compare(dir.Name, "bmp", True) = 0 And
			   Not String.Compare(dir.Name, "help files", True) = 0 And
			   Not String.Compare(dir.Name, "CPS", True) = 0 And
			   Not String.Compare(dir.Name, "backup", True) = 0 And
			   Not String.Compare(dir.Name, "temp", True) = 0 Then
					Dim fileExists As Boolean = False
					Dim fileBrackets As Boolean = False
					Dim extraEnters As Integer = 0
					If Directory.Exists(Dest) Then
						Directory.Delete(Dest, True)
					End If
					If (My.Computer.FileSystem.GetFiles(dir.FullName).Count = 0) Then
						Continue For
						L_convert.Text = "Folder skipped, no files"                             ' Check if folder is empty
						Thread.Sleep(500)
					ElseIf Not (containsGPC) Then
						Continue For
						L_convert.Text = "Folder skipped, does not contain graphics files"      ' Check if folder even contains gpc files
						Thread.Sleep(1000)
					End If
					Directory.CreateDirectory(Dest)                                             ' create destination folder
					AppActivate("ORCAView")
					custKeypress("%t", 800)                     ' Alt+T
					custKeypress("{DOWN}", 800)
					custKeypress("{DOWN}", 800)
					custKeypress("{DOWN}", 800)
					custKeypress("{DOWN}", 800)
					custKeypress("{RIGHT}", 800)
					custKeypress("{DOWN}", 800)
					custKeypress("{ENTER}", 800)
					custKeypress("{TAB}", 800)
					custKeypress("{TAB}", 2000)
					custKeypress("{TAB}", 800)
					custKeypress("{TAB}", 800)
					custKeypress("{TAB}", 800)
					custKeypress("{TAB}", 800)
					custKeypress("{ENTER}", 800)
					custKeypress(d, 2000)                       ' source drive
					custKeypress("{ENTER}", 800)
					custKeypress("+{TAB}", 800)                 ' Shift+Tab
					custKeypress("^a", 800)                     ' Ctrl+A
					custKeypress("{TAB}", 800)
					custKeypress("{TAB}", 800)
					custKeypress("{TAB}", 800)
					custKeypress("{ENTER}", 1500)
					custKeypress("{TAB}", 2000)
					custKeypress("{TAB}", 800)
					custKeypress("{TAB}", 800)
					destTypedOut(Dest)                               ' destination drive
					custKeypress("{ENTER}", 1500, 1000)                     ' Check to see when conversion is done (popup will appear, wait for that to be active window)
					theHwnd = GetForegroundWindow()                     ' get foreground window's handle
					length = GetWindowTextLength(theHwnd) + 1           ' get the length of the title of that handle
					buf = Space$(length)                                ' make a buffer variable filled with spaces equal to the length of the foreground window's title
					length = GetWindowText(theHwnd, buf, length)        ' copies the text of the specified window's title bar into the buffer, returns final length of the title
					var = buf.Substring(0, length)                      ' substring the buffer to make sure title is proper length and text (not sure how it could be wrong, but everything online had this...)

					If var <> "Convert Graphics to Web Page" Then
						While (var <> "Convert Graphics to Web Page")
							Thread.Sleep(500)
							theHwnd = GetForegroundWindow()
							length = GetWindowTextLength(theHwnd) + 1
							buf = Space$(length)
							length = GetWindowText(theHwnd, buf, length)
							var = buf.Substring(0, length)
							If var = "Incorrect Version" Then           ' check to see if incorrect verison window pops up (rare, but does happen and would cause program to wait here forever)
								custKeypress("{ENTER}", 300)
							ElseIf var = "Open" Then                    ' if something goes wrong, try again. HAVE NOT BEEN ABLE TO TEST. Things have not gone wrong recently. 
								custKeypress("{ESCAPE}", 800)
								custKeypress("{ESCAPE}", 800)
								custKeypress("{ESCAPE}", 800)
								custKeypress("{ESCAPE}", 800)
								GoTo Line1                              ' not tested, but should return to top of the for loop with the same folder
							End If
						End While
					End If

					custKeypress("{ENTER}", 800, 500)
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Continue For

			End Try
		Next
		If (cancel <> True) Then
			L_convert.Text = "Conversion Complete"
		Else
			L_convert.Text = "Conversion Cancelled!"
		End If
	End Sub
	' Find if there are brackets in the output folder
	' Sendkeys cannot type out the brackets by default, it requires an escape character of sorts. 
	Private Sub destTypedOut(ByVal dest As String)
		Dim tempDest As String = dest
		If dest.Contains("(") Then
			tempDest = dest.Replace("(", "{(}")
		End If
		If dest.Contains(")") Then
			tempDest = dest.Replace(")", "{)}")
		End If
		custKeypress(tempDest, 1500, 1500)
	End Sub

End Class