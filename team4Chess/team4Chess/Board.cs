using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoardModel2
{
    public class Board
    {
        int Size { get; set; }
        bool passantPresent = false;
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
            TheGrid[0, 0].castleAble = true;
            TheGrid[1, 0].isKnight = true;
            TheGrid[2, 0].isBishop = true;
            TheGrid[3, 0].isQueen = true;
            TheGrid[4, 0].isKing = true;
            TheGrid[4, 0].castleAble = true;
            TheGrid[5, 0].isBishop = true;
            TheGrid[6, 0].isKnight = true;
            TheGrid[7, 0].isRook = true;
            TheGrid[7, 0].castleAble = true;

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
            TheGrid[0, 7].castleAble = true;
            TheGrid[1, 7].isKnight = true;
            TheGrid[2, 7].isBishop = true;
            TheGrid[3, 7].isQueen = true;
            TheGrid[4, 7].isKing = true;
            TheGrid[4, 7].castleAble = true;
            TheGrid[5, 7].isBishop = true;
            TheGrid[6, 7].isKnight = true;
            TheGrid[7, 7].isRook = true;
            TheGrid[7, 7].castleAble = true;

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
            bool[,] colorBoard = new bool[8, 8];

            if (TheGrid[x, y].isWhite)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        currentBoard[i, j] = TheGrid[i, j].CurrentlyOccupied;
                        colorBoard[i, j] = TheGrid[i, j].isBlack;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        currentBoard[i, j] = TheGrid[i, j].CurrentlyOccupied;
                        colorBoard[i, j] = TheGrid[i, j].isWhite;
                    }
                }
            }

            currentBoard[x, y] = false;

            if (TheGrid[x, y].isPawn)
            {
                return pieceManager.PawnMoves(currentBoard, colorBoard, x, y, TheGrid[x, y].isWhite);
            }
            else if (TheGrid[x, y].isKnight)
            {
                return pieceManager.KnightMoves(currentBoard, colorBoard, x, y);
            }
            else if (TheGrid[x, y].isBishop)
            {
                return pieceManager.BishopMoves(currentBoard, colorBoard, x, y);
            }
            else if (TheGrid[x, y].isRook)
            {
                return pieceManager.RookMoves(currentBoard, colorBoard, x, y);
            }
            else if (TheGrid[x, y].isQueen)
            {
                return pieceManager.QueenMoves(currentBoard, colorBoard, x, y);
            }
            else if (TheGrid[x,y].isKing)
            {
                //The king has to make sure it cannot move into check and as such all the pieces must be know and there specific type to check
                //whether a specific square is in check;
                bool[,] pawnBoard =  new bool[8,8];
                bool[,] knightBoard = new bool[8,8];
                bool[,] bishopBoard = new bool[8,8];
                bool[,] rookBoard = new bool[8,8];
                bool[,] queenBoard = new bool[8,8];
                bool[,] kingBoard = new bool [8,8];
                
                for(int i=0; i<8; i++)
                {
                    for(int j =0; j<8; j++)
                    {
                        pawnBoard[i, j] = TheGrid[i, j].isPawn;
                        knightBoard[i, j] = TheGrid[i, j].isKnight;
                        bishopBoard[i, j] = TheGrid[i, j].isBishop;
                        rookBoard[i, j] = TheGrid[i, j].isRook;
                        queenBoard[i, j] = TheGrid[i, j].isQueen;
                        kingBoard[i, j] = TheGrid[i, j].isKing;
                    }
                }
                bool[] castleStates = new bool[3];
                if (TheGrid[x, y].isWhite)
                {
                    castleStates = new bool[3] { TheGrid[0, 7].castleAble, TheGrid[4, 7].castleAble, TheGrid[7, 7].castleAble };
                }
                else
                {
                    castleStates = new bool[3] { TheGrid[0, 0].castleAble, TheGrid[4, 0].castleAble, TheGrid[7, 0].castleAble };
                }

                return pieceManager.KingMoves(currentBoard, colorBoard, pawnBoard, knightBoard, bishopBoard, rookBoard, queenBoard, kingBoard, castleStates, x, y);
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
            //Check for a castle
            if(TheGrid[movingX,movingY].isKing && TheGrid[movingX, movingY].castleAble)
            {
                if(destinationX == movingX + 2)
                {
                    if (TheGrid[7, 0].castleAble && TheGrid[movingX,movingY].isBlack)
                    {
                        TheGrid[destinationX-1, destinationY].isPawn = TheGrid[7, 0].isPawn;
                        TheGrid[destinationX-1, destinationY].isKnight = TheGrid[7, 0].isKnight;
                        TheGrid[destinationX-1, destinationY].isBishop = TheGrid[7, 0].isBishop;
                        TheGrid[destinationX-1, destinationY].isRook = TheGrid[7, 0].isRook;
                        TheGrid[destinationX-1, destinationY].isQueen = TheGrid[7, 0].isQueen;
                        TheGrid[destinationX-1, destinationY].isKing = TheGrid[7, 0].isKing;
                        TheGrid[destinationX-1, destinationY].isWhite = TheGrid[7, 0].isWhite;
                        TheGrid[destinationX-1, destinationY].isBlack = TheGrid[7, 0].isBlack;
                        TheGrid[destinationX-1, destinationY].CurrentlyOccupied = true;
                        TheGrid[7, 0].isPawn = false;
                        TheGrid[7, 0].isKnight = false;
                        TheGrid[7, 0].isBishop = false;
                        TheGrid[7, 0].isRook = false;
                        TheGrid[7, 0].isQueen = false;
                        TheGrid[7, 0].isKing = false;
                        TheGrid[7, 0].isBlack = false;
                        TheGrid[7, 0].CurrentlyOccupied = false;
                    }
                    if(TheGrid[7,7].castleAble && TheGrid[movingX, movingY].isWhite)
                    {
                        TheGrid[destinationX - 1, destinationY].isPawn = TheGrid[7, 7].isPawn;
                        TheGrid[destinationX - 1, destinationY].isKnight = TheGrid[7, 7].isKnight;
                        TheGrid[destinationX - 1, destinationY].isBishop = TheGrid[7, 7].isBishop;
                        TheGrid[destinationX - 1, destinationY].isRook = TheGrid[7, 7].isRook;
                        TheGrid[destinationX - 1, destinationY].isQueen = TheGrid[7, 7].isQueen;
                        TheGrid[destinationX - 1, destinationY].isKing = TheGrid[7, 7].isKing;
                        TheGrid[destinationX - 1, destinationY].isWhite = TheGrid[7, 7].isWhite;
                        TheGrid[destinationX - 1, destinationY].isBlack = TheGrid[7, 7].isBlack;
                        TheGrid[destinationX - 1, destinationY].CurrentlyOccupied = true;
                        TheGrid[7, 7].isPawn = false;
                        TheGrid[7, 7].isKnight = false;
                        TheGrid[7, 7].isBishop = false;
                        TheGrid[7, 7].isRook = false;
                        TheGrid[7, 7].isQueen = false;
                        TheGrid[7, 7].isKing = false;
                        TheGrid[7, 7].isWhite = false;
                        TheGrid[7, 7].CurrentlyOccupied = false;
                    }
                }
                if(destinationX == movingX-2)
                {
                    if(TheGrid[0,0].castleAble && TheGrid[movingX, movingY].isBlack)
                    {
                        TheGrid[destinationX + 1, destinationY].isPawn = TheGrid[0, 0].isPawn;
                        TheGrid[destinationX + 1, destinationY].isKnight = TheGrid[0, 0].isKnight;
                        TheGrid[destinationX + 1, destinationY].isBishop = TheGrid[0, 0].isBishop;
                        TheGrid[destinationX + 1, destinationY].isRook = TheGrid[0, 0].isRook;
                        TheGrid[destinationX + 1, destinationY].isQueen = TheGrid[0, 0].isQueen;
                        TheGrid[destinationX + 1, destinationY].isKing = TheGrid[0, 0].isKing;
                        TheGrid[destinationX + 1, destinationY].isWhite = TheGrid[0, 0].isWhite;
                        TheGrid[destinationX + 1, destinationY].isBlack = TheGrid[0, 0].isBlack;
                        TheGrid[destinationX + 1, destinationY].CurrentlyOccupied = true;
                        TheGrid[0, 0].isPawn = false;
                        TheGrid[0, 0].isKnight = false;
                        TheGrid[0, 0].isBishop = false;
                        TheGrid[0, 0].isRook = false;
                        TheGrid[0, 0].isQueen = false;
                        TheGrid[0, 0].isKing = false;
                        TheGrid[0, 0].isBlack = false;
                        TheGrid[0, 0].CurrentlyOccupied = false;
                    }
                    if (TheGrid[0, 7].castleAble && TheGrid[movingX, movingY].isWhite)
                    {
                        TheGrid[destinationX + 1, destinationY].isPawn = TheGrid[0, 7].isPawn;
                        TheGrid[destinationX + 1, destinationY].isKnight = TheGrid[0, 7].isKnight;
                        TheGrid[destinationX + 1, destinationY].isBishop = TheGrid[0, 7].isBishop;
                        TheGrid[destinationX + 1, destinationY].isRook = TheGrid[0, 7].isRook;
                        TheGrid[destinationX + 1, destinationY].isQueen = TheGrid[0, 7].isQueen;
                        TheGrid[destinationX + 1, destinationY].isKing = TheGrid[0, 7].isKing;
                        TheGrid[destinationX + 1, destinationY].isWhite = TheGrid[0, 7].isWhite;
                        TheGrid[destinationX + 1, destinationY].isBlack = TheGrid[0, 7].isBlack;
                        TheGrid[destinationX + 1, destinationY].CurrentlyOccupied = true;
                        TheGrid[0, 7].isPawn = false;
                        TheGrid[0, 7].isKnight = false;
                        TheGrid[0, 7].isBishop = false;
                        TheGrid[0, 7].isRook = false;
                        TheGrid[0, 7].isQueen = false;
                        TheGrid[0, 7].isKing = false;
                        TheGrid[0, 7].isWhite = false;
                        TheGrid[0, 7].CurrentlyOccupied = false;
                    }
                }
                //Once the king moves it can no longer castle.
                TheGrid[movingX, movingY].castleAble = false;
            }

            //If a rook moves it can no longer be castled
            if(TheGrid[movingX,movingY].isRook && TheGrid[movingX, movingY].castleAble)
            {
                TheGrid[movingX, movingY].castleAble = false;
            }

            //Check if the move commits en passant
            if (passantPresent)
            {
                if (TheGrid[destinationX, destinationY].passantAble && TheGrid[movingX, movingY].isWhite && TheGrid[movingX,movingY].isPawn)
                {
                    TheGrid[destinationX, destinationY + 1].isPawn = false;
                    TheGrid[destinationX, destinationY + 1].isKnight = false;
                    TheGrid[destinationX, destinationY + 1].isBishop = false;
                    TheGrid[destinationX, destinationY + 1].isRook = false;
                    TheGrid[destinationX, destinationY + 1].isQueen = false;
                    TheGrid[destinationX, destinationY + 1].isKing = false;
                    TheGrid[destinationX, destinationY + 1].isWhite = false;
                    TheGrid[destinationX, destinationY + 1].isBlack = false;
                    TheGrid[destinationX, destinationY + 1].CurrentlyOccupied = false;
                }
                if (TheGrid[destinationX, destinationY].passantAble && TheGrid[movingX, movingY].isBlack && TheGrid[movingX,movingY].isPawn)
                {
                    TheGrid[destinationX, destinationY - 1].isPawn = false;
                    TheGrid[destinationX, destinationY - 1].isKnight = false;
                    TheGrid[destinationX, destinationY - 1].isBishop = false;
                    TheGrid[destinationX, destinationY - 1].isRook = false;
                    TheGrid[destinationX, destinationY - 1].isQueen = false;
                    TheGrid[destinationX, destinationY - 1].isKing = false;
                    TheGrid[destinationX, destinationY - 1].isWhite = false;
                    TheGrid[destinationX, destinationY - 1].isBlack = false;
                    TheGrid[destinationX, destinationY - 1].CurrentlyOccupied = false;
                }

                for(int i = 0; i<8; i++)
                {
                    TheGrid[i, 2].passantAble = false;
                    TheGrid[i, 5].passantAble = false;
                }
                passantPresent = false;
            }

            //If a pawn moved into an en passant position set the flag
            if (TheGrid[movingX, movingY].isPawn && destinationY == movingY + 2)
            {
                TheGrid[movingX, movingY + 1].passantAble = true;
                passantPresent = true;
            }
            if (TheGrid[movingX, movingY].isPawn && destinationY == movingY - 2)
            {
                TheGrid[movingX, movingY - 1].passantAble = true;
                passantPresent = true;
            }

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
