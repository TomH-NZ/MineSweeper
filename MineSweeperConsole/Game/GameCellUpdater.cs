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

        public void UpdateAdjacentMineTotalAtGameStart(IGameGrid currentGameGrid)
        {
            for (var row = 0; row < currentGameGrid.Size; row++)
            {
                for (var column = 0; column < currentGameGrid.Size; column++)
                {
                    var selectedCell = new PlayerMove(row, column);

                    if (!currentGameGrid.GeneratedGameCell[row, column].IsMine)
                    {
                        currentGameGrid.GeneratedGameCell[row,column].AdjacentMinesTotal = 
                            _mineUpdater.CalculateAdjacentMineTotal(currentGameGrid, selectedCell);
                    }
                }
            }
        }
    }
}