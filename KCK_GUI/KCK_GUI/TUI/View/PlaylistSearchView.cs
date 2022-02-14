using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCK_GUI.TUI.View.Templates;

namespace KCK_GUI.TUI.View
{
    class PlaylistSearchView : ViewTamplate
    {
        public PlaylistSearchView()
        {

            SearchBox search = new SearchBox(new Position(29, 30), new Size(36, 0))
            {
                Identifier = "PlaylistSearchBox",
                buttonPositionX = 0,
                buttonPositionY = 0



            };
            Items.Add(search);
        }
        public void ClearMidBox()
        {
            foreach (var item in Items)
            {
                item.Clear();
            }
        }
    }
}
