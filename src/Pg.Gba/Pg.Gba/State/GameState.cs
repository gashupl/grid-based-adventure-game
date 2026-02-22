using Pg.Gba.Gameplay;
using System.Collections.Generic;

namespace Pg.Gba.State
{
    internal class GameState
    {
        private static readonly GameState _instance = new GameState();

        public static GameState Instance => _instance;

        public GameScreen CurrentScreen { get; set; }
        public List<InventoryItem> InventoryItems { get; set; }

        private GameState()
        {
            InventoryItems = new List<InventoryItem>();
        }
    }
}
