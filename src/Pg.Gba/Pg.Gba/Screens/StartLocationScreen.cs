using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Pg.Gba.State;
using Microsoft.Xna.Framework.Graphics;
using Pg.Gba.Gameplay;
using Pg.Gba.Gameplay.Items;

namespace Pg.Gba.Screens
{
    internal class StartLocationScreen : GameplayScreenBase
    {
        public StartLocationScreen(GridBasedAdventureGame game) : base(game) 
        {
            SetBackground(); 
            SetSceneItems(); 
        }

        protected override void SetSceneItems()
        {
            this.ScreenItems =
            [
                new ScreenItem
                {
                    Item = new KeyItem(), 
                    Position = new Vector2(200, 200),
                    IsVisible = false
                },
                new ScreenItem
                {
                    Item = new CupItem(), 
                    Position = new Vector2(800, 535),
                    IsVisible = true
                },
                new ScreenItem
                {
                    Item = new CalendarItem(),
                    Position = new Vector2(550, 250),
                    IsVisible = true
                }
            ];
        }
        protected override void SetBackground()
        {
            _backgroundTexture = Game.Content.Load<Texture2D>("img/backgrounds/startlocationbackground");
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
            DrawScene(); 

            SpriteBatch.DrawString(TitleScreenTitleFont, "POCKET DEMO SCREEN", new Vector2(30, 800), Color.White);
            SpriteBatch.DrawString(TitleScreenMenuItemFont, "Press Escape to return to Title", new Vector2(30, 850), Color.White);
        }
    }
}
