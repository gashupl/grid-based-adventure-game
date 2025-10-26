using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Pg.Gba.State;
using Microsoft.Xna.Framework.Graphics;

namespace Pg.Gba.Screens
{
    internal class TitleScreen : GameScreen
    {
        private Texture2D _backgroundTexture;

        public TitleScreen(GridBasedAdventureGame game) : base(game) 
        {
            // Load the background image
            _backgroundTexture = Game.Content.Load<Texture2D>("img/backgrounds/titlescreenbackground");

        }

        public override void Update(GameTime gameTime, InputDevicesState inputDeviceState)
        {
            if (IsKeyPressed(Keys.Enter, inputDeviceState.CurrentKeyState, inputDeviceState.PreviousKeyState))
            {
                ChangeScreen(GameState.Game1);
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

            SpriteBatch.DrawString(Font, "ADVENTURE GAME", new Vector2(100, 100), Color.White);
            SpriteBatch.DrawString(Font, "PRESS ENTER TO PLAY", new Vector2(100, 150), Color.White);
            SpriteBatch.DrawString(Font, "PRESS ESCAPE TO EXIT", new Vector2(100, 200), Color.White);
        }
    }
}
