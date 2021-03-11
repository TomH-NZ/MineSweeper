// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public interface IValidate
    {
        bool IsUserMoveValid(string userMove, int gridSize);
        bool IsInitialGridSizeValid(string userGridSize);
        bool IsPlayerDead(IGameGrid gameGrid, PlayerMove userInput);
    }
}