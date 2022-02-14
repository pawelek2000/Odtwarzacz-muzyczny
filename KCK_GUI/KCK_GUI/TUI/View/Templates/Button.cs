using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_GUI.TUI.View.Templates
{
    class Button : Item
    {
        
        
        public bool Selected { get; set; }
        
        
        public Button(Position position, Size size) : base(position, size) {

            Selected = false;
            
        }
        public override void Print()
        {
            if (Selected)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(Position.X+ (Text.Length / 2) - 1, Position.Y+1);
                Console.Write("º");
            }
            else {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(Position.X + (Text.Length/ 2)-1, Position.Y + 1);
                Console.Write(" ");

            }
            Console.ForegroundColor = consoleColor;
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(Text);

        }
        public override void OnClick()
        {
            
            EventHandler(this, EventArgs.Empty);
        }
      
    }
}
