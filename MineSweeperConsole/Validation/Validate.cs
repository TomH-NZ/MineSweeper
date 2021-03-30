using MineSweeper.Enums;
using MineSweeper.Interfaces;
using MineSweeper.Player;

namespace MineSweeper.Validation
{
    public class Validate : IValidate
    {
        public bool IsUserMoveValid(string userMove, int gridSize)
        {
            var output = false;
            var rowValidation = false;
            var columnValidation = false;
            var maxUsableGridSize = gridSize + 1;

            var individualUserMoves = userMove.Split(',');
            if (individualUserMoves.Length != 2) return output;
            var rowConversion = int.TryParse(individualUserMoves[0], out var row);
            var columnConversion = int.TryParse(individualUserMoves[1], out var column);
               
            if (rowConversion && row > 0 && row < maxUsableGridSize)
            {
                rowValidation = true;
            }
               
            if (columnConversion && column > 0 && column < maxUsableGridSize)
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
            var isValid = !int.TryParse(userGridSize, out var gridSize) || gridSize < 2 || gridSize > 11;
            if (isValid)
            {
                size = 0;
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