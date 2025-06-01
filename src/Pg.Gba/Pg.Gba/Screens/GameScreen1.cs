using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Pg.Gba.State;

namespace Pg.Gba.Screens
{
    internal class GameScreen1 : GameScreen
    {
        public GameScreen1(GridBasedAdventureGame game) : base(game) { }

        public override void Update(GameTime gameTime, KeyboardState currentKeyState, KeyboardState previousKeyState)
        {
            if (IsKeyPressed(Keys.Enter, currentKeyState, previousKeyState))
            {
                Game.ChangeState(GameState.Game2);
            }
            else if (IsKeyPressed(Keys.Escape, currentKeyState, previousKeyState))
            {
                Game.ChangeState(GameState.Title);
            }
        }

        public override void Draw()
        {
            SpriteBatch.DrawString(Font, "GAME 1 SCREEN", new Vector2(100, 100), Color.White);
            SpriteBatch.DrawString(Font, "Press Enter to go to Game 2", new Vector2(100, 150), Color.White);
            SpriteBatch.DrawString(Font, "Press Escape to return to Title", new Vector2(100, 200), Color.White);
        }
    }
}
