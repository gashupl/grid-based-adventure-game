using Pg.Gba.Utils;
using System.Collections.Generic;

namespace Pg.Gba.Gameplay
{
    internal class Item
    {
        internal string Name { get; set; }

        internal string Label { get; set; }
        internal string Description { get; set; }

        internal string ImagePath { get; set; }

        internal List<PopupMenuActionType> AvailableActions { get; set; }

    }
}
