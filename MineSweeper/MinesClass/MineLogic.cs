using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class MineLogic
    {
        public static bool CheckForMines(string rowInput, string columnInput, IEnumerable<Cell> mineLocations)
        {
            int.TryParse(rowInput, out var row);
            int.TryParse(columnInput, out var column);
            var output = false;

            var playerInput = new Cell(row, column, CellStatus.OccupiedByMine); // do I really need CellStatus??
            
            foreach (var mine in mineLocations)
            {
                if (mine == playerInput) //one possibility is to compare each element in the cell (player.row == mine.row, etc)
                {
                    output = true;
                } //another way is convert cell to string, compare to player input string

                return output;
            }
            
            return true;
        }
    }
}
// ToDo: Issue may be related to hashcode equality issue.
// ToDo: Need to implement hashcode for the Cell class as it has 2 int/1 enum for equality.
// ToDo: https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=net-5.0
// ToDo: https://docs.microsoft.com/en-us/visualstudio/ide/reference/generate-equals-gethashcode-methods?view=vs-2019
// ToDo: https://www.jetbrains.com/help/resharper/Code_Generation__Equality_Members.html