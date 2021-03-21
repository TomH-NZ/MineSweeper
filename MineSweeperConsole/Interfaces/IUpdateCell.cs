using MineSweeper.Interfaces;
using MineSweeper.Player;

namespace MineSweeper.Game
{
    public interface IUpdateCell
    {
        void DisplayStatusAfterUserMove(PlayerMove userInputMove, IGameGrid currentGameGrid);
        
        void AdjacentMineTotalAfterUserMove(PlayerMove userInputMove, IGameGrid currentGameGrid);
    }
}