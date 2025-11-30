using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pg.Gba.Gameplay.Items
{
    internal class CupItem : Item
    {
        internal CupItem()
        {
            this.Name = "Cup Item";
            this.Label = "Cup";
            this.Description = "A simple cup used for drinking.";
            this.ImagePath = "img/items/cup_item";
        }
    }
}
