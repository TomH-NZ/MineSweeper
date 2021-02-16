using MineSweeper_v01.Factories;
using MineSweeper_v01.GridClass;
using MineSweeper_v01.Interfaces;
using Xunit;

namespace MineSweeperUnitTests
{
    public class BoardUnitTestsShould
    {
        [Fact]
        public void GenerateABoardOfSize2()
        {
            //Arrange
            
            //Act
            var result = Factory.NewGameGrid(2);
            
            //Assert
            Assert.Equal(2, result.Size);
        }

        /*[Fact]
        public void DisplayABoardOfSizeTwoCorrectly()
        {
            //Arrange
            var newTestGame = Factory.NewGameGrid(2);
            
            //Act
            var result = Factory.NewGridDisplay(newTestGame);
            
            //Assert
            Assert.Equal(". . \n. . \n", result);
        }*/

        private class StubForMineGeneration :IMine
        {
            public Cell MineCellGeneration
            { 
                return {Cell(0, 0)};
            }
        }
        
        [Fact]
        public void ReturnAMineLocationCorrectly()
        {
            //Arrange
            var gameBoard = Factory.NewGameGrid(2);

            //Act

            //Assert
        }
    }
}