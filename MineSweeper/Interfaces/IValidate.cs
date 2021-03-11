// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public interface IValidate
    {
        bool IsUserMoveValid(string userMove, int gridSize);
        bool IsInitialGridSizeValid(string userGridSize);
        bool IsGameOver(IGameGrid gameGrid, PlayerMove userInput);
        bool IsCellRevealed(IGameGrid gameGrid, PlayerMove userInput);
    }
}