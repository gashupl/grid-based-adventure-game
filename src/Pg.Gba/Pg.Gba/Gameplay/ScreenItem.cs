using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pg.Gba.Utils;
using System.Collections.Generic;

namespace Pg.Gba.Gameplay
{
    internal class ScreenItem
    {
        internal Item Item { get; set; }

        internal Vector2 Position { get; set; }

        internal bool IsVisible { get; set; }

        internal Texture2D Image { get; set; }

        internal void LoadContent(ContentManager contentManager)
        {
            try
            {
                Image = contentManager.Load<Texture2D>(this.Item.ImagePath);
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading item image at path: {this.Item.ImagePath}. Exception: {ex.Message}");
                throw;
            }
        }

        internal PopupMenu CreatePopupMenu(List<PopupMenuAction> availableActions)
        {
            var itemActions = availableActions.FindAll(action => Item.AvailableActions.Contains(action.ActionType));
            if (itemActions.Count > 0)
            {
                return new PopupMenu(itemActions);
            }
            else
            {
                return null;
            }   
        }
    }
}
