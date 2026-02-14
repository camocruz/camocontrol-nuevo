Public Class NumericTextBox
    Inherits TextBox

    Public Event EnterPressed(value As Integer)

    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        MyBase.OnKeyDown(e)

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If Me.Text <> "" Then
                RaiseEvent EnterPressed(CInt(Me.Text))
            End If
        End If
    End Sub

    Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
        MyBase.OnKeyPress(e)

        If Char.IsControl(e.KeyChar) Then Return

        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class
