Imports Awesomium.Core

Public Class tab
    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        settings.Show()
    End Sub

    Private Sub tab_Load(sender As Object, e As EventArgs) Handles Me.Load
        WebControl1.Source = New Uri(My.Settings.HomePage)
    End Sub

    Private Sub ButtonHome_Click(sender As Object, e As EventArgs) Handles ButtonHome.Click
        WebControl1.Source = New Uri(My.Settings.HomePage)
    End Sub

    Private Sub Button_Back_Click(sender As Object, e As EventArgs) Handles Button_Back.Click
        If WebControl1.CanGoBack Then
            WebControl1.GoBack()
        End If
    End Sub

    Private Sub Button_Forward_Click(sender As Object, e As EventArgs) Handles Button_Forward.Click
        If WebControl1.CanGoForward Then
            WebControl1.GoForward()
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox1.Text.Contains(".com") Or TextBox1.Text.Contains(".net") Or TextBox1.Text.Contains(".gr") Or TextBox1.Text.Contains(".org") Or TextBox1.Text.Contains(".gov") Or TextBox1.Text.Contains(".edu") Then
                Try
                    WebControl1.Source = New Uri(TextBox1.Text)
                Catch ex As System.UriFormatException
                    WebControl1.Source = New Uri("http://" + TextBox1.Text)
                    TextBox1.Text = ("http://" + TextBox1.Text)
                End Try
            Else
                If My.Settings.SearchEngine = 1 Then
                    WebControl1.Source = New Uri("https://www.google.gr/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=" + TextBox1.Text)
                End If
                If My.Settings.SearchEngine = 2 Then
                    WebControl1.Source = New Uri("https://www.bing.com/search?q=" + TextBox1.Text)
                End If
                If My.Settings.SearchEngine = 3 Then
                    WebControl1.Source = New Uri("https://www.youtube.com/results?search_query=" + TextBox1.Text)
                End If
                If My.Settings.SearchEngine = 4 Then
                    WebControl1.Source = New Uri("https://www.facebook.com/search/top/?q=" + TextBox1.Text)
                End If
                If My.Settings.SearchEngine = 5 Then
                    WebControl1.Source = New Uri("https://twitter.com/search?q=" + TextBox1.Text)
                End If
                If My.Settings.SearchEngine = 6 Then
                    WebControl1.Source = New Uri(My.Settings.CustomSearchEngine + TextBox1.Text)
                End If
            End If
        End If
    End Sub
    Private Sub WebControl1_LoadingFrameComplete(sender As Object, e As FrameEventArgs) Handles WebControl1.LoadingFrameComplete
        Button_ReloadStop.BackgroundImage = My.Resources.blazerefresh
        PictureBox1.Visible = False
        Parent.Text = WebControl1.Title
        TextBox1.Text = WebControl1.Source.ToString
    End Sub

    Private Sub WebControl1_LoadingFrame(sender As Object, e As LoadingFrameEventArgs) Handles WebControl1.LoadingFrame
        Button_ReloadStop.BackgroundImage = My.Resources.blazestop
        PictureBox1.Visible = True
    End Sub

    Private Sub AddTabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddTabToolStripMenuItem.Click
        If My.Settings.NewTab = 1 Then
            Dim tab As New TabPage
            Dim newtab As New tab
            newtab.Show()
            newtab.Dock = DockStyle.Fill
            newtab.TopLevel = False
            tab.Controls.Add(newtab)
            Form1.TabControl1.TabPages.Add(tab)
            Form1.TabControl1.SelectedTab = tab
        End If
        If My.Settings.NewTab = 2 Then
            Dim tab As New TabPage
            Dim newtab As New tab
            newtab.Show()
            newtab.Dock = DockStyle.Fill
            newtab.TopLevel = False
            tab.Controls.Add(newtab)
            Form1.TabControl1.TabPages.Add(tab)
        End If
    End Sub

    Private Sub Button_ReloadStop_Click(sender As Object, e As EventArgs) Handles Button_ReloadStop.Click
        If WebControl1.IsNavigating Then
            WebControl1.Stop()
            PictureBox1.Visible = False
            Parent.Text = "About:Blank"
            Button_ReloadStop.Text = "R"
        End If
        If Not WebControl1.IsNavigating Then
            WebControl1.Reload(ignoreCache:=True)
            If TextBox1.Text.Contains(".com") Or TextBox1.Text.Contains(".net") Or TextBox1.Text.Contains(".gr") Or TextBox1.Text.Contains(".org") Or TextBox1.Text.Contains(".gov") Or TextBox1.Text.Contains(".edu") Then
                Try
                    WebControl1.Source = New Uri(TextBox1.Text)
                Catch ex As System.UriFormatException
                    WebControl1.Source = New Uri("http://" + TextBox1.Text)
                    TextBox1.Text = ("http://" + TextBox1.Text)
                End Try
            Else
                If My.Settings.SearchEngine = 1 Then
                    WebControl1.Source = New Uri("https://www.google.gr/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=" + TextBox1.Text)
                End If
                If My.Settings.SearchEngine = 2 Then
                    WebControl1.Source = New Uri("https://www.bing.com/search?q=" + TextBox1.Text)
                End If
                If My.Settings.SearchEngine = 3 Then
                    WebControl1.Source = New Uri("https://www.youtube.com/results?search_query=" + TextBox1.Text)
                End If
                If My.Settings.SearchEngine = 4 Then
                    WebControl1.Source = New Uri("https://www.facebook.com/search/top/?q=" + TextBox1.Text)
                End If
                If My.Settings.SearchEngine = 5 Then
                    WebControl1.Source = New Uri("https://twitter.com/search?q=" + TextBox1.Text)
                End If
                If My.Settings.SearchEngine = 6 Then
                    WebControl1.Source = New Uri(My.Settings.CustomSearchEngine + TextBox1.Text)
                End If
            End If
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        about.Show()
    End Sub

    Private Sub CloseTabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseTabToolStripMenuItem.Click
        If Form1.TabControl1.TabCount = 1 Then
            Dim tab As New TabPage
            Dim newtab As New tab
            newtab.Show()
            newtab.Dock = DockStyle.Fill
            newtab.TopLevel = False
            tab.Controls.Add(newtab)
            Form1.TabControl1.TabPages.Add(tab)
            Form1.TabControl1.SelectedTab = tab
            Form1.TabControl1.SelectedTab.Dispose()
        Else : Form1.TabControl1.SelectedTab.Dispose()
        End If
    End Sub
End Class