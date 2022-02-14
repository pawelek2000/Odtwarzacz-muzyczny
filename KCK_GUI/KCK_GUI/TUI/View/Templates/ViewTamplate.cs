using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCK_GUI.TUI.View.Templates
{
    class ViewTamplate
    {
        public List<Item> Items { get; set; }

        public Button selectedButton { get; set; }

        public ViewTamplate prevView { get; set; }

        public bool Selected;

        public ViewTamplate() {
            Items = new List<Item>();

            Selected = false;
        }
        public void Show()
        {

            foreach (var item in Items)
            {
                item.Print();
            }


        }

        public void MoveCursor(int X, int Y)
        {
            selectedButton.Selected = false;
            selectedButton.Print();
            if (X != 0)
            {
                if (Items.Find(p => p.buttonPositionX == selectedButton.buttonPositionX + X && p.buttonPositionY == selectedButton.buttonPositionY + Y) != null)
                {
                    selectedButton = (Items.Find(p => p.buttonPositionX == selectedButton.buttonPositionX + X && p.buttonPositionY == selectedButton.buttonPositionY + Y) as Button);
                }
            }
            if (Y != 0)
            {
                if (Items.Find(p => p.buttonPositionX == 0 && p.buttonPositionY == selectedButton.buttonPositionY + Y) != null)
                {
                    selectedButton = (Items.Find(p => p.buttonPositionX == 0 && p.buttonPositionY == selectedButton.buttonPositionY + Y) as Button);
                }
            }
            selectedButton.Selected = true;
            selectedButton.Print();
        }
        public void SwitchSelectMode() {

            if (Selected) {
                Selected = false;
                if (selectedButton != null) {
                    selectedButton.Selected = false;
                    selectedButton.Print();
                }
            }
            else {
                Selected = true;
                selectedButton = (Items.Find(p => p.buttonPositionX == 0 && p.buttonPositionY == 0) as Button);
                selectedButton.Selected = true;
                selectedButton.Print();
            }
        }
        public void OnClick() {
            selectedButton.OnClick();
        }
        public void SetCallback(string name, EventHandler handler)
        {
            var item = Items.Find(p => p.Identifier == name);
            item.SetCallback(handler);

        }
        public void PutText(string text, string identifier)
        {
            var item = Items.Find(p => p.Identifier == identifier);
            item.PutText(text);
            item.Print();
        }
        public void OnClick(string identifier)
        {
            var item = Items.Find(p => p.Identifier == identifier);
            item.OnClick();
        }
        public void Clear(string identifier) {
            var item = Items.Find(p => p.Identifier == identifier);
            item.Clear();
        }
        public string GetText(string identifier)
        {
            var item = Items.Find(p => p.Identifier == identifier);
            return item.GetText();
        }
        public void Fill(int X, string identifier)
        {
            var item = Items.Find(p => p.Identifier == identifier);
            (item as ProgressBar).Fill(X);
        }
        public void Print(string identifier) {
            var item = Items.Find(p => p.Identifier == identifier);
            item.Print();
        }
        public void SetPervView(ViewTamplate view){
            prevView = view;
        }
        public void SetConsoleColor(ConsoleColor consoleColor, string identifier)
        {
            var item = Items.Find(p => p.Identifier == identifier);
            item.SetConsoleColor(consoleColor);
        }
        public ViewTamplate GetPervView()
        {
            return prevView;
        }
    }
}
