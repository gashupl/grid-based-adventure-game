using Microsoft.Xna.Framework.Graphics;

namespace Pg.Gba.Gameplay
{
    internal class InventoryItem
    {
        internal Item Item { get; set; }

        internal Texture2D Image { get; set; }

        internal InventoryItem(ScreenItem screenItem) 
        {
            Item = screenItem.Item;
            Image = screenItem.Image;
        }
    }
}
