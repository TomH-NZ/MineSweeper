// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class DisplayGrid : IDisplayGrid
    {
        public string GenerateGameDisplay(IGameGrid gameGrid)
        {
            var output = "";

            for (var row = 0; row < gameGrid.Size; row++)
            {
                for (var column = 0; column < gameGrid.Size; column++)
                {
                    var gameCell = gameGrid.GeneratedGameCell[row, column];
                    
                    output += ". "; //ToDo: Change to ternary for testing, display + for mine, . for non-mine.
                }

                output += "\n";
            }

            return output;
        }
    }
}
