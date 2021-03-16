using System;
using System.Collections.Generic;
using MineSweeper.Factories;
using MineSweeper.Grid;
using MineSweeper.Interfaces;
using Xunit;

namespace MineSweeperUnitTests
{
    public class GridUnitTestsShould
    {
        private class StubForTwoMineLocations : IMineGenerator
        {
            public List<Cell> MineLocations(int gridSize)
            {
                var output = new List<Cell> {new Cell(0, 1), new Cell(1, 0)};

                return output;
            }
        }
        
        [Theory]
        [InlineData(2, 2)]
        [InlineData(4, 4)]
        [InlineData(10, 10)]
        [InlineData(5, 5)]
        public void GenerateABoardOfTheCorrectSize(int size, int expected)
        {
            //Arrange
            
            //Act
            var result = GridFactory.NewGameGrid(size);
            
            //Assert
            Assert.Equal(expected, result.Size);
        }

        [Theory]
        [InlineData(2, ". . \n. . \n")]
        [InlineData(3, ". . . \n. . . \n. . . \n")]
        [InlineData(4, ". . . . \n. . . . \n. . . . \n. . . . \n")]
        [InlineData(5, ". . . . . \n. . . . . \n. . . . . \n. . . . . \n. . . . . \n")]
        public void DisplayABoardWithTheCorrectDimensions(int size, string expected)
        {
            //Arrange
            var newDisplay = GridFactory.NewDisplayGrid();
            var gameGrid = GridFactory.NewGameGrid(size);
            
            //Act
            var result = newDisplay.GenerateGameDisplay(gameGrid);
            
            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DisplayBoardWithGeneratedMinesCorrectly()
        {
            //Arrange
            var gridSize = 2;
            var newGrid = GridFactory.NewGameGrid(gridSize);
            var gameDisplay = GridFactory.NewDisplayGrid();
            var mineLogic = MineFactory.NewMineChecker();
            var mineLocations = new StubForTwoMineLocations();
            mineLogic.UpdateCellWithMineStatus(mineLocations.MineLocations(gridSize), newGrid);

            //Act
            
            var result = gameDisplay.GenerateGameDisplay(newGrid);

            //Assert
            Assert.Equal(". + \n+ . \n", result);
        }
    }
}