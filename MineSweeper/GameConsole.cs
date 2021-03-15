using System;
using MineSweeper_v01.Enums;

namespace MineSweeper_v01
{
    public class GameConsole
    {
        public void NewGame()
        {
            //For the game, [0,0] is located in the top left corner, with the largest row/column being bottom right.
            //Player move is always entered as Row then Column.

            // ToDo: Insert fancy greeting using Figgle.  Add Figgle as module to project.
            // ToDo: use emoji for bomb??

            var userInputGridSize = "";
            var userInputValidation = Factory.NewUserInputValidation();

            while (!userInputValidation.IsInitialGridSizeValid(userInputGridSize))
            {
                Console.WriteLine("Please enter a grid size between 2 and 10: ");
                userInputGridSize = Console.ReadLine();
            }

            int.TryParse(userInputGridSize, out var gridSize);
            var newGameGrid = GridFactory.NewGameGrid(gridSize);

            var gameGridDisplay = GridFactory.NewDisplayGrid();
            var mineGeneration = MineFactory.NewMineLocations();
            var mineUpdater = MineFactory.NewMineChecker();

            var rowMove = 0;
            var columnMove = 0;
            var userInputMove = new PlayerMove(rowMove, columnMove);
            var turnCount = 0;

            while (!userInputValidation.IsGameOver(newGameGrid, userInputMove))
            {
                if (turnCount == 0)
                {
                    mineUpdater.UpdateCellWithMineStatus(mineGeneration.MineLocations(gridSize), newGameGrid);
                }

                while (userInputValidation.IsCellRevealed(newGameGrid, userInputMove) || turnCount == 0)
                {
                    Console.Clear();
                    Console.WriteLine(gameGridDisplay.GenerateGameDisplay(newGameGrid));

                    var inputMove = string.Empty;
                    do
                    {
                        Console.WriteLine($"Please enter grid coordinates (row,column) between 0 - {gridSize - 1}: ");
                        inputMove = Console.ReadLine();
                    } while (!userInputValidation.IsUserMoveValid(inputMove, newGameGrid.Size)); // ToDo: do-while
                    
                    var moveSplit =
                        inputMove.Split(','); // ToDO: move logic to a new class, have output as PlayerMove[,]
                    int.TryParse(moveSplit[0], out var row);
                    int.TryParse(moveSplit[1], out var column);
                    userInputMove = new PlayerMove(row, column);
                    turnCount++;
                }

                newGameGrid.GeneratedGameCell[userInputMove.Row, userInputMove.Column].DisplayStatus =
                    CellDisplayStatus.Revealed;
                newGameGrid.GeneratedGameCell[userInputMove.Row, userInputMove.Column].AdjacentMinesTotal
                    = mineUpdater.CalculateAdjacentMineTotal(newGameGrid, userInputMove);

                if (turnCount == gridSize * gridSize - gridSize)
                {
                    break;
                }
            }

            Console.Clear();
            Console.WriteLine(gameGridDisplay.GameOverDisplay(newGameGrid));

            Console.WriteLine(newGameGrid.GeneratedGameCell[userInputMove.Row, userInputMove.Column].IsMine
                ? "Sorry, you have lost.\nGame over!"
                : "Congrats!\nYou have won!");
        }
    }
}