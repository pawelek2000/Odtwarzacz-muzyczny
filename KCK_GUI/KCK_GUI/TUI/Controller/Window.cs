using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KCK_GUI.MVVM.Model;
using KCK_GUI.TUI.View;
using KCK_GUI.TUI.View.Templates;

namespace KCK_GUI.TUI.Controller
{
    class Window
    {
        #region Stałe
        private static string BUTTON_SEARCH_BUTTON = "SearchButton";
        private static string BUTTON_PLAYLIST_BUTTON = "PlayListButton";
        private static string BUTTON_FAVOURITE_BUTTON = "FavouriteButton";
        private static string BUTTON_PREVIOUS_BUTTON = "PreviousButton";
        private static string BUTTON_PLAY_BUTTON = "PlayButton";
        private static string BUTTON_NEXT_BUTTON = "NextButton";
        private static string BUTTON_VOLUME_UP_BUTTON = "VolumeUpButton";
        private static string BUTTON_VOLUME_DOWN_BUTTON = "VolumeDownButton";
        private static string BUTTON_FAVOURITEPLAYLIST = "FavouritePlayList";
        private static string BUTTON_PLAYLIST1 = "playList1";
        private static string BUTTON_PLAYLIST2 = "playList2";
        private static string BUTTON_PLAYLIST3 = "playList3";
        private static string BUTTON_PLAYLIST4 = "playList4";
        private static string BUTTON_PLAYLIST5 = "playList5";
        private static string BUTTON_PLAYLIST6 = "playList6";
        private static string BUTTON_PLAYLIST7 = "playList7";
        private static string BUTTON_PLAYLIST8 = "playList8";
        private static string BUTTON_PLAYLIST9 = "playList9";
        private static string BUTTON_SEARCHRESULT = "SearchResult";
        private static string BUTTON_PLAYLISTRESULT = "PlaylistResult";

        private static string BUTTON_SEARCHSONG_BUTTON = "SearchAddMusicButton";
        private static string BUTTON_NEXTSONG_BUTTON = "NextSongButton";
        private static string BUTTON_PLAYSONG_BUTTON = "PlaySongButton";
        private static string BUTTON_PREVSONG_BUTTON = "PrevSongButton";
        private static string BUTTON_DELETESONG_BUTTON = "DeleteSongButton";
        private static string BUTTON_SONG_BUTTON = "SongButton";

        private static string LABEL_SONGLABEL = "SongLabel";
        

        private static string LABEL_SONGNAME = "SongName";
        private static string LABEL_CURRENTTIME = "CurrentTime";
        private static string LABEL_SONGTIME = "SongTime";
        private static string LABEL_VOLUME = "VoluMe";
        private static string PROGRESBAR_PROGERSBAR = "ProgressBar";
        private static string SEARCHBOX_MAIN_SEARCHBOX = "MainSearchBox";
        private static string SEARCHBOX_PLAYLIST_SEARCHBOX = "PlaylistSearchBox";
        
