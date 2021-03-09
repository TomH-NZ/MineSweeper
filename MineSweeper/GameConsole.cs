using System;

namespace MineSweeper_v01
{
    public class GameConsole
    {
        public void NewGame()
        {
            // ToDo: Insert fancy greeting using Figgle.  Add Figgle as module to project.

            var userInputGridSize = "";
            var userInputValidation = Factory.NewUserInputValidation();
            var gridDisplay = GridFactory.NewGridDisplay();
            var mineGeneration = MineFactory.NewMineLocations();
            var mineUpdater = MineFactory.NewMineChecker();
            
            while (!userInputValidation.IsInitialGridSizeValid(userInputGridSize))
            {
                Console.WriteLine("Please enter a grid size between 2 and 10: ");
                userInputGridSize = Console.ReadLine();
                userInputValidation.IsInitialGridSizeValid(userInputGridSize);
            }

            int.TryParse(userInputGridSize, out var gridSize);
            var newGameGrid = GridFactory.NewGameGrid(gridSize);
            newGameGrid.GenerateGrid(newGameGrid.Size);
            mineUpdater.UpdateCellWithMineStatus(mineGeneration.MineLocations(gridSize), newGameGrid);
            Console.WriteLine(gridDisplay.GenerateGameDisplay(newGameGrid));
            // ToDo: GenerateGameDisplay runs the grid generation again, resetting cell mien status to False. 
            // ToDo: Need to figure out how to generate the grid and then feed it into the Display method separately ....
            // ToDo: so that it doesn't reset the cell status.
        }
    }
}