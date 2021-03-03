using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class MineLogic : IMineLogic
    {
        public void UpdateCellMineStatus(List<string> mineLocations, IGameGrid gameGrid) // ToDo: Reduce  number of parameters being passed in.
        {// ToDo: If query to compare cell in mine list to cell in generated grid??
            foreach (var entry in mineLocations)
            {
                var output = entry.Split(',');
                int.TryParse(output[0], out var row);
                int.TryParse(output[1], out var column);

                gameGrid.GeneratedGameCell[row, column].IsAMine = true;
            }
        }
    }
}
