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

            var output = "";

            for (var row = 0; row < size; row++)
            {
                for (var column = 0; column < size; column++)
                {

                    output += ". ";
                }

                output += "\n";
            }
            return output;
        }
    }
}

/*for (var row = 0; row < size; row++)
            {
                for (var column = 0; column < size; column++)
                {
                    
                    output += ". ";
                }

                output += "\n";
            }*/