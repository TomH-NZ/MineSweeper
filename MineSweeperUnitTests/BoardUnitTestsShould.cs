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
            
            //Act
            var result = Factory.DisplayGrid();
            
            //Assert
            Assert.Equal(".. \n..\n", result);
        }
    }
}