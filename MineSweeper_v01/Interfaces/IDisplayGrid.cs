using MineSweeper_v01.Interfaces;

namespace MineSweeper_v01.GridClass
{
    public interface IDisplayGrid
    {
        string GenerateGameDisplay(IGameGrid gameGrid);
    }
}