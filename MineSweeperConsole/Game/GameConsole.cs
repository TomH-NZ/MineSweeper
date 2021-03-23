using System;
using MineSweeper.Factories;
using MineSweeper.Interfaces;
using MineSweeper.Player;

namespace MineSweeper.Game
{
    public class GameConsole
    {
        private readonly IConvertUserInput _convertUserInput = Factory.NewUserInputConverter();
        private readonly IMineGenerator _mineGeneration = MineFactory.NewMineLocations();
        private readonly IMineUpdater _mineUpdater = MineFactory.NewMineChecker();
        private readonly IDisplayGrid _gameGridDisplay = GridFactory.NewDisplayGrid();
        private readonly IUpdateCell _updateCell = Factory.NewCellUpdater();
        private readonly IValidate _userInputValidation = Factory.NewUserInputValidation();
        private readonly IDisplay _gameDisplay = Factory.NewDisplayLogic();
        private int _turnCount;
        

        public void NewGame()
        {
            //For the game, [0,0] is located in the top left corner, with the largest row/column being bottom right.
            //Player move is always entered as Row then Column.

            // ToDo: Insert fancy greeting using Figgle.  Add Figgle as module to project.

            var gridSize = GetGridSize();
            var currentGameGrid = GridFactory.NewGameGrid(gridSize);
            
            var userInputMove = new PlayerMove(0, 0);
            var maxNonMineCells = gridSize * gridSize - gridSize;
            
            
            while (!_userInputValidation.IsGameOver(currentGameGrid, userInputMove) && _turnCount < maxNonMineCells)
            {
                var firstTimeRun = _turnCount == 0;
                userInputMove = RunGame(userInputMove, currentGameGrid, firstTimeRun);
                _turnCount++;
            }

            Console.Clear();
            _gameDisplay.EndGameMessage(currentGameGrid, userInputMove);
        }

        

        private PlayerMove RunGame(PlayerMove userInputMove, IGameGrid currentGameGrid, bool firstTimeRun) // ToDo: Move to separate class?
        {
            if (firstTimeRun) 
            {
                _mineUpdater.UpdateCellWithMineStatus(_mineGeneration.MineLocations(currentGameGrid.Size), currentGameGrid);
            }

            do
            {
                Console.Clear();
                Console.WriteLine(_gameGridDisplay.GenerateGameDisplay(currentGameGrid));

                var inputMove = _gameDisplay.ShowUserInputMessage(currentGameGrid.Size);

                userInputMove = _convertUserInput.ConvertUserInputToUserMove(inputMove);
                
                
            } while (_userInputValidation.IsCellRevealed(currentGameGrid, userInputMove));

            _updateCell.UpdateDisplayStatusAfterUserMove(userInputMove, currentGameGrid);
            _updateCell.UpdateAdjacentMineTotalAfterUserMove(userInputMove, currentGameGrid);

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