// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public interface IGameGrid
    {
        int Size { get; set; }
        Cell[,] GeneratedGameCell { get; set; }
    }
}