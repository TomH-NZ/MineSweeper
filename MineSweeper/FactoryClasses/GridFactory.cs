// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class GridFactory
    {
        public static IGameGrid NewGameGrid(int size)
        {
            return new GameGrid(size);
        }

        public static IDisplayGrid NewGridDisplay(int size)
        {
            return new DisplayGrid(size);
        }
    }
}