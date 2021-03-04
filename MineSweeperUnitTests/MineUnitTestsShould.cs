using System.Collections.Generic;
using MineSweeper_v01;
using Xunit;

namespace MineSweeperUnitTests
{
    public class MineUnitTestsShould
    {
        private class StubForMineLocationZeroZero : IMineGenerator
        {
            public List<Cell> MineLocations(int gridSize)
            {
                var output = new List<Cell> {new Cell(0,0)};
                return output;
            }
        }
        
        private class StubForTwoMineLocations : IMineGenerator
        {
            public List<Cell> MineLocations(int gridSize)
            {
                var output = new List<Cell> {new Cell(0, 1), new Cell(1, 0)};

                return output;
            }
        }
        
        [Fact]
        public void UpdateTheStatusOfACellToRecordAMineAsTrue()
        {
            //Arrange
            var gridSize = 2;
            var newGameGrid = GridFactory.NewGameGrid(gridSize);
            newGameGrid.GenerateGrid(newGameGrid.Size);
            var updateMineStatus = new MineLogic();
            var mineStub = new StubForMineLocationZeroZero();

            //Act
            updateMineStatus.UpdateCellWithMineStatus(mineStub.MineLocations(newGameGrid.Size), newGameGrid);

            //Assert
            Assert.True(newGameGrid.GeneratedGameCell[0,0].IsAMine);
        }
        
        [Fact]
        public void UpdateTheStatusOfACellToRecordAMineAsFalse()
        {
            //Arrange
            var gridSize = 2;
            var newGame = GridFactory.NewGameGrid(gridSize);
            newGame.GenerateGrid(newGame.Size);
            var updateMineStatus = new MineLogic();
            var mineStub = new StubForMineLocationZeroZero();

            //Act
            updateMineStatus.UpdateCellWithMineStatus(mineStub.MineLocations(newGame.Size), newGame);

            //Assert
            Assert.False(newGame.GeneratedGameCell[1,1].IsAMine);
        }

        [Fact]
        public void ReturnTwoAdjacentMinesAfterAPlayerMove()
        {
            //Arrange
            var newGameGrid = GridFactory.NewGameGrid(3);
            newGameGrid.GenerateGrid(newGameGrid.Size);
            var updateMineStatus = new MineLogic();
            var mineStub = new StubForTwoMineLocations();

            //Act
            updateMineStatus.UpdateCellWithMineStatus(mineStub.MineLocations(newGameGrid.Size), newGameGrid);
            var result = updateMineStatus.CalculateAdjacentMineTotal(newGameGrid, "1,1");

            //Assert
            Assert.Equal(2, result);
        }
    }
}