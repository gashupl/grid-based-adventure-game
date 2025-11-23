using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pg.Gba.Localization;
using Pg.Gba.State;

namespace Pg.Gba.Screens
{
    internal class TitleScreen : GameScreenBase
    {
        private readonly Texture2D _backgroundTexture;

        public TitleScreen(GridBasedAdventureGame game) : base(game) 
        {
            // Load the background image
            _backgroundTexture = Game.Content.Load<Texture2D>("img/backgrounds/titlescreenbackground");

        }

        public override void Update(GameTime gameTime, InputDevicesState inputDeviceState)
        {
            if (IsKeyPressed(Keys.Enter, inputDeviceState.CurrentKeyState, inputDeviceState.PreviousKeyState))
            {
                ChangeScreen(State.GameScreen.Game1);
            }
            else if (IsKeyPressed(Keys.Escape, inputDeviceState.CurrentKeyState, inputDeviceState.PreviousKeyState))
            {
                ExitGame(); 
            }
        }

        public override void Draw()
        {
            // Draw the background image stretched to the window size
            SpriteBatch.Draw(
                _backgroundTexture,
                destinationRectangle: new Rectangle(0, 0, Game._graphics.PreferredBackBufferWidth, Game._graphics.PreferredBackBufferHeight),
                color: Color.White
            );

            var x = 50;
            var y = Game._graphics.PreferredBackBufferHeight / 2 + 250;
            SpriteBatch.DrawString(TitleScreenTitleFont, LocalizationManager.GetString("TitleScreen_Title"), new Vector2(x, y), Color.White);
            SpriteBatch.DrawString(TitleScreenMenuItemFont, LocalizationManager.GetString("TitleScreen_Play"), new Vector2(x, y + 50), Color.White);
            SpriteBatch.DrawString(TitleScreenMenuItemFont, LocalizationManager.GetString("TitleScreen_Exit"), new Vector2(x, y + 100), Color.White);
        }
    }
}
