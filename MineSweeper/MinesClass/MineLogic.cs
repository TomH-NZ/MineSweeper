using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class MineLogic
    {
        public static bool CheckForMines(string rowInput, string columnInput, IEnumerable<string> mineLocations)
        {
            var output = false;
            var playerInput = rowInput.Trim() + "," + columnInput.Trim();

            foreach (var mine in mineLocations)
            {
                if (mine == playerInput)
                {
                    output = true;
                }

                return output;
            }
            
            return true;
        }
    }
}
