Imports System.IO
Imports System.Threading
Imports System.Windows.Forms

Public Module Module1
	Private Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As Long, ByVal lpString As String, ByVal cch As Long) As Long
	Private Declare Function GetWindowTextLength Lib "user32" Alias "GetWindowTextLengthA" (ByVal hwnd As Long) As Long
	Private Declare Function GetForegroundWindow Lib "user32" () As Long

	Private Declare Auto Function ShowWindow Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As Boolean
	Private Declare Auto Function GetConsoleWindow Lib "kernel32.dll" () As IntPtr
	Private Const SW_HIDE As Integer = 0

	Private MyStr As String, theHwnd As Long
	Dim length As Integer
	Dim buf, var As String
	Dim Destination As String = "Y:\UWO\Graphics"
	Sub Main()
		Dim hWndConsole As IntPtr
		hWndConsole = GetConsoleWindow()
		ShowWindow(hWndConsole, SW_HIDE)
		Dim Source As String = "W:\PUBLIC\Delta\Graphics"
		'Dim Source As String = "C:\Users\lwestel\Desktop"               'for testing purposes
		Dim Destination As String = "Y:\Graphics"
		'Dim Destination As String = "C:\Users\lwestel\Documents"
		Dim containsGPC As Boolean = False

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
					SendKeys.SendWait("%t")                 ' % = alt, so this line means ALT+T
					Thread.Sleep(300)
					SendKeys.SendWait("{DOWN}")
					Thread.Sleep(300)
					SendKeys.SendWait("{DOWN}")
					Thread.Sleep(300)
					SendKeys.SendWait("{DOWN}")
					Thread.Sleep(300)
					SendKeys.SendWait("{DOWN}")
					Thread.Sleep(300)
					SendKeys.SendWait("{RIGHT}")
					Thread.Sleep(300)
					SendKeys.SendWait("{DOWN}")
					Thread.Sleep(300)
					SendKeys.SendWait("{ENTER}")            'graphics to webpage
					Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(1000)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(300)
					SendKeys.SendWait("{ENTER}")            ' Add button
					Thread.Sleep(2000)
					SendKeys.SendWait(d)
					Thread.Sleep(300)
					SendKeys.SendWait("{ENTER}")
					Thread.Sleep(300)
					SendKeys.SendWait("+{TAB}")
					Thread.Sleep(300)
					SendKeys.SendWait("^a")                 '^ is for CRTL, so this line means CTRL+A, selects all files that are to be added
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(300)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(300)
					Thread.Sleep(1000)
					SendKeys.SendWait("{ENTER}")
					Thread.Sleep(2000)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(400)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(400)
					SendKeys.SendWait("{TAB}")
					Thread.Sleep(2000)
					SendKeys.SendWait(Dest)
					Thread.Sleep(400)
					Thread.Sleep(1000)
					SendKeys.SendWait("{ENTER}")
					Thread.Sleep(1000)
					'Check to see when conversion is done (popup will appear, wait for that to be active window)
					theHwnd = GetForegroundWindow()
					length = GetWindowTextLength(theHwnd) + 1
					buf = Space$(length)
					length = GetWindowText(theHwnd, buf, length)
					var = buf.Substring(0, length)
					If var <> "Convert Graphics to Web Page" Then
						While (var <> "Convert Graphics to Web Page")
							Thread.Sleep(1000)
							theHwnd = GetForegroundWindow()
							length = GetWindowTextLength(theHwnd) + 1
							buf = Space$(length)
							length = GetWindowText(theHwnd, buf, length)
							var = buf.Substring(0, length)
							If var = "Incorrect Version" Then       'check to see if incorrect verison window pops up (rare, but does happen and would cause program to wait here forever)
								SendKeys.SendWait("{ENTER}")
							ElseIf var = "Open" Then                'if something goes wrong, try again. HAVE NOT BEEN ABLE TO TEST. Things have not gone wrong recently. 
								Thread.Sleep(300)
								SendKeys.SendWait("{ESCAPE}")       'not sure how many escapes I need
								Thread.Sleep(300)
								SendKeys.SendWait("{ESCAPE}")
								Thread.Sleep(300)
								SendKeys.SendWait("{ESCAPE}")
								Thread.Sleep(300)
								SendKeys.SendWait("{ESCAPE}")
								GoTo Line1                          'not tested, but should return to top of the for loop with the same folder
							End If
						End While
					End If
					SendKeys.SendWait("{ENTER}")
					'Conversion done
					Thread.Sleep(1000)
				End If
			Catch ex As UnauthorizedAccessException
				Continue For
			End Try
		Next
	End Sub

End Module
