using Pg.Gba.Localization;

LocalizationManager.SetLanguage("en");

using var game = new Pg.Gba.GridBasedAdventureGame();
game.Run();
