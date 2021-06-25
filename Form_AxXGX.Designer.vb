<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_AxXGX
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_AxXGX))
        Me.AxXGX = New AxXGXLib.AxXGX()
        CType(Me.AxXGX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AxXGX
        '
        Me.AxXGX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxXGX.Enabled = True
        Me.AxXGX.Location = New System.Drawing.Point(0, 0)
        Me.AxXGX.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AxXGX.Name = "AxXGX"
        Me.AxXGX.OcxState = CType(resources.GetObject("AxXGX.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxXGX.Size = New System.Drawing.Size(1128, 846)
        Me.AxXGX.TabIndex = 37
        '
        'Form_AxXGX
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1381, 846)
        Me.Controls.Add(Me.AxXGX)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form_AxXGX"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        CType(Me.AxXGX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents AxXGX As AxXGXLib.AxXGX
End Class
