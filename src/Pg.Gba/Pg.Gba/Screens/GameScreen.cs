using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;


namespace Pg.Gba.Screens
{
    // Base class for all game screens
    internal abstract class GameScreen
    {
        protected GridBasedAdventureGame Game { get; private set; }
        protected SpriteBatch SpriteBatch => Game._spriteBatch;
        protected SpriteFont Font => Game._font;

        public GameScreen(GridBasedAdventureGame game)
        {
            Game = game;
        }

        public abstract void Update(GameTime gameTime, KeyboardState currentKeyState, KeyboardState previousKeyState);
        public abstract void Draw();

        protected bool IsKeyPressed(Keys key, KeyboardState currentKeyState, KeyboardState previousKeyState)
        {
            return currentKeyState.IsKeyDown(key) && previousKeyState.IsKeyUp(key);
        }
    }
}
