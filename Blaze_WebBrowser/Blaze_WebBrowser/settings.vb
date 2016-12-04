Public Class settings
    Private Sub settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Text = My.Settings.CustomSearchEngine
        If My.Settings.SearchEngine = 1 Then
            RadioButton1.Checked = True
        End If
        If My.Settings.SearchEngine = 2 Then
            RadioButton2.Checked = True
        End If
        If My.Settings.SearchEngine = 3 Then
            RadioButton3.Checked = True
        End If
        If My.Settings.SearchEngine = 4 Then
            RadioButton4.Checked = True
        End If
        If My.Settings.SearchEngine = 5 Then
            RadioButton5.Checked = True
        End If
        If My.Settings.SearchEngine = 6 Then
            RadioButton6.Checked = True
        End If
        If My.Settings.NewTab = 1 Then
            RadioButton7.Checked = True
        End If
        If My.Settings.NewTab = 2 Then
            RadioButton8.Checked = True
        End If
        TextBox1.Text = My.Settings.HomePage
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text.Contains("http://") Or TextBox2.Text.Contains("https://") Or TextBox2.Text.Contains("http://www.") Or TextBox2.Text.Contains("https://www.") Or TextBox2.Text.Contains("http://www") Or TextBox2.Text.Contains("https://www") Then
            My.Settings.HomePage = TextBox1.Text
            MsgBox("Done")
        Else : MsgBox("Insert a valid URL")
        End If
        MsgBox("Done")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Settings.HomePage = ("http://www.google.com")
        MsgBox("Done")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Visible = False
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        My.Settings.SearchEngine = 1
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        My.Settings.SearchEngine = 2
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        My.Settings.SearchEngine = 3
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        My.Settings.SearchEngine = 4
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        My.Settings.SearchEngine = 5
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        My.Settings.SearchEngine = 6
        My.Settings.CustomSearchEngine = TextBox2.Text.ToString
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If My.Settings.SearchEngine = 6 Then
            If TextBox2.Text.Contains("http://") Or TextBox2.Text.Contains("https://") Or TextBox2.Text.Contains("http://www.") Or TextBox2.Text.Contains("https://www.") Or TextBox2.Text.Contains("http://www") Or TextBox2.Text.Contains("https://www") Then
                My.Settings.CustomSearchEngine = TextBox2.Text
                MsgBox("Done")
            Else : MsgBox("Insert a valid URL")
            End If
        ElseIf Not My.Settings.SearchEngine = 6 Then
            MsgBox("Select Custom search first")
            My.Settings.SearchEngine = 1
            RadioButton1.Checked = True
        End If
    End Sub

    Private Sub RadioButton7_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton7.CheckedChanged
        My.Settings.NewTab = 1
    End Sub

    Private Sub RadioButton8_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton8.CheckedChanged
        My.Settings.NewTab = 2
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        My.Settings.HomePage = ("http://www.google.com")
        TextBox1.Text = My.Settings.HomePage
        My.Settings.SearchEngine = 1
        My.Settings.NewTab = 1
        My.Settings.CustomSearchEngine = Nothing
        TextBox2.Text = Nothing
        MsgBox("Done")
    End Sub
End Class