using MineSweeper_v01.GridClass;
using MineSweeper_v01.Interfaces;
using MineSweeper_v01.MinesClass;

namespace MineSweeper_v01.Factories
{
    public class Factory
    {
        public static IGrid NewGameGrid(int size)
        {
            return new Grid(size);
        }

        public static IDisplayGrid NewGridDisplay(IGrid gameGrid)
        {
            return new DisplayGrid(gameGrid);
        }

        public static IMineGenerator NewMineLocations()
        {
            return new MineGenerator();
        }
    }
}