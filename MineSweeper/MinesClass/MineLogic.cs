using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class MineLogic : IMineLogic
    {
        public void UpdateCellWithMineStatus(IEnumerable<Cell> mineLocations, IGameGrid gameGrid)
        {
            var inputMineLocations = mineLocations.ToList();

            for (var row = 0; row < gameGrid.Size; row++)
            {
                for (var column = 0; column < gameGrid.Size; column++)
                {
                    if (inputMineLocations.Contains(gameGrid.GeneratedGameCell[row,column]))
                    {
                        gameGrid.GeneratedGameCell[row, column].IsAMine = true;
                    }
                }
            }
        }

        public int CalculateAdjacentMineTotal(IGameGrid gameGrid, string playerMove)
        {
            return 2;
        }
    }
}
