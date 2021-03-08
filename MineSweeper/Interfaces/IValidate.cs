// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public interface IValidate
    {
        bool IsValidUserMove(string userMove);
        bool IsInitialGridSizeCorrect(string userInput);
        bool IsPlayerDead(IGameGrid gameGrid, string userInput);
    }
}