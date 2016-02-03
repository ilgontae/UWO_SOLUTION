Imports System.IO
Imports System.Threading
Imports System.Windows.Forms
Public Module Module1
	Private Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As Long, ByVal lpString As String, ByVal cch As Long) As Long
	Private Declare Function GetWindowTextLength Lib "user32" Alias "GetWindowTextLengthA" (ByVal hwnd As Long) As Long
	Private Declare Function GetForegroundWindow Lib "user32" () As Long
	Private Declare Auto Function ShowWindow Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As Boolean
	Private Declare Auto Function GetConsoleWindow Lib "kernel32.dll" () As IntPtr
	Private MyStr As String, theHwnd As Long
	Dim length As Integer
	Dim buf, var As String
	Dim Destination As String = "Y:\UWO\Graphics"

	Sub Main()
		Dim Source As String = "W:\PPDwes\PUBLIC\Delta\Graphics"
		Dim Destination As String = "C:\Program Files (x86)\Delta Controls\enteliWEB\website\public\svggraphics\graphics\UWO\Graphics"
		Dim containsGPC As Boolean = False

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
			   Not String.Compare(dir.Name, "ICFAR", True) = 0 And
			   Not String.Compare(dir.Name, "temp", True) = 0 Then
					Dim fileExists As Boolean = False
					Dim fileBrackets As Boolean = False
					Dim extraEnters As Integer = 0
					If Directory.Exists(Dest) Then
						Directory.Delete(Dest, True)
					End If
					If (My.Computer.FileSystem.GetFiles(dir.FullName).Count = 0) Then
						Continue For
						Thread.Sleep(500)
					ElseIf Not (containsGPC) Then
						Continue For
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
	End Sub

	Private Sub custKeypress(ByVal key As String, ByVal time As Integer)
		Thread.Sleep(time)
		SendKeys.SendWait(key)
	End Sub

	Private Sub custKeypress(ByVal key As String, ByVal time As Integer, ByVal time2 As Integer)
		Thread.Sleep(time)
		SendKeys.SendWait(key)
		Thread.Sleep(time2)
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

End Module