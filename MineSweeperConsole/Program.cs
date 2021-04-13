using Microsoft.Extensions.Configuration;
using MineSweeper.Game;

namespace MineSweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var game = new GameConsole();
            game.NewGame();
        }
    } // ToDo: Add code to be able to have settings in a json file. Have demo status and grid size in settings file.
}