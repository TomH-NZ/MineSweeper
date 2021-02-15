namespace MineSweeper_v01.GridClass
{
    public interface IGrid
    {
        int Size { get; set; }
        Cell[,] GeneratedGame { get; set; }
    }
}