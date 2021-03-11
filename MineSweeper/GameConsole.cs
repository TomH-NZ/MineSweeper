using System;

namespace MineSweeper_v01
{
    public class GameConsole
    {
        public void NewGame()
        {
            //For the game, [0,0] is located in the top left corner, with the largest row/column being bottom right.
            //Player move is always entered as Row then Column.
            
            // ToDo: Insert fancy greeting using Figgle.  Add Figgle as module to project.

            var userInputGridSize = "";
            var userInputValidation = Factory.NewUserInputValidation();
            var gameGridDisplay = GridFactory.NewGridDisplay();
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
            
            var rowOutput = 0; // ToDo: Define variables just before they are used, rather than at the top of the class.
            var columnOutput = 0;
            var userInputMove = new PlayerMove(rowOutput, columnOutput); // ToDo: Swap to using Cell[,] as the input type?? Tuple??
            var turnCount = 0;
            
            while (!userInputValidation.IsPlayerDead(newGameGrid, userInputMove))
            {
                Console.Clear();
                Console.WriteLine(gameGridDisplay.GenerateGameDisplay(newGameGrid));
                
                var rowInput = "";
                while (!userInputValidation.IsUserMoveValid(rowInput, newGameGrid.Size))
                {
                    Console.WriteLine($"Please enter a row ( 0 - {gridSize - 1 }): ");
                    rowInput += Console.ReadLine();
                    
                }
                
                var columnInput = "";
                while (!userInputValidation.IsUserMoveValid(columnInput, newGameGrid.Size))
                {
                    Console.WriteLine($"Please enter a column ( 0 - {gridSize - 1 }): ");
                    columnInput = Console.ReadLine();
                }

                int.TryParse(rowInput, out var row);
                int.TryParse(columnInput, out var column);
                userInputMove = new PlayerMove(row, column);
                userInputValidation.IsPlayerDead(newGameGrid, userInputMove);

                if (turnCount == 0)
                {
                    mineUpdater.UpdateCellWithMineStatus(mineGeneration.MineLocations(gridSize), newGameGrid);
                }

                turnCount++;
            }

            Console.WriteLine("Game Over!");
        }
    }
}