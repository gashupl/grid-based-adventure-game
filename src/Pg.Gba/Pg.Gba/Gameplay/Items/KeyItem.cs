using Pg.Gba.Utils;
using System.Collections.Generic;

namespace Pg.Gba.Gameplay.Items
{
    internal class KeyItem : Item
    {
        public KeyItem()
        {
            this.Name = "Key Item";
            this.Label = "Key";
            this.Description = "Strange looking key!"; 
            this.ImagePath = "img/items/key_item";
            this.AvailableActions = new List<PopupMenuActionType>
            {
                PopupMenuActionType.Examine, 
                PopupMenuActionType.Take
            };
        }
    }
}
