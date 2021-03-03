using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class MineGenerator : IMineGenerator
    {
        public List<string> MineLocations(int gridSize)
        {
            var generatedMineList = new List<string>();

            for (var row = 0; row < gridSize; row++)
            {
                for (var column = 0; column < gridSize; column++)
                {
                    generatedMineList.Add(row + "," + column);
                }
            }

            var convertedMineList = generatedMineList.OrderBy(x => Guid.NewGuid()).ToList().Take(gridSize);
            var outputMineList = convertedMineList.ToList();
            
            return outputMineList;
        }
    }
}
// ToDo: when grid generated, output cells to list.
// ToDo: import list into mine logic, shuffle list then choose first [size] in list as mine location.

// 