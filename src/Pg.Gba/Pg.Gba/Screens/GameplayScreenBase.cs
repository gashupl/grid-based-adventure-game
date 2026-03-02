using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pg.Gba.Gameplay;
using Pg.Gba.State;
using Pg.Gba.Utils;
using System;
using System.Collections.Generic;

namespace Pg.Gba.Screens
{
    internal abstract class GameplayScreenBase : GameScreenBase
    {
        protected List<ScreenItem> ScreenItems;
        protected List<PopupMenuAction> PopupMenuActions;
        protected Texture2D _backgroundTexture;

        protected GameplayScreenBase(GridBasedAdventureGame game, bool enableMouseInput) : base(game, enableMouseInput)
        {
            ScreenItems = new List<ScreenItem>();
            LoadPopupMenuActions(); 
        }

        protected abstract void SetSceneItems();

        protected void DrawScene()
        {     
            DrawBackground();
            DrawScreenItems();
        }

        protected void DrawInventoryItems()
        {
            int xPosition = 10;
            const int yPosition = 10;
            const int itemSpacing = 70;

            foreach (var inventoryItem in GameState.Instance.InventoryItems)
            {
                if (inventoryItem?.Image != null)
                {
                    SpriteBatch.Draw(inventoryItem.Image, new Vector2(xPosition, yPosition), Color.White);
                    xPosition += itemSpacing;
                }
            }
        }

        protected abstract void SetBackground(); 

        private void DrawBackground()
        {
            if(_backgroundTexture != null)
            {
                SpriteBatch.Draw(
                    _backgroundTexture,
                    destinationRectangle: new Rectangle(0, 100, Game._graphics.PreferredBackBufferWidth, Game._graphics.PreferredBackBufferHeight - 200),
                    color: Color.White
                );
            }
            else
            {
                //TODO: Add logging for missing background texture
            }
        }

        private void DrawScreenItems()
        {
            foreach (var item in this.ScreenItems)
            {
                item.LoadContent(Game.Content);
                if (item.IsVisible)
                {        
                    SpriteBatch.Draw(

                        item.Image,
                        item.Position,
                        Color.White
                    );
                }
            }
        }

        private void LoadPopupMenuActions()
        {
            if(PopupMenuActions == null) 
            { 
                PopupMenuActions = new List<PopupMenuAction>
                {
                    new PopupMenuAction(
                
                        PopupMenuActionType.Examine, 
                        Game.Content.Load<Texture2D>("img/menuitems/examine_action")
                    ),
                    new PopupMenuAction(

                        PopupMenuActionType.Take,
                        Game.Content.Load<Texture2D>("img/menuitems/take_action"), 
                        (item) => 
                        {
                            if(item != null && item is ScreenItem)
                            {
                                GameState.Instance.InventoryItems.Add(new InventoryItem(item));
                                this.ScreenItems.Remove(item);
                            }
                        }
                    )
                };
            }
        }
    }
}
