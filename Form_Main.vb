' TODO

' System.Runtime.InteropServices.InvalidComObjectException: 'COM object that has been separated from its underlying RCW cannot be used.
' The COM object was released while it was still in use on another thread.'

' Controller von Kathrin in Halle 7 lässt partout FTP nicht zu (10.77.19.163)

' Make  Form_Files like Form_AxXGX dependend on the Row so it can be opened multiple times

' TOP PRIO
' Restore from backup mit Auswahl (user nach setting_Datum fragen das restored werden soll)
' Gebackupte Version von SD2 wieder auf SD1 schreiben (vor Restore aktuelle SD1 backuppen in Automatic Backups)
' FTP File Management (for folder creation and renaming)
' Improve File Browser to use FTP consistently instead of ActiveX Methods from Keyence

' FTP: 1-309

' SPÄTER:
' Make Icon of Form_AxXGX a screenshot of the controller (download screenshot to temp and convert to ico)
' Save and restore Window Sizes beim schließen (locations already done)
' Maske mit allen Variablen inkl. Systemvariablen (2-40 Communications Control Manual)
' Lösung für das Problem Controllername: Wie von Bernd Scholz vorgeschlagen Namen des Controllers in Variable schreiben beim Setup des Controllers und die Variable dann lesen o.a.
' Trigger 1-4 + Issues all triggers
' Version information readout (Page 2-96)
' Logdateien .csv pro Messung Zeile mit Ergebnissen
' .csv viewer (open source?)
' Ordnergröße anzeigen, evtl. durch rekursiven Aufruf der GetFileList? (könnte lange dauern)
'   oder eigener Methode zum Orderdurchlaufen und Größe der Dateien aufaddieren oder FTP (am besten)
' Handling of "this folder is empty"-message could be improved: don't allow user to delete, download etc. this entry
' Speed and Performance improvements: getting Programs takes too long, run on own thread or something like that
'   Read variables in Sub GetRootFolder in one command to improve speed
'   e.g. state = sender.AxXGX.ExecuteCommand("MR,%Sd1FreeSpace,%Sd2FreeSpace,%USBExist", response)
'   separate by first occurence of any number until "."
' What happens when SD-Card is not inserten? What does the MR-Command return?

Imports System.IO
Imports System.Net
Imports FluentFTP

