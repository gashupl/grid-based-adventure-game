using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
