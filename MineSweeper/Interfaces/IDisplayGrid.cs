// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public interface IDisplayGrid
    {
        int Size { get; set; }
        Cell[,] GeneratedGameCell { get; set; }
        string GenerateGameDisplay(int size);
    }
}