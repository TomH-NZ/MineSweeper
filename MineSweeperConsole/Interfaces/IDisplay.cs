using MineSweeper.Interfaces;
using MineSweeper.Player;

namespace MineSweeper.Game
{
    public interface IDisplay
    {
        string ShowUserInputMessage(int gridSize);
        void EndGameMessage(IGameGrid currentGameGrid, PlayerMove userInputMove);
    }
}