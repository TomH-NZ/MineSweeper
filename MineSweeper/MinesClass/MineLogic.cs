using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class MineLogic : IMineLogic
    {
        public bool HasAMine(string rowInput, string columnInput, IEnumerable<string> mineLocations) // ToDo: Do I need this class? Possibly move mine checking to use IsAMine prop of Cell?
        {
            var output = false;
            int.TryParse(rowInput.Trim(), out var row); // ToDo: move validation to player input class?
            int.TryParse(columnInput.Trim(), out var column);
            var playerInput =  row + "," + column;

            foreach (var mine in mineLocations)
            {
                if (mine == playerInput)
                {
                    output = true;
                }
            }
            
            return output;
        }

        public void UpdateCellMineStatus(IEnumerable<string> mineLocations)
        {
            foreach (var mine in mineLocations)
            {
                var coordinates = mine.Split(',');
                int.TryParse(coordinates[0], out var mineRow);
                int.TryParse(coordinates[1], out var mineColumn);
                
                // ToDo: add logic to update IsAMine field in Cell.
            }
        }
    }
}
