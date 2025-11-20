using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Pg.Gba.State;
using Microsoft.Xna.Framework.Graphics;

namespace Pg.Gba.Screens
{
    internal class GameScreen2 : GameScreen
    {
        public GameScreen2(GridBasedAdventureGame game) : base(game) { }

        public override void Update(GameTime gameTime, InputDevicesState inputDeviceState)
        {
            if (IsKeyPressed(Keys.Escape, inputDeviceState.CurrentKeyState, inputDeviceState.PreviousKeyState))
            {
                ChangeScreen(State.GameScreen.Title);
            }
        }

        public override void Draw()
        {
            SpriteBatch.DrawString(TitleScreenTitleFont, "GAME 2 SCREEN", new Vector2(100, 100), Color.White);
            SpriteBatch.DrawString(TitleScreenMenuItemFont, "Press Escape to return to Title", new Vector2(100, 150), Color.White);
        }
    }
}
