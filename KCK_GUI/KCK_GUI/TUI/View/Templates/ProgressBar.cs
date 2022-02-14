using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_GUI.TUI.View.Templates
{
    class ProgressBar: Item
    {
        
        public ProgressBar(Position position, Size size) : base(position, size) {


        }
        public override void Print()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < Size.Width; i++)
            {
                Console.SetCursorPosition(i + Position.X, Position.Y);
                Console.Write("|");
            }
            Console.ResetColor();


        }
        public void Fill(int X) {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < X; i++)
            {
                Console.SetCursorPosition(Position.X +i, Position.Y);
                Console.Write("|");
            }
            Console.ResetColor();
        }
    }
}
