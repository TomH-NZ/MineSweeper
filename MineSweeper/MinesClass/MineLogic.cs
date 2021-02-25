using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class MineLogic : IMineLogic
    {
        public bool HasAMine(string rowInput, string columnInput, IEnumerable<string> mineLocations)
        {
            var output = false;
            int.TryParse(rowInput.Trim(), out var row);
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
    }
}
