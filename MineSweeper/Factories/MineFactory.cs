// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
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