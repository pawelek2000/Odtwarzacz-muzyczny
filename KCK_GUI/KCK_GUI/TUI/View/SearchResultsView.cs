using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCK_GUI.TUI.View.Templates;

namespace KCK_GUI.TUI.View
{
    class SearchResultsView : ViewTamplate 
    {
        public SearchResultsView()
        {


        }
        public void ClearMidBox()
        {
            foreach (var item in Items) {
                item.Clear();
            }
        }
        public void ButtonList(int searchNumbers)
        {
            Items = new List<Item>();
            int size = 8;
            if (size > searchNumbers)
                size = searchNumbers;
            for (int i = 1; i <= size; i++)
            {
                Button searchResult = new Button(new Position(21, 6 + 2 * i), new Size(40, 0))
                {
                    Identifier = "SearchResult" + i,
                    buttonPositionX = 0,
                    buttonPositionY = -1+i,
                    Text = "s"+i
                };
                Items.Add(searchResult);
            }
        }
        public int ButtonListCount() {
            return Items.Count();
        }
    }

 }

