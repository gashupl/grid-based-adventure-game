using Pg.Gba.Utils;
using System.Collections.Generic;

namespace Pg.Gba.Gameplay.Items
{
    internal class CupItem : Item
    {
        internal CupItem()
        {
            this.Name = "Cup Item";
            this.Label = "Cup";
            this.Description = "An ordinary cup. Nothing I should be interested in.";
            this.ImagePath = "img/items/cup_item";
            this.AvailableActions = new List<PopupMenuActionType>
            {
                PopupMenuActionType.Examine,
                PopupMenuActionType.Take
            };
        }
    }
}
