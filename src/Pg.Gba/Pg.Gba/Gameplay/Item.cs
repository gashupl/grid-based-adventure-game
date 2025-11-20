using Microsoft.Xna.Framework.Graphics;

namespace Pg.Gba.Gameplay
{
    internal class Item
    {
        public string Name { get; set; }

        public string CodeName { get; set; }
        public string Description { get; set; }

        private Texture2D Image { get; set; }
    }
}
