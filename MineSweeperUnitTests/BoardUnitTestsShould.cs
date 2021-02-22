
using System.Collections.Generic;
using MineSweeper_v01;
using Xunit;

namespace MineSweeperUnitTests
{
    public class BoardUnitTestsShould
    {
        private class StubReturnsZeroZeroAsCoordinates: IMineGenerator
        {
            public List<string> MineLocations(int gridSize)
            {
                var internalMineList = new List<string> {"0,0"};
                
                return internalMineList;
            }
        }
        
        private class StubReturnsOneOneAsCoordinates: IMineGenerator
        {
            public List<string> MineLocations(int gridSize)
            {
                var internalMineList = new List<string> {"1,1"};
                
                return internalMineList;
            }
            
        }
        
        private class StubReturnsTwoTwoAsCoordinates: IMineGenerator
        {
            public List<string> MineLocations(int gridSize)
            {
                var internalMineList = new List<string> {"2,2"};
                
                return internalMineList;
            }
        }
        
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

        
        [Fact]
        public void ReturnTrueWhenCellIsOccupiedByAMine()
        {
            //Arrange
            var rowUserInput = "0";
            var columnUserInput = "0";
            var mineLocations = new StubReturnsZeroZeroAsCoordinates();

            //Act
            var result = MineLogic.CheckForMines(rowUserInput, columnUserInput, mineLocations.MineLocations(2));

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void ReturnFalseWhenAMineIsNotOccupiedByAMine()
        {
            //Arrange
            var rowUserInput = " 0 ";
            var columnUserInput = "0";
            var mineLocations = new StubReturnsOneOneAsCoordinates();

            //Act
            var result = MineLogic.CheckForMines(rowUserInput, columnUserInput, mineLocations.MineLocations(2));

            //Assert
            Assert.False(result);    
        }
    }
}