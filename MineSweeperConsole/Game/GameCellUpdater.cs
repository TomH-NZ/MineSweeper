using MineSweeper.Enums;
using MineSweeper.Factories;
using MineSweeper.Interfaces;
using MineSweeper.Player;

namespace MineSweeper.Game
{
    public class GameCellUpdater : IGameCellUpdater
    {
        private readonly IMineUpdater _mineUpdater = MineFactory.NewMineChecker();
        
        public void UpdateDisplayStatusAfterUserMove(PlayerMove userInputMove, IGameGrid currentGameGrid)
        {
            currentGameGrid.GeneratedGameCell[userInputMove.Row, userInputMove.Column].DisplayStatus =
                CellDisplayStatus.Revealed;
        }

        public void UpdateAdjacentMineTotalAfterUserMove(PlayerMove userInputMove, IGameGrid currentGameGrid)
        {
            currentGameGrid.GeneratedGameCell[userInputMove.Row, userInputMove.Column].AdjacentMinesTotal
                = _mineUpdater.CalculateAdjacentMineTotal(currentGameGrid, userInputMove);
        }
    }
}