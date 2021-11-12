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
            TheGrid[1, 0].isKnight = true;
            TheGrid[2, 0].isBishop = true;
            TheGrid[3, 0].isQueen = true;
            TheGrid[4, 0].isKing = true;
            TheGrid[5, 0].isBishop = true;
            TheGrid[6, 0].isKnight = true;
            TheGrid[7, 0].isRook = true;

            for(int i =0; i<8; i++)
            {
                TheGrid[i, 1].isPawn = true;
                TheGrid[i, 0].isBlack = true;
                TheGrid[i, 1].isBlack = true;
                TheGrid[i, 0].CurrentlyOccupied = true;
                TheGrid[i, 1].CurrentlyOccupied = true;
            }

            //Begin White piece creation
            TheGrid[0, 7].isRook = true;
            TheGrid[1, 7].isKnight = true;
            TheGrid[2, 7].isBishop = true;
            TheGrid[3, 7].isQueen = true;
            TheGrid[4, 7].isKing = true;
            TheGrid[5, 7].isBishop = true;
            TheGrid[6, 7].isKnight = true;
            TheGrid[7, 7].isRook = true;

            for (int i = 0; i < 8; i++)
            {
                TheGrid[i, 6].isPawn = true;
                TheGrid[i, 6].isWhite = true;
                TheGrid[i, 7].isWhite = true;
                TheGrid[i, 6].CurrentlyOccupied = true;
                TheGrid[i, 7].CurrentlyOccupied = true;
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
            else if (TheGrid[x, y].isBishop)
            {
                return pieceManager.BishopMoves(currentBoard, x, y);
            }
            else if (TheGrid[x, y].isRook)
            {
                return pieceManager.RookMoves(currentBoard, x, y);
            }
            else if (TheGrid[x, y].isQueen)
            {
                return pieceManager.QueenMoves(currentBoard, x, y);
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

        //The CompleteMove method updates the board with a users move.
        public void CompleteMove (int movingX, int movingY, int destinationX, int destinationY)
        {
            //Set the destinations data equal to the data of the piece moving there
            TheGrid[destinationX, destinationY].isPawn = TheGrid[movingX, movingY].isPawn;
            TheGrid[destinationX, destinationY].isKnight = TheGrid[movingX, movingY].isKnight;
            TheGrid[destinationX, destinationY].isBishop = TheGrid[movingX, movingY].isBishop;
            TheGrid[destinationX, destinationY].isRook = TheGrid[movingX, movingY].isRook;
            TheGrid[destinationX, destinationY].isQueen = TheGrid[movingX, movingY].isQueen;
            TheGrid[destinationX, destinationY].isKing = TheGrid[movingX, movingY].isKing;
            TheGrid[destinationX, destinationY].isWhite = TheGrid[movingX, movingY].isWhite;
            TheGrid[destinationX, destinationY].isBlack = TheGrid[movingX, movingY].isBlack;
            TheGrid[destinationX, destinationY].CurrentlyOccupied = true;
            //Set the data from the location the piece moved from to false
            TheGrid[movingX, movingY].isPawn = false;
            TheGrid[movingX, movingY].isKnight = false;
            TheGrid[movingX, movingY].isBishop = false;
            TheGrid[movingX, movingY].isRook = false;
            TheGrid[movingX, movingY].isQueen = false;
            TheGrid[movingX, movingY].isKing = false;
            TheGrid[movingX, movingY].isWhite = false;
            TheGrid[movingX, movingY].isBlack = false;
            TheGrid[movingX, movingY].CurrentlyOccupied = false;
        }
    }
}
