using MineSweeper.Interfaces;
using MineSweeper.Mines;

namespace MineSweeper.Factories
{
    public class MineFactory
    {
        public static IMineGenerator NewMineLocations()
        {
            return new MineGenerator();
        }

        public static IMineUpdater NewMineChecker()
        {
            return new MineUpdater();
        }
    }
}