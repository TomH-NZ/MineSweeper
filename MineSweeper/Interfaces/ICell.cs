// ReSharper disable once CheckNamespace

using MineSweeper_v01.Enums;

namespace MineSweeper_v01
{
    public interface ICell
    {
        int Row { get; }
        int Column { get; }
        bool IsMine { get; set; }
        int AdjacentMinesTotal { get; set; }
        CellDisplayStatus DisplayStatus { get; set; }
    }
}