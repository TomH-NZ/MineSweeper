using System.Collections.Generic;
using MineSweeper.Grid;
using MineSweeper.Player;

namespace MineSweeper.Interfaces
{
    public interface IMineLogic
    {
        void UpdateCellWithMineStatus(List<Cell> mineLocations, IGameGrid gameGrid);
        int CalculateAdjacentMineTotal(IGameGrid gameGrid, PlayerMove playerMove);
    }
}