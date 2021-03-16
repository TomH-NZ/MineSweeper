using System.Collections.Generic;
using MineSweeper.Grid;

namespace MineSweeper.Interfaces
{
    public interface IMineGenerator
    {
        List<Cell> MineLocations(int gridSize);
    }
}