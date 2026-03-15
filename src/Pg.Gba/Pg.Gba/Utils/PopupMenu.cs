using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pg.Gba.Gameplay;

namespace Pg.Gba.Utils
{
    internal class PopupMenu
    {
        private Vector2 _position;
        private List<PopupMenuAction> _actions;
        private bool _isVisible;
        private ScreenItem _parentScreenItem; 

        private const int ImagePadding = 5;

        public bool IsVisible => _isVisible;

        public PopupMenu(List<PopupMenuAction> actions, ScreenItem parentScreenItem)
        {
            _actions = actions;
            _parentScreenItem = parentScreenItem; 
            _isVisible = false;
        }

        public void Show(Vector2 position)
        {
            _position = position;
            _isVisible = true;
        }

        public void Hide()
        {
            _isVisible = false;
        }

        //TODO (1) This method has too many responsiblitites and should be refactored to separate concerns (e.g. click detection vs action handling)
        public bool Update(MouseState currentMouseState, MouseState previousMouseState)
        {
            if (!_isVisible)
                return false;

            if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
                Vector2 mousePosition = new Vector2(currentMouseState.X, currentMouseState.Y);

                for (int i = 0; i < _actions.Count; i++)
                {
                    Rectangle buttonRect = GetImageRect(i);
                    if (buttonRect.Contains(mousePosition.ToPoint()))
                    {
                        OnActionSelected(_actions[i]);
                        Hide();
                        return true;
                    }
                }

                // Close popup if clicked outside (still consume the click)
                Hide();
                return true;
            }

            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!_isVisible)
                return;

            for (int i = 0; i < _actions.Count; i++)
            {
                Rectangle imageRect = GetImageRect(i);
                spriteBatch.Draw(_actions[i].Image, imageRect, Color.White);
            }
        }

        private Rectangle GetImageRect(int actionIndex)
        {
            int x = (int)_position.X + (actionIndex * (32 + ImagePadding));
            return new Rectangle(x, (int)_position.Y, 32, 32);
        }

        private void OnActionSelected(PopupMenuAction action)
        {
            // Handle action based on type
            // This can be extended with callback functionality if needed
            Console.WriteLine($"Action selected: {action.ActionType}");
            if(action.OnActionSelected != null)
            {
                action.OnActionSelected.Invoke(_parentScreenItem);
            }
        }
    }
}