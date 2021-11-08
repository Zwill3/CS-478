using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoardModel2
{
    public class Board
    {
        int Size { get; set; }
        Cell[,] TheGrid { get; set; }

        Piece pieceManager = new Piece();

        //Default Constructor
        public Board()
        {
            Size = 8;

            //Instantiate each of the cells that make up the board.
            TheGrid = new Cell[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    TheGrid[i, j] = new Cell(i, j);
                }
            }

            //The initial board creation is manual so the code can then properly use the cells after creation
            //Begin Black Piece Creation
            TheGrid[0, 0].isRook = true;
            TheGrid[0, 1].isKnight = true;
            TheGrid[0, 2].isBishop = true;
            TheGrid[0, 3].isQueen = true;
            TheGrid[0, 4].isKing = true;
            TheGrid[0, 5].isBishop = true;
            TheGrid[0, 6].isKnight = true;
            TheGrid[0, 7].isRook = true;

            for(int i =0; i<8; i++)
            {
                TheGrid[1, i].isPawn = true;
            }

            for(int i = 0; i<8; i++)
            {
                TheGrid[0, i].isBlack = true;
                TheGrid[1, i].isBlack = true;
                TheGrid[0, i].CurrentlyOccupied = true;
                TheGrid[1, i].CurrentlyOccupied = true;
            }

            //Begin White piece creation
            TheGrid[7, 0].isRook = true;
            TheGrid[7, 1].isKnight = true;
            TheGrid[7, 2].isBishop = true;
            TheGrid[7, 3].isQueen = true;
            TheGrid[7, 4].isKing = true;
            TheGrid[7, 5].isBishop = true;
            TheGrid[7, 6].isKnight = true;
            TheGrid[7, 7].isRook = true;

            for (int i = 0; i < 8; i++)
            {
                TheGrid[6, i].isPawn = true;
            }

            for(int i=0; i<8; i++)
            {
                TheGrid[6, i].isWhite = true;
                TheGrid[7, i].isWhite = true;
                TheGrid[6, i].CurrentlyOccupied = true;
                TheGrid[7, i].CurrentlyOccupied = true;
            }
        }

        //The GetType method checks the different booleans of the cell to find what piece it is and what color it is. These determine a type number
        //that is used to properly display the board visually
        public int GetType(int x, int y)
        {
            int type = 0;
            if (TheGrid[x, y].isPawn) { type = 1; }
            if (TheGrid[x, y].isKnight) { type = 3; }
            if (TheGrid[x, y].isBishop) { type = 5; }
            if (TheGrid[x, y].isRook) { type = 7; }
            if (TheGrid[x, y].isQueen) { type = 9; }
            if (TheGrid[x, y].isKing) { type = 11; }

            if (TheGrid[x, y].isWhite) { type += 1; }

            return type;
        }

        //The QueueMoves method will mark the potential moves that can be made after clicking a certain piece
        public List<int[]> QueueMoves(int x, int y)
        {
            List<int[]> legalMoves = new List<int[]>();
            bool[,] currentBoard = new bool[8, 8];
            for (int i=0; i<8; i++)
            {
                for (int j=0; j<8; j++)
                {
                    currentBoard[i, j] = TheGrid[i, j].CurrentlyOccupied;
                }
            }

            if (TheGrid[x, y].isPawn)
            {
                return pieceManager.PawnMoves(currentBoard, x, y, TheGrid[x, y].isWhite);
            }
            else if (TheGrid[x, y].isKnight)
            {
                return pieceManager.KnightMoves(currentBoard, x, y);
            }

            return legalMoves;
        }

        public bool[,] TestBoard()
        {
            bool[,] currentBoard = new bool[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    currentBoard[i, j] = TheGrid[i, j].CurrentlyOccupied;
                }
            }

            return currentBoard;
        }

        public void MarkNextLegalMoves(Cell currentCell, string chessPiece)
        {
            // clear previous moves
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    TheGrid[i, j].LegalNextMove = false;
                    TheGrid[i, j].CurrentlyOccupied = false;

                }
            }
            // find legal moves
            switch (chessPiece)
            {
                case "Knight":
                    TheGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    TheGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    TheGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    TheGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    break;
                case "King":
                    break;
                case "Rook":
                    break;
                case "Bishop":
                    break;
                case "Queen":
                    break;
                default:
                    break;
            }
            TheGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;
        }

    }
}
