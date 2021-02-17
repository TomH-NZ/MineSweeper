using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public interface IMineGenerator
    {
        List<Cell> MineLocations(int gridSize);
    }
}