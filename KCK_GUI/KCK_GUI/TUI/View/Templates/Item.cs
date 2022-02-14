using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_GUI.TUI.View.Templates
{
    struct Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }

    struct Size
    {
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; set; }
        public int Height { get; set; }
    }

    class Item
    {
        public ConsoleColor consoleColor { get; set; }
        public string Text { get; set; }
        public int? buttonPositionX { get; set; }
        public int? buttonPositionY { get; set; }
        protected EventHandler EventHandler;
        protected Position Position;
        protected Size Size;
        public string Identifier { get; set; }
        public Item(Position position, Size size)
        {
            Position = position;
            Size = size;
            Identifier = "NULL";
            consoleColor = ConsoleColor.Gray;

        }
        public virtual void Print() {

        }
        public virtual void OnClick() {

        }
        public void SetCallback(EventHandler callback)
        {
            EventHandler = callback;
        }
        public void PutText(string text)
        {
            Text = text;
        }
        public void Clear() {
            for (int i = 0; i < Size.Width; i++)
            {
                Console.SetCursorPosition(i + Position.X, Position.Y);
                Console.Write(" ");
                Console.SetCursorPosition(i + Position.X, Position.Y+1);
                Console.Write(" ");
            }
        }
        public string GetText()
        {
            return Text;
        }
        public void SetConsoleColor(ConsoleColor consoleColor) {
            this.consoleColor = consoleColor;
        }
    }
}
