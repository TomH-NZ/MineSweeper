using System.Runtime.CompilerServices;
using MineSweeper_v01.Enums;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
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

        public bool IsInitialGridSizeValid(string userGridSize)
        {
            var output = false;
            var validatedUserInput = int.TryParse(userGridSize, out var gridSize);

            if (validatedUserInput && gridSize >= 2 && gridSize <= 10)
            {
                output = true;
            }

            return output;
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