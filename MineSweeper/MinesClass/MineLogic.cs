using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class MineLogic : IMineLogic
    {
        public void UpdateCellMineStatus(IEnumerable<Cell> mineLocations)
        {
            foreach (var cell in mineLocations)
            {
                cell.IsAMine = true;
            }
        }
    }
}
