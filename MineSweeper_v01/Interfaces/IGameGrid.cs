using MineSweeper_v01.GridClass;

namespace MineSweeper_v01.Interfaces
{
    public interface IGameGrid
    {
        int Size { get; set; }
        Cell[,] GeneratedGameCell { get; set; }
    }
}