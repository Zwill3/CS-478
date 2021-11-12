using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoardModel2
{
   public class Piece
    {
        public bool Moved
        {
            protected set;
            get;
        }

        public Piece()
        {
            Moved = false;
        }

        //Highlight all possible pawn moves
        public List<int[]> PawnMoves(bool[,] currentBoard, int x, int y, bool whitePiece)
        {
            List < int[] > possibleMoves = new List<int[]>();
            int[] tempRay;
            tempRay = new int[2] { x, y };
            possibleMoves.Add(tempRay);
            if (whitePiece)
            {
                if (y > 0)
                {
                    if (currentBoard[x,y-1]==false)
                    {
                        tempRay = new int[2] { x, y-1 };
                        possibleMoves.Add(tempRay);
                    }
                    if (y == 6)
                    {
                        if (!currentBoard[x,y-2]) 
                        {
                            tempRay = new int[2] { x, y-2 };
                            possibleMoves.Add(tempRay); 
                        }
                    }
                    if (x<7)
                    {
                        if (currentBoard[x+1,y-1])
                        {
                            tempRay = new int[2] { x + 1, y - 1 };
                            possibleMoves.Add(tempRay);
                        }
                    }
                    if (x > 0)
                    {
                        if (currentBoard[x - 1, y - 1])
                        {
                            tempRay = new int[2] { x - 1, y - 1 };
                            possibleMoves.Add(tempRay);
                        }
                    }
                }
            }
            else
            {
                if (y < 7)
                {
                    if (!currentBoard[x, y+1])
                    {
                        tempRay = new int[2] { x, y + 1 };
                        possibleMoves.Add(tempRay);
                    }
                    if (y == 1)
                    {
                        if (!currentBoard[x,y+2])
                        {
                            tempRay = new int[2] { x, y + 2 };
                            possibleMoves.Add(tempRay);
                        }
                    }
                    if (x < 7)
                    {
                        if (currentBoard[x + 1, y + 1])
                        {
                            tempRay = new int[2] { x + 1, y + 1 };
                            possibleMoves.Add(tempRay);
                        }
                    }
                    if (x > 0)
                    {
                        if (currentBoard[x + 1, y-1])
                        {
                            tempRay = new int[2] { x - 1, y + 1 };
                            possibleMoves.Add(tempRay);
                        }
                    }
                }
            }

            return possibleMoves;
        }

        //Highlight all possible knight moves.
        public List<int[]> KnightMoves(bool[,] currentBoard, int x, int y)
        {
            List<int[]> possibleMoves = new List<int[]>();
            int[] tempRay;
            if (x > 1)
            {
                if (y > 1)
                {
                    if(!currentBoard[x-1, y-2])
                    {
                        tempRay = new int[2] { x - 1, y - 2 };
                        possibleMoves.Add(tempRay);
                    }
                    if (!currentBoard[x - 2, y - 1])
                    {
                        tempRay = new int[2] { x - 2, y - 1 };
                        possibleMoves.Add(tempRay);
                    }
                }
                if (y == 1)
                {
                    if (!currentBoard[x-2, y-1])
                    {
                        tempRay = new int[2] { x - 2, y - 1 };
                        possibleMoves.Add(tempRay);
                    }
                }

                if (y < 6)
                {
                    if(!currentBoard[x-1, y+2])
                    {
                        tempRay = new int[2] { x - 1, y + 2 };
                        possibleMoves.Add(tempRay);
                    }
                    if (!currentBoard[x-2, y+1])
                    {
                        tempRay = new int[2] { x - 2, y + 1 };
                        possibleMoves.Add(tempRay);
                    }
                }
                if (y == 6)
                {
                    if (!currentBoard[x-2, y+1])
                    {
                        tempRay = new int[2] { x - 2, y + 1 };
                        possibleMoves.Add(tempRay);
                    }
                }
            }

            if (x == 1)
            {
                if (y > 1)
                {
                    if (!currentBoard[x-1, y-2])
                    {
                        tempRay = new int[2] { x - 1, y - 2 };
                        possibleMoves.Add(tempRay);
                    }
                }
                if (y < 6)
                {
                    if (!currentBoard[x-1, y+2])
                    {
                        tempRay = new int[2] { x - 1, y + 2 };
                        possibleMoves.Add(tempRay);
                    }

                }
            }

            if (x < 6)
            {
                if (y > 1)
                {
                    if (!currentBoard[x+1, y-2])
                    {
                        tempRay = new int[2] { x + 1, y - 2 };
                        possibleMoves.Add(tempRay);
                    }
                    if (!currentBoard[x+2, y-1])
                    {
                        tempRay = new int[2] { x + 2, y - 1 };
                        possibleMoves.Add(tempRay);
                    }
                }
                if (y == 1)
                {
                    if (!currentBoard[x+2, y-1])
                    {
                        tempRay = new int[2] { x + 2, y - 1 };
                        possibleMoves.Add(tempRay);
                    }
                }

                if (y < 6)
                {
                    if (!currentBoard[x+1, y+2])
                    {
                        tempRay = new int[2] { x + 1, y + 2 };
                        possibleMoves.Add(tempRay);
                    }
                    if (!currentBoard[x+2, y+1])
                    {
                        tempRay = new int[2] { x + 2, y + 1 };
                        possibleMoves.Add(tempRay);
                    }
                }
                if (y == 6)
                {
                    if (!currentBoard[x+2, y+1])
                    {
                        tempRay = new int[2] { x + 2, y + 1 };
                        possibleMoves.Add(tempRay);
                    }
                }
            }

            if (x == 6)
            {
                if (y > 1)
                {
                    if (!currentBoard[x+1, y-2])
                    {
                        tempRay = new int[2] { x + 1, y - 2 };
                        possibleMoves.Add(tempRay);
                    }
                }
                if (y < 6)
                {
                    if (!currentBoard[x+1, y+2])
                    {
                        tempRay = new int[2] { x + 1, y + 2 };
                        possibleMoves.Add(tempRay);
                    }

                }
            }

            return possibleMoves;
        }

        //Highlight all possible Bishop moves
        public List<int[]> BishopMoves(bool[,] currentBoard, int x, int y)
        {
            List<int[]> possibleMoves = new List<int[]>();
            int[] tempRay;
            int tempX = x;
            int tempY = y;
            while(tempX>0 && tempY > 0)
            {
                tempX--;
                tempY--;
                tempRay = new int[2] { tempX, tempY };
                possibleMoves.Add(tempRay);
            }

            tempX = x;
            tempY = y;
            while (tempX < 7 && tempY > 0)
            {
                tempX++;
                tempY--;
                tempRay = new int[2] { tempX, tempY };
                possibleMoves.Add(tempRay);
            }

            tempX = x;
            tempY = y;
            while (tempX < 7 && tempY < 7)
            {
                tempX++;
                tempY++;
                tempRay = new int[2] { tempX, tempY };
                possibleMoves.Add(tempRay);
            }

            tempX = x;
            tempY = y;
            while (tempX > 0 && tempY < 7)
            {
                tempX--;
                tempY++;
                tempRay = new int[2] { tempX, tempY };
                possibleMoves.Add(tempRay);
            }

            return possibleMoves;
        }

        //Highlight all possible Rook moves
        public List<int[]> RookMoves(bool[,] currentBoard, int x, int y)
        {
            List<int[]> possibleMoves = new List<int[]>();
            int[] tempRay;
            int tempX = x;
            int tempY = y;

            while (tempX > 0)
            {
                tempX--;
                tempRay = new int[2] { tempX, tempY };
                possibleMoves.Add(tempRay);
            }

            tempX = x;
            while (tempX < 7)
            {
                tempX++;
                tempRay = new int[2] { tempX, tempY };
                possibleMoves.Add(tempRay);
            }

            tempX = x;
            while (tempY > 0)
            {
                tempY--;
                tempRay = new int[2] { tempX, tempY };
                possibleMoves.Add(tempRay);
            }

            tempY = y;
            while (tempY < 7)
            {
                tempY++;
                tempRay = new int[2] { tempX, tempY };
                possibleMoves.Add(tempRay);
            }

            return possibleMoves;
        }

        //Highlight all possible Queen moves
        public List<int[]> QueenMoves(bool[,] currentBoard, int x, int y)
        {
            List<int[]> possibleMoves = new List<int[]>();
            int[] tempRay;
            int tempX = x;
            int tempY = y;
            while (tempX > 0 && tempY > 0)
            {
                tempX--;
                tempY--;
                tempRay = new int[2] { tempX, tempY };
                possibleMoves.Add(tempRay);
            }

            tempX = x;
            tempY = y;
            while (tempX < 7 && tempY > 0)
            {
                tempX++;
                tempY--;
                tempRay = new int[2] { tempX, tempY };
                possibleMoves.Add(tempRay);
            }

            tempX = x;
            tempY = y;
            while (tempX < 7 && tempY < 7)
            {
                tempX++;
                tempY++;
                tempRay = new int[2] { tempX, tempY };
                possibleMoves.Add(tempRay);
            }

            tempX = x;
            tempY = y;
            while (tempX > 0 && tempY < 7)
            {
                tempX--;
                tempY++;
                tempRay = new int[2] { tempX, tempY };
                possibleMoves.Add(tempRay);
            }

            tempY = y;
            while (tempX > 0)
            {
                tempX--;
                tempRay = new int[2] { tempX, tempY };
                possibleMoves.Add(tempRay);
            }

            tempX = x;
            while (tempX < 7)
            {
                tempX++;
                tempRay = new int[2] { tempX, tempY };
                possibleMoves.Add(tempRay);
            }

            tempX = x;
            while (tempY > 0)
            {
                tempY--;
                tempRay = new int[2] { tempX, tempY };
                possibleMoves.Add(tempRay);
            }

            tempY = y;
            while (tempY < 7)
            {
                tempY++;
                tempRay = new int[2] { tempX, tempY };
                possibleMoves.Add(tempRay);
            }

            return possibleMoves;
        }

        //Returns all possible King Moves
    }
}