        #endregion
        #region Zmienne
        public MPlayer Player { get; set; }
        public List<ViewTamplate> Views { get; set; }
        public ViewTamplate currentView { get; set; }
        public ViewTamplate previousView { get; set; }
        public List<MusicFile> musicFiles { get; set; }
        public  string playListPath { get; set; }
        public  string SearchBoxText { get; set; }
        public  MusicFile CurrentSong { get; set; }
        public int PlaylistSongIndex { get; set; }
        public int Volume { get; set; }
        #endregion
        #region Konstruktor
        public Window(){

            Volume = 50;
            
            Console.CursorVisible = false;
            Views = new List<ViewTamplate>();
            Player = new MPlayer();
            Player.SetVolume(Volume);
            // usunąć
            musicFiles = MusicFile.GetMusicFiles();
            CurrentSong = musicFiles[0];
            
            SearchBoxText = "";
            playListPath = "";
            Player.Open(CurrentSong.MusicPath);
            //
            Console.SetWindowSize(76, 60);
            Console.SetBufferSize(76, 60);
            Views.Add(new MainBackground());
            Views.Add(new PlaylistView());
            Views.Add(new MainSearchView());
            Views.Add(new SearchResultsView());
            Views.Add(new PlaylistSearchView());
            Views.Add(new PlaylistResultView());
            Views.Add(new PlaylistManageView());
        }
        #endregion
        #region Kreator
        public void Create() {
            SetCallbacks();
            previousView = Views[0];
            currentView = Views[0];
            currentView.SetPervView(previousView);
            Views[0].PutText(CurrentSong.Title, LABEL_SONGNAME);
            Views[0].PutText(Player.SongTime(), LABEL_SONGTIME);
            var temp = MusicFile.GetPlaylist("Data/fav.json");
            if (temp.Find(p => p.MusicPath == CurrentSong.MusicPath) != null)
            {
                Views[0].SetConsoleColor(ConsoleColor.DarkRed, BUTTON_FAVOURITE_BUTTON); 
            }
            Views[0].SwitchSelectMode();
            Views[0].Show();
            Views[1].Show();
            Views[2].Show();
            //Views[4].Show();
            // usunac
            //(Views[6] as PlaylistManageView).ButtonList(8);
            //Views[6].Show();
            //
            Thread thread1 = new Thread(TimeWatcher);
            thread1.Start();
            Thread thread2 = new Thread(SearchThread);
            thread2.Start();
            while (true) {
                Move();
            }
        }
        #endregion
        #region Interakcja
        private void Move() {
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
            
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow: {
                        currentView.MoveCursor(0, -1);
                        break;
                }
                case ConsoleKey.DownArrow:
                    {
                        currentView.MoveCursor(0, 1);
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        currentView.MoveCursor(-1, 0);
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        currentView.MoveCursor(1, 0);
                        break;
                    }
                case ConsoleKey.Enter: {
                        currentView.OnClick();
                    break;
                }


                case ConsoleKey.Escape: {
                        if (currentView.Equals(Views[0]))
                        {
                            currentView.SwitchSelectMode();
                            currentView = currentView.GetPervView();
                            currentView.SwitchSelectMode();
                        }
                        else if (currentView.Equals(currentView.GetPervView()))
                        {
                            currentView.SwitchSelectMode();
                            currentView = Views[0];
                            previousView = Views[0];
                            currentView.SwitchSelectMode();
                            (Views[3] as SearchResultsView).ClearMidBox();
                        }
                        else {
                            currentView.SwitchSelectMode();
                            if (currentView.Equals(Views[2]))
                                (Views[3] as SearchResultsView).ClearMidBox();
                            else if (currentView.Equals(Views[4]))
                            {
                                (Views[4] as PlaylistSearchView).ClearMidBox();
                                (Views[5] as PlaylistResultView).ClearMidBox();
                                currentView = currentView.GetPervView(); ;
                                currentView.SwitchSelectMode();
                                (Views[6] as PlaylistManageView).ClearMidBox();
                            }
                            else if (currentView.Equals(Views[6]))
                                (Views[6] as PlaylistManageView).ClearMidBox();
                            

                            
                            currentView =currentView.GetPervView();
                            currentView.SwitchSelectMode();
                           
                        }

                        break;    
                }
            }
        }
       
