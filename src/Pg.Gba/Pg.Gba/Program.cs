using Pg.Gba.Localization;

LocalizationManager.SetLanguage("en");

Debug.WriteLine("Starting game...");

using var game = new Pg.Gba.GridBasedAdventureGame();
game.Run();
