<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_AxXGX1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_AxXGX1))
        Me.AxXGX1 = New AxXGXLib.AxXGX()
        CType(Me.AxXGX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AxXGX1
        '
        Me.AxXGX1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxXGX1.Enabled = True
        Me.AxXGX1.Location = New System.Drawing.Point(0, 0)
        Me.AxXGX1.Name = "AxXGX1"
        Me.AxXGX1.OcxState = CType(resources.GetObject("AxXGX1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxXGX1.Size = New System.Drawing.Size(1276, 957)
        Me.AxXGX1.TabIndex = 37
        '
        'Form_AxXGX1
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1323, 958)
        Me.Controls.Add(Me.AxXGX1)
        Me.KeyPreview = True
        Me.Name = "Form_AxXGX1"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Form1"
        CType(Me.AxXGX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents AxXGX1 As AxXGXLib.AxXGX
End Class
