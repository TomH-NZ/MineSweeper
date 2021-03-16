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

        public static IMineLogic NewMineChecker()
        {
            return new MineLogic();
        }
    }
}