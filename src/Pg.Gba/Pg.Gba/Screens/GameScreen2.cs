using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Pg.Gba.State;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Pg.Gba.Screens
{
    internal class GameScreen2 : GameScreen
    {
        public GameScreen2(GridBasedAdventureGame game) : base(game) { }

        public override void Update(GameTime gameTime, KeyboardState currentKeyState, KeyboardState previousKeyState)
        {
            if (IsKeyPressed(Keys.Escape, currentKeyState, previousKeyState))
            {
                Game.ChangeState(GameState.Title);
            }
        }

        public override void Draw()
        {
            SpriteBatch.DrawString(Font, "GAME 2 SCREEN", new Vector2(100, 100), Color.White);
            SpriteBatch.DrawString(Font, "Press Escape to return to Title", new Vector2(100, 150), Color.White);
        }

        public override void LoadContent()
        {
            ;
        }
    }
}
