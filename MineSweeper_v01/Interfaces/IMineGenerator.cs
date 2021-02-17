using System.Collections.Generic;
using MineSweeper_v01.GridClass;

namespace MineSweeper_v01.MinesClass
{
    public interface IMineGenerator
    {
        List<Cell> MineLocations(int gridSize);
    }
}