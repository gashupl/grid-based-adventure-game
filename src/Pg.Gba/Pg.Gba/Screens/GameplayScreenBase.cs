using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pg.Gba.Gameplay;
using System.Collections.Generic;

namespace Pg.Gba.Screens
{
    internal abstract class GameplayScreenBase : GameScreenBase
    {
        protected List<ScreenItem> ScreenItems;
        protected Texture2D _backgroundTexture;

        protected GameplayScreenBase(GridBasedAdventureGame game) : base(game)
        {
            ScreenItems = new List<ScreenItem>();
            
        }

        protected abstract void SetSceneItems();

        protected void DrawScene()
        {     
            DrawBackground();
            DrawScreenItems();
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
                if (item.IsVisible)
                {
                    item.LoadContent(Game.Content);
                    SpriteBatch.Draw(

                        item.Image,
                        item.Position,
                        Color.White
                    );
                }
            }
        }
    }
}
