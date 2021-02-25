// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public interface IGameGrid
    {
        public int Size { get; set; }
        public Cell[,] GeneratedGameCell { get; set; }
    }
}