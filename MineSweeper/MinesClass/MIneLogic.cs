using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class MineLogic
    {
        public static CellStatus CheckForMines(string rowInput, string columnInput, List<Cell> mineLocations)
        {
            return CellStatus.OccupiedByMine;
        }
    }
}