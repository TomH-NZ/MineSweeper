using MineSweeper.Enums;
using MineSweeper.Interfaces;
using MineSweeper.Player;

namespace MineSweeper.Validation
{
    public class Validate : IValidate
    {
        public bool IsUserMoveValid(string userMove, int gridSize)
        { //ToDo: quit command?
            var output = false;
            var rowValidation = false;
            var columnValidation = false;

            var individualMoves = userMove.Split(',');
            if (individualMoves.Length != 2) return output;
            var rowConversion = int.TryParse(individualMoves[0], out var row);
            var columnConversion = int.TryParse(individualMoves[1], out var column);
               
            if (rowConversion && row >= 0 && row < gridSize)
            {
                rowValidation = true;
            }
               
            if (columnConversion && column >= 0 && column < gridSize)
            {
                columnValidation = true;
            }
               
            if (rowValidation && columnValidation)
            {
                output = true;
            }
            
            return output;
        }

        public bool IsInitialGridSizeValid(string userGridSize, out int size )
        {
            
            if (!int.TryParse(userGridSize, out var gridSize) || gridSize < 2 || gridSize > 10)
            {
                size = 3;
                return false;
            }

            size = gridSize;
            return true;
        }

        public bool IsGameOver(IGameGrid gameGrid, PlayerMove userInput)
        {
            return gameGrid.GeneratedGameCell[userInput.Row, userInput.Column].IsMine;
        }
        
        public bool IsCellRevealed(IGameGrid gameGrid, PlayerMove userInput)
        {
            return gameGrid.GeneratedGameCell[userInput.Row, userInput.Column].DisplayStatus == CellDisplayStatus.Revealed;
        }
    }
}