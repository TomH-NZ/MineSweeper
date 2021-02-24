using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public interface IMineLogic
    {
        bool HasAMine(string rowInput, string columnInput, IEnumerable<string> mineLocations);
    }
}