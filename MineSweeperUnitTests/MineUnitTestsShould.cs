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
        
        [Fact]
        public void UpdateTheStatusOfACellToRecordAMineAsTrue()
        {
            //Arrange
            var gridSize = 2;
            var newGameGrid = GridFactory.NewGameGrid(gridSize);
            newGameGrid.GenerateGrid(newGameGrid.Size);
            var updateCellMineStatus = new MineLogic();
            var mineStub = new StubForMineLocationZeroZero();

            //Act
            updateCellMineStatus.UpdateCellMineStatus(mineStub.MineLocations(newGameGrid.Size), newGameGrid);

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
            var updateCellMineStatus = new MineLogic();
            var mineStub = new StubForMineLocationZeroZero();

            //Act
            updateCellMineStatus.UpdateCellMineStatus(mineStub.MineLocations(newGame.Size), newGame);

            //Assert
            Assert.False(newGame.GeneratedGameCell[1,1].IsAMine);
        }
    }
}