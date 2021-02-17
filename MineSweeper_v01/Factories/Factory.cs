using MineSweeper_v01.GridClass;
using MineSweeper_v01.Interfaces;
using MineSweeper_v01.MinesClass;

namespace MineSweeper_v01.Factories
{
    public class Factory
    {
        public static IGameGrid NewGameGrid(int size)
        {
            return new GameGrid(size);
        }

        public static IDisplayGrid NewGridDisplay(IGameGrid gameGrid)
        {
            return new DisplayGrid(gameGrid);
        }

        public static IMineGenerator NewMineLocations()
        {
            return new MineGenerator();
        }
    }
}