namespace MineSweeper_v01
{
    public interface IValidate
    {
        bool IsValidUserMove(string userMove);
        bool IsCorrectInitialGridSize(string userInput);
        bool IsPlayerDead(IGameGrid gameGrid, string userInput);
    }
}