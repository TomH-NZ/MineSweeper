using System.Linq;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class DisplayGrid : IDisplayGrid 
    {
        /*For the game, [0,0] is located in the top left corner, with the largest row/column being bottom right.*/
        
        public int Size { get; set; }
        public Cell[,] GeneratedGameCell { get; set; }

        public DisplayGrid(int size)
        {
            Size = size;
        }
        public string GenerateGameDisplay(int size)
        {
            var gameGrid = Factory.NewGameGrid(size);
            var output = gameGrid.GeneratedGameCell.Cast<Cell>().Aggregate("", (current, variable) => current + ". ");

            /*for (var row = 0; row < size; row++)
            {
                for (var column = 0; column < size; column++)
                {
                    
                    output += ". ";
                }

                output += "\n";
            }*/

            return output;
        }
    }
}
/*foreach (var mine in mineGenerator.MineLocations(size)) // ToDo: Look at extracting this to a separate class.
{
    var cellCoordinates = row + "," + column;

    if (mine == cellCoordinates) // ToDo: look into a contains method, or a LINQ query
    {
        GeneratedGameCell[row, column] = new Cell(row, column, CellStatus.OccupiedByMine);
    }
    else
    {
        GeneratedGameCell[row, column] = new Cell(row, column, CellStatus.NotOccupiedByMine); 
    }
}
            var mineGenerator = Factory.NewMineLocations();
            */