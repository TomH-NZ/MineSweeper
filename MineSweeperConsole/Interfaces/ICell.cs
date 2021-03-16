

using MineSweeper.Enums;

namespace MineSweeper.Interfaces
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