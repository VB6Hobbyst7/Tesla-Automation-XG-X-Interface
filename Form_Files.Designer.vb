<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Files
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Files))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Button_Home = New System.Windows.Forms.Button()
        Me.Button_Forward = New System.Windows.Forms.Button()
        Me.CheckBox_ConfirmDelete = New System.Windows.Forms.CheckBox()
        Me.Button_Delete = New System.Windows.Forms.Button()
        Me.Button_Download = New System.Windows.Forms.Button()
        Me.TextBox_Path = New System.Windows.Forms.TextBox()
        Me.Button_Back = New System.Windows.Forms.Button()
        Me.Label_Path = New System.Windows.Forms.Label()
        Me.Button_Upload = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.FileType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FileName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FileSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Last_Modified = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Read_Only = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ContextMenuStrip_Files = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem_Backspace = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Forward = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Download = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Upload = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Home = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Rename = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Refresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_NewFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip_Files.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_Home
        '
        resources.ApplyResources(Me.Button_Home, "Button_Home")
        Me.Button_Home.ForeColor = System.Drawing.Color.Transparent
        Me.Button_Home.Name = "Button_Home"
        Me.Button_Home.UseVisualStyleBackColor = False
        '
        'Button_Forward
        '
        resources.ApplyResources(Me.Button_Forward, "Button_Forward")
        Me.Button_Forward.ForeColor = System.Drawing.Color.Transparent
        Me.Button_Forward.Name = "Button_Forward"
        Me.Button_Forward.UseVisualStyleBackColor = False
        '
        'CheckBox_ConfirmDelete
        '
        resources.ApplyResources(Me.CheckBox_ConfirmDelete, "CheckBox_ConfirmDelete")
        Me.CheckBox_ConfirmDelete.Checked = True
        Me.CheckBox_ConfirmDelete.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_ConfirmDelete.ForeColor = System.Drawing.Color.Transparent
        Me.CheckBox_ConfirmDelete.Name = "CheckBox_ConfirmDelete"
        Me.CheckBox_ConfirmDelete.UseVisualStyleBackColor = True
        '
        'Button_Delete
        '
        resources.ApplyResources(Me.Button_Delete, "Button_Delete")
        Me.Button_Delete.ForeColor = System.Drawing.Color.Transparent
        Me.Button_Delete.Name = "Button_Delete"
        Me.Button_Delete.UseVisualStyleBackColor = False
        '
        'Button_Download
        '
        resources.ApplyResources(Me.Button_Download, "Button_Download")
        Me.Button_Download.ForeColor = System.Drawing.Color.Transparent
        Me.Button_Download.Name = "Button_Download"
        Me.Button_Download.UseVisualStyleBackColor = False
        '
        'TextBox_Path
        '
        Me.TextBox_Path.BackColor = System.Drawing.Color.Black
        Me.TextBox_Path.ForeColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.TextBox_Path, "TextBox_Path")
        Me.TextBox_Path.Name = "TextBox_Path"
        '
        'Button_Back
        '
        resources.ApplyResources(Me.Button_Back, "Button_Back")
        Me.Button_Back.ForeColor = System.Drawing.Color.Transparent
        Me.Button_Back.Name = "Button_Back"
        Me.Button_Back.UseVisualStyleBackColor = False
        '
        'Label_Path
        '
        resources.ApplyResources(Me.Label_Path, "Label_Path")
        Me.Label_Path.BackColor = System.Drawing.Color.Black
        Me.Label_Path.ForeColor = System.Drawing.Color.Transparent
        Me.Label_Path.Name = "Label_Path"
        '
        'Button_Upload
        '
        resources.ApplyResources(Me.Button_Upload, "Button_Upload")
        Me.Button_Upload.ForeColor = System.Drawing.Color.Transparent
        Me.Button_Upload.Name = "Button_Upload"
        Me.Button_Upload.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        resources.ApplyResources(Me.DataGridView1, "DataGridView1")
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.Black
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FileType, Me.FileName, Me.FileSize, Me.Last_Modified, Me.Read_Only})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip_Files
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.GridColor = System.Drawing.Color.Black
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Black
        Me.DataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Gray
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Black
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.DataGridView1.RowTemplate.Height = 18
        Me.DataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Tag = ""
        '
        'FileType
        '
        Me.FileType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        resources.ApplyResources(Me.FileType, "FileType")
        Me.FileType.Name = "FileType"
        Me.FileType.ReadOnly = True
        '
        'FileName
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        Me.FileName.DefaultCellStyle = DataGridViewCellStyle3
        resources.ApplyResources(Me.FileName, "FileName")
        Me.FileName.Name = "FileName"
        Me.FileName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'FileSize
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.FileSize.DefaultCellStyle = DataGridViewCellStyle4
        resources.ApplyResources(Me.FileSize, "FileSize")
        Me.FileSize.Name = "FileSize"
        Me.FileSize.ReadOnly = True
        '
        'Last_Modified
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle5.Format = "g"
        DataGridViewCellStyle5.NullValue = Nothing
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.Last_Modified.DefaultCellStyle = DataGridViewCellStyle5
        resources.ApplyResources(Me.Last_Modified, "Last_Modified")
        Me.Last_Modified.Name = "Last_Modified"
        Me.Last_Modified.ReadOnly = True
        Me.Last_Modified.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Read_Only
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Gray
        DataGridViewCellStyle6.NullValue = False
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        Me.Read_Only.DefaultCellStyle = DataGridViewCellStyle6
        Me.Read_Only.FalseValue = "0"
        resources.ApplyResources(Me.Read_Only, "Read_Only")
        Me.Read_Only.Name = "Read_Only"
        Me.Read_Only.ReadOnly = True
        Me.Read_Only.TrueValue = "1"
        '
        'ContextMenuStrip_Files
        '
        Me.ContextMenuStrip_Files.BackColor = System.Drawing.Color.Black
        Me.ContextMenuStrip_Files.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip_Files.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_Backspace, Me.ToolStripMenuItem_Forward, Me.ToolStripMenuItem_Download, Me.ToolStripMenuItem_Upload, Me.ToolStripMenuItem_Home, Me.ToolStripMenuItem_Delete, Me.ToolStripMenuItem_Rename, Me.ToolStripMenuItem_Refresh, Me.ToolStripMenuItem_NewFolder})
        Me.ContextMenuStrip_Files.Name = "ContextMenuStrip1"
        resources.ApplyResources(Me.ContextMenuStrip_Files, "ContextMenuStrip_Files")
        '
        'ToolStripMenuItem_Backspace
        '
        Me.ToolStripMenuItem_Backspace.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Backspace.Name = "ToolStripMenuItem_Backspace"
        resources.ApplyResources(Me.ToolStripMenuItem_Backspace, "ToolStripMenuItem_Backspace")
        '
        'ToolStripMenuItem_Forward
        '
        Me.ToolStripMenuItem_Forward.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Forward.Name = "ToolStripMenuItem_Forward"
        resources.ApplyResources(Me.ToolStripMenuItem_Forward, "ToolStripMenuItem_Forward")
        '
        'ToolStripMenuItem_Download
        '
        Me.ToolStripMenuItem_Download.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Download.Name = "ToolStripMenuItem_Download"
        resources.ApplyResources(Me.ToolStripMenuItem_Download, "ToolStripMenuItem_Download")
        '
        'ToolStripMenuItem_Upload
        '
        Me.ToolStripMenuItem_Upload.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Upload.Name = "ToolStripMenuItem_Upload"
        resources.ApplyResources(Me.ToolStripMenuItem_Upload, "ToolStripMenuItem_Upload")
        '
        'ToolStripMenuItem_Home
        '
        Me.ToolStripMenuItem_Home.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Home.Name = "ToolStripMenuItem_Home"
        resources.ApplyResources(Me.ToolStripMenuItem_Home, "ToolStripMenuItem_Home")
        '
        'ToolStripMenuItem_Delete
        '
        Me.ToolStripMenuItem_Delete.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Delete.Name = "ToolStripMenuItem_Delete"
        resources.ApplyResources(Me.ToolStripMenuItem_Delete, "ToolStripMenuItem_Delete")
        '
        'ToolStripMenuItem_Rename
        '
        Me.ToolStripMenuItem_Rename.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Rename.Name = "ToolStripMenuItem_Rename"
        resources.ApplyResources(Me.ToolStripMenuItem_Rename, "ToolStripMenuItem_Rename")
        '
        'ToolStripMenuItem_Refresh
        '
        Me.ToolStripMenuItem_Refresh.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Refresh.Name = "ToolStripMenuItem_Refresh"
        resources.ApplyResources(Me.ToolStripMenuItem_Refresh, "ToolStripMenuItem_Refresh")
        '
        'ToolStripMenuItem_NewFolder
        '
        Me.ToolStripMenuItem_NewFolder.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_NewFolder.Name = "ToolStripMenuItem_NewFolder"
        resources.ApplyResources(Me.ToolStripMenuItem_NewFolder, "ToolStripMenuItem_NewFolder")
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Multiselect = True
        resources.ApplyResources(Me.OpenFileDialog1, "OpenFileDialog1")
        '
        'Form_Files
        '
        Me.AllowDrop = True
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.Button_Home)
        Me.Controls.Add(Me.Button_Forward)
        Me.Controls.Add(Me.CheckBox_ConfirmDelete)
        Me.Controls.Add(Me.Button_Delete)
        Me.Controls.Add(Me.Button_Download)
        Me.Controls.Add(Me.TextBox_Path)
        Me.Controls.Add(Me.Button_Back)
        Me.Controls.Add(Me.Label_Path)
        Me.Controls.Add(Me.Button_Upload)
        Me.Controls.Add(Me.DataGridView1)
        Me.KeyPreview = True
        Me.Name = "Form_Files"
        Me.ShowIcon = False
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip_Files.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button_Home As System.Windows.Forms.Button
    Friend WithEvents Button_Forward As System.Windows.Forms.Button
    Friend WithEvents CheckBox_ConfirmDelete As System.Windows.Forms.CheckBox
    Friend WithEvents Button_Delete As System.Windows.Forms.Button
    Friend WithEvents Button_Download As System.Windows.Forms.Button
    Friend WithEvents TextBox_Path As System.Windows.Forms.TextBox
    Friend WithEvents Button_Back As System.Windows.Forms.Button
    Friend WithEvents Label_Path As System.Windows.Forms.Label
    Friend WithEvents Button_Upload As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ContextMenuStrip_Files As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem_Backspace As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Download As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Forward As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Home As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Upload As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Refresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Rename As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_NewFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileType As DataGridViewTextBoxColumn
    Friend WithEvents FileName As DataGridViewTextBoxColumn
    Friend WithEvents FileSize As DataGridViewTextBoxColumn
    Friend WithEvents Last_Modified As DataGridViewTextBoxColumn
    Friend WithEvents Read_Only As DataGridViewCheckBoxColumn
End Class
