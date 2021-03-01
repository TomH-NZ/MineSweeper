// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class Factory
    {
        public static IGameGrid NewGameGrid(int size)
        {
            return new GameGrid(size);
        }

        public static IDisplayGrid NewGridDisplay(int size)
        {
            return new DisplayGrid(size);
        }

        public static IMineGenerator NewMineLocations()
        {
            return new MineGenerator();
        }

        public static IMineLogic NewMineChecker()
        {
            return new MineLogic();
        }
    }
}