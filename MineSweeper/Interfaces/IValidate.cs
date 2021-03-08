// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public interface IValidate
    {
        bool IsUserMoveValid(string userMove);
        bool IsInitialGridSizeValid(string userInput);
        bool IsPlayerDead(IGameGrid gameGrid, string userInput);
    }
}