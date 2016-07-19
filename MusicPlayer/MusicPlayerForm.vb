Public Class MusicPlayerForm

    Private Sub MusicPlayerForm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle     ' Enable control to move form, minimize to taskbar and exit
        Opacity = "1"       ' Solid form
    End Sub

    Private Sub MusicPlayerForm_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        FormBorderStyle = Windows.Forms.FormBorderStyle.None             ' Hide the form controls
        Opacity = "0.8"     ' Transparency effect
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub MusicPlayerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load background and Connection string
        PlayerUserControl1.LoadConfig()
        ' Load all songs from database to Song List
        PlayerUserControl1.LoadSongList()
    End Sub
End Class
