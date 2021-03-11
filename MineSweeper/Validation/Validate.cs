
// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class Validate : IValidate
    {
        public bool IsUserMoveValid(string userMove, int gridSize)
        {
            var output = false;
            var validatedUserInput = int.TryParse(userMove, out var number);

            if (validatedUserInput && number >= 0 && number < gridSize)
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

        public bool IsPlayerDead(IGameGrid gameGrid, PlayerMove userInput)
        {// ToDo: player selects all non-mine squares, what happens??
            var output = gameGrid.GeneratedGameCell[userInput.Row, userInput.Column].IsMine;

            return output;
        }
    }
}