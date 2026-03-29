using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Pg.Gba.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pg.Gba.Screens
{
    internal class StartScreen : GameplayScreenBase
    {

        public StartScreen(GridBasedAdventureGame game, bool enableMouseInput) : base(game, enableMouseInput)
        {
            //SetBackground();
            //SetSceneItems();
        }

        public override void Update(GameTime gameTime, InputDevicesState inputDeviceState)
        {
            if (IsKeyPressed(Keys.Enter, inputDeviceState.CurrentKeyState, inputDeviceState.PreviousKeyState))
            {
                ChangeScreen(GameScreen.StartLocation);
            }

        }
        public override void Draw()
        {
            var textYLineDistance = 32;
            SpriteBatch.DrawString(ScreenItemDescriptionFont, "You wake up in an unfamiliar room. ", new Vector2(10, 10), Color.White);
            SpriteBatch.DrawString(ScreenItemDescriptionFont, "You have no idea how you got there.", new Vector2(10, 10 + textYLineDistance), Color.White);
            SpriteBatch.DrawString(ScreenItemDescriptionFont, "You touch your aching head and find traces of dried blood.", new Vector2(10, 10 + textYLineDistance * 2), Color.White);
            SpriteBatch.DrawString(ScreenItemDescriptionFont, "No matter what happened, it's time to find a way out!", new Vector2(10, 10 + textYLineDistance * 3), Color.White);
            SpriteBatch.DrawString(ScreenItemDescriptionFont, "Press [ENTER]", new Vector2(10, 10 + textYLineDistance * 4), Color.White);
        }

        protected override void SetBackground()
        {
            throw new NotImplementedException();
        }

        protected override void SetSceneItems()
        {
            throw new NotImplementedException();
        }
    }
}
