using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_GUI.TUI.View.Templates
{
   
    class Box : Item
    {
        
        public Box(Position position, Size size) :base(position,size) {

   
        }
        public override void Print() {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < Size.Height; i++) {
                Console.SetCursorPosition(Position.X, i + Position.Y);
                Console.Write(" ");
            }
            for (int i = 0; i < Size.Width; i++) {
                Console.SetCursorPosition(i + Position.X, Position.Y);
                Console.Write(" ");
            }
            for (int i = 0; i < Size.Height; i++) {
                Console.SetCursorPosition(Position.X + (Size.Width - 1), i + Position.Y);
                Console.Write(" ");
            }
            for (int i = 0; i < Size.Width; i++) {
                Console.SetCursorPosition(i + Position.X, Position.Y + (Size.Height - 1));
                Console.Write(" ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
