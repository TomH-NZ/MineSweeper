using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class MineLogic // Do I need this class?
    {
        public static bool CheckForMines(string rowInput, string columnInput, IEnumerable<string> mineLocations) // ToDo: Remove static
        {
            var output = false;
            var playerInput = rowInput.Trim() + "," + columnInput.Trim(); //add validation to confirm is integer.

            foreach (var mine in mineLocations)
            {
                if (mine == playerInput)
                {
                    output = true;
                }

                return output;
            }
            
            return output;
        }
    }
}
