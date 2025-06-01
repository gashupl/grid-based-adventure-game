using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Pg.Gba.State;

namespace Pg.Gba.Screens
{
    internal class TitleScreen : GameScreen
    {
        public TitleScreen(GridBasedAdventureGame game) : base(game) { }

        public override void Update(GameTime gameTime, KeyboardState currentKeyState, KeyboardState previousKeyState)
        {
            if (IsKeyPressed(Keys.Enter, currentKeyState, previousKeyState))
            {
                Game.ChangeState(GameState.Game1);
            }
            else if (IsKeyPressed(Keys.Escape, currentKeyState, previousKeyState))
            {
                Game.Exit();
            }
        }

        public override void Draw()
        {
            SpriteBatch.DrawString(Font, "TITLE SCREEN", new Vector2(100, 100), Color.White);
            SpriteBatch.DrawString(Font, "Press Enter to play Game 1", new Vector2(100, 150), Color.White);
            SpriteBatch.DrawString(Font, "Press Escape to exit", new Vector2(100, 200), Color.White);
        }
    }
}
