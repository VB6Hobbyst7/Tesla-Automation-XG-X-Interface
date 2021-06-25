Public Class Form_AxXGX

    Sub OnFileTransferred(sender As Object, e As AxXGXLib._DXGXEvents_OnFileTransferredEvent) _
        Handles AxXGX.OnFileTransferred
        Dim strKind As String 'type of file transfer
        If e.kind = 0 Then
            strKind = "Download"
        Else
            strKind = "Upload"
        End If
        If e.state = 0 Then 'processing if this method succeeds
            Form_Main.Log.SelectionColor = Color.LawnGreen
            Form_Main.Log.AppendText(vbNewLine & strKind & " successfully completed")
        Else
            Form_Main.Log.SelectionColor = Color.Red
            Form_Main.Log.AppendText(vbNewLine & strKind & " failed")
            Form_Main.StateErrorHandling(e.state)
        End If
    End Sub

    Sub OnCommandFinished(sender As Object, e As AxXGXLib._DXGXEvents_OnCommandFinishedEvent) _
        Handles AxXGX.OnCommandFinished
        If e.state = 0 Then
            'Form_Main.Log.SelectionColor = Color.LawnGreen
            'Form_Main.Log.AppendText(vbNewLine & e.command & " successfully completed")
            'Form_Main.Log.SelectionColor = Color.White
        Else
            Form_Main.Log.SelectionColor = Color.Red
            Form_Main.Log.AppendText(vbNewLine & e.command & " failed")
            Form_Main.StateErrorHandling(e.state)
        End If
    End Sub

    Sub Form_AxXGX_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Tag.Cells("PosX").Value = Location.X
        Tag.Cells("PosY").Value = Location.Y
        Form_Main.Disconnect(Tag)
    End Sub
End Class