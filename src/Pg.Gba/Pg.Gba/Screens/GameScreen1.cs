using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Pg.Gba.State;
using Microsoft.Xna.Framework.Graphics;
using System;
using SharpDX.Direct2D1;
using Pg.Gba.Utils;

namespace Pg.Gba.Screens
{
    internal class GameScreen1 : GameScreenBase
    {

        private Texture2D _sampleImage;
        private Vector2 _imagePosition;
        private bool _isImageClicked = false;
        private readonly Random _random = new Random();

        // Add this variable to store the mouse position
        private Vector2? _lastLeftClickPosition = null;
        private Vector2? _lastRightClickPosition = null;
        private PopupMenu _popupMenu;
        private Texture2D _buttonTexture;

        public GameScreen1(GridBasedAdventureGame game, bool enableMouseInput) : base(game, enableMouseInput)
        {
            LoadContent();
        }

        public override void Update(GameTime gameTime, InputDevicesState inputDeviceState)
        {
            if (IsKeyPressed(Keys.Enter, inputDeviceState.CurrentKeyState, inputDeviceState.PreviousKeyState))
            {
                ChangeScreen(State.GameScreen.Game2);
            }
            else if (IsKeyPressed(Keys.Escape, inputDeviceState.CurrentKeyState, inputDeviceState.PreviousKeyState))
            {
                ChangeScreen(State.GameScreen.Title);
            }

            _popupMenu?.Update(inputDeviceState.CurrentMouseState, inputDeviceState.PreviousMouseState);

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

            _popupMenu?.Draw(SpriteBatch);
        }

        private void LoadContent()
        {
            // Load the image
            _sampleImage = this.Game.Content.Load<Texture2D>("img/sample01");

            // Create a simple 1x1 white texture for buttons
            _buttonTexture = new Texture2D(Game.GraphicsDevice, 1, 1);
            _buttonTexture.SetData(new[] { Color.White });

            // Calculate random position ensuring the image stays within bounds
            int maxX = this.Game.GraphicsDevice.Viewport.Width - 32;
            int maxY = this.Game.GraphicsDevice.Viewport.Height - 32;
            _imagePosition = new Vector2(_random.Next(0, maxX + 1), _random.Next(0, maxY + 1));
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
                _popupMenu = new PopupMenu(_buttonTexture, TitleScreenMenuItemFont);
                _popupMenu.AddButton("Look at", () => { });
                _popupMenu.AddButton("Take", () => { });
                _popupMenu.Show(_lastRightClickPosition.Value);
            }
            else
            {
                _popupMenu?.Hide();
            }

        }
    }
}
