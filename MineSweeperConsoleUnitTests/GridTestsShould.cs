using System.Collections.Generic;
using MineSweeper.Factories;
using MineSweeper.Grid;
using MineSweeper.Interfaces;
using Xunit;

namespace MineSweeperConsoleUnitTests
{
    public class GridTestsShould
    {
        private class StubForTwoMineLocations : IMineGenerator
        {
            public List<Cell> MineLocations(int gridSize)
            {
                var output = new List<Cell> {new Cell(1, 2), new Cell(2, 1)};

                return output;
            }
        }
        
        [Theory]
        [InlineData(2, 3)]
        [InlineData(4, 5)]
        [InlineData(10, 11)]
        [InlineData(5, 6)]
        public void GenerateABoardOfTheCorrectSize(int size, int expected)
        {
            //Arrange
            
            //Act
            var result = GridFactory.NewGameGrid(size);
            
            //Assert
            Assert.Equal(expected, result.Size);
        }

        [Theory]
        [InlineData(2, "0 1 2 \n1 . . \n2 . . \n")]
        [InlineData(3, "0 1 2 3 \n1 . . . \n2 . . . \n3 . . . \n")]
        [InlineData(4, "0 1 2 3 4 \n1 . . . . \n2 . . . . \n3 . . . . \n4 . . . . \n")]
        [InlineData(5, "0 1 2 3 4 5 \n1 . . . . . \n2 . . . . . \n3 . . . . . \n4 . . . . . \n5 . . . . . \n")]
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
            Assert.Equal("0 1 2 \n1 . + \n2 + . \n", result);
        }
    }
}