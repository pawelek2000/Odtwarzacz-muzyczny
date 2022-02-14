using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCK_GUI.TUI.View.Templates;

namespace KCK_GUI.TUI.View
{
    class MainBackground:ViewTamplate
    {
     
        public MainBackground() {
            
            

            Box leftCornerBox = new Box(new Position(0, 0), new Size(20, 7));
            Items.Add(leftCornerBox);
            Box secondLeftCornerBox = new Box(new Position(0, 6), new Size(20, 7));
            Items.Add(secondLeftCornerBox);
            Box leftBox = new Box(new Position(0, 12), new Size(20, 34));
            Items.Add(leftBox);
            Box bottomBox = new Box(new Position(0, 45), new Size(75, 14));
            Items.Add(bottomBox);
            Box midBox = new Box(new Position(19, 6), new Size(56, 40));
            Items.Add(midBox);
            Box topBox = new Box(new Position(19, 0), new Size(56, 7));
            Items.Add(topBox);

            

            Button searchButton = new Button(new Position(6,3),new Size(0,0)) { 
                Identifier = "SearchButton",             
                buttonPositionX = 0,
                buttonPositionY = 0,
                Text = "SZUKAJ:"
            };
            Items.Add(searchButton);
            Button playListButton = new Button(new Position(2, 9), new Size(0, 0)) {
                Identifier = "PlayListButton",
                buttonPositionX = 0,
                buttonPositionY = 1,
                Text = "Twoje Playlisty:"
            };
            Items.Add(playListButton);
            Button favouriteButton = new Button(new Position(8, 49), new Size(0, 0)) {
                Identifier = "FavouriteButton",
                buttonPositionX = 0,
                buttonPositionY = 2,
                Text = "♥ "
            };
            Items.Add(favouriteButton);
            Button previousButton = new Button(new Position(30, 49), new Size(0, 0)) {
                Identifier = "PreviousButton",
                buttonPositionX = 1,
                buttonPositionY = 2,
                Text = "|◄",
               
                
            };
            Items.Add(previousButton);
            Button playButton = new Button(new Position(36, 49), new Size(0, 0)) {
                Identifier = "PlayButton",
                buttonPositionX = 2,
                buttonPositionY = 2,
                Text = "► ",


            };
            Items.Add(playButton);
            Button nextButton = new Button(new Position(41, 49), new Size(0, 0)) {
                Identifier = "NextButton",
                buttonPositionX = 3,
                buttonPositionY = 2,
                Text = "►|",


            };
            Items.Add(nextButton);

            Label volume = new Label(new Position(61, 47), new Size(10, 0))
            {
                Identifier = "Volume",
                Text = "Głośność"
            };
            Items.Add(volume);

            ProgressBar progressBar = new ProgressBar(new Position(3, 52), new Size(69, 1))
            {
                Identifier = "ProgressBar"
            };

            Label currentTime = new Label(new Position(3, 54), new Size(12, 0)) {
                Identifier = "CurrentTime",
                Text = "NULL"
            };
            Items.Add(currentTime);

            Label songTime = new Label(new Position(64, 54), new Size(12, 0))
            {
                Identifier = "SongTime",
                Text = "NULL"
            };
            Items.Add(songTime);

            Items.Add(progressBar);
            Label songName = new Label(new Position(3, 56), new Size(69, 0))
            {
                Identifier = "SongName",
                Text = "Tytuł utworu"
            };
            Items.Add(songName);

            Button volumeUpButton = new Button(new Position(63, 49), new Size(0, 0))
            {
                Identifier = "VolumeUpButton",
                buttonPositionX = 4,
                buttonPositionY = 2,
                Text = "▲ ",


            };
            Items.Add(volumeUpButton);
            Button volumeDownButton = new Button(new Position(66, 49), new Size(0, 0))
            {
                Identifier = "VolumeDownButton",
                buttonPositionX = 5,
                buttonPositionY = 2,
                Text = "▼ ",


            };
            Items.Add(volumeDownButton);

       
        }
      
    }
}
