// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public interface IGameGrid
    {
        int Size { get; set; }
        ICell[,] GeneratedGameCell { get; set; }

        void GenerateGrid(int size) // ToDo: look into using a celldisplay class, with logic for each staus (. , * , @)
            ;
    }
}