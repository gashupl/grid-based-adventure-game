using Microsoft.Extensions.Configuration;
using Pg.Gba.Localization;
using Serilog;
using System;


//TODO: Add global abstraction over log library 

// Load configuration
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Initialize Serilog from configuration
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

try
{
    LocalizationManager.SetLanguage("en");

    Log.Debug("Starting game...");

    using var game = new Pg.Gba.GridBasedAdventureGame();
    game.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    // Flush and close Serilog
    Log.CloseAndFlush();
}
