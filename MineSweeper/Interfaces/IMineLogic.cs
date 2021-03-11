using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public interface IMineLogic
    {
        void UpdateCellWithMineStatus(List<Cell> mineLocations, IGameGrid gameGrid);
        int CalculateAdjacentMineTotal(IGameGrid gameGrid, PlayerMove playerMove);
    }
}