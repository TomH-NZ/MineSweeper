// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public interface IDisplayGrid
    {
        int Size { get; set; }
        string GenerateGameDisplay(int size);
    }
}