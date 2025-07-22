using Microsoft.Xna.Framework.Input;

namespace Pg.Gba.State
{
    internal class InputDevicesState
    {
        public InputDevicesState(KeyboardState currentKeyState, KeyboardState previousKeyState, MouseState currentMouseState, MouseState previousMouseState)
        {
            CurrentKeyState = currentKeyState;
            PreviousKeyState = previousKeyState;
            CurrentMouseState = currentMouseState;
            PreviousMouseState = previousMouseState;
        }
        public KeyboardState CurrentKeyState { get; set; }
        public KeyboardState PreviousKeyState { get; set; }
        public MouseState CurrentMouseState { get; set; }
        public MouseState PreviousMouseState { get; set; }
    }
}
