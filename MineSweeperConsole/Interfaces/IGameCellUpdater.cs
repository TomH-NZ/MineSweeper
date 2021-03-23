using MineSweeper.Interfaces;
using MineSweeper.Player;

namespace MineSweeper.Game
{
    public interface IGameCellUpdater
    {
        void UpdateDisplayStatusAfterUserMove(PlayerMove userInputMove, IGameGrid currentGameGrid);
        
        void UpdateAdjacentMineTotalAfterUserMove(PlayerMove userInputMove, IGameGrid currentGameGrid);
    }
}