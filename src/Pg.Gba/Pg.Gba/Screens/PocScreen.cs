using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Pg.Gba.State;
using Microsoft.Xna.Framework.Graphics;
using System;
using Pg.Gba.Utils;

namespace Pg.Gba.Screens
{
    internal class PocScreen : GameplayScreenBase
    {

        private Texture2D _sampleImage;
        private Vector2 _imagePosition;
        private bool _isImageClicked = false;
        private bool _isDraggingImage = false;
        private Vector2 _dragOffset;
        private readonly Random _random = new Random();

        // Add this variable to store the mouse position
        private Vector2? _lastLeftClickPosition = null;
        private Vector2? _lastRightClickPosition = null;
        

        public PocScreen(GridBasedAdventureGame game, bool enableMouseInput) : base(game, enableMouseInput)
        {
            LoadContent();
        }

        public override void Update(GameTime gameTime, InputDevicesState inputDeviceState)
        {
            if (IsKeyPressed(Keys.Enter, inputDeviceState.CurrentKeyState, inputDeviceState.PreviousKeyState))
            {
                ChangeScreen(GameScreen.StartLocation);
            }
            else if (IsKeyPressed(Keys.Escape, inputDeviceState.CurrentKeyState, inputDeviceState.PreviousKeyState))
            {
                ChangeScreen(GameScreen.Title);
            }

            UpdateImageDragging(inputDeviceState.CurrentMouseState, inputDeviceState.PreviousMouseState);
            PopupMenu?.Update(inputDeviceState.CurrentMouseState, inputDeviceState.PreviousMouseState);

            base.Update(gameTime, inputDeviceState);
        }

        public override void Draw()
        {
            SpriteBatch.DrawString(TitleScreenTitleFont, "GAME 1 SCREEN", new Vector2(100, 100), Color.White);
            SpriteBatch.DrawString(TitleScreenMenuItemFont, "Press Enter to go to Game 2", new Vector2(100, 150), Color.White);
            SpriteBatch.DrawString(TitleScreenMenuItemFont, "Press Escape to return to Title", new Vector2(100, 200), Color.White);
            SpriteBatch.DrawString(TitleScreenMenuItemFont, $"Left mouse button clicked on X: {_lastLeftClickPosition?.X} Y: {_lastLeftClickPosition?.Y}",
                new Vector2(100, 250), Color.White);
            SpriteBatch.DrawString(TitleScreenMenuItemFont, $"Right mouse button clicked on X: {_lastRightClickPosition?.X} Y: {_lastRightClickPosition?.Y}",
                new Vector2(100, 300), Color.White);
            SpriteBatch.DrawString(TitleScreenMenuItemFont, $"Image Clicked: {_isImageClicked}", new Vector2(100, 350), Color.Yellow);


            SpriteBatch.Draw(_sampleImage, _imagePosition, Color.White);

            PopupMenu?.Draw(SpriteBatch);
        }

        private void LoadContent()
        {
            // Load the image
            _sampleImage = this.Game.Content.Load<Texture2D>("img/sample01");

            // Calculate random position ensuring the image stays within bounds
            int maxX = this.Game.GraphicsDevice.Viewport.Width - _sampleImage.Width;
            int maxY = this.Game.GraphicsDevice.Viewport.Height - _sampleImage.Height;
            _imagePosition = new Vector2(_random.Next(0, maxX + 1), _random.Next(0, maxY + 1));
        }

        private void UpdateImageDragging(MouseState currentMouseState, MouseState previousMouseState)
        {
            if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
                _isImageClicked = ImageHelper.IsImageClicked(_sampleImage, _imagePosition, currentMouseState);
                if (_isImageClicked)
                {
                    _isDraggingImage = true;
                    _dragOffset = new Vector2(
                        currentMouseState.X - _imagePosition.X,
                        currentMouseState.Y - _imagePosition.Y);
                }
            }
            else if (_isDraggingImage && currentMouseState.LeftButton == ButtonState.Pressed)
            {
                _imagePosition = ClampImagePosition(new Vector2(
                    currentMouseState.X - _dragOffset.X,
                    currentMouseState.Y - _dragOffset.Y));
            }
            else if (_isDraggingImage && currentMouseState.LeftButton == ButtonState.Released)
            {
                _isDraggingImage = false;
            }
        }

        private Vector2 ClampImagePosition(Vector2 position)
        {
            var maxX = Math.Max(0, Game.GraphicsDevice.Viewport.Width - _sampleImage.Width);
            var maxY = Math.Max(0, Game.GraphicsDevice.Viewport.Height - _sampleImage.Height);

            return new Vector2(
                Math.Clamp(position.X, 0, maxX),
                Math.Clamp(position.Y, 0, maxY));
        }

        protected override void HandleLeftMouseClick(MouseState currentMouseState, MouseState previousMouseState)
        {
            // Store mouse position on left click
            _lastLeftClickPosition = new Vector2(currentMouseState.X, currentMouseState.Y);
            _isImageClicked = ImageHelper.IsImageClicked(_sampleImage, _imagePosition, currentMouseState);
        }

        protected override void HandleRightMouseClick(MouseState currentMouseState, MouseState previousMouseState)
        {
            // Store mouse position on right click
            _lastRightClickPosition = new Vector2(currentMouseState.X, currentMouseState.Y);
            // Initialize popup menu
            if(ImageHelper.IsImageClicked(_sampleImage, _imagePosition, currentMouseState))
            {
                PopupMenu = new PopupMenu(PopupMenuActions, null); 
                PopupMenu.Show(_lastRightClickPosition.Value);
            }
            else
            {
                PopupMenu?.Hide();
            }

        }

    }
}
