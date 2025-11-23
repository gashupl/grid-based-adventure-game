using Microsoft.Xna.Framework;

namespace Pg.Gba.Gameplay
{
    internal class ScreenItem
    {
        internal Item Item { get; set; }

        internal Vector2 Position { get; set; }

        internal bool IsVisible { get; set; }
    }
}
