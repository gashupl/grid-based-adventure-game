using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pg.Gba.Utils
{
    internal class PopupMenu
    {
        private Vector2 _position;
        private List<PopupButton> _buttons;
        private bool _isVisible;
        private readonly Texture2D _buttonTexture;
        private readonly SpriteFont _font;

        private const int ButtonWidth = 120;
        private const int ButtonHeight = 30;
        private const int ButtonPadding = 5;

        public bool IsVisible => _isVisible;

        public PopupMenu(Texture2D buttonTexture, SpriteFont font)
        {
            _buttonTexture = buttonTexture;
            _font = font;
            _buttons = new List<PopupButton>();
            _isVisible = false;
        }

        public void AddButton(string label, Action onClicked)
        {
            _buttons.Add(new PopupButton
            {
                Label = label,
                OnClicked = onClicked
            });
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

        public void Update(MouseState currentMouseState, MouseState previousMouseState)
        {
            if (!_isVisible)
                return;

            if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
                Vector2 mousePosition = new Vector2(currentMouseState.X, currentMouseState.Y);

                for (int i = 0; i < _buttons.Count; i++)
                {
                    Rectangle buttonRect = GetButtonRect(i);
                    if (buttonRect.Contains(mousePosition.ToPoint()))
                    {
                        _buttons[i].OnClicked?.Invoke();
                        Hide();
                        return;
                    }
                }

                // Close popup if clicked outside
                Hide();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!_isVisible)
                return;

            for (int i = 0; i < _buttons.Count; i++)
            {
                Rectangle buttonRect = GetButtonRect(i);
                spriteBatch.Draw(_buttonTexture, buttonRect, Color.ForestGreen);

                Vector2 textSize = _font.MeasureString(_buttons[i].Label);
                Vector2 textPosition = new Vector2(
                    buttonRect.X + (buttonRect.Width - textSize.X) / 2,
                    buttonRect.Y + (buttonRect.Height - textSize.Y) / 2
                );

                spriteBatch.DrawString(_font, _buttons[i].Label, textPosition, Color.White);
            }
        }

        private Rectangle GetButtonRect(int buttonIndex)
        {
            int y = (int)_position.Y + (buttonIndex * (ButtonHeight + ButtonPadding));
            return new Rectangle((int)_position.X, y, ButtonWidth, ButtonHeight);
        }

        private class PopupButton
        {
            internal string Label { get; set; }
            internal Action OnClicked { get; set; }
        }
    }
}