// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class Factory
    {
        public static IGameGrid NewGameGrid(int size)
        {
            return new GameGrid(size);
        }

        public static IDisplayGrid NewGridDisplay()
        {
            return new DisplayGrid();
        }

        public static IMineGenerator NewMineLocations()
        {
            return new MineGenerator();
        }

        public static IGameCreation NewMineSweeperGame()
        {
            return new GameCreation();
        }

        public static IMineLogic NewMineChecker()
        {
            return new MineLogic();
        }
    }
}