        public void WriteText(ViewTamplate view,string TEXTBOX)
        {

            SearchBoxText = "";

            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                if ((Char.ToUpper(consoleKeyInfo.KeyChar) >= 'A' && Char.ToUpper(consoleKeyInfo.KeyChar) <= 'Z' || consoleKeyInfo.Key == ConsoleKey.Spacebar) || consoleKeyInfo.KeyChar >= '0' && consoleKeyInfo.KeyChar <= '9')
                {
                    SearchBoxText += consoleKeyInfo.KeyChar;
                    currentView.PutText(SearchBoxText, TEXTBOX);

                }
                else if (consoleKeyInfo.Key == ConsoleKey.Backspace && SearchBoxText.Length > 0)
                {
                    SearchBoxText = SearchBoxText.Remove(SearchBoxText.Length - 1);
                    currentView.PutText(SearchBoxText, TEXTBOX);

                }
                else if (consoleKeyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (consoleKeyInfo.Key == ConsoleKey.Escape)
                {
                    currentView.SwitchSelectMode();
                    if (currentView.Equals(Views[2]))
                        (Views[3] as SearchResultsView).ClearMidBox();

                    else if (currentView.Equals(Views[4]))
                    {
                        (Views[5] as PlaylistResultView).ClearMidBox();
                        (Views[4] as PlaylistSearchView).ClearMidBox();
                       
                    }
                   
                    currentView = currentView.GetPervView();
                    currentView.SwitchSelectMode();
                   

                    break;
                }
            }
        }
        #endregion
        #region SetCallbacks
        private void PlaylistCallbacks() {
            SetCallback(BUTTON_SEARCHSONG_BUTTON, PlaylistSearchButton_OnClick);
            if (musicFiles.Count > 0) {
                SetCallback(BUTTON_NEXTSONG_BUTTON, NextSongOnPlaylist);
                SetCallback(BUTTON_PLAYSONG_BUTTON, PlayPlaylistSong);
                SetCallback(BUTTON_PREVSONG_BUTTON, PrevSongOnPlaylist);
                SetCallback(BUTTON_DELETESONG_BUTTON, DeletePlaylistSong);
                SetCallback(BUTTON_SONG_BUTTON, PlaylistSearchButton_OnClick);
            }
           
        }
        private void SetCallbacks() {
            currentView = Views[0];
            SetCallback(BUTTON_PLAYLIST_BUTTON, MyPlayList_OnClick);
            SetCallback(BUTTON_SEARCH_BUTTON, SearchButton_OnClick);

            SetCallback(BUTTON_FAVOURITE_BUTTON, SerceBolesne);
            SetCallback(BUTTON_PREVIOUS_BUTTON, PlayPrev_OnClick);

            SetCallback(BUTTON_PLAY_BUTTON, PlayPause_OnClick);

            SetCallback(BUTTON_NEXT_BUTTON, PlayNext_OnClick);

            SetCallback(BUTTON_VOLUME_UP_BUTTON, VolumeUp_OnClick);
            SetCallback(BUTTON_VOLUME_DOWN_BUTTON, VolumeDown_OnClick);

            currentView = Views[1];
            SetCallback(BUTTON_FAVOURITEPLAYLIST, favourite_OnClick);
            SetCallback(BUTTON_PLAYLIST1, PlayList1_OnClick);
            SetCallback(BUTTON_PLAYLIST2, PlayList2_OnClick);
            SetCallback(BUTTON_PLAYLIST3, PlayList3_OnClick);
            SetCallback(BUTTON_PLAYLIST4, PlayList4_OnClick);
            SetCallback(BUTTON_PLAYLIST5, PlayList5_OnClick);
            SetCallback(BUTTON_PLAYLIST6, PlayList6_OnClick);
            SetCallback(BUTTON_PLAYLIST7, PlayList7_OnClick);
            SetCallback(BUTTON_PLAYLIST8, PlayList8_OnClick);
            SetCallback(BUTTON_PLAYLIST9, PlayList9_OnClick);

            currentView = Views[2];
            SetCallback(SEARCHBOX_MAIN_SEARCHBOX, SearchText_OnClick);

            
            
        }
            private void SetCallback(string name, EventHandler handler)
        {
            currentView.SetCallback(name, handler);
        }
        #endregion
        #region Guziki
        #region Zarządanie Playlista
        public void MyPlayList_OnClick(object sender, EventArgs args)
        {
            previousView = currentView;
            currentView = Views[1];
            currentView.SetPervView(previousView);
            previousView.SwitchSelectMode();
            currentView.SwitchSelectMode();

        }
        #region Otwieranie Playlisty
        public void PlayList1_OnClick(object sender, EventArgs args)
        {
            
            playListPath = @"Data\p1.json";
            LoadPlaylist();
          
        }
        public void PlayList2_OnClick(object sender, EventArgs args)
        {
            
            playListPath = @"Data\p2.json";
            LoadPlaylist();
          
        }
        public void PlayList3_OnClick(object sender, EventArgs args)
        {
            
            playListPath = @"Data\p3.json";
            LoadPlaylist();
        
        }
        public void PlayList4_OnClick(object sender, EventArgs args)
        {
            
            playListPath = @"Data\p4.json";
            LoadPlaylist();
           
        }
        public void PlayList5_OnClick(object sender, EventArgs args)
        {
            
            playListPath = @"Data\p5.json";
            LoadPlaylist();
          
        }
        public void PlayList6_OnClick(object sender, EventArgs args)
        {
            
            playListPath = @"Data\p6.json";
            LoadPlaylist();
          
        }
        public void PlayList7_OnClick(object sender, EventArgs args)
        {
            
            playListPath = @"Data\p7.json";
            LoadPlaylist();
            
        }
        public void PlayList8_OnClick(object sender, EventArgs args)
        {
            
            playListPath = @"Data\p8.json";
            LoadPlaylist();
          
        }
        public void PlayList9_OnClick(object sender, EventArgs args)
        {
            
            playListPath = @"Data\p9.json";
            LoadPlaylist();
          
        }
        public void favourite_OnClick(object sender, EventArgs args)
        {
            
            playListPath = @"Data\fav.json";
            LoadPlaylist();
          
        }
        #endregion
   
