using MineSweeper.Interfaces;
using MineSweeper.Player;

namespace MineSweeper.Game
{
    public interface IUpdateCell
    {
        void UpdateDisplayStatusAfterUserMove(PlayerMove userInputMove, IGameGrid currentGameGrid);
        
        void UpdateAdjacentMineTotalAfterUserMove(PlayerMove userInputMove, IGameGrid currentGameGrid);
    }
}