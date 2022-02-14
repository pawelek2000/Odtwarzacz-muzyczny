using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_GUI.TUI.View.Templates
{
    class SearchBox : Button
    {
        
        public int textLenght { get; set; }
        public SearchBox(Position position, Size size) : base(position, size)
        {
            Text = "";
            textLenght = Text.Length;
            Selected = false;
        }
        
        public override void Print()
        {
            if (Selected)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(Position.X + (Size.Width / 2) - 1, Position.Y + 2);
                Console.Write("º");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(Position.X + (Size.Width / 2) - 1, Position.Y + 2);
                Console.Write(" ");
            }

            if (Text.Length == textLenght)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                for (int i = 0; i < Size.Width; i++)
                {
                    Console.SetCursorPosition(i + Position.X, Position.Y + 1);
                    Console.Write("▬");
                    Console.SetCursorPosition(i + Position.X, Position.Y);
                    Console.Write(" ");
                }
                Console.ResetColor();

            }
            else if (textLenght > Text.Length) {
                Console.SetCursorPosition(Position.X + Text.Length, Position.Y);
                Console.Write(" ");
                textLenght = Text.Length;
            }
            else
            {

                textLenght = Text.Length;

                Console.SetCursorPosition(Position.X, Position.Y);
                if (Text.Length > Size.Width)
                    Text = Text.Substring(0, Size.Width);
                Console.Write(Text);
                

            }
        }

      

    }
}
