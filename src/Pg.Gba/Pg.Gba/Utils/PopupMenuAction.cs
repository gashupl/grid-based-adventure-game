using Microsoft.Xna.Framework.Graphics;
using Pg.Gba.Gameplay;
using System;

namespace Pg.Gba.Utils
{
    internal class PopupMenuAction
    {
        public PopupMenuActionType ActionType { get; }

        public Texture2D Image { get; set; }

        public Action<ScreenItem> OnActionSelected { get; set; }

        public PopupMenuAction(PopupMenuActionType actionType, Texture2D image, Action<ScreenItem> onActionSelected = null)
        {
            ActionType = actionType;
            Image = image;
            OnActionSelected = onActionSelected;
        }
    }

    enum PopupMenuActionType
    {
        Examine,
        Take,
        Use,
    }
}
