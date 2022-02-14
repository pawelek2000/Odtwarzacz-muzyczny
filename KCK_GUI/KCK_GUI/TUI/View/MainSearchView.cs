using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCK_GUI.TUI.View.Templates;

namespace KCK_GUI.TUI.View
{
    class MainSearchView : ViewTamplate
    {
        public MainSearchView() {

            SearchBox search = new SearchBox(new Position(29, 3), new Size(36, 0))
            {
                Identifier = "MainSearchBox",
                buttonPositionX = 0,
                buttonPositionY =0
                
                

            };
            Items.Add(search);
        }
    }
}
