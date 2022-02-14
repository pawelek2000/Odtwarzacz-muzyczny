using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCK_GUI.TUI.View.Templates;

namespace KCK_GUI.TUI.View
{
    class PlaylistManageView : ViewTamplate
    {
        public static int size { get; set; }
        public PlaylistManageView(){
            
         
        }
        public void ClearMidBox()
        {
            foreach (var item in Items)
            {
                item.Clear();
            }
        }
        public void ClearMidBoxButton()
        {
            foreach (var item in Items)
            {
                if(item.Identifier==("SongButton")|| item.Identifier.Contains("SongLabel"))
                item.Clear(); 
            }
        }
        public void ButtonList(int searchNumbers)
        {
            size = 6;
            Items = new List<Item>();
            Button searchSong = new Button(new Position(63, 8), new Size(10, 0))
            {
                Identifier = "SearchAddMusicButton",
                buttonPositionX = 0,
                buttonPositionY = 0,
                Text = "Szukaj:"
            };
            Items.Add(searchSong);
            
            if (searchNumbers > 0)
            {
                Button nextSong = new Button(new Position(65, 10), new Size(5, 0))
                {
                    Identifier = "NextSongButton",
                    buttonPositionX = 0,
                    buttonPositionY = 1,
                    Text = "↑ "
                };
                Items.Add(nextSong);
                Button playSong = new Button(new Position(65, 12), new Size(5, 0))
                {
                    Identifier = "PlaySongButton",
                    buttonPositionX = 0,
                    buttonPositionY = 2,
                    Text = "► "
                };
                Items.Add(playSong);
                Button prevSong = new Button(new Position(65, 14), new Size(5, 0))
                {
                    Identifier = "PrevSongButton",
                    buttonPositionX = 0,
                    buttonPositionY = 3,
                    Text = "↓ "
                };
                Items.Add(prevSong);
                Button deleteSong = new Button(new Position(63, 16), new Size(5, 0))
                {
                    Identifier = "DeleteSongButton",
                    buttonPositionX = 0,
                    buttonPositionY = 4,
                    Text = "Usun"
                };
                Items.Add(deleteSong);
                
            }
            
            
            if (size > searchNumbers)
                size = searchNumbers;
            for (int i = 0; i < size; i++)
            {
                if (i == 0)
                {
                    Button searchResult = new Button(new Position(21, 6 + 2 * (i+1)), new Size(40, 0))
                    {
                        Identifier = "SongButton",
                        Text = "ButtonS" + i
                    };
                    Items.Add(searchResult);
                }
                else {
                    Label searchResult = new Label(new Position(21, 6 + 2 * (i+1)), new Size(40, 0))
                    {
                        Identifier = "SongLabel"+i,
                        Text = "LabelS" + i
                    };
                    Items.Add(searchResult);

                }
            }
        }
        public int ButtonListCount()
        {
            return size;
        }
    }
}
