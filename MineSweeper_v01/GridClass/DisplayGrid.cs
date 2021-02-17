using System;
using MineSweeper_v01.Interfaces;

namespace MineSweeper_v01.GridClass
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
                    
                    if (!gameCell.IsOccupiedByMine)
                    {
                        output += ". ";
                    }
                    else
                    {
                        output += "+ ";
                    }
                }

                output += "\n";
            }

            return output;
        }
    }
} //move logic to method outside const, output as string using Console.Write
