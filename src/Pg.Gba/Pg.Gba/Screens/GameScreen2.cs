using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Pg.Gba.State;
using Microsoft.Xna.Framework.Graphics;
using Pg.Gba.Gameplay;
using Pg.Gba.Gameplay.Items;

namespace Pg.Gba.Screens
{
    internal class GameScreen2 : GameScreenBase
    {
        public GameScreen2(GridBasedAdventureGame game) : base(game) 
        {
            LoadContent(); 
        }

        void LoadContent()
        {
            this.ScreenItems =
            [
                new ScreenItem
                {
                    Item = new KeyItem(), 
                    Position = new Vector2(200, 200),
                    IsVisible = true
                },
                new ScreenItem
                {
                    Item = new CalendarItem(), 
                    Position = new Vector2(300, 300),
                    IsVisible = false
                },
                new ScreenItem
                {
                    Item = new CalendarItem(),
                    Position = new Vector2(500, 500),
                    IsVisible = true
                }
            ];
        }

        public override void Update(GameTime gameTime, InputDevicesState inputDeviceState)
        {
            if (IsKeyPressed(Keys.Escape, inputDeviceState.CurrentKeyState, inputDeviceState.PreviousKeyState))
            {
                ChangeScreen(GameScreen.Title);
            }
        }

        public override void Draw()
        {
            SpriteBatch.DrawString(TitleScreenTitleFont, "POCKET DEMO SCREEN", new Vector2(100, 100), Color.White);
            SpriteBatch.DrawString(TitleScreenMenuItemFont, "Press Escape to return to Title", new Vector2(100, 150), Color.White);

            foreach(var item in this.ScreenItems) {                 
                if(item.IsVisible)
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
