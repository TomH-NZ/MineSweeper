using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class MineGenerator : IMineGenerator // ToDo: look into writing test for this class.
    {
        public List<string> MineLocations(int gridSize)
        {
            var internalMineList = new List<string>();
            var randomCoordinates = RandomMineCoordinates(gridSize);

            while (internalMineList.Count < gridSize)
            {
                if (!internalMineList.Contains(randomCoordinates))
                {
                    internalMineList.Add(randomCoordinates);
                }
                else
                {
                    randomCoordinates = RandomMineCoordinates(gridSize);
                }
            }
            
            return internalMineList;
        }

        private string RandomMineCoordinates(int gridSize)
        {
            var randomMineRow = new Random().Next(0, gridSize);
            var randomMineColumn = new Random().Next(0, gridSize);

            var mine = randomMineRow + "," + randomMineColumn;

            return mine;
        }
    }
}
// ToDo: when grid generated, output cells to list.
// ToDo: import list into mine logic, shuffle list then choose first [size] in list as mine location.