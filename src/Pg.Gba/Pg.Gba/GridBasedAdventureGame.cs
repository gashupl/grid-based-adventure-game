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
        internal static int GameResolutionWidth = 1600; //1920;
        internal static int GameResolutionHeigth = 900; //1080;

        internal GraphicsDeviceManager _graphics;
        internal SpriteBatch _spriteBatch;
        private GameState _currentState;
        private KeyboardState _previousKeyboardState; 
        private MouseState _previousMouseState;
        internal SpriteFont _font;

        // Dictionary to store all game screens
        private Dictionary<GameState, GameScreen> _screens;

        public GridBasedAdventureGame()
        {

            if (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width < GameResolutionWidth ||
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height < GameResolutionHeigth)
            {
                throw new Exception("Required resolution not supported");
            }

            //this.GraphicsDevice.DeviceReset += OnDeviceReset;

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _currentState = GameState.Title;
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
            _screens = new Dictionary<GameState, GameScreen>
            {
                { GameState.Title, new TitleScreen(this) },
                { GameState.Game1, new GameScreen1(this, true) },
                { GameState.Game2, new GameScreen2(this) }
            };

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("Font1");

        }

        public void ChangeState(GameState newState)
        {
            _currentState = newState;
        }

        protected override void Update(GameTime gameTime)
        {
            var currentKeyboardState = Keyboard.GetState();
            var currentMouseState = Mouse.GetState();

            // Get the current screen and update it
            _screens[_currentState].Update(gameTime, 
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
            _screens[_currentState].Draw();

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private Color GetBackgroundColor()
        {
            switch (_currentState)
            {
                case GameState.Title:
                    return Color.CornflowerBlue;
                case GameState.Game1:
                    return Color.Black; 
                case GameState.Game2:
                    return Color.Crimson;
                default:
                    return Color.Yellow;
            }
        }
    }
}
