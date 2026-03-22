using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pg.Gba.Gameplay;
using Pg.Gba.Gameplay.Items;
using Pg.Gba.State;
using Pg.Gba.Utils;
using System;

namespace Pg.Gba.Screens
{
    internal class StartLocationScreen : GameplayScreenBase
    {
        private bool _popupClickExecuted; 
        public StartLocationScreen(GridBasedAdventureGame game, bool enableMouseInput) : base(game, enableMouseInput) 
        {
            SetBackground(); 
            SetSceneItems(); 
        }

        protected override void SetSceneItems()
        {
            this.ScreenItems =
            [
                new ScreenItem
                {
                    Item = new KeyItem(), 
                    Position = new Vector2(200, 200),
                    IsVisible = false
                },
                new ScreenItem
                {
                    Item = new CupItem(), 
                    Position = new Vector2(800, 535),
                    IsVisible = true
                },
                new ScreenItem
                {
                    Item = new CalendarItem(),
                    Position = new Vector2(550, 250),
                    IsVisible = true
                }
            ];
         
        }
        protected override void SetBackground()
        {
            _backgroundTexture = Game.Content.Load<Texture2D>("img/backgrounds/startlocationbackground");
        }

        public override void Update(GameTime gameTime, InputDevicesState inputDeviceState)
        {
            if (IsKeyPressed(Keys.Escape, inputDeviceState.CurrentKeyState, inputDeviceState.PreviousKeyState))
            {
                ChangeScreen(GameScreen.Title);
            }

            // Update popup menu first - it returns true if it consumed the click
            _popupClickExecuted = PopupMenu?.Update(inputDeviceState.CurrentMouseState, inputDeviceState.PreviousMouseState) ?? false;

            // Must call base.Update() so mouse click handlers are invoked
            base.Update(gameTime, inputDeviceState);
        }

        public override void Draw()
        {
            DrawScene();

            //TODO (3): Test code for showing inventory items - to be removed when some real logic will be implemented to add items to inventory
            if (GameState.Instance.InventoryItems.Count == 0)
            {
                GameState.Instance.InventoryItems.Add(new InventoryItem(this.ScreenItems[0]));
            }

            DrawInventoryItems(); 

            SpriteBatch.DrawString(TitleScreenTitleFont, "POCKET DEMO SCREEN", new Vector2(30, 800), Color.White);
            SpriteBatch.DrawString(TitleScreenMenuItemFont, "Press Escape to return to Title", new Vector2(30, 850), Color.White);

            PopupMenu?.Draw(SpriteBatch);
        }

        protected override void HandleLeftMouseClick(MouseState currentMouseState, MouseState previousMouseState)
        {
            TryHandlePopupClickExecuted(); 
        }

        protected override void HandleRightMouseClick(MouseState currentMouseState, MouseState previousMouseState)
        {
            TryHandlePopupClickExecuted();

            // Store mouse position on right click
            var rightClickPosition = new Vector2(currentMouseState.X, currentMouseState.Y);

            foreach (var screenItem in ScreenItems)
            {
                if (screenItem.IsVisible && ImageHelper.IsImageClicked(screenItem.Image, screenItem.Position, currentMouseState))
                {
                    PopupMenu = screenItem.CreatePopupMenu(PopupMenuActions);
                    PopupMenu.Show(rightClickPosition);
                    break; 
                }
                else
                {
                    PopupMenu?.Hide();
                }
            }
        }

        private void TryHandlePopupClickExecuted()
        {
            // Only process screen input if popup didn't consume the click
            if (!_popupClickExecuted)
            {
                this.ScreenItems.ForEach(screenItem =>
                {
                    screenItem.IsDescriptionVisible = false;
                });
            }
        }
    }
}
