using System.Collections.Generic;
using System.Runtime.InteropServices;
using MineSweeper_v01.Factories;
using MineSweeper_v01.GridClass;
using MineSweeper_v01.MinesClass;
using Xunit;

namespace MineSweeperUnitTests
{
    public class BoardUnitTestsShould
    {
        [Theory]
        [InlineData(2, 2)]
        [InlineData(4, 4)]
        [InlineData(10, 10)]
        [InlineData(5, 5)]
        public void GenerateABoardOfTheCorrectSize(int difficulty, int expected)
        {
            //Arrange
            
            //Act
            var result = Factory.NewGameGrid(difficulty);
            
            //Assert
            Assert.Equal(expected, result.Size);
        }

        [Theory]
        [InlineData(2, ". . \n. . \n")]
        [InlineData(3, ". . . \n. . . \n. . . \n")]
        [InlineData(4, ". . . . \n. . . . \n. . . . \n. . . . \n")]
        [InlineData(5, ". . . . . \n. . . . . \n. . . . . \n. . . . . \n. . . . . \n")]
        public void DisplayABoardWithTheCorrectDimensions(int difficulty, string expected)
        {
            //Arrange
            var newTestGame = Factory.NewGameGrid(difficulty);
            var newDisplay = Factory.NewGridDisplay();
            
            //Act
            var result = newDisplay.GenerateGameDisplay(newTestGame);
            
            //Assert
            Assert.Equal(expected, result);
        }

        /*private class StubForMineGeneration: IMineGenerator
        {
            public List<Cell> MineLocations(int gridSize)
            {
                var internalMineList = new List<Cell> {new Cell(0,0)}; // needed to instantiate the Cell class to be able to feed it the coords
                
                return internalMineList;
            }
        }*/
        
        /*[Fact]
        public void ReturnAMineLocationCorrectly()
        {
            //Arrange
            var gameBoard = Factory.NewGameGrid(2);

            //Act

            //Assert
        }*/
    }
}