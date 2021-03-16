
using MineSweeper.Grid;
using MineSweeper.Interfaces;

namespace MineSweeper.Factories
{
    public class GridFactory
    {
        public static IGameGrid NewGameGrid(int size)
        {
            return new GameGrid(size);
        }

        public static IDisplayGrid NewDisplayGrid()
        {
            return new DisplayGrid();
        }
    }
}