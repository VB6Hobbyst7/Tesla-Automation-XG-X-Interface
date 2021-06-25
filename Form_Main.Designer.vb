<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Main
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Main))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button_ClearLog = New System.Windows.Forms.Button()
        Me.Log = New System.Windows.Forms.RichTextBox()
        Me.Button_SaveLog = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Overview = New System.Windows.Forms.DataGridView()
        Me.IP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Connection = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Autoconnect = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Files = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Timezone = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Program = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.PosX = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PosY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Backup_Btn = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Restore_btn = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.BackupToRestore = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ContextMenuStrip_Main = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem_Reset = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Reboot = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Backup = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Restore = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem_GetTime = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_GetProgram = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Overview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_ClearLog
        '
        Me.Button_ClearLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.Button_ClearLog.ForeColor = System.Drawing.Color.Transparent
        Me.Button_ClearLog.Location = New System.Drawing.Point(8, 376)
        Me.Button_ClearLog.Name = "Button_ClearLog"
        Me.Button_ClearLog.Size = New System.Drawing.Size(136, 44)
        Me.Button_ClearLog.TabIndex = 35
        Me.Button_ClearLog.Text = "Clear Log"
        Me.Button_ClearLog.UseVisualStyleBackColor = False
        '
        'Log
        '
        Me.Log.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Log.BackColor = System.Drawing.Color.Black
        Me.Log.EnableAutoDragDrop = True
        Me.Log.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Log.ForeColor = System.Drawing.Color.Transparent
        Me.Log.Location = New System.Drawing.Point(8, 426)
        Me.Log.Name = "Log"
        Me.Log.ReadOnly = True
        Me.Log.Size = New System.Drawing.Size(544, 419)
        Me.Log.TabIndex = 34
        Me.Log.Text = ""
        '
        'Button_SaveLog
        '
        Me.Button_SaveLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.Button_SaveLog.ForeColor = System.Drawing.Color.Transparent
        Me.Button_SaveLog.Location = New System.Drawing.Point(150, 376)
        Me.Button_SaveLog.Name = "Button_SaveLog"
        Me.Button_SaveLog.Size = New System.Drawing.Size(136, 44)
        Me.Button_SaveLog.TabIndex = 36
        Me.Button_SaveLog.Text = "Save Log"
        Me.Button_SaveLog.UseVisualStyleBackColor = False
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.FileName = """XG-X_Interface_Log_"" + Date.Today.ToShortDateString"
        Me.SaveFileDialog1.Filter = """TextFile (*.txt;*.rtf)|*.txt;*.rtf|All Files (*.*)|*.*"""
        '
        'Overview
        '
        Me.Overview.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.Overview.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Overview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Overview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Overview.BackgroundColor = System.Drawing.Color.Black
        Me.Overview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        Me.Overview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Overview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Overview.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IP, Me.Connection, Me.Autoconnect, Me.Files, Me.DateTime, Me.Timezone, Me.Program, Me.PosX, Me.PosY, Me.Backup_Btn, Me.Restore_btn, Me.BackupToRestore})
        Me.Overview.ContextMenuStrip = Me.ContextMenuStrip_Main
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Overview.DefaultCellStyle = DataGridViewCellStyle12
        Me.Overview.Dock = System.Windows.Forms.DockStyle.Top
        Me.Overview.EnableHeadersVisualStyles = False
        Me.Overview.GridColor = System.Drawing.Color.Black
        Me.Overview.Location = New System.Drawing.Point(0, 0)
        Me.Overview.MultiSelect = False
        Me.Overview.Name = "Overview"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Overview.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.Overview.RowHeadersVisible = False
        Me.Overview.RowHeadersWidth = 51
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White
        Me.Overview.RowsDefaultCellStyle = DataGridViewCellStyle14
        Me.Overview.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Black
        Me.Overview.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Gray
        Me.Overview.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Black
        Me.Overview.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.Overview.RowTemplate.Height = 18
        Me.Overview.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Overview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Overview.ShowCellErrors = False
        Me.Overview.ShowRowErrors = False
        Me.Overview.Size = New System.Drawing.Size(1467, 370)
        Me.Overview.TabIndex = 40
        Me.Overview.Tag = ""
        '
        'IP
        '
        Me.IP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle3.Format = "###.###.###.###"
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        Me.IP.DefaultCellStyle = DataGridViewCellStyle3
        Me.IP.HeaderText = "XG-X IP Address"
        Me.IP.MaxInputLength = 15
        Me.IP.MinimumWidth = 6
        Me.IP.Name = "IP"
        Me.IP.Width = 174
        '
        'Connection
        '
        Me.Connection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle4.NullValue = "Connect"
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.Connection.DefaultCellStyle = DataGridViewCellStyle4
        Me.Connection.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Connection.HeaderText = "Connection"
        Me.Connection.MinimumWidth = 6
        Me.Connection.Name = "Connection"
        Me.Connection.ReadOnly = True
        Me.Connection.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Connection.Text = "Connect"
        Me.Connection.Width = 106
        '
        'Autoconnect
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle5.NullValue = False
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.Autoconnect.DefaultCellStyle = DataGridViewCellStyle5
        Me.Autoconnect.HeaderText = "Autoconnect"
        Me.Autoconnect.MinimumWidth = 6
        Me.Autoconnect.Name = "Autoconnect"
        Me.Autoconnect.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Autoconnect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Autoconnect.Width = 138
        '
        'Files
        '
        Me.Files.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle6.NullValue = "📁"
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        Me.Files.DefaultCellStyle = DataGridViewCellStyle6
        Me.Files.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Files.HeaderText = "Files"
        Me.Files.MinimumWidth = 6
        Me.Files.Name = "Files"
        Me.Files.ReadOnly = True
        Me.Files.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Files.Width = 53
        '
        'DateTime
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle7.Format = "F"
        DataGridViewCellStyle7.NullValue = Nothing
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        Me.DateTime.DefaultCellStyle = DataGridViewCellStyle7
        Me.DateTime.HeaderText = "Date and Time"
        Me.DateTime.MinimumWidth = 6
        Me.DateTime.Name = "DateTime"
        Me.DateTime.Width = 156
        '
        'Timezone
        '
        Me.Timezone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Red
        Me.Timezone.DefaultCellStyle = DataGridViewCellStyle8
        Me.Timezone.DisplayStyleForCurrentCellOnly = True
        Me.Timezone.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Timezone.HeaderText = "Timezone"
        Me.Timezone.Items.AddRange(New Object() {"GMT-12:00", "GMT-11:00", "GMT-10:00", "GMT-9:00", "GMT-8:00", "GMT-7:00", "GMT-6:00", "GMT-5:00", "GMT-4:30", "GMT-4:00", "GMT-3:30", "GMT-3:00", "GMT-2:00", "GMT-1:00", "GMT, UTC", "GMT+1:00", "GMT+2:00", "GMT+3:00", "GMT+3:30", "GMT+4:00", "GMT+4:30", "GMT+5:00", "GMT+5:30", "GMT+5:45", "GMT+6:00", "GMT+6:30", "GMT+7:00", "GMT+8:00", "GMT+9:00", "GMT+9:30", "GMT+10:00", "GMT+11:00", "GMT+12:00", "GMT+13:00"})
        Me.Timezone.MaxDropDownItems = 35
        Me.Timezone.MinimumWidth = 6
        Me.Timezone.Name = "Timezone"
        Me.Timezone.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Timezone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Timezone.Width = 116
        '
        'Program
        '
        Me.Program.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Red
        Me.Program.DefaultCellStyle = DataGridViewCellStyle9
        Me.Program.DisplayStyleForCurrentCellOnly = True
        Me.Program.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Program.HeaderText = "Program"
        Me.Program.MinimumWidth = 6
        Me.Program.Name = "Program"
        Me.Program.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Program.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Program.Width = 106
        '
        'PosX
        '
        Me.PosX.HeaderText = "Position X"
        Me.PosX.MinimumWidth = 6
        Me.PosX.Name = "PosX"
        Me.PosX.Visible = False
        Me.PosX.Width = 125
        '
        'PosY
        '
        Me.PosY.HeaderText = "Position Y"
        Me.PosY.MinimumWidth = 6
        Me.PosY.Name = "PosY"
        Me.PosY.Visible = False
        Me.PosY.Width = 99
        '
        'Backup_Btn
        '
        Me.Backup_Btn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle10.NullValue = "Backup"
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White
        Me.Backup_Btn.DefaultCellStyle = DataGridViewCellStyle10
        Me.Backup_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Backup_Btn.HeaderText = "Backup"
        Me.Backup_Btn.MinimumWidth = 6
        Me.Backup_Btn.Name = "Backup_Btn"
        Me.Backup_Btn.ReadOnly = True
        Me.Backup_Btn.Text = ""
        Me.Backup_Btn.Width = 81
        '
        'Restore_btn
        '
        Me.Restore_btn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle11.NullValue = "Restore"
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White
        Me.Restore_btn.DefaultCellStyle = DataGridViewCellStyle11
        Me.Restore_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Restore_btn.HeaderText = "Restore"
        Me.Restore_btn.MinimumWidth = 6
        Me.Restore_btn.Name = "Restore_btn"
        Me.Restore_btn.ReadOnly = True
        Me.Restore_btn.Width = 84
        '
        'BackupToRestore
        '
        Me.BackupToRestore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.BackupToRestore.DisplayStyleForCurrentCellOnly = True
        Me.BackupToRestore.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BackupToRestore.HeaderText = "Available Backups"
        Me.BackupToRestore.MaxDropDownItems = 35
        Me.BackupToRestore.MinimumWidth = 6
        Me.BackupToRestore.Name = "BackupToRestore"
        Me.BackupToRestore.ToolTipText = "Please choose from which Backup you want to restore:"
        Me.BackupToRestore.Visible = False
        Me.BackupToRestore.Width = 125
        '
        'ContextMenuStrip_Main
        '
        Me.ContextMenuStrip_Main.BackColor = System.Drawing.Color.Black
        Me.ContextMenuStrip_Main.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip_Main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_Reset, Me.ToolStripMenuItem_Reboot, Me.ToolStripMenuItem_Backup, Me.ToolStripMenuItem_Restore, Me.ToolStripMenuItem_Delete, Me.ToolStripSeparator1, Me.ToolStripMenuItem_GetTime, Me.ToolStripMenuItem_GetProgram})
        Me.ContextMenuStrip_Main.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip_Main.Size = New System.Drawing.Size(186, 206)
        '
        'ToolStripMenuItem_Reset
        '
        Me.ToolStripMenuItem_Reset.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Reset.Name = "ToolStripMenuItem_Reset"
        Me.ToolStripMenuItem_Reset.ShortcutKeyDisplayString = ""
        Me.ToolStripMenuItem_Reset.Size = New System.Drawing.Size(185, 28)
        Me.ToolStripMenuItem_Reset.Text = "Reset"
        '
        'ToolStripMenuItem_Reboot
        '
        Me.ToolStripMenuItem_Reboot.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Reboot.Name = "ToolStripMenuItem_Reboot"
        Me.ToolStripMenuItem_Reboot.ShortcutKeyDisplayString = ""
        Me.ToolStripMenuItem_Reboot.Size = New System.Drawing.Size(185, 28)
        Me.ToolStripMenuItem_Reboot.Text = "Reboot"
        '
        'ToolStripMenuItem_Backup
        '
        Me.ToolStripMenuItem_Backup.BackColor = System.Drawing.Color.Black
        Me.ToolStripMenuItem_Backup.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Backup.Name = "ToolStripMenuItem_Backup"
        Me.ToolStripMenuItem_Backup.ShortcutKeyDisplayString = ""
        Me.ToolStripMenuItem_Backup.Size = New System.Drawing.Size(185, 28)
        Me.ToolStripMenuItem_Backup.Text = "Backup"
        '
        'ToolStripMenuItem_Restore
        '
        Me.ToolStripMenuItem_Restore.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Restore.Name = "ToolStripMenuItem_Restore"
        Me.ToolStripMenuItem_Restore.ShortcutKeyDisplayString = ""
        Me.ToolStripMenuItem_Restore.Size = New System.Drawing.Size(185, 28)
        Me.ToolStripMenuItem_Restore.Text = "Restore"
        '
        'ToolStripMenuItem_Delete
        '
        Me.ToolStripMenuItem_Delete.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Delete.Name = "ToolStripMenuItem_Delete"
        Me.ToolStripMenuItem_Delete.ShortcutKeyDisplayString = ""
        Me.ToolStripMenuItem_Delete.Size = New System.Drawing.Size(185, 28)
        Me.ToolStripMenuItem_Delete.Text = "Delete"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(182, 6)
        '
        'ToolStripMenuItem_GetTime
        '
        Me.ToolStripMenuItem_GetTime.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_GetTime.Name = "ToolStripMenuItem_GetTime"
        Me.ToolStripMenuItem_GetTime.ShortcutKeyDisplayString = ""
        Me.ToolStripMenuItem_GetTime.Size = New System.Drawing.Size(185, 28)
        Me.ToolStripMenuItem_GetTime.Text = "Get Time"
        '
        'ToolStripMenuItem_GetProgram
        '
        Me.ToolStripMenuItem_GetProgram.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_GetProgram.Name = "ToolStripMenuItem_GetProgram"
        Me.ToolStripMenuItem_GetProgram.ShortcutKeyDisplayString = ""
        Me.ToolStripMenuItem_GetProgram.Size = New System.Drawing.Size(185, 28)
        Me.ToolStripMenuItem_GetProgram.Text = "Get Programs"
        '
        'Form_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1467, 845)
        Me.Controls.Add(Me.Overview)
        Me.Controls.Add(Me.Button_SaveLog)
        Me.Controls.Add(Me.Button_ClearLog)
        Me.Controls.Add(Me.Log)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Form_Main"
        Me.Text = "Tesla Automation XG-X Interface"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Overview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip_Main.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button_ClearLog As System.Windows.Forms.Button
    Friend WithEvents Log As System.Windows.Forms.RichTextBox
    Friend WithEvents Button_SaveLog As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Overview As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip_Main As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem_Reset As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Reboot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Restore As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_GetTime As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem_GetProgram As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Backup As ToolStripMenuItem
    Friend WithEvents IP As DataGridViewTextBoxColumn
    Friend WithEvents Connection As DataGridViewButtonColumn
    Friend WithEvents Autoconnect As DataGridViewCheckBoxColumn
    Friend WithEvents Files As DataGridViewButtonColumn
    Friend WithEvents DateTime As DataGridViewTextBoxColumn
    Friend WithEvents Timezone As DataGridViewComboBoxColumn
    Friend WithEvents Program As DataGridViewComboBoxColumn
    Friend WithEvents PosX As DataGridViewTextBoxColumn
    Friend WithEvents PosY As DataGridViewTextBoxColumn
    Friend WithEvents Backup_Btn As DataGridViewButtonColumn
    Friend WithEvents Restore_btn As DataGridViewButtonColumn
    Friend WithEvents BackupToRestore As DataGridViewComboBoxColumn
End Class