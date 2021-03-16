
using MineSweeper.Grid;

namespace MineSweeper.Interfaces
{
    public interface IGameGrid
    {
        int Size { get; set; }
        Cell[,] GeneratedGameCell { get; set; }
    }
}