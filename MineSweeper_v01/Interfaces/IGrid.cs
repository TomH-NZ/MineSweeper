using MineSweeper_v01.GridClass;

namespace MineSweeper_v01.Interfaces
{
    public interface IGrid
    {
        int Size { get; set; }
        Cell[,] GeneratedGame { get; set; }
    }
}