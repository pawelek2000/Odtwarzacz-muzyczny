using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCK_GUI.TUI.View.Templates;

namespace KCK_GUI.TUI.View
{

   
    class PlaylistView : ViewTamplate 
    {

        public PlaylistView() {
            Button favouritePlayList = new Button(new Position(4, 15), new Size(0, 0))
            {
                Identifier = "FavouritePlayList",
                buttonPositionX = 0,
                buttonPositionY = 0,
                Text = "Polubione ♥"
            };
            Items.Add(favouritePlayList);

            Button playList1 = new Button(new Position(4, 18), new Size(0, 0))
            {
                Identifier = "playList1",
                buttonPositionX = 0,
                buttonPositionY = 1,
                Text = "Playlista 1"
            };
            Items.Add(playList1);

            Button playList2 = new Button(new Position(4, 21), new Size(0, 0))
            {
                Identifier = "playList2",
                buttonPositionX = 0,
                buttonPositionY = 2,
                Text = "Playlista 2"
            };
            Items.Add(playList2);

            Button playList3 = new Button(new Position(4, 24), new Size(0, 0))
            {
                Identifier = "playList3",
                buttonPositionX = 0,
                buttonPositionY = 3,
                Text = "Playlista 3"
            };
            Items.Add(playList3);

            Button playList4 = new Button(new Position(4, 27), new Size(0, 0))
            {
                Identifier = "playList4",
                buttonPositionX = 0,
                buttonPositionY = 4,
                Text = "Playlista 4"
            };
            Items.Add(playList4);

            Button playList5 = new Button(new Position(4, 30), new Size(0, 0))
            {
                Identifier = "playList5",
                buttonPositionX = 0,
                buttonPositionY = 5,
                Text = "Playlista 5"
            };
            Items.Add(playList5);

            Button playList6 = new Button(new Position(4, 33), new Size(0, 0))
            {
                Identifier = "playList6",
                buttonPositionX = 0,
                buttonPositionY = 6,
                Text = "Playlista 6"
            };
            Items.Add(playList6);

            Button playList7 = new Button(new Position(4, 36), new Size(0, 0))
            {
                Identifier = "playList7",
                buttonPositionX = 0,
                buttonPositionY = 7,
                Text = "Playlista 7"
            };
            Items.Add(playList7);

            Button playList8 = new Button(new Position(4, 39), new Size(0, 0))
            {
                Identifier = "playList8",
                buttonPositionX = 0,
                buttonPositionY = 8,
                Text = "Playlista 8"
            };
            Items.Add(playList8);

            Button playList9 = new Button(new Position(4,42), new Size(0, 0))
            {
                Identifier = "playList9",
                buttonPositionX = 0,
                buttonPositionY = 9,
                Text = "Playlista 9"
            };
            Items.Add(playList9);
        }
      
       
    }
}
