using MineSweeper.Interfaces;
using MineSweeper.Player;

namespace MineSweeper.Game
{
    public interface IMessageDisplay
    {
        string ShowUserInputMessage(int gridSize);
        string EndGameMessage(IGameGrid currentGameGrid, PlayerMove userInputMove);
    }
}