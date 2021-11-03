using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoardModel2
{
    public class Cell
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public bool LegalNextMove { get; set; }

        //The "is" set of boolean variables are used to represent the board in boolean form.  CurrentlyOccupied shows which spots have a piece, the isPieceName
        //variables show which pieces are which on the board, and isColor are used to show the color.
        public bool CurrentlyOccupied { get; set; }
        public bool isKnight { get; set; }
        public bool isPawn { get; set; }
        public bool isBishop { get; set; }
        public bool isRook { get; set; }
        public bool isQueen { get; set; }
        public bool isKing { get; set; }
        public bool isWhite { get; set; }
        public bool isBlack { get; set; }

        public Cell(int x, int y)
        {
            RowNumber = x;
            ColumnNumber = y;
        }
    }
}
