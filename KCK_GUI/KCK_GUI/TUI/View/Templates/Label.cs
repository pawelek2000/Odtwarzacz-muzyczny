using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_GUI.TUI.View.Templates
{
    class Label : Item
    {
        
        public Label(Position position, Size size) : base(position, size){

        }
        public override void Print()
        {

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(Position.X, Position.Y);
            if (Text.Length > Size.Width)
                Text = Text.Substring(0, Size.Width);
            Console.Write(Text);

        }
      
    }
}