        public void NextSongOnPlaylist(object sender, EventArgs args) {
            (Views[6] as PlaylistManageView).ButtonList(musicFiles.Count);
            
            if ((PlaylistSongIndex + 1) >= musicFiles.Count())
                PlaylistSongIndex = 0;
            else
                PlaylistSongIndex++;

            if ((Views[6] as PlaylistManageView).ButtonListCount() > 0)
                Views[6].PutText(musicFiles[PlaylistSongIndex].Title, BUTTON_SONG_BUTTON);
            for (int i = 1; i < (Views[6] as PlaylistManageView).ButtonListCount(); i++)
            {
                Views[6].Clear(LABEL_SONGLABEL + (i));
                Views[6].PutText(musicFiles[(PlaylistSongIndex + i) % musicFiles.Count()].Title, LABEL_SONGLABEL + (i));
            }
            
            PlaylistCallbacks();
        }
        public void PrevSongOnPlaylist(object sender, EventArgs args)
        {
            (Views[6] as PlaylistManageView).ButtonList(musicFiles.Count);
            
            if ((PlaylistSongIndex - 1) < 0)
                PlaylistSongIndex = musicFiles.Count()-1;
            else
                PlaylistSongIndex--;

            if ((Views[6] as PlaylistManageView).ButtonListCount() > 0)
            {
                Views[6].Clear(BUTTON_SONG_BUTTON);
                Views[6].PutText(musicFiles[PlaylistSongIndex].Title, BUTTON_SONG_BUTTON);
            }
            for(int i = 1; i< (Views[6] as PlaylistManageView).ButtonListCount(); i++)
            {
                Views[6].Clear(LABEL_SONGLABEL + (i));
                Views[6].PutText(musicFiles[(PlaylistSongIndex + i)%musicFiles.Count()].Title, LABEL_SONGLABEL + (i));
            }

        
            PlaylistCallbacks();
        }
        public void SerceBolesne(object sender, EventArgs args) {
            var temp = MusicFile.GetPlaylist("Data/fav.json");
            if (temp.Find(p => p.MusicPath == CurrentSong.MusicPath) != null)
            {
                Views[0].SetConsoleColor(ConsoleColor.Gray, BUTTON_FAVOURITE_BUTTON);
                MusicFile.DeleteMusic(CurrentSong, "Data/fav.json");
            }
            else
            {
                Views[0].SetConsoleColor(ConsoleColor.DarkRed, BUTTON_FAVOURITE_BUTTON);
                MusicFile.AddMusic(CurrentSong, "Data/fav.json");
            }
            Views[0].Print(BUTTON_FAVOURITE_BUTTON);
        }
        public void DeletePlaylistSong(object sender, EventArgs args) {
            (Views[6] as PlaylistManageView).ClearMidBoxButton();
            if (musicFiles.Count() != 0)
            {
                MusicFile.DeleteMusic(musicFiles[PlaylistSongIndex], playListPath);
                musicFiles = MusicFile.GetPlaylist(playListPath);
                if (musicFiles.Count() == 0)
                {
                    
                    currentView.SwitchSelectMode();
                    currentView = currentView.GetPervView();
                    currentView.SwitchSelectMode();
                    (Views[6] as PlaylistManageView).ClearMidBox();
                }
                else
                {
                    (Views[6] as PlaylistManageView).ButtonList(musicFiles.Count);

                    if ((PlaylistSongIndex - 1) < 0)
                        PlaylistSongIndex = musicFiles.Count() - 1;
                    else
                        PlaylistSongIndex--;

                    if ((Views[6] as PlaylistManageView).ButtonListCount() > 0)
                    {
                        Views[6].Clear(BUTTON_SONG_BUTTON);
                        Views[6].PutText(musicFiles[PlaylistSongIndex].Title, BUTTON_SONG_BUTTON);
                    }
                    for (int i = 1; i < (Views[6] as PlaylistManageView).ButtonListCount(); i++)
                    {
                        Views[6].Clear(LABEL_SONGLABEL + (i));
                        Views[6].PutText(musicFiles[(PlaylistSongIndex + i) % musicFiles.Count()].Title, LABEL_SONGLABEL + (i));
                    }

                    PlaylistCallbacks();
                }
            }
        }
        public void PlayPlaylistSong(object sender, EventArgs args) {
            Player.Stop();
            CurrentSong = musicFiles[PlaylistSongIndex];
            Player.Open(musicFiles[PlaylistSongIndex].MusicPath);
            PlayNew();
        }
        #endregion
        #region Zarządanie muzyką
        public void PlayNext_OnClick(object sender, EventArgs args)
        {
            if (playListPath.Length != 0)
                musicFiles = MusicFile.GetPlaylist(playListPath);
            if (playListPath.Length != 0 && musicFiles.Count == 0)
                musicFiles = MusicFile.GetMusicFiles();
            if (musicFiles.Count > musicFiles.IndexOf(musicFiles.Find(p => p.MusicPath == CurrentSong.MusicPath)) + 1)
                CurrentSong = musicFiles[(musicFiles.IndexOf(musicFiles.Find(p => p.MusicPath == CurrentSong.MusicPath)) + 1)];
            else
                CurrentSong = musicFiles[0];
            Player.Stop();
            Player.Open(CurrentSong.MusicPath);
            PlayNew();
        }
        public void PlayPrev_OnClick(object sender, EventArgs args)
        {
            if (playListPath.Length != 0)
                musicFiles = MusicFile.GetPlaylist(playListPath);
            if (playListPath.Length != 0 && musicFiles.Count==0)
                musicFiles = MusicFile.GetMusicFiles();
            if (0 <= musicFiles.IndexOf(musicFiles.Find(p => p.MusicPath == CurrentSong.MusicPath)) - 1)
                CurrentSong = musicFiles[(musicFiles.IndexOf(musicFiles.Find(p => p.MusicPath == CurrentSong.MusicPath))) - 1];
            else
                CurrentSong = musicFiles[musicFiles.Count - 1];
            Player.Stop();
            Player.Open(CurrentSong.MusicPath);
            PlayNew();
        }
        public void PlayPause_OnClick(object sender, EventArgs args) {
            if (Player.play)
            {
                Player.Pause();
                currentView.PutText("► ", BUTTON_PLAY_BUTTON);
                

            }

            else
            {
                Player.Play();
                currentView.PutText("||", BUTTON_PLAY_BUTTON);
            }
           
        }
        public void VolumeUp_OnClick(object sender, EventArgs args) {
            Volume += 5;
            Player.SetVolume(Volume);
        }
        public void VolumeDown_OnClick(object sender, EventArgs args)
        {
            Volume -= 5;
            Player.SetVolume(Volume);
        }
        #endregion
        #region Zarządanie Wyszukiwaniem
        public void SearchButton_OnClick(object sender, EventArgs args)
        {
            previousView = currentView;
            currentView = Views[2];
            currentView.SetPervView(previousView);
            previousView.SwitchSelectMode();
            currentView.SwitchSelectMode();
            WriteText(currentView,SEARCHBOX_MAIN_SEARCHBOX);

        }
        public void SearchText_OnClick(object sender, EventArgs args) {
            if ((Views[3] as SearchResultsView).ButtonListCount() !=0 ) {
                previousView = currentView;
                currentView = Views[3];
                currentView.SetPervView(previousView);

                previousView.SwitchSelectMode();
                currentView.SwitchSelectMode();
            }

        }
        public void PlayFromSearch(object sender, EventArgs args)
        {
            musicFiles = MusicFile.GetMusicFiles();
            CurrentSong = musicFiles.Find(p => p.Title == (sender as Button).Text);
            Player.Stop();
            Player.Open(CurrentSong.MusicPath);
            PlayNew();
            playListPath = "";
        }
        public void PlaylistSearchButton_OnClick(object sender, EventArgs args)
        {
            previousView = currentView;
            currentView = Views[4];
            currentView.SetPervView(previousView);
            previousView.SwitchSelectMode();
            currentView.SwitchSelectMode();
            SetCallback(SEARCHBOX_PLAYLIST_SEARCHBOX, PlaylistSearchText_OnClick);
            WriteText(currentView, SEARCHBOX_PLAYLIST_SEARCHBOX);

        }
        public void PlaylistSearchText_OnClick(object sender, EventArgs args)
        {
            if ((Views[5] as PlaylistResultView).ButtonListCount() != 0)
            {
                previousView = currentView;
                currentView = Views[5];
                currentView.SetPervView(previousView);

                previousView.SwitchSelectMode();
                currentView.SwitchSelectMode();
            }

        }
        public void AddToPlaylist(object sender, EventArgs args)
        {
            musicFiles = MusicFile.GetMusicFiles();
            CurrentSong = musicFiles.Find(p => p.Title == (sender as Button).Text);
            musicFiles = MusicFile.GetPlaylist(playListPath);
            MusicFile.AddMusic(CurrentSong, playListPath);
        }
        #endregion
        public void Empty_OnClick(object sender, EventArgs args)
        {

        }
        #endregion
        #region Pozostałe
        public void PlayNew()
        {
            Player.Play();
            Views[0].PutText("||", BUTTON_PLAY_BUTTON);
            Views[0].Print(PROGRESBAR_PROGERSBAR);
            Views[0].Clear(LABEL_SONGNAME);
            Views[0].PutText(CurrentSong.Title, LABEL_SONGNAME);
            Views[0].PutText(Player.SongTime(), LABEL_SONGTIME);
            var temp = MusicFile.GetPlaylist("Data/fav.json");
            if (temp.Find(p => p.MusicPath == CurrentSong.MusicPath) != null)
            {
                Views[0].SetConsoleColor(ConsoleColor.DarkRed, BUTTON_FAVOURITE_BUTTON);
                Views[0].Print(BUTTON_FAVOURITE_BUTTON);
            }
            else
                Views[0].SetConsoleColor(ConsoleColor.Gray, BUTTON_FAVOURITE_BUTTON);
            Views[0].Print(BUTTON_FAVOURITE_BUTTON);
        }
        public void LoadPlaylist() {
            previousView = currentView;

            musicFiles = MusicFile.GetPlaylist(playListPath);
            PlaylistSongIndex = 0;

            (Views[6] as PlaylistManageView).ButtonList(musicFiles.Count);
            currentView = Views[6];
            if ((Views[6] as PlaylistManageView).ButtonListCount() > 0)
                Views[6].PutText(musicFiles[0].Title, BUTTON_SONG_BUTTON);

            for (int i = 1; i < (Views[6] as PlaylistManageView).ButtonListCount(); i++)
            {
                Views[6].PutText(musicFiles[ +i].Title, LABEL_SONGLABEL + i);

            }
            Views[6].Show();
            currentView.SetPervView(previousView);
            previousView.SwitchSelectMode();
            currentView.SwitchSelectMode();
            PlaylistCallbacks();


        }
        
