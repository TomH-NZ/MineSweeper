using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class MineLogic : IMineLogic // ToDo: Delete class? Checking logic moved to DisplayGrid.
    {
        public bool HasAMine(string rowInput, string columnInput, IEnumerable<string> mineLocations) //ToDo: Change to use CellStatus for mine checking
        {
            var output = false;
            var playerInput = rowInput.Trim() + "," + columnInput.Trim(); //ToDo: add validation to confirm is integer.

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