Public Class Form_Main

    Dim state As Integer, response As String = ""
    Public tempFolder As String = Path.GetTempPath() & Application.ProductName
    ReadOnly credentials As New NetworkCredential("Administrator", "0000")

    Async Sub Form_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FtpTrace.LogFunctions = True
        Log.AppendText("Current Version: 24.06.2021" & vbNewLine &
                                   "Changelog:" & vbNewLine &
                                   "BACKUP AND RESTORE WORKS! TRY IT OUT NOW!" & vbNewLine &
                                   "*Only 420,69 DOGE/day, terms apply" & vbNewLine &
                                   "________________________________________________________" & vbNewLine)
        Debug.WriteLine("Loading from settings...")
        Try ' to load settings
            For Each SavedXGX As String In My.Settings.SavedXGX
                Dim IP As String = SavedXGX.Substring(0, SavedXGX.IndexOfAny(", "))
                If SavedXGX.Contains("WindowPos") Then
                    Dim PosX As String = SavedXGX.Substring(SavedXGX.IndexOfAny("X=") + 2)
                    PosX = PosX.Remove(PosX.LastIndexOfAny(","))
                    Dim PosY As String = SavedXGX.Substring(SavedXGX.IndexOf("Y=") + 2)
                    PosY = PosY.TrimEnd("}")
                    Overview.Rows.Add(IP, "Connect", SavedXGX.Contains("True"), "📁", "", "", "", PosX, PosY)
                Else
                    Overview.Rows.Add(IP, "Connect", SavedXGX.Contains("True"), "📁", "", "", "", "", "")
                End If
                If SavedXGX.Contains("True") Then
                    Dim index = Overview.Rows.Count - 2
                    Debug.WriteLine("Autoconnecting to " & Overview.Rows.Item(index).ToString)
                    Await Connect(Overview.Rows.Item(index))
                End If
                'Log.AppendText(SavedXGX.ToString & vbNewLine)
            Next
        Catch ex As Exception
            Log.AppendText(vbNewLine & "Did not load setting." & vbNewLine &
                                           ex.Message & vbNewLine &
                                           ex.Source)
        End Try
        Overview.Focus()
    End Sub

    ''' <summary>
    ''' This Async Function connects an XG-X and updates the GUI.
    ''' Returns True is connection was established, False if connection failed
    ''' </summary>
    ''' <param name="Row"> The Row to connect</param>
    ''' <returns>Whether the connection was established successfully</returns>
    Async Function Connect(Row As DataGridViewRow) As Task(Of Boolean)
        Dim XGX As New Form_AxXGX
        Row.Tag = XGX                ' Attach the Form_AxXGX to its Row.Tag
        Row.Tag.Tag = Row            ' Attach the Row to its Form_AxXGX.Tag
        Await Task.Run(Sub() state = XGX.AxXGX.Initialize())
        If state = 0 Then
            Debug.WriteLine("Initialization successful.")
            XGX.AxXGX.Address = Row.Cells("IP").Value
            Await Task.Run(Sub() state = XGX.AxXGX.Connect())
            If state = 0 Then
                Log.AppendText(vbNewLine &
                    "________________________________________________________" & vbNewLine &
                    "Connection to " & XGX.AxXGX.Address & " Succeeded." & vbNewLine)
                XGX.AxXGX.EnableRemoteConsole = True
                Await Task.Run(Sub() state = XGX.AxXGX.StartRemoteDesktop(0)) '0: Auto update mode
                If state = 0 Then
                    Row.Cells("Connection").Value = "Disconnect"
                    If Row.Cells("PosX").Value IsNot "" AndAlso Row.Cells("PosY").Value IsNot "" Then
                        XGX.Location = New Point(Row.Cells("PosX").Value, Row.Cells("PosY").Value)
                    End If
                    XGX.Show(Me)
                    Await GetTime(Row)
                    Await GetAllPrograms(Row)
                    'Form_Files.Show(Row.Tag)
                    Return True
                Else
                    Log.SelectionColor = Color.Red
                    Log.AppendText("StartRemoteDesktop failed." & vbNewLine)
                    StateErrorHandling(state)
                    Disconnect(Row)
                    Return False
                End If
            Else
                Log.SelectionColor = Color.Red
                Log.AppendText(vbNewLine &
                               "Connection to " & XGX.AxXGX.Address & " failed." & vbNewLine)
                StateErrorHandling(state)
                Disconnect(Row)
                Return False
                ' Attempt search?
            End If
        Else
            Log.SelectionColor = Color.Red
            Log.AppendText("Initializing failed. Application must be rebooted" & vbNewLine)
            StateErrorHandling(state)
            Disconnect(Row)
            Application.Restart()
            Return False
        End If
    End Function

    ''' <summary>
    ''' This Sub disconnects an XG-X and updates the GUI
    ''' </summary>
    ''' <param name="Row"> The Row to disconnect</param>
    Sub Disconnect(Row As DataGridViewRow)
        With Row
            .Tag.AxXGX.Disconnect()
            .Tag.Dispose()
            .Tag.Tag = Nothing
            .Tag = Nothing
            .Cells("Connection").Value = "Connect"
            .Cells("DateTime").Value = ""
            .Cells("Timezone").Value = ""
            .Cells("Program").Value = ""
            .Cells("BackupToRestore").Value = ""
            Log.AppendText(vbNewLine & "Disconnected from " &
                                           .Cells("IP").Value & vbNewLine)
        End With
    End Sub

    ''' <summary>
    ''' This Async Function executes a command on an XG-X
    ''' </summary>
    ''' <param name="Row"> The Row to which the XG-X belongs</param>
    ''' <param name="command"> The command to execute as String including possible parameters</param>
    ''' <param name="Async"> Whether the command should be executed asynchronously on the XG-X. An asynchronous command execution will NOT return a response-String</param>
    ''' <returns>the state of the operation (state 0 = no fault). Changes response to "" if command fails.</returns>
    Async Function ExecuteCommand(Row As DataGridViewRow, command As String, Async As Boolean) As Task(Of Integer)
        Dim XGX As AxXGXLib.AxXGX = Row.Tag.AxXGX
        If Async Then
            Await Task.Run(Sub() state = XGX.ExecuteCommandAsync(command))
        Else
            Await Task.Run(Sub() state = XGX.ExecuteCommand(command, response))
        End If
        If state = 0 Then
            Debug.WriteLine(Row.ToString & " " & command & " successful")
        Else
            Debug.WriteLine(Row.ToString & " " & command & " failed")
            response = ""
            StateErrorHandling(state)
        End If
        Return state
    End Function

    ''' <summary>
    ''' This Async Function gets the current time from an XG-X and updates the corresponding cell
    ''' </summary>
    ''' <param name="Row"> The Row to which the XG-X belongs</param>
    ''' <returns>The current time on the XG-X. Returns "" if operation failed.</returns>
    Async Function GetTime(Row As DataGridViewRow) As Task(Of String)
        If Await ExecuteCommand(Row, "TR", False) = 0 Then
            Row.Cells("DateTime").Value = response.Substring(9, 2) & "." &   ' dd
                                response.Substring(6, 2) & "." &             ' mm
                                "20" & response.Substring(3, 2) & " " &      ' yy
                                response.Substring(12, 2) & ":" &            ' hh
                                response.Substring(15, 2) & ":" &            ' mm
                                response.Substring(18, 2)                    ' ss
            Await GetTimezone(Row)
            Return Row.Cells("DateTime").Value
        Else
            Log.SelectionColor = Color.Red
            Log.AppendText(vbNewLine & "Getting Date/Time failed." & vbNewLine)
            Return ""
        End If
    End Function

    ''' <summary>
    ''' This Async Function gets the current timezone from an XG-X and updates the corresponding cell
    ''' </summary>
    ''' <param name="Row"> The Row to which the XG-X belongs</param>
    ''' <returns>The current response on the XG-X. Returns "" if operation failed.</returns>
    Async Function GetTimezone(Row As DataGridViewRow) As Task(Of String)
        If Await ExecuteCommand(Row, "TZR", False) = 0 Then
            response = response.Remove(0, 4)
            Select Case response
                Case 0
                    response = "GMT-12:00"
                Case 1
                    response = "GMT-11:00"
                Case 2
                    response = "GMT-10:00"
                Case 3
                    response = "GMT-9:00"
                Case 4
                    response = "GMT-8:00"
                Case 5
                    response = "GMT-7:00"
                Case 6
                    response = "GMT-6:00"
                Case 7
                    response = "GMT-5:00"
                Case 8
                    response = "GMT-4:30"
                Case 9
                    response = "GMT-4:00"
                Case 10
                    response = "GMT-3:30"
                Case 11
                    response = "GMT-3:00"
                Case 12
                    response = "GMT-2:00"
                Case 13
                    response = "GMT-1:00"
                Case 14
                    response = "GMT, UTC"
                Case 15
                    response = "GMT+1:00"
                Case 16
                    response = "GMT+2:00"
                Case 17
                    response = "GMT+3:00"
                Case 18
                    response = "GMT+3:30"
                Case 19
                    response = "GMT+4:00"
                Case 20
                    response = "GMT+4:30"
                Case 21
                    response = "GMT+5:00"
                Case 22
                    response = "GMT+5:50"
                Case 23
                    response = "GMT+5:45"
                Case 24
                    response = "GMT+6:00"
                Case 25
                    response = "GMT+6:30"
                Case 26
                    response = "GMT+7:30"
                Case 27
                    response = "GMT+8:00"
                Case 28
                    response = "GMT+9:00"
                Case 29
                    response = "GMT+9:30"
                Case 30
                    response = "GMT+10:00"
                Case 31
                    response = "GMT+11:00"
                Case 32
                    response = "GMT+12:00"
                Case 33
                    response = "GMT+13:00"
            End Select
            Row.Cells("Timezone").Value = response
        End If
        Return response
    End Function

    ''' <summary>
    ''' This Async Sub uploads the time from the time-cell to an XG-X
    ''' </summary>
    Async Sub SetTime(sender As Object, e As DataGridViewCellEventArgs) _
        Handles Overview.CellEndEdit
        If e.ColumnIndex = 4 Then
            Dim DateTimeCellValue As String =
                Overview.Item(e.ColumnIndex, e.RowIndex).FormattedValue
            Log.AppendText(vbNewLine & "Uploading the entered Date and Time: " &
                                           DateTimeCellValue & vbNewLine)
            Try
                Dim dateTimeToUpload = "TW," +
                        DateTimeCellValue.Substring(6, 4) & "," &   ' yyyy
                        DateTimeCellValue.Substring(3, 2) & "," &   ' mm
                        DateTimeCellValue.Substring(0, 2) & "," &   ' dd
                        DateTimeCellValue.Substring(11, 2) & "," &  ' hh
                        DateTimeCellValue.Substring(14, 2) & "," &  ' mm   
                        DateTimeCellValue.Substring(17, 2)          ' ss
                If Await ExecuteCommand(Overview.SelectedRows(0), dateTimeToUpload, False) = 0 Then
                    Log.SelectionColor = Color.LawnGreen
                    Log.AppendText("succeeded." & vbNewLine)
                    Log.SelectionColor = Color.Red
                End If
            Catch ex As Exception
                Log.SelectionColor = Color.Red
                Log.AppendText("failed." & vbNewLine &
                               "The entered Date/Time is not in the correct format." & vbNewLine &
                               ex.Message)
                Log.SelectionColor = Color.White
            End Try
        End If
    End Sub

    ''' <summary>
    ''' This Async Function gets the current program from an XG-X and updates the corresponding cell
    ''' </summary>
    ''' <param name="Row"> The Row to which the XG-X belongs</param>
    ''' <returns>The current program on the XG-X. Returns "" if operation failed.</returns>
    Async Function GetCurrentProgram(Row As DataGridViewRow) As Task(Of String)
        If Await ExecuteCommand(Row, "PR", False) = 0 Then
            Dim SDandProgNr As String = "SD" & response.Substring(3, 1) &
                ", Prog" & response.Substring(5)
            If Await ExecuteCommand(Row, "PR,NM", False) = 0 Then
                response = SDandProgNr & ", " & response.Substring(3)
                Log.AppendText(vbNewLine & "Current program:" & vbNewLine & response)
                Row.Cells("Program").Value = response
                Row.Tag.Text = Row.Tag.AxXGX.Address & " | " & response
                Log.ScrollToCaret()
            End If
        End If
        Return response
    End Function

    ''' <summary>
    ''' This Async Function gets all programs from an XG-X and updates the corresponding cell.
    ''' Only programs within folders named "setting" are found. 
    ''' Backups and other programs within folders named differently than "setting" will not be found.
    ''' </summary>
    ''' <param name="Row"> The Row to which the XG-X belongs</param>
    Async Function GetAllPrograms(Row As Object) As Task 'Have to use Row as Object here as stupid compiler says that a Cell cannot have Items
        Dim listNum As Integer = 0
        If Row.Tag.AxXGX.GetInspectList(listNum) = 0 Then
            If listNum < 1 Then
                Return 'exit if there are no list items
            End If
            Log.AppendText(vbNewLine & "All available programs:" & vbNewLine)
            Row.Cells("Program").Items.Clear()
            Dim index, SDcard As Byte
            Dim Name As String = ""
            Dim settingNo As String = Nothing
            For index = 0 To listNum - 1
                If Row.Tag.AxXGX.GetInspectInfo(index, SDcard, settingNo, Name) = 0 Then
                    While settingNo.ToString.Length < 4 'make settingNo always 4 chars long
                        settingNo = settingNo.ToString.Insert(0, 0)
                    End While
                    response = "SD" & SDcard & ", Prog" & settingNo & ", " & Name
                    Log.AppendText(response & vbNewLine)
                    Row.Cells("Program").Items.Add(response)
                Else
                    StateErrorHandling(state)
                End If
            Next index
            Await GetCurrentProgram(Row)
        Else
            Log.SelectionColor = Color.Red
            Log.AppendText(vbNewLine & "GetInspectList in GetAllPrograms failed." & vbNewLine)
            StateErrorHandling(state)
        End If
    End Function

    Private Sub Button_LoadVars_Click(sender As Object, e As EventArgs)
        state = sender.AxXGX.ExecuteCommand(
            "MR,%Error0,%ControllerId", response)
        If Not state = 0 Then
            Log.SelectionColor = Color.Red
            Log.AppendText(vbNewLine + "Failed to execute experimental command" + vbNewLine)
            StateErrorHandling(state)
        End If
    End Sub

    Async Sub Overview_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles Overview.CellContentClick
        If e.RowIndex <> -1 Then ' Actual data cells and not header is clicked (header has e.RowIndex = -1)
            Dim Row As DataGridViewRow = Overview.SelectedRows(0)
            If e.ColumnIndex = 1 Then ' Connection_Btn
                If Row.Tag Is Nothing Then
                    If Await Connect(Row) = False Then
                        Return 'if connection attempt fails
                    End If
                Else
                    Disconnect(Row)
                End If
            ElseIf e.ColumnIndex = 3 Or e.ColumnIndex = 9 Or e.ColumnIndex = 10 Then
                If Row.Tag Is Nothing Then
                    If Await Connect(Row) = False Then
                        Return
                    End If
                End If
                If e.ColumnIndex = 3 Then ' Files_Btn
                    If Form_Files.Visible Then
                        Form_Files.Focus()
                    Else
                        Form_Files.Text = "Files: " & Row.Tag.Text
                        Form_Files.Show(Row.Tag)
                    End If
                ElseIf e.ColumnIndex = 9 Then ' Backup_Btn
                    Await Backup(Row)
                ElseIf e.ColumnIndex = 10 Then ' Restore_Btn
                    Await GetRestoreableBackups(Row)
                End If
            End If
        End If
    End Sub

    Async Function Backup(Row As Object) As Task 'Have to use Row as Object here as stupid compiler says that a Cell cannot have Items
        Log.AppendText(vbNewLine & vbNewLine & "Backing up programs to SD2..." & vbNewLine)
        'programs
        For Each program As String In Row.Cells("Program").Items
            If program.Contains("SD1") Then
                program = program.Substring(10, 3)
                Debug.WriteLine("PC,1," & program & ",2," & program)
                If Await ExecuteCommand(Row, "PC,1," & program & ",2," & program, True) = 0 Then 'THIS IS SLOW AF
                    While Row.Tag.AxXGX.CommandBusy ' Let Application DoEvents, so UI isn't blocked
                        Application.DoEvents()
                    End While
                    Log.AppendText("Finished backing up program " & program & vbNewLine)
                End If
            End If
        Next

        Log.AppendText("Backing up env.dat and gvar.dat to SD2..." & vbNewLine)
        'gvar.dat and env.dat (have to be down- & uploaded again)
        Dim host As String = Row.Tag.AxXGX.Address
        Using ftp = New FtpClient(host, credentials) 'credentials)
            MsgBox(ftp.AutoConnect.ToString)
            'Await ftp.ConnectAsync()
            'Await ftp.DownloadFilesAsync(tempFolder,
            '                  {"/SD1/xg/setting/env.dat", "/SD1/xg/setting/gvar.dat"},
            '                  FtpLocalExists.Overwrite)
            'Await ftp.UploadFilesAsync({tempFolder & "/env.dat",
            '                tempFolder & "/gvar.dat"},
            '                "/SD2/xg/setting/",
            '                FtpRemoteExists.Overwrite)
            'Await ftp.MoveDirectoryAsync("/SD2/xg/setting",
            '                  "/SD2/xg/setting_" & Format(Now, "dd_MM_yyyy"),
            '                  FtpRemoteExists.Overwrite)
            'Log.SelectionColor = Color.LawnGreen
            'Log.AppendText(vbNewLine &
            '               "Backup complete! Find it in /SD2/xg/setting_" & Format(Now, "dd_MM_yyyy"))
            'Log.SelectionColor = Color.White
            'Date.Now.Year & "_" & Date.Now.Month & "_" & Date.Now.Day,
        End Using
        'If Form_Files.Visible Then
        '    Form_Files.Focus()
        'Else
        '    Form_Files.Text = "Files: " & Overview.CurrentRow.Tag.Text
        '    Form_Files.Show(Overview.CurrentRow.Tag)
        'End If
    End Function

    Async Function GetRestoreableBackups(Row As Object) As Task
        Dim host As String = Row.Tag.AxXGX.Address
        Using ftp = New FtpClient(host, credentials)
            Await ftp.ConnectAsync()
            Row.Cells("BackupToRestore").Items.Clear()
            For Each setting In Await ftp.GetListingAsync("/SD2/xg", FtpListOption.Auto)
                If setting.Type = FtpFileSystemObjectType.Directory And setting.Name.Contains("setting") Then
                    Row.Cells("BackupToRestore").Items.Add(setting.Name)
                    Log.AppendText(vbNewLine & "Backup found: " & setting.Name)
                    For Each prog In Await ftp.GetListingAsync("/SD2/xg/" & setting.Name, FtpListOption.Auto)
                        If prog.Type = FtpFileSystemObjectType.Directory And prog.Name.Contains("0") Then
                            Row.Cells("BackupToRestore").Items.Add(" - " & prog.Name)
                            Log.AppendText(vbNewLine & " - Program found: " & prog.Name)
                        End If
                    Next
                    'selects the last found backup so that the user knows where to select
                    Row.Cells("BackupToRestore").Value = setting.Name
                End If
            Next
        End Using
        Row.Cells("BackupToRestore").OwningColumn.Visible = True
    End Function

    Public Sub StateErrorHandling(state As Integer)
        Log.SelectionColor = Color.Red
        If state = 1001 Then
            Log.AppendText("Processing failed." + vbNewLine +
                           "(initialization not done, etc.)" + vbNewLine)
        ElseIf state = 1002 Then
            Log.AppendText("Illegal Parameter." + vbNewLine)
        ElseIf state = 1003 Then
            Log.AppendText("Illegal Operation." + vbNewLine +
                           "(duplicate method calls, etc.)" + vbNewLine)
        ElseIf state = 1004 Then
            Log.AppendText("Not enough memory space." + vbNewLine)
        ElseIf state = 1005 Then
            Log.AppendText("The file already exists." + vbNewLine)
        ElseIf state = 1006 Then
            Log.AppendText("Processing in progress." + vbNewLine)
        ElseIf state = 1007 Then
            Log.AppendText("The device is unavailable." + vbNewLine)
        ElseIf state = 1008 Then
            Log.AppendText("The requested operation has been disabled." + vbNewLine)
        ElseIf state = 1009 Then
            Log.AppendText("Cannot find the target data (or file)." + vbNewLine)
        ElseIf state = 1100 Then
            Log.AppendText("Communication failure due to a fault in the communication path." + vbNewLine +
                           "Reconnect to the controller" + vbNewLine)
        ElseIf state = 2002 Then
            Log.AppendText("The requested command does not exist." + vbNewLine)
        ElseIf state = 2003 Then
            Log.AppendText("The received command cannot be performed." + vbNewLine)
        ElseIf state = 2022 Then
            Log.AppendText("Value specified in the command is out of range." + vbNewLine)
        ElseIf state = 2080 Then
            Log.AppendText("Incorrect password" + vbNewLine)
        ElseIf state = 2081 Then
            Log.AppendText("Command cannot be executed while device input is disabled." + vbNewLine)
        Else
            Log.AppendText("Execution error." + vbNewLine)
        End If
        Log.SelectionColor = Color.White
        Log.ScrollToCaret()
    End Sub

    ''' <summary>
    ''' Closes the corresponding Form_AxXGX and thus disconnects its XG-X when a user deletes a row
    ''' </summary>
    Private Sub Overview_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) _
        Handles Overview.UserDeletingRow
        If e.Row.Tag IsNot Nothing Then
            e.Row.Tag.Close()
        End If
    End Sub

    ''' <summary>
    ''' Event handler raised when EditingControl is shown (when the list of Combobox entries is shown)
    ''' </summary>
    Private Sub Overview_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) _
        Handles Overview.EditingControlShowing
        With Overview
            'If .SelectedRows(0).Tag Is Nothing Then
            '    If Await Connect(.SelectedRows(0)) = False Then
            '        Return
            '    End If
            'Else
            If TypeOf e.Control Is ComboBox Then
                Dim cb As ComboBox = TryCast(e.Control, ComboBox)
                'remove handlers if they were added before
                RemoveHandler cb.SelectedIndexChanged, AddressOf ComboboxSelectionChanged
                AddHandler cb.SelectedIndexChanged, AddressOf ComboboxSelectionChanged
            End If
            'End If
        End With
    End Sub

    ''' <summary>
    ''' Delegates execution to the relevant Function when a Combobox in Overview changed selection
    ''' </summary>
    Async Sub ComboboxSelectionChanged(sender As Object, e As EventArgs)
        If Overview.CurrentCell.OwningColumn.Name = "Timezone" Then
            Await TimezoneSelectionChanged(sender, Nothing)
        ElseIf Overview.CurrentCell.OwningColumn.Name = "Program" Then
            Await ProgramSelectionChanged(sender, Nothing)
        ElseIf Overview.CurrentCell.OwningColumn.Name = "BackupToRestore" Then
            Await BackupToRestoreSelectionChanged(sender, Nothing)
        End If
    End Sub

    ''' <summary>
    ''' This Async Function uploads the selected timezone from the timezone-Combobox-cell to an XG-X
    ''' </summary>
    Async Function TimezoneSelectionChanged(sender As Object, e As EventArgs) As Task
        Dim ComboBoxTimezone As ComboBox = CType(sender, ComboBox)
        Dim Row As DataGridViewRow = Overview.SelectedRows(0)
        If Await GetTimezone(Row) <> ComboBoxTimezone.Text Then ' only change if current Timezone differs from selected Timezone
            Log.AppendText(vbNewLine + "Changing Timezone to: " +
                    ComboBoxTimezone.Text + vbNewLine)
            Select Case ComboBoxTimezone.Text
                Case "GMT-12:00"
                    state = Await ExecuteCommand(Row, "TZW,0", True)
                Case "GMT-11:00"
                    state = Await ExecuteCommand(Row, "TZW,1", True)
                Case "GMT-10:00"
                    state = Await ExecuteCommand(Row, "TZW,2", True)
                Case "GMT-9:00"
                    state = Await ExecuteCommand(Row, "TZW,3", True)
                Case "GMT-8:00"
                    state = Await ExecuteCommand(Row, "TZW,4", True)
                Case "GMT-7:00"
                    state = Await ExecuteCommand(Row, "TZW,5", True)
                Case "GMT-6:00"
                    state = Await ExecuteCommand(Row, "TZW,6", True)
                Case "GMT-5:00"
                    state = Await ExecuteCommand(Row, "TZW,7", True)
                Case "GMT-4:30"
                    state = Await ExecuteCommand(Row, "TZW,8", True)
                Case "GMT-4:00"
                    state = Await ExecuteCommand(Row, "TZW,9", True)
                Case "GMT-3:30"
                    state = Await ExecuteCommand(Row, "TZW,10", True)
                Case "GMT-3:00"
                    state = Await ExecuteCommand(Row, "TZW,11", True)
                Case "GMT-2:00"
                    state = Await ExecuteCommand(Row, "TZW,12", True)
                Case "GMT-1:00"
                    state = Await ExecuteCommand(Row, "TZW,13", True)
                Case "GMT, UTC"
                    state = Await ExecuteCommand(Row, "TZW,14", True)
                Case "GMT+1:00"
                    state = Await ExecuteCommand(Row, "TZW,15", True)
                Case "GMT+2:00"
                    state = Await ExecuteCommand(Row, "TZW,16", True)
                Case "GMT+3:00"
                    state = Await ExecuteCommand(Row, "TZW,17", True)
                Case "GMT+3:30"
                    state = Await ExecuteCommand(Row, "TZW,18", True)
                Case "GMT+4:00"
                    state = Await ExecuteCommand(Row, "TZW,19", True)
                Case "GMT+4:30"
                    state = Await ExecuteCommand(Row, "TZW,20", True)
                Case "GMT+5:00"
                    state = Await ExecuteCommand(Row, "TZW,21", True)
                Case "GMT+5:30"
                    state = Await ExecuteCommand(Row, "TZW,22", True)
                Case "GMT+5:45"
                    state = Await ExecuteCommand(Row, "TZW,23", True)
                Case "GMT+6:00"
                    state = Await ExecuteCommand(Row, "TZW,24", True)
                Case "GMT+6:30"
                    state = Await ExecuteCommand(Row, "TZW,25", True)
                Case "GMT+7:00"
                    state = Await ExecuteCommand(Row, "TZW,26", True)
                Case "GMT+8:00"
                    state = Await ExecuteCommand(Row, "TZW,27", True)
                Case "GMT+9:00"
                    state = Await ExecuteCommand(Row, "TZW,28", True)
                Case "GMT+9:30"
                    state = Await ExecuteCommand(Row, "TZW,29", True)
                Case "GMT+10:00"
                    state = Await ExecuteCommand(Row, "TZW,30", True)
                Case "GMT+11:00"
                    state = Await ExecuteCommand(Row, "TZW,31", True)
                Case "GMT+12:00"
                    state = Await ExecuteCommand(Row, "TZW,32", True)
                Case "GMT+13:00"
                    state = Await ExecuteCommand(Row, "TZW,33", True)
                Case Else 'actually useless as user can only select from list, leaving this for stability
                    Log.SelectionColor = Color.Red
                    Log.AppendText("The entered Timezone is not part of the Timezone list." & vbNewLine &
                                       "Please select a Timezone from the list.")
                    Log.SelectionColor = Color.White
                    Return
            End Select
            If state = 0 Then
                Log.SelectionColor = Color.LawnGreen
                Log.AppendText("Success." & vbNewLine)
                Log.SelectionColor = Color.White
            End If
        End If
    End Function

    ''' <summary>
    ''' This Async Function changes to the selected program from the program-Combobox-cell on an XG-X
    ''' </summary>
    Async Function ProgramSelectionChanged(sender As Object, e As EventArgs) As Task
        Dim ComboBoxPrograms As ComboBox = CType(sender, ComboBox)
        Dim Row = Overview.SelectedRows(0)
        If Await GetCurrentProgram(Row) <> ComboBoxPrograms.Text Then ' only change if current program differs from selected program
            Try
                Dim SDCard As Integer = Integer.Parse(ComboBoxPrograms.Text.ElementAt(2))
                Dim settingNo As String = ComboBoxPrograms.Text.Substring(9, 4)
                Dim ProgramName As String = ComboBoxPrograms.Text.Substring(15)
                Log.AppendText(vbNewLine & "Trying to switch to" & vbNewLine &
                                               "SD" & SDCard & ", Prog" & settingNo & ", " & ProgramName)
                If Await ExecuteCommand(Row, "PW," & SDCard & "," & settingNo, True) = 0 Then
                    Log.SelectionColor = Color.LawnGreen
                    Log.AppendText(vbNewLine & "Success." & vbNewLine)
                    Log.SelectionColor = Color.White
                    Row.Tag.Text = Row.Tag.AxXGX.Address & " | " & ComboBoxPrograms.Text
                Else
                    Log.SelectionColor = Color.Red
                    Log.AppendText("Failure." & vbNewLine)
                    StateErrorHandling(state)
                End If
            Catch ex As Exception 'actually useless as user can only select from list, leaving this for stability
                Log.SelectionColor = Color.Red
                Log.AppendText(vbNewLine & "Failure." & vbNewLine &
                                               "The entered Program is most likely not in the correct format." & vbNewLine &
                                               ex.Message)
                Log.SelectionColor = Color.White
            End Try
        End If
    End Function

    ''' <summary>
    ''' This Async Function restores a selected program from the BackupToRestore-Combobox-cell from SD2 to SD1 on an XG-X
    ''' </summary>
    Async Function BackupToRestoreSelectionChanged(sender As Object, e As EventArgs) As Task
        Dim ComboBoxBackupToRestore As ComboBox = CType(sender, ComboBox)
        Dim Row As DataGridViewRow = Overview.SelectedRows(0)
        ' 1. Perform a safety backup
        'Dim BackupTask As Task = Task.Run(Sub() Backup(Row))
        'BackupTask.Wait(40000)

        ' 2. Change name of selected setting_DATE folder to setting,
        '    so that the progs within it are recognizes as progs by GetAllPrograms
        '       => Find setting_DATE of selected prog
        If ComboBoxBackupToRestore.Text.Contains("setting") Then
            Log.SelectionColor = Color.Orange
            Log.AppendText(vbNewLine &
                           "Entire setting-folder cannot yet be restored." & vbNewLine &
                           "Please select a program number to restore.")
            Log.SelectionColor = Color.White
        Else
            Dim setting As String = ""
            Dim selectedIndex As Byte = ComboBoxBackupToRestore.SelectedIndex
            Dim i As Byte = 0
            While Not setting.Contains("setting") And i < selectedIndex
                i += 1
                setting = ComboBoxBackupToRestore.Items.Item(selectedIndex - i).ToString
            End While

            Dim prog As String = ComboBoxBackupToRestore.Text.Substring(4)
            Log.AppendText(vbNewLine & "Attempting to restore prog: " & prog & vbNewLine &
                           "from: " & setting)

            ' ONLY RENAME IF NECESSARY
            If Not setting = "setting" Then
                Log.AppendText(vbNewLine &
                                   "renaming /SD2/xg/" & setting & " to /SD2/xg/setting")
                Dim host As String = Row.Tag.AxXGX.Address
                Using ftp = New FtpClient(host, credentials)
                    Await ftp.ConnectAsync()
                    Await ftp.MoveDirectoryAsync("/SD2/xg/" & setting,
                                  "/SD2/xg/setting",
                                  FtpRemoteExists.Overwrite)
                End Using
            End If

            ' 3. Copy selected Program from SD2 to same Program Number on SD1
            If Await ExecuteCommand(Row, "PC,2," & prog & ",1," & prog, False) = 0 Then
                Log.SelectionColor = Color.LawnGreen
                Log.AppendText(vbNewLine &
                           "Restore complete! " & vbNewLine &
                           prog & " from " & setting & " was restored to SD1 " & prog)
                Log.SelectionColor = Color.White
            Else
                Log.SelectionColor = Color.Red
                Log.AppendText(vbNewLine & "Restore failed!" & vbNewLine)
            End If


            'Dim GetProgramsTask As Task = Task.Run(Sub() GetAllPrograms(Row))
            'GetProgramsTask.Wait(20000)
            Await GetAllPrograms(Row)

            ' (4. Check whether XG-X reboots automatically when the current program is overwritten
            '     by the backup. If not, reboot.)
        End If
    End Function

    ''' <summary>
    ''' This Async Sub handles the execution of ContextMenuStrip_Main items when they are clicked
    ''' </summary>
    Async Sub ContextMenuStrip_Main_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) _
        Handles ContextMenuStrip_Main.ItemClicked
        Dim Row As DataGridViewRow = Overview.SelectedRows.Item(0)
        If Row.Tag Is Nothing Then
            If Await Connect(Row) = False Then
                Return
            End If
        End If
        If e.ClickedItem Is ToolStripMenuItem_Reset Then
            Await ExecuteCommand(Row, "RS", False)
        ElseIf e.ClickedItem Is ToolStripMenuItem_Reboot Then
            Await ExecuteCommand(Row, "RB", False)
        ElseIf e.ClickedItem Is ToolStripMenuItem_Backup Then
            Await Backup(Row)
        ElseIf e.ClickedItem Is ToolStripMenuItem_Restore Then
            Await GetRestoreableBackups(Row)
        ElseIf e.ClickedItem Is ToolStripMenuItem_Delete Then
            Dim XGX As Form_AxXGX = Row.Tag
            If XGX IsNot Nothing Then
                XGX.Close()
            End If
            Overview.Rows.RemoveAt(Row.Index)
        ElseIf e.ClickedItem Is ToolStripMenuItem_GetTime Then
            Await GetTime(Row)
        ElseIf e.ClickedItem Is ToolStripMenuItem_GetProgram Then
            Await GetAllPrograms(Row)
        End If
    End Sub

    'Private Sub Overview_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) _
    '    Handles Overview.DataError
    '    MessageBox.Show(e.Exception.Message & vbNewLine &
    '                    e.Exception.Source & vbNewLine &
    '                    "ColumnIndex: " & e.ColumnIndex & vbNewLine &
    '                    "RowIndex: " & e.RowIndex & vbNewLine &
    '                    "Item: " & Overview.Item(e.ColumnIndex, e.RowIndex).Value)
    'End Sub

    ''' <summary>
    ''' Selects the Row the user right clicked
    ''' </summary>
    Private Sub Overview_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) _
        Handles Overview.CellMouseDown
        If (e.ColumnIndex > -1 And e.RowIndex > -1 And e.Button = Windows.Forms.MouseButtons.Right) Then
            Overview.Rows(e.RowIndex).Selected = True
        End If
    End Sub

    Private Sub Button_ClearLog_Click(sender As Object, e As EventArgs) Handles Button_ClearLog.Click
        Log.Clear()
    End Sub

    Private Sub Button_SaveLog_Click(sender As Object, e As EventArgs) Handles Button_SaveLog.Click
        SaveFileDialog1.FileName = "XG-X_Interface_Log_" + Date.Today.ToShortDateString
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            File.Delete(SaveFileDialog1.FileName)
            File.AppendAllText(SaveFileDialog1.FileName, Log.Text)
        End If
    End Sub

    Private Sub Form_Main_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        If Directory.Exists(tempFolder) Then
            Directory.Delete(tempFolder, True)
        End If
        My.Settings.SavedXGX.Clear()
        For Each Row As DataGridViewRow In Overview.Rows
            If Not Row.Cells("IP").Value = "" Then
                If Row.Cells("PosX").FormattedValue = "" Then ' no WindowPos to save
                    My.Settings.SavedXGX.Add(Row.Cells("IP").Value &
                                                 ", Autoconnect: " & Row.Cells("Autoconnect").Value)
                Else ' save WindowPos
                    My.Settings.SavedXGX.Add(Row.Cells("IP").Value &
                                                 ", Autoconnect: " & Row.Cells("Autoconnect").Value &
                                                 ", WindowPos: X=" & Row.Cells("PosX").Value &
                                                 ",Y=" & Row.Cells("PosY").Value & "}")
                End If
            End If
        Next
    End Sub
End Class