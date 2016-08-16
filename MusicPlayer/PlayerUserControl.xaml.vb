'Imports System.Data
Public Class PlayerUserControl
    Dim IsPlaying As Boolean                    ' Is the song playing?
    Dim DatabaseCon As OleDb.OleDbConnection    ' Database connection
    Dim strDataSource As String                 ' Database file path
    Dim strConnectionString As String           ' Connection string for database connection
    Dim blnMenu As Boolean                      ' Is showing listbox Menu?

    Sub OnMouseDownOpenMenu(sender As Object, e As Windows.Input.MouseButtonEventArgs)
        ' Stop the song if it is playing
        MediaElement1.Stop()
        IsPlaying = False
        ' Swith between Song List and Menu
        If blnMenu = False Then                                 ' Showing Song List
            lstMenu.Visibility = Windows.Visibility.Visible
            lstSongs.Visibility = Windows.Visibility.Hidden
        Else                                                    ' Showing Menu List
            LoadSongList()
            lstMenu.Visibility = Windows.Visibility.Hidden
            lstSongs.Visibility = Windows.Visibility.Visible
        End If
        blnMenu = Not blnMenu
    End Sub

    Sub OnMouseDownPlayPause(sender As Object, e As Windows.Input.MouseButtonEventArgs)
        ' If Showing Menu List, this button's event behave as Select
        If blnMenu = True Then
            If lstMenu.SelectedIndex = 1 Then ' ADD SONG
                AddSong()
            ElseIf lstMenu.SelectedIndex = 2 Then ' EDIT SONG
                If lstSongs.SelectedIndex > 0 Then
                    EditSong(lstSongs.SelectedItem)
                End If
            ElseIf lstMenu.SelectedIndex = 3 Then ' REMOVE SONG
                If lstSongs.SelectedIndex > 0 Then
                    RemoveSong(lstSongs.SelectedItem)
                End If
                ' Clear the song location
                MediaElement1.Source = New Uri(Application.StartupPath)
            ElseIf lstMenu.SelectedIndex = 4 Then ' BACK
                lstMenu.Visibility = Windows.Visibility.Hidden
                lstSongs.Visibility = Windows.Visibility.Visible
                ' Reload the song list
                LoadSongList()
                blnMenu = False
            Else
                ' Do Nothing
            End If
        Else
            ' Play or Pause song if showing Song List
            MenuPlayPause()
        End If
    End Sub

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Show Song List by default
        blnMenu = False
    End Sub

    Public Sub LoadConfig()
        Try
            ' Get datasource from configuration file (MusicPlayer.exe.config inside debug folder) to construct Connection string
            Dim config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None)
            strDataSource = System.Configuration.ConfigurationManager.ConnectionStrings("datasource").ToString
            If strDataSource = "" Then
                ' If empty, set default value for datasource
                strDataSource = Application.StartupPath + "\data\dbSong.accdb"
                config.ConnectionStrings.ConnectionStrings("datasource").ConnectionString = strDataSource
                ' Save the value for datasource
                config.Save(System.Configuration.ConfigurationSaveMode.Minimal)
                ' Refresh the configuration section
                System.Configuration.ConfigurationManager.RefreshSection("connectionStrings")
            End If
            ' Construct Connection string
            strConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;"
            strConnectionString += "Data Source=" + strDataSource
            strConnectionString += ";Persist Security Info=False;"
            ' Get background image ( images/blue.jpg or images/black.jpg )
            Dim strBackground As String
            strBackground = System.Configuration.ConfigurationManager.AppSettings("background").ToString
            If strBackground <> "" Then
                Dim bmpImage As New System.Windows.Media.Imaging.BitmapImage
                bmpImage.BeginInit()
                bmpImage.UriSource = New Uri(strBackground, UriKind.Relative)
                bmpImage.EndInit()
                imgBackground.Source = bmpImage
            End If
        Catch ex As Exception
            MsgBox("Error loading configuration!", vbExclamation, "Music Player")
        End Try
    End Sub

    ' Go to Previous list
    Sub OnMouseDownGoPrevious(sender As Object, e As Windows.Input.MouseButtonEventArgs)
        Dim i As Integer
        If blnMenu = True Then
            i = lstMenu.SelectedIndex
            If i > 1 Then
                lstMenu.SelectedIndex = i - 1
            Else
                lstMenu.SelectedIndex = lstMenu.Items.Count - 1
            End If
        Else
            i = lstSongs.SelectedIndex
            If i > 1 Then
                lstSongs.SelectedIndex = i - 1
            Else
                lstSongs.SelectedIndex = lstSongs.Items.Count - 1
            End If
        End If
    End Sub

    ' Go to Next list
    Sub OnMouseDownGoNext(sender As Object, e As Windows.Input.MouseButtonEventArgs)
        Dim i As Integer
        If blnMenu = True Then
            i = lstMenu.SelectedIndex
            If i < lstMenu.Items.Count - 1 Then
                lstMenu.SelectedIndex = i + 1
            Else
                lstMenu.SelectedIndex = 1
            End If
        Else
            i = lstSongs.SelectedIndex
            If i < lstSongs.Items.Count - 1 Then
                lstSongs.SelectedIndex = i + 1
            Else
                lstSongs.SelectedIndex = 1
            End If
        End If
    End Sub

    ' Add song into playlist
    Private Sub AddSong()
        With MusicPlayerForm.OpenFileDialog1
            '.InitialDirectory = "C:\Users\Public\Music\Sample Music\"
            .FileName = ""
            .Multiselect = False
            .Filter = "MP3 files (*.mp3)|*.mp3|WMA files (*wma) |*.wma|All files (*.*)|*.*"
            .FilterIndex = 1
            If .ShowDialog() = DialogResult.OK Then
                'Dim strSongName As String
                '' User input unique Song name
                'strSongName = InputBox("Please enter a song title:", "Add song", "")
                'If strSongName = "" Then
                '    MsgBox("You has not specified a song title!", vbInformation)
                '    Exit Sub
                'End If
                ' Check song location in database
                If IsExistInDatabase(.FileName, True) = True Then
                    MsgBox("Song already exist in database!", vbInformation, "Add song")
                    Exit Sub
                End If
                InsertSongToDatabase(.SafeFileName, .FileName)
            End If
        End With
    End Sub

    ' Edit song in playlist
    Private Sub EditSong(strSongName As String)
        Dim strNewSongName As String
        strNewSongName = InputBox("Please enter song name:", "Edit Song Name", strSongName)
        If strNewSongName = strSongName Then
            Exit Sub
        End If
        If strNewSongName = "" Then
            MsgBox("You have not specified a song name!", vbInformation, "Edit song")
            Exit Sub
        End If
        If IsExistInDatabase(strNewSongName) = True Then
            MsgBox("Song name already exist in database!", vbInformation, "Edit song")
            Exit Sub
        End If
        UpdateSongInDatabase(strSongName, strNewSongName)
    End Sub

    ' Remove song from playlist
    Private Sub RemoveSong(strSongName As String)
        If strSongName = "" Then
            MsgBox("You have not selected any song!", vbInformation)
            Exit Sub
        End If
        ' Check whether the song is exist in database
        If IsExistInDatabase(strSongName) = False Then
            MsgBox("Song name not found in database!", vbInformation, "Remove song")
            Exit Sub
        End If
        ' Ask user to confirm remove song
        If MsgBoxResult.Yes = MsgBox("Are you sure to remove this song?", vbQuestion + vbYesNo, "Remove song: " + strSongName) Then
            DeleteSongFromDatabase(strSongName)
        End If
    End Sub

    ' Play or Pause the selected song
    Private Sub MenuPlayPause()
        If IsPlaying Then
            MediaElement1.Pause()
        Else
            MediaElement1.Play()
        End If
        IsPlaying = Not IsPlaying
    End Sub

    ' Load all songs from database into listbox
    Public Sub LoadSongList()
        Dim oleDBCmd As OleDb.OleDbCommand
        Dim oleDBReader As OleDb.OleDbDataReader
        Dim strSQL As String = "SELECT * FROM tbl_Songs"
        Dim lbiTitle As New System.Windows.Controls.ListBoxItem

        lstSongs.Items.Clear()
        With lbiTitle
            .Content = "SONG LIST"
            .FontSize = 18
            .FontWeight = System.Windows.FontWeights.Bold
            .IsEnabled = False
        End With
        ' Add a title with big font
        lstSongs.Items.Add(lbiTitle)
        Try
            DatabaseCon = New OleDb.OleDbConnection(strConnectionString)
            DatabaseCon.Open()
            oleDBCmd = New OleDb.OleDbCommand(strSQL, DatabaseCon)
            oleDBReader = oleDBCmd.ExecuteReader()
            While oleDBReader.Read()
                lstSongs.Items.Add(oleDBReader.Item("Song_Name"))
            End While
            lstSongs.SelectedIndex = lstSongs.Items.Count - 1
            oleDBReader.Close()
            oleDBCmd.Dispose()
            DatabaseCon.Close()
        Catch ex As Exception
            MsgBox("Error loading Song list!", vbExclamation, "Load song")
        End Try
    End Sub

    ' Get song file path from database
    Private Function GetSongLocation(strSongName As String) As String
        Dim oleDBCmd As OleDb.OleDbCommand
        Dim oleDBReader As OleDb.OleDbDataReader
        Dim strSQL As String = "SELECT Song_Location FROM tbl_Songs WHERE Song_Name = '" & strSongName & "'"
        Try
            DatabaseCon = New OleDb.OleDbConnection(strConnectionString)
            DatabaseCon.Open()
            oleDBCmd = New OleDb.OleDbCommand(strSQL, DatabaseCon)
            oleDBReader = oleDBCmd.ExecuteReader()
            While oleDBReader.Read
                Return oleDBReader.Item("Song_Location")
                Exit Function
            End While
            oleDBReader.Close()
            oleDBCmd.Dispose()
            DatabaseCon.Close()
            Return ""
        Catch ex As Exception
            MsgBox("Error getting song location!", vbExclamation, "Song location")
            Return ""
        End Try
    End Function

    ' Check whether the song with same name/location exist in database to prevent duplicate
    Private Function IsExistInDatabase(strSongName As String, Optional blnSongLocation As Boolean = False) As Boolean
        Dim oleDBCmd As OleDb.OleDbCommand
        Dim oleDBReader As OleDb.OleDbDataReader
        Dim strSQL As String
        Try
            DatabaseCon = New OleDb.OleDbConnection(strConnectionString)
            DatabaseCon.Open()
            If blnSongLocation = True Then
                strSQL = "SELECT * FROM tbl_Songs WHERE Song_Location = '" & strSongName & "'"
            Else
                strSQL = "SELECT * FROM tbl_Songs WHERE Song_Name = '" & strSongName & "'"
            End If
            oleDBCmd = New OleDb.OleDbCommand(strSQL, DatabaseCon)
            oleDBReader = oleDBCmd.ExecuteReader()
            If oleDBReader.Read Then
                Return True     ' Exist in database
            Else
                Return False    ' Not exist in database
            End If
            oleDBReader.Close()
            oleDBCmd.Dispose()
            DatabaseCon.Close()
        Catch ex As Exception
            MsgBox("Error in executing database command!", vbExclamation, "Check data")
            Return False
        End Try
    End Function

    ' Add song into database
    Private Sub InsertSongToDatabase(strSongName As String, strSongLocation As String)
        Dim oleDBCmd As OleDb.OleDbCommand
        Dim strSQL As String = "INSERT INTO tbl_Songs (Song_Name, Song_Location) VALUES ('" & strSongName & "','" & strSongLocation & "')"
        Try
            DatabaseCon = New OleDb.OleDbConnection(strConnectionString)
            DatabaseCon.Open()
            oleDBCmd = New OleDb.OleDbCommand(strSQL, DatabaseCon)
            oleDBCmd.ExecuteNonQuery()
            oleDBCmd.Dispose()
            DatabaseCon.Close()
            lstSongs.Items.Add(strSongName)
            MsgBox("New song added into database.", vbInformation, "Add song")
            lstSongs.SelectedIndex = lstSongs.Items.Count - 1
        Catch ex As Exception
            MsgBox("Error adding new song into database!", vbExclamation, "Add song")
        End Try
    End Sub

    ' Update song name in database
    Private Sub UpdateSongInDatabase(strOldSongName As String, strNewSongName As String)
        Dim oleDBCmd As OleDb.OleDbCommand
        Dim strSQL As String = "UPDATE tbl_Songs SET Song_Name = '" & strNewSongName & "' WHERE Song_Name = '" & strOldSongName & "'"
        Try
            DatabaseCon = New OleDb.OleDbConnection(strConnectionString)
            DatabaseCon.Open()
            oleDBCmd = New OleDb.OleDbCommand(strSQL, DatabaseCon)
            oleDBCmd.ExecuteNonQuery()
            oleDBCmd.Dispose()
            DatabaseCon.Close()
            MsgBox("Song name updated in database.", vbInformation, "Edit song name")
        Catch ex As Exception
            MsgBox("Error updating song name in database!", vbExclamation, "Edit song name")
        End Try
    End Sub

    ' Delete the song from database
    Private Sub DeleteSongFromDatabase(strSongName As String)
        Dim oleDBCmd As OleDb.OleDbCommand
        Dim strSQL As String = "DELETE * FROM tbl_Songs WHERE Song_Name = '" & strSongName & "'"
        Try
            DatabaseCon = New OleDb.OleDbConnection(strConnectionString)
            DatabaseCon.Open()
            oleDBCmd = New OleDb.OleDbCommand(strSQL, DatabaseCon)
            oleDBCmd.ExecuteNonQuery()
            oleDBCmd.Dispose()
            DatabaseCon.Close()
            MsgBox("Song removed from database.", vbInformation, "Remove song")
        Catch ex As Exception
            MsgBox("Error removing song from database!", vbExclamation, "Remove song")
        End Try
    End Sub

    ' Select song file path to play
    Private Sub lstSongs_SelectionChanged(sender As Object, e As Windows.Controls.SelectionChangedEventArgs) Handles lstSongs.SelectionChanged
        Dim strSongLocation As String
        If lstSongs.SelectedIndex > 0 Then
            strSongLocation = GetSongLocation(lstSongs.SelectedItem)
            If strSongLocation <> "" Then
                MediaElement1.Source = New Uri(strSongLocation)
            End If
        End If
    End Sub

    ' Play next song when finished playing current song
    Private Sub MediaElement1_MediaEnded(sender As Object, e As Windows.RoutedEventArgs) Handles MediaElement1.MediaEnded
        Dim i As Integer
        i = lstSongs.SelectedIndex
        If i < lstSongs.Items.Count - 1 Then
            lstSongs.SelectedIndex = i + 1
        Else
            lstSongs.SelectedIndex = 1
        End If
    End Sub
End Class
