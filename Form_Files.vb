Imports System.IO
Imports System.Net
Imports System.Threading
Imports FluentFTP
Imports FluentFTP.Rules

' FLUENTFTP EVERYTHING! DELETE DOESN'T WORK

Public Class Form_Files

#Disable Warning IDE0044 ' Add readonly modifier - cannot be readonly as Methods must write to it
    Private state, listnum As Integer
#Enable Warning IDE0044 ' Add readonly modifier

    Private cred As New NetworkCredential("Administrator", "0000")
    Private response As String
    Private XGX As Form_AxXGX

    Private Sub Form_Files_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        XGX = Owner
        GetRootFolder(XGX, e)
        DataGridView1.Focus()
        If Not Directory.Exists(Form_Main.tempFolder) Then
            Directory.CreateDirectory(Form_Main.tempFolder)
        End If
    End Sub

    ''' <summary>
    ''' Shows the RootFolder with SD1,SD2,USB (if available) on the Datagridview1
    ''' </summary>
    ''' <param name="sender"> the corresponding Form_AxXGX</param>
    Public Sub GetRootFolder(sender As Object, e As EventArgs) Handles Button_Home.Click
        DataGridView1.Rows.Clear()
        'These cannot be performed in root directory
        DataGridView1.RowTemplate.ReadOnly = True ' user cannot rename SD1, SD2, USB
        DataGridView1.ContextMenuStrip.Items.Item("ToolStripMenuItem_Backspace").Visible = False
        DataGridView1.ContextMenuStrip.Items.Item("ToolStripMenuItem_NewFolder").Visible = False
        DataGridView1.ContextMenuStrip.Items.Item("ToolStripMenuItem_Rename").Visible = False
        DataGridView1.ContextMenuStrip.Items.Item("ToolStripMenuItem_Delete").Visible = False

        TextBox_Path.Text = ""
        DataGridView1.Columns.Item("Filesize").HeaderText = "Free Space"
        'Form_Main.RichTextBox_Log.AppendText(vbNewLine & "Getting Root Folder..." & vbNewLine)
        Dim SD1FreeSpace As String = "", SD2FreeSpace As String = ""
        state = XGX.AxXGX.ExecuteCommand("MR,%Sd1FreeSpace", SD1FreeSpace)
        If state = 0 Then
            SD1FreeSpace = SD1FreeSpace.Remove(0, 4)
            SD1FreeSpace = SD1FreeSpace.Trim("0") ' Have to trim "0" first and only then "."
            SD1FreeSpace = SD1FreeSpace.Trim(".") ' Otherwise we would trim "0" at the end of FreeSpace, e.g. "2300" would be trimmed to "23"
            DataGridView1.Rows.Add("📁", "SD1:", SD1FreeSpace & " MB")
        Else
            Form_Main.StateErrorHandling(state)
        End If
        state = XGX.AxXGX.ExecuteCommand("MR,%Sd2FreeSpace", SD2FreeSpace)
        If state = 0 Then
            SD2FreeSpace = SD2FreeSpace.Remove(0, 4)
            SD2FreeSpace = SD2FreeSpace.Trim("0")
            SD2FreeSpace = SD2FreeSpace.Trim(".")
            DataGridView1.Rows.Add("📁", "SD2:", SD2FreeSpace & " MB")
        Else
            Form_Main.StateErrorHandling(state)
        End If
        state = XGX.AxXGX.ExecuteCommand("MR,%USBExist", response)
        If state = 0 Then
            If response.Contains("1") Then
                DataGridView1.Rows.Add("📁", "USB:")
            End If
        Else
            Form_Main.StateErrorHandling(state)
        End If
        Form_Main.Log.ScrollToCaret()
    End Sub

    ''' <summary>
    ''' Displays everything in folder on the Datagridview1
    ''' </summary>
    ''' <param name="folder"> the folder which content should be displayed</param>
    Public Sub GetFileList(folder As String)
        If folder = "" Then
            GetRootFolder(XGX, Nothing)
        Else
            state = XGX.AxXGX.GetFileList(folder, listnum)
            If state = 0 Then
                DataGridView1.Rows.Clear()
                DataGridView1.RowTemplate.ReadOnly = False
                DataGridView1.ContextMenuStrip.Items.Item("ToolStripMenuItem_Backspace").Visible = True
                DataGridView1.ContextMenuStrip.Items.Item("ToolStripMenuItem_NewFolder").Visible = True
                DataGridView1.ContextMenuStrip.Items.Item("ToolStripMenuItem_Rename").Visible = True
                DataGridView1.ContextMenuStrip.Items.Item("ToolStripMenuItem_Delete").Visible = True
                DataGridView1.Columns.Item("Filesize").HeaderText = "Size"
                TextBox_Path.Text = folder
                If listnum = 1 Then 'exit if there are no list items
                    Form_Main.Log.AppendText(vbNewLine &
                        "The folder " & folder & " is empty" & vbNewLine)
                    DataGridView1.Rows.Add("", "This folder is empty.")
                    Return
                End If
                Dim index As Integer 'index for list items
                Dim name As String = "" 'file or folder name
                Dim kind As Short ' type (1: file, 0: folder, -1 if retrieval fails)
                Dim attr As Integer ' read attribute (1: read-only, 0 not read-only, -1 if retrieval fails)
                Dim dateTime As Date ' date of creation
                Dim size As Integer ' size (bytes)
                For index = 1 To listnum - 1
                    state = XGX.AxXGX.GetFileInfo(index, name, kind, attr, dateTime, size)
                    If state = 0 Then
                        If kind = 0 Then ' it's a folder
                            DataGridView1.Rows.Add("📁", name, "", dateTime, attr)
                        Else ' it's a file
                            size /= 1000
                            DataGridView1.Rows.Add("", name, size & " KB", dateTime, attr)
                        End If
                        If attr = 1 Then
                            Form_Main.Log.AppendText(vbNewLine & name & " is read-only")
                        End If
                        'Sort the folders up top
                        'DataGridView1.Sort(DataGridView1.Columns(0),
                        '                       ComponentModel.ListSortDirection.Descending)
                    Else
                        Form_Main.Log.SelectionColor = Color.Red
                        Form_Main.Log.AppendText(vbNewLine & "Failed to GetFileInfo of index: " &
                                                             index & " from XG-X Controller" & vbNewLine)
                        Form_Main.StateErrorHandling(state)
                    End If
                Next index
            Else
                Form_Main.Log.SelectionColor = Color.Red
                Form_Main.Log.AppendText(vbNewLine & "Failed to GetFileList(" & folder & ")" +
                                       " from XG-X Controller" & vbNewLine)
                Form_Main.StateErrorHandling(state)
                Return
            End If
        End If
        Form_Main.Log.ScrollToCaret()
    End Sub

    ''' <summary>
    ''' Tries to access the Current Row Item (folder/file)
    ''' </summary>
    Private Sub AccessElement(sender As Object, e As EventArgs) _
    Handles DataGridView1.CellDoubleClick, Button_Forward.Click
        With DataGridView1.CurrentRow
            If .Cells("Filetype").Value = "" Then ' a file was clicked
                ' download the file to temp folder and open the file
                Button_Download_Click(Me, e, Form_Main.tempFolder)
            Else ' "normal" folder selection
                'Form_Main.RichTextBox_Log.AppendText(vbNewLine +
                '                   "Trying to GetFileList(" &
                '                    TextBox_Path.Text & "\" & DataGridView1.SelectedCells.Item(1).Value & ")")
                GetFileList(TextBox_Path.Text & .Cells("Filename").Value & "\")
            End If
        End With
    End Sub

    ''' <summary>
    ''' Goes up one folder
    ''' </summary>
    Private Sub Button_Back_Click(sender As Object, e As EventArgs) Handles Button_Back.Click
        TextBox_Path.Text = TextBox_Path.Text.TrimEnd("\") ' Trim last=rightmost "\"
        If TextBox_Path.Text.Contains("\") Then
            ' There is still a "\" in the Path -> Remove anything right of it, but leave the "\" (that's why + 1)
            TextBox_Path.Text = TextBox_Path.Text.Remove(TextBox_Path.Text.LastIndexOf("\") + 1)
            'Form_Main.RichTextBox_Log.AppendText(vbNewLine + "Going back to " + TextBox_Path.Text)
            GetFileList(TextBox_Path.Text)
        Else ' There is no "\" left
            GetRootFolder(XGX, e)
        End If
    End Sub

    Private Sub Button_Delete_Click(sender As Object, e As EventArgs) Handles Button_Delete.Click
        If CheckBox_ConfirmDelete.Checked Then
            Dim toDelete As String = ""
            For Each Item As DataGridViewRow In DataGridView1.SelectedRows
                toDelete += Item.Cells("Filename").FormattedValue & vbNewLine
            Next
            If MsgBox("Are you sure you want to delete " & vbNewLine & toDelete & "?",
                      vbQuestion + vbYesNo + vbDefaultButton1,
                      "Confirm Delete") <> vbYes Then
                Return
            End If
        End If
        'Dim state As Integer
        Dim dstFile As String
        For Each Row As DataGridViewRow In DataGridView1.SelectedRows
            dstFile = "/" & TextBox_Path.Text.Remove(3, 1) & Row.Cells.Item("FileName").Value
            dstFile = dstFile.Replace("\", "/")

            Using ftp = New FtpClient(XGX.AxXGX.Address, cred)
                'ftp.Connect()
                'Form_Main.RichTextBox_Log.AppendText(vbNewLine & "Trying to delete " & vbNewLine &
                '                                     dstFile & vbNewLine &
                '                                     "from XG-X Controller" & vbNewLine)
                If DataGridView1.CurrentRow.Cells("Filetype").Value = "" Then ' it's a file
                    ftp.DeleteFile(dstFile)
                Else ' it's a folder
                    ftp.DeleteDirectory(dstFile)
                End If
            End Using

            'state = XGX.AxXGX.DeleteFile(dstFile)
            'Do While XGX.AxXGX.FileTransferBusy
            '    Application.DoEvents()
            'Loop
            'If state = 0 Then
            '    'Form_Main.RichTextBox_Log.AppendText(vbNewLine + "Succesfully deleted." + vbNewLine + dstFile + vbNewLine +
            '    '                   " from XG-X Controller" + vbNewLine)
            'Else
            '    Form_Main.RichTextBox_Log.SelectionColor = Color.Red
            '    Form_Main.RichTextBox_Log.AppendText(vbNewLine & "Failed to delete " & vbNewLine & dstFile & vbNewLine &
            '                       " from XG-X Controller" & vbNewLine)
            '    Form_Main.StateErrorHandling(state)
            'End If
        Next Row
        GetFileList(TextBox_Path.Text)
    End Sub

    Private Sub Button_Download_Click(sender As Object, e As EventArgs, Optional dstFolder As String = "") _
    Handles Button_Download.Click
        ' TODO: Download/Upload entire folders with FTP
        Dim srcFile, dstFile As String

        If dstFolder = "" Then ' user has to select folder
            FolderBrowserDialog1.ShowDialog()
            If FolderBrowserDialog1.SelectedPath = "" Then
                Return ' because user did not select a folder
            End If
        End If

        For Each Row As DataGridViewRow In DataGridView1.SelectedRows
            If dstFolder = "" Then ' user selected folder
                dstFile = FolderBrowserDialog1.SelectedPath & "\" & Row.Cells("FileName").Value
            Else ' Method was called with optional parameter dstFolder
                dstFile = dstFolder & "\" & Row.Cells("FileName").Value
            End If
            srcFile = TextBox_Path.Text & Row.Cells("FileName").Value
            'Form_Main.RichTextBox_Log.AppendText(vbNewLine & "Trying to Download " & vbNewLine & srcFile & vbNewLine &
            '                       "from XG-X Controller to PC directory " & vbNewLine & dstFile & vbNewLine)
            state = XGX.AxXGX.DownloadFile(srcFile, dstFile)
            Do While XGX.AxXGX.FileTransferBusy
                Application.DoEvents()
            Loop

            ' Quality peeps laden Fotos runter, Zeitstempel werden auf Downloadzeitpunkt gesetzt
            '   -> Zeitpunkt CREATED STANDARDMÄßig so lassen wie er auf dem Keyence Controller ist
            If (File.Exists(dstFile)) Then
                File.SetLastWriteTime(dstFile, Row.Cells("Last_Modified").Value)
            End If

            If Not dstFolder = "" Then ' Open the file
                Form_Main.Log.AppendText(
                    vbNewLine & "Opening file: " & vbNewLine & dstFile & vbNewLine)
                Try
                    Process.Start(dstFile)
                Catch ex As Exception ' Bring up the 'Windows cannot open this file' dialog
                    Dim P As New Process
                    P.StartInfo.FileName = "rundll32.exe"
                    P.StartInfo.Arguments = "shell32.dll,OpenAs_RunDLL " + dstFile
                    P.Start()
                End Try
            End If
        Next
    End Sub

    Private Sub Button_Upload_Click(sender As Object, e As EventArgs) Handles Button_Upload.Click
        OpenFileDialog1.ShowDialog()
        sender = Owner
        For Each srcFile In OpenFileDialog1.FileNames
            OpenFileDialog1.FileName = srcFile
            Dim dstFile = TextBox_Path.Text & OpenFileDialog1.SafeFileName
            'Form_Main.RichTextBox_Log.AppendText(vbNewLine + "Trying to Upload " + vbNewLine + srcFile + vbNewLine +
            '                       " from this PC to XG-X Controller directory " + vbNewLine + dstFile + vbNewLine)
            state = XGX.AxXGX.UploadFile(srcFile, dstFile)
            Do While XGX.AxXGX.FileTransferBusy
                Application.DoEvents()
            Loop
        Next srcFile
        GetFileList(TextBox_Path.Text)
    End Sub

    Private Sub ContextMenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) _
        Handles ContextMenuStrip_Files.ItemClicked
        If e.ClickedItem Is ToolStripMenuItem_Backspace Then
            Button_Back.PerformClick()
        ElseIf e.ClickedItem Is ToolStripMenuItem_Forward Then
            Button_Forward.PerformClick()
        ElseIf e.ClickedItem Is ToolStripMenuItem_Home Then
            Button_Home.PerformClick()
        ElseIf e.ClickedItem Is ToolStripMenuItem_Delete Then
            Button_Delete.PerformClick()
        ElseIf e.ClickedItem Is ToolStripMenuItem_NewFolder Then
            Using ftp = New FtpClient(XGX.AxXGX.Address, cred)
                ftp.Connect()
                Dim Path As String = "/" & TextBox_Path.Text.Remove(3, 1)
                Path = Path.Replace("\", "/")
                'conn.CreateDirectory("/SD2/xg/New Folder") 'works
                ftp.CreateDirectory(Path & "New Folder")
                GetFileList(TextBox_Path.Text)
            End Using
        ElseIf e.ClickedItem Is ToolStripMenuItem_Download Then
            Button_Download.PerformClick()
        ElseIf e.ClickedItem Is ToolStripMenuItem_Upload Then
            Button_Upload.PerformClick()
        ElseIf e.ClickedItem Is ToolStripMenuItem_Refresh Then
            GetFileList(TextBox_Path.Text)
        End If
    End Sub

    Private Sub DataGridView1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) _
        Handles DataGridView1.PreviewKeyDown
        Select Case e.KeyData
            Case Keys.Back
                Button_Back.PerformClick()
            Case Keys.Left
                Button_Back.PerformClick()
            Case Keys.Right
                Button_Forward.PerformClick()
            Case Keys.Enter
                Button_Forward.PerformClick()
            Case Keys.Delete
                Button_Delete.PerformClick()
            Case Keys.F5
                GetFileList(TextBox_Path.Text)
            Case Keys.Escape
                Me.Close()
            Case Keys.U
                Button_Upload.PerformClick()
            Case Keys.D
                Button_Download.PerformClick()
            Case Keys.H
                Button_Home.PerformClick()
        End Select
    End Sub

    ''' <summary>
    ''' Selects the Row the user right clicked
    ''' </summary>
    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) _
        Handles DataGridView1.CellMouseDown
        If (e.ColumnIndex > -1 And e.RowIndex > -1 And e.Button = Windows.Forms.MouseButtons.Right) Then
            DataGridView1.Rows(e.RowIndex).Selected = True
        End If
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) _
        Handles DataGridView1.CellEndEdit
        sender = Owner
        'Form_Main.RichTextBox_Log.AppendText(vbNewLine & "DataGridView1_CellEndEdit to" & vbNewLine &
        '    DataGridView1.CurrentCell.Value & vbNewLine &
        '    "e.ToString: " & e.ToString & vbNewLine &
        '    "sender.ToString: " & sender.ToString)
        Form_Main.Log.ScrollToCaret()

        If e.ColumnIndex = 1 Then
            Dim Path As String = TextBox_Path.Text.Remove(0, 5) ' remove first 5 chars "XXX:\" (e.g. "SD1:\")
            Path = Path.Replace("\", "/")
            Dim oldName As String = "ftp://" & XGX.AxXGX.Address & "/" & Path & response
            Dim newName As String = "ftp://" & XGX.AxXGX.Address & "/" & Path & DataGridView1.CurrentCell.Value
            'Renaming 
            'MessageBox.Show("oldName: ftp://" & XGX.AxXGX.Address & "/SD2/xg/setting" & vbNewLine &
            '                "newName: ftp://" & XGX.AxXGX.Address & "/SD2/xg/setting_" & Date.Now.Year & "_" & Date.Now.Month & "_" & Date.Now.Day)
            'Rename(XGX.AxXGX.Address, credentials,
            '       "ftp://" & XGX.AxXGX.Address & "/SD2/xg/setting",
            '       "ftp://" & XGX.AxXGX.Address & "/SD2/xg/setting_" & Date.Now.Year & "_" & Date.Now.Month & "_" & Date.Now.Day)

            'works
            'Rename(XGX.AxXGX.Address, credentials,
            '       "/SD2/xg/setting",
            '       "/SD2/xg/setting_" & Date.Now.Year & "_" & Date.Now.Month & "_" & Date.Now.Day)
            If TextBox_Path.Text.Contains("SD2") Then
                ' different behaviour needed bc of necessary "cd /SD2" command (no direct access to SD2 via a path)
                'doesn't work yet
                'ExecuteFTPCommand(XGX.AxXGX.Address, credentials, "cd /SD2") 'works in CMD, doesn't know the command when sent like this?!?!?!?
                'Rename(sender.AxXGX.Address, credentials, oldName, newName)

            Else ' SD1 is default dir

            End If
        End If
    End Sub

    Sub Rename(host As String, credentials As NetworkCredential, oldFullPath As String, newFullPath As String)
        Using conn = New FtpClient(host, credentials)
            conn.Connect()
            'conn.Rename("/full/or/relative/path/to/src", "/full/or/relative/path/to/dest")
            'conn.Rename(oldFullPath, newFullPath)
            MessageBox.Show("Was moved?" &
                            conn.MoveDirectory(oldFullPath, newFullPath, FtpRemoteExists.Overwrite))
        End Using
    End Sub

    Sub ExecuteFTPCommand(host As String, credentials As NetworkCredential, command As String)
        Using client = New FtpClient(host, credentials)
            client.Connect()
            ' Don't download BMP files as they take too long
            Dim rules = New List(Of FtpRule) From {
                    New FtpFileExtensionRule(False, New List(Of String) From { ' only allow PDF files
                        "bmp"
                    })}
            'New FtpSizeRule(FtpOperator.LessThan, 1000000000), ' only allow files <1 GB
            'client.DownloadDirectory(My.Computer.FileSystem.SpecialDirectories.Desktop, "xg/setting",
            '    Nothing, Nothing, Nothing, rules)
            'MessageBox.Show("/SD2/xg/setting_" & Date.Now.Year & "_" & Date.Now.Month & "_" & Date.Now.Day)
            client.UploadDirectoryAsync(My.Computer.FileSystem.SpecialDirectories.Desktop + "/SD1/xg/setting",
                                   "/SD2/xg/setting_" & Date.Now.Year & "_" & Date.Now.Month & "_" & Date.Now.Day)
            'client.DownloadDirectory(My.Computer.FileSystem.SpecialDirectories.Desktop, "xg/setting")
            'Dim reply As FtpReply = client.Execute(command)
            'MessageBox.Show("reply.Code: " & reply.Code & vbNewLine &
            '                "reply.Type: " & reply.Type.ToString & vbNewLine &
            '                "reply.Success? " & reply.Success & vbNewLine &
            '                "reply.ErrorMessage: " & reply.ErrorMessage & vbNewLine &
            '                "reply.InfoMessages: " & reply.InfoMessages & vbNewLine &
            '                "reply.Message: " & reply.Message)
        End Using
    End Sub


    Private Sub DataGridView1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) _
        Handles DataGridView1.CellBeginEdit
        response = DataGridView1.CurrentCell.Value
        Form_Main.Log.AppendText(vbNewLine & "Before edit: " & response)
    End Sub
End Class