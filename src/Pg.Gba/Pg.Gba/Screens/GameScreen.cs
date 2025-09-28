using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pg.Gba.State;
using Pg.Gba.Utils;


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

        public virtual void Update(GameTime gameTime, InputDevicesState inputDeviceState)
        {
            // Mouse handling
            if (IsLeftMouseButtonClicked(inputDeviceState.CurrentMouseState, inputDeviceState.PreviousMouseState))
            {
                HandleLeftMouseClick(inputDeviceState.CurrentMouseState, inputDeviceState.PreviousMouseState);
            }

            if(IsRightMouseButtonClicked(inputDeviceState.CurrentMouseState, inputDeviceState.PreviousMouseState))
            {
                HandleRightMouseClick(inputDeviceState.CurrentMouseState, inputDeviceState.PreviousMouseState);
            }
        }
        public abstract void Draw();

        protected void ChangeScreen(GameState newState)
        {
            Game.ChangeState(newState);
        }
        protected void ExitGame()
        {
            Game.Exit();
        }   

        protected static bool IsKeyPressed(Keys key, KeyboardState currentKeyState, KeyboardState previousKeyState)
        {
            return currentKeyState.IsKeyDown(key) && previousKeyState.IsKeyUp(key);
        }

        protected virtual void HandleLeftMouseClick(MouseState currentMouseState, MouseState previousMouseState)
        {
        }

        protected virtual void HandleRightMouseClick(MouseState currentMouseState, MouseState previousMouseState)
        {
        }

        private bool IsLeftMouseButtonClicked(MouseState currentMouseState, MouseState previousMouseState)
        {
            if (!EnableMouseInput) 
                return false; 

            return currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released;
        }

        private bool IsRightMouseButtonClicked(MouseState currentMouseState, MouseState previousMouseState)
        {
            if (!EnableMouseInput)
                return false;

            return currentMouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released;
        }
    }
}
