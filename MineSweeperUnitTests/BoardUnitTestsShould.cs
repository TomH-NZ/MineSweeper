using MineSweeper_v01.Factories;
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

        [Fact]
        public void DisplayABoardOfSizeTwoCorrectly()
        {
            //Arrange
            var newTestGame = Factory.NewGameGrid(2);
            var newGridDisplay = Factory.DisplayGrid(newTestGame);
            
            //Act
            var result = newGridDisplay;
            
            //Assert
            Assert.Equal("..\n..\n", result);
        }
    }
}