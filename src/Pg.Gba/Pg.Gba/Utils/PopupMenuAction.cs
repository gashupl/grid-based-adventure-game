using Microsoft.Xna.Framework.Graphics;

namespace Pg.Gba.Utils
{
    internal class PopupMenuAction
    {
        public PopupMenuActionType ActionType { get; }

        public Texture2D Image { get; set; }

        public PopupMenuAction(PopupMenuActionType actionType, Texture2D image)
        {
            ActionType = actionType;
            Image = image; 
        }
    }

    enum PopupMenuActionType
    {
        Examine,
        Take,
        Use,
    }
}
