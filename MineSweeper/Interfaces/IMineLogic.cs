using System.Collections.Generic;

namespace MineSweeper_v01
{
    public interface IMineLogic
    {
        bool CheckForMines(string rowInput, string columnInput, IEnumerable<string> mineLocations) // ToDo: Remove static
            ;
    }
}