
using MineSweeper.Player;

namespace MineSweeper.Interfaces
{
    public interface IValidate
    {
        bool IsUserMoveValid(string userMove, int gridSize);
        bool IsInitialGridSizeValid(string userGridSize, out int size);
        bool IsGameOver(IGameGrid gameGrid, PlayerMove userInput);
        bool IsCellRevealed(IGameGrid gameGrid, PlayerMove userInput);
    }
}