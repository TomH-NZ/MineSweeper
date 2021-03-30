using System;
using System.Collections.Generic;
using MineSweeper.Factories;
using MineSweeper.Grid;
using MineSweeper.Interfaces;

namespace MineSweeper.Mines
{
    public class MineGenerator : IMineGenerator
    {
        public List<Cell> MineLocations(int gridSize)
        {
            var generatedMineList = new List<Cell>();
            var displayedGridSize = gridSize - 1;
            var gameGrid = GridFactory.NewGameGrid(displayedGridSize);

            for (var row = 1; row < gameGrid.Size; row++)
            {
                for (var column = 1; column < gameGrid.Size; column++)
                {
                    generatedMineList.Add(gameGrid.GeneratedGameCell[row, column]);
                    gameGrid.GeneratedGameCell[row, column].IsMine = true;
                }
            }

            var convertedMineList = new List<Cell>(); 

            for (var cell = 1; cell < gameGrid.Size; cell++)
            {
                var rnd = new Random();
                var randomMine = generatedMineList.Count;
                var mine = rnd.Next(randomMine);
                convertedMineList.Add(generatedMineList[mine]);
                generatedMineList.Remove(generatedMineList[mine]);
            }
            
            return convertedMineList;
        }
    }
}
