using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pg.Gba.Screens;
using Pg.Gba.State;
using System;
using System.Collections.Generic;

namespace Pg.Gba
{
    public class GridBasedAdventureGame : Game
    {


        internal GraphicsDeviceManager _graphics;
        internal SpriteBatch _spriteBatch;
        private KeyboardState _previousKeyboardState; 
        private MouseState _previousMouseState;
        internal SpriteFont _titleScreenTitleFont;
        internal SpriteFont _titleScreenMenuItemFont;

        private static int GameResolutionWidth = 1600; 
        private static int GameResolutionHeigth = 900;

        // Dictionary to store all game screens
        private Dictionary<State.GameScreen, Screens.GameScreenBase> _screens;

        public GridBasedAdventureGame()
        {

            if (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width < GameResolutionWidth ||
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height < GameResolutionHeigth)
            {
                throw new NotSupportedException("Required resolution not supported");
            }

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            GameState.CurrentScreen = State.GameScreen.Title;
        }

        protected override void Initialize()
        {


#if !DEBUG
            // Get the display's current resolution
            var displayMode = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
            GameResolutionWidth = displayMode.Width;
            GameResolutionHeigth = displayMode.Height;
            _graphics.PreferredBackBufferWidth = GameResolutionWidth;
            _graphics.PreferredBackBufferHeight = GameResolutionHeigth;
            _graphics.HardwareModeSwitch = false; //Prevent crashes when clicking in the bottom of the game window
            _graphics.ToggleFullScreen();
#elif DEBUG
            _graphics.PreferredBackBufferWidth = GameResolutionWidth;
            _graphics.PreferredBackBufferHeight = GameResolutionHeigth;
#endif
            _graphics.ApplyChanges();

            _previousKeyboardState = Keyboard.GetState();
            _previousMouseState = Mouse.GetState();

            // Create all screens
            _screens = new Dictionary<State.GameScreen, Screens.GameScreenBase>
            {
                { State.GameScreen.Title, new TitleScreen(this) },
                { State.GameScreen.Game1, new GameScreen1(this, true) },
                { State.GameScreen.Game2, new StartLocationScreen(this) }
            };

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _titleScreenTitleFont = Content.Load<SpriteFont>("fonts/TitleScreenTitleFont");
            _titleScreenMenuItemFont = Content.Load<SpriteFont>("fonts/TitleScreenMenuItemsFont");

        }

        public void ChangeState(State.GameScreen newState)
        {
            GameState.CurrentScreen = newState;
        }

        protected override void Update(GameTime gameTime)
        {
            var currentKeyboardState = Keyboard.GetState();
            var currentMouseState = Mouse.GetState();

            // Get the current screen and update it
            _screens[GameState.CurrentScreen].Update(gameTime, 
                new InputDevicesState(currentKeyboardState, _previousKeyboardState, currentMouseState, _previousMouseState));

            _previousKeyboardState = currentKeyboardState;
            _previousMouseState = currentMouseState;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(GetBackgroundColor());

            _spriteBatch.Begin();

            // Draw the current screen
            _screens[GameState.CurrentScreen].Draw();

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private Color GetBackgroundColor()
        {
            switch (GameState.CurrentScreen)
            {
                case State.GameScreen.Title:
                    return Color.CornflowerBlue;
                case State.GameScreen.Game1:
                    return Color.Green; 
                case State.GameScreen.Game2:
                    return Color.Black;
                default:
                    return Color.Yellow;
            }
        }
    }
}
