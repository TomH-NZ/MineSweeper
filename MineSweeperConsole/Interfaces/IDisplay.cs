using MineSweeper.Interfaces;
using MineSweeper.Player;

namespace MineSweeper.Game
{
    public interface IDisplay
    {
        string ShowUserInputMessage(int gridSize);
        void renameThisMethod(IGameGrid currentGameGrid, PlayerMove userInputMove);
    }
}