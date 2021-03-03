using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class MineLogic : IMineLogic
    {
        public void UpdateCellMineStatus(IEnumerable<Cell> mineLocations, IGameGrid gameGrid, int row, int column) // ToDo: Reduce  number of parameters being passed in.
        {
            foreach (var cell in mineLocations)
            {
                gameGrid.GeneratedGameCell[row, column].IsAMine = true;
            }
        }
    }
}
