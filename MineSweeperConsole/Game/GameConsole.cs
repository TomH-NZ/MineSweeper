using System;
using MineSweeper.Factories;
using MineSweeper.Interfaces;
using MineSweeper.Player;

namespace MineSweeper.Game
{
    public class GameConsole
    {
        private readonly IValidate _userInputValidation = Factory.NewUserInputValidation();
        private readonly IDisplay _gameDisplay = Factory.NewDisplayLogic();
        
        public void NewGame()
        {
            //For the game, [0,0] is located in the top left corner, with the largest row/column being bottom right.
            //Player move is always entered as Row then Column.

            // ToDo: Insert fancy greeting using Figgle.  Add Figgle as module to project.

            var gridSize = GetGridSize();
            var currentGameGrid = GridFactory.NewGameGrid(gridSize);
            
            var userInputMove = new PlayerMove(0, 0);
            var maxNonMineCells = gridSize * gridSize - gridSize;
            var turnCount = 0;
            
            
            while (!_userInputValidation.IsGameOver(currentGameGrid, userInputMove) && turnCount < maxNonMineCells)
            {
                var firstTimeRun = turnCount == 0;
                userInputMove = RunGame(userInputMove, currentGameGrid, firstTimeRun);
                turnCount++;
            }

            Console.Clear();
            _gameDisplay.EndGameMessage(currentGameGrid, userInputMove);
        }

        

        private PlayerMove RunGame(PlayerMove userInputMove, IGameGrid currentGameGrid, bool firstTimeRun) // ToDo: Move to separate class?
        {
            var updateCell = Factory.NewCellUpdater();
            var mineUpdater = MineFactory.NewMineChecker();
            var mineGeneration = MineFactory.NewMineLocations();
            var gameGridDisplay = GridFactory.NewDisplayGrid();
            var convertUserInput = Factory.NewUserInputConverter();
            
            if (firstTimeRun) 
            {
                mineUpdater.UpdateCellWithMineStatus(mineGeneration.MineLocations(currentGameGrid.Size), currentGameGrid);
            }

            do
            {
                Console.Clear();
                Console.WriteLine(gameGridDisplay.GenerateGameDisplay(currentGameGrid));

                var inputMove = _gameDisplay.ShowUserInputMessage(currentGameGrid.Size);

                userInputMove = convertUserInput.ConvertInputToUserMove(inputMove);
            } while (_userInputValidation.IsCellRevealed(currentGameGrid, userInputMove));

            updateCell.UpdateDisplayStatusAfterUserMove(userInputMove, currentGameGrid);
            updateCell.UpdateAdjacentMineTotalAfterUserMove(userInputMove, currentGameGrid);

            return userInputMove;
        }

        private int GetGridSize()
        {
            var userInputGridSize = "";
            int size;
            
            while (!_userInputValidation.IsInitialGridSizeValid(userInputGridSize, out size))
            {
                Console.WriteLine("Please enter a grid size between 2 and 10: ");
                userInputGridSize = Console.ReadLine();
            }

            return size;
        }
    }
}