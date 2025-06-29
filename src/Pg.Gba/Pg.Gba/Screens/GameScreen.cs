using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pg.Gba.State;


namespace Pg.Gba.Screens
{
    // Base class for all game screens
    internal abstract class GameScreen
    {
        protected GridBasedAdventureGame Game { get; private set; }
        protected SpriteBatch SpriteBatch => Game._spriteBatch;
        protected SpriteFont Font => Game._font;
        protected bool EnableMouseInput;
        

        protected GameScreen(GridBasedAdventureGame game, bool enableMouseInput = false)
        {
            Game = game;
            EnableMouseInput = enableMouseInput;
        }

        public abstract void Update(GameTime gameTime, InputDevicesState inputDeviceState);
        public abstract void Draw();

        protected static bool IsKeyPressed(Keys key, KeyboardState currentKeyState, KeyboardState previousKeyState)
        {
            return currentKeyState.IsKeyDown(key) && previousKeyState.IsKeyUp(key);
        }

        protected bool IsLeftMouseButtonClicked(MouseState currentMouseState, MouseState previousMouseState)
        {
            if (!EnableMouseInput) 
                return false; 

            return currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released;
        }

        protected bool IsRightMouseButtonClicked(MouseState currentMouseState, MouseState previousMouseState)
        {
            if (!EnableMouseInput)
                return false;

            return currentMouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released;
        }
    }
}
