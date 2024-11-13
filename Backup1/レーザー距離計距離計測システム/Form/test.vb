Public Class test

    Private Sub test_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        For i As Integer = 0 To 100
            Me.TextBox1.AppendText("aaaaaaaaaaaaaaaaaaaaaaa" & vbCrLf)
            Me.TextBox2.AppendText("aaaaaaaaaaaaaaaaaaaaaaa" & vbCrLf)
        Next

        Me.TextBox2.SelectionStart = Me.TextBox2.Text.Length
        Me.TextBox2.Focus()
        Me.TextBox2.ScrollToCaret()

    End Sub

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus, TextBox2.GotFocus
        Me.TextBox1.SelectionStart = Me.TextBox1.Text.Length
        'Me.TextBox1.SelectionStart = 1
        Me.TextBox1.Focus()
        Me.TextBox1.ScrollToCaret()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.TextBox2.SelectionStart = 1
        Me.TextBox2.ScrollToCaret()

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Me.TextBox2.SelectionStart = Me.TextBox2.Text.Length
        Me.TextBox2.ScrollToCaret()

    End Sub
End Class