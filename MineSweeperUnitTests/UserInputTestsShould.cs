using MineSweeper_v01;
using Xunit;

namespace MineSweeperUnitTests
{
    public class UserInputTestsShould
    {
        [Fact]
        public void ReturnTrueForAUserInputNumberBetweenZeroAndNine()
        {
            //Arrange
            var validateTest = new Validate();

            //Act

            //Assert
            Assert.True(validateTest.UserGridMove("1"));
        }

        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("9a")]
        [InlineData("10")]
        public void ReturnFalseForUserInputNotANumberOrGreaterThanNine(string input)
        {
            //Arrange
            var validateTest = new Validate();

            //Act

            //Assert
            Assert.False(validateTest.UserGridMove(input));
        }

        [Fact]
        public void ReturnTrueForAUserInputGridSizeBetweenTwoAndTen()
        {
            //Arrange
            var validateTest = new Validate();

            //Act

            //Assert
            Assert.True(validateTest.InitialGridSize("5"));
        }

        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("9a")]
        [InlineData("11")]
        public void ReturnFalseForUserInputGridSizeNotANumberOrOutsideZeroAndTen(string input)
        {
            //Arrange
            var validateTest = new Validate();

            //Act

            //Assert
            Assert.False(validateTest.InitialGridSize(input));
        }
    }
}