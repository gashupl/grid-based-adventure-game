using Pg.Gba.Gameplay;
using System.Collections.Generic;

namespace Pg.Gba.State
{
    internal static class GameState
    {
        internal static GameScreen CurrentScreen { get; set; }
        internal static List<Item> Pocket { get; set;  }
    }
}
