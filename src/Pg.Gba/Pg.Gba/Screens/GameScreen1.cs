using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Pg.Gba.State;
using Microsoft.Xna.Framework.Graphics;
using System;
using SharpDX.Direct2D1;

namespace Pg.Gba.Screens
{
    internal class GameScreen1 : GameScreen
    {

        private Texture2D _sampleImage;
        private Vector2 _imagePosition;
        private readonly Random _random = new Random();

        // Add this variable to store the mouse position
        private Vector2? _lastLeftClickPosition = null;

        // Store previous mouse state for click detection
        private MouseState _previousMouseState;

        public GameScreen1(GridBasedAdventureGame game) : base(game) 
        {
            LoadContent(); 
        }

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

            // Mouse handling
            MouseState currentMouseState = Mouse.GetState();
            if (currentMouseState.LeftButton == ButtonState.Pressed &&
                _previousMouseState.LeftButton == ButtonState.Released)
            {
                // Store mouse position on left click
                _lastLeftClickPosition = new Vector2(currentMouseState.X, currentMouseState.Y);
            }
            _previousMouseState = currentMouseState;
        }

        public override void Draw()
        {
            SpriteBatch.DrawString(Font, "GAME 1 SCREEN", new Vector2(100, 100), Color.White);
            SpriteBatch.DrawString(Font, "Press Enter to go to Game 2", new Vector2(100, 150), Color.White);
            SpriteBatch.DrawString(Font, "Press Escape to return to Title", new Vector2(100, 200), Color.White);
            SpriteBatch.DrawString(Font, $"Mouse clicked on X: {_lastLeftClickPosition?.X} Y: {_lastLeftClickPosition?.Y}", 
                new Vector2(100, 250), Color.White);

            SpriteBatch.Draw(_sampleImage, _imagePosition, Color.White);
        }

        private void LoadContent()
        {
            // Load the image
            _sampleImage = this.Game.Content.Load<Texture2D>("img/sample01");

            // Calculate random position ensuring the image stays within bounds
            int maxX = this.Game.GraphicsDevice.Viewport.Width - 32;
            int maxY = this.Game.GraphicsDevice.Viewport.Height - 32;
            _imagePosition = new Vector2(_random.Next(0, maxX + 1), _random.Next(0, maxY + 1));
        }
    }
}