        #endregion
        #region Wątek
        public void TimeWatcher()
        {
            
            while (true)
            {

                Thread.Sleep(100);
                Views[0].PutText(Player.CurrentSongTime(), LABEL_CURRENTTIME);
                Thread.Sleep(100);
                int prev = 0;
                int curr = (int)(69 * Player.CurrentSongTimePercent());
                if (curr > prev && curr <= 69)
                {
                    prev = curr;
                    Views[0].Fill(curr, PROGRESBAR_PROGERSBAR);
                }
                Thread.Sleep(50);
                if (Player.SongTimeEnd())
                {
                    Player.Stop();
                }
                Thread.Sleep(50);

            }
        }
        public void SearchThread() {
            int prevSearchBoxTextLength = 0;
            int currSearchBoxTextLength;
            while (true) {
                Thread.Sleep(500);
                if (currentView.Equals(Views[2]) ||currentView.Equals(Views[4])) {
                    currSearchBoxTextLength = SearchBoxText.Length;
                    if (prevSearchBoxTextLength != currSearchBoxTextLength){   
                        
                        if(currentView.Equals(Views[2]))
                            (Views[3] as SearchResultsView).ClearMidBox();

                        else if(currentView.Equals(Views[4]))
                            (Views[5] as PlaylistResultView).ClearMidBox();

                        prevSearchBoxTextLength = currSearchBoxTextLength;
                        if (currSearchBoxTextLength != 0)
                        {

                            List<MusicFile> tempList = MusicFile.GetMusicFiles();
                            tempList = tempList.Where(p => p.Title.ToLower().Contains(SearchBoxText.ToLower())).ToList();
                            if (currentView.Equals(Views[2]))
                            {
                                (Views[3] as SearchResultsView).ButtonList(tempList.Count);
                                for (int i = 1; i <= (Views[3] as SearchResultsView).ButtonListCount(); i++)
                                {
                                    currentView = Views[3];
                                    SetCallback(BUTTON_SEARCHRESULT + i, PlayFromSearch);
                                    currentView = Views[2];
                                    Views[3].PutText(tempList[i - 1].Title, BUTTON_SEARCHRESULT + i);
                                }
                            }
                            else if (currentView.Equals(Views[4]))
                            {
                                (Views[5] as PlaylistResultView).ButtonList(tempList.Count);
                                for (int i = 1; i <= (Views[5] as PlaylistResultView).ButtonListCount(); i++)
                                {
                                    currentView = Views[5];
                                    SetCallback(BUTTON_PLAYLISTRESULT + i, AddToPlaylist);
                                    currentView = Views[4];
                                    Views[5].PutText(tempList[i - 1].Title, BUTTON_PLAYLISTRESULT + i);
                                }
                            }
                        }
                        else
                        {
                            if (currentView.Equals(Views[2]))
                                (Views[3] as SearchResultsView).ButtonList(0);
                            else if (currentView.Equals(Views[4]))
                                (Views[5] as PlaylistResultView).ButtonList(0);
                        }
                        if (currentView.Equals(Views[2]))
                            Views[3].Show();
                        else if (currentView.Equals(Views[4]))
                            Views[5].Show();
                    }
                }
            }

        }
        #endregion
    }

}
