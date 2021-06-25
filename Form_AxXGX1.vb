Public Class Form_AxXGX1

    Public FileTransferBusy As Boolean = False

    Public Sub OnFileTransferred(sender As Object, e As AxXGXLib._DXGXEvents_OnFileTransferredEvent) _
        Handles AxXGX1.OnFileTransferred
        FileTransferBusy = False
        Dim strKind As String 'type of file transfer
        If e.kind = 0 Then
            strKind = "Download"
        Else
            strKind = "Upload"
        End If
        If e.state = 0 Then 'processing if this method succeeds
            Form_Main.RichTextBox_Log.AppendText(vbNewLine + strKind & " successfully completed")
        Else
            Form_Main.stateErrorHandling(e.state)
        End If
        Form_Files.GetFileList(Form_Files.TextBox_Path.Text)
    End Sub
End Class