// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public interface ICell
    {
        int RowLocationValue { get; }
        int ColumnLocationValue { get; }
        bool IsAMine { get; set; }
        int NumberOfAdjacentMines { get; set; }
        bool HasBeenRevealed { get; set; }
    }
}