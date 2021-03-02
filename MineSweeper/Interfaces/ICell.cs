// ReSharper disable once CheckNamespace

using MineSweeper_v01.Enums;

namespace MineSweeper_v01
{
    public interface ICell
    {
        int RowLocationValue { get; }
        int ColumnLocationValue { get; }
        bool IsAMine { get; set; }
        int NumberOfAdjacentMines { get; set; }
        CellDisplayStatus DisplayStatus { get; set; }
    }
}