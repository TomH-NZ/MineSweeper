using MineSweeper_v01.GridClass;

namespace MineSweeper_v01.Factories
{
    public class Factory
    {
        public static IGrid NewGameGrid(int difficulty)
        {
            return new Grid(difficulty);
        }

        public static IDisplayGrid NewGridDisplay(IGrid gameGrid)
        {
            return new DisplayGrid(gameGrid);
        }
    }
}