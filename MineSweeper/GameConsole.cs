using System;

namespace MineSweeper_v01
{
    public class GameConsole
    {
        public void NewGame()
        {
            // ToDo: Insert fancy greeting using Figgle.  Add Figgle as module to project.

            var userInputValidation = Factory.NewUserInputValidation();
            var userInputGridSize = "";
            var gridDisplay = GridFactory.NewGridDisplay();

            while (!userInputValidation.IsInitialGridSizeCorrect(userInputGridSize))
            {
                Console.WriteLine("Please enter a grid size between 2 and 10: ");
                userInputGridSize = Console.ReadLine();
                userInputValidation.IsInitialGridSizeCorrect(userInputGridSize);
            }

            int.TryParse(userInputGridSize, out var gridSize);
            var newGameGrid = GridFactory.NewGameGrid(gridSize);
            Console.WriteLine(gridDisplay.GenerateGameDisplay(newGameGrid));
        }
    }
}