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
        public List<int[]> PawnMoves(bool[,] currentBoard, int y, int x, bool whitePiece)
        {
            List < int[] > possibleMoves = new List<int[]>();
            int[] tempRay;
            if (whitePiece)
            {
                if (y > 0)
                {
                    if (currentBoard[y-1, x]==false)
                    {
                        tempRay = new int[2] { x, y-1 };
                        possibleMoves.Add(tempRay);
                    }
                    if (y == 6)
                    {
                        if (!currentBoard[y-2, x]) 
                        {
                            tempRay = new int[2] { x, y-2 };
                            possibleMoves.Add(tempRay); 
                        }
                    }
                    if (x<7)
                    {
                        if (currentBoard[y-1, x+1])
                        {
                            tempRay = new int[2] { x + 1, y - 1 };
                            possibleMoves.Add(tempRay);
                        }
                    }
                    if (x > 0)
                    {
                        if (currentBoard[y - 1, x - 1])
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
                    if (!currentBoard[y+1, x])
                    {
                        tempRay = new int[2] { x, y + 1 };
                        possibleMoves.Add(tempRay);
                    }
                    if (y == 1)
                    {
                        if (!currentBoard[y+2, x])
                        {
                            tempRay = new int[2] { x, y + 2 };
                            possibleMoves.Add(tempRay);
                        }
                    }
                    if (x < 7)
                    {
                        if (currentBoard[y + 1, x + 1])
                        {
                            tempRay = new int[2] { x + 1, y + 1 };
                            possibleMoves.Add(tempRay);
                        }
                    }
                    if (x > 0)
                    {
                        if (currentBoard[y + 1, x-1])
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
        public List<int[]> KnightMoves(bool[,] currentBoard, int y, int x)
        {
            List<int[]> possibleMoves = new List<int[]>();
            int[] tempRay;
            if (x > 1)
            {
                if (y > 1)
                {
                    if(!currentBoard[y-2, x - 1])
                    {
                        tempRay = new int[2] { x - 1, y - 2 };
                        possibleMoves.Add(tempRay);
                    }
                    if (!currentBoard[y - 1, x - 2])
                    {
                        tempRay = new int[2] { x - 2, y - 1 };
                        possibleMoves.Add(tempRay);
                    }
                }
                if (y == 1)
                {
                    if (!currentBoard[y - 1, x - 2])
                    {
                        tempRay = new int[2] { x - 2, y - 1 };
                        possibleMoves.Add(tempRay);
                    }
                }

                if (y < 6)
                {
                    if(!currentBoard[y+2, x - 1])
                    {
                        tempRay = new int[2] { x - 1, y + 2 };
                        possibleMoves.Add(tempRay);
                    }
                    if (!currentBoard[y + 1, x - 2])
                    {
                        tempRay = new int[2] { x - 2, y + 1 };
                        possibleMoves.Add(tempRay);
                    }
                }
                if (y == 6)
                {
                    if (!currentBoard[y + 1, x - 2])
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
                    if (!currentBoard[y - 2, x - 1])
                    {
                        tempRay = new int[2] { x - 1, y - 2 };
                        possibleMoves.Add(tempRay);
                    }
                }
                if (y < 6)
                {
                    if (!currentBoard[y + 2, x - 1])
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
                    if (!currentBoard[y - 2, x + 1])
                    {
                        tempRay = new int[2] { x + 1, y - 2 };
                        possibleMoves.Add(tempRay);
                    }
                    if (!currentBoard[y - 1, x + 2])
                    {
                        tempRay = new int[2] { x + 2, y - 1 };
                        possibleMoves.Add(tempRay);
                    }
                }
                if (y == 1)
                {
                    if (!currentBoard[y - 1, x + 2])
                    {
                        tempRay = new int[2] { x + 2, y - 1 };
                        possibleMoves.Add(tempRay);
                    }
                }

                if (y < 6)
                {
                    if (!currentBoard[y + 2, x + 1])
                    {
                        tempRay = new int[2] { x + 1, y + 2 };
                        possibleMoves.Add(tempRay);
                    }
                    if (!currentBoard[y + 1, x + 2])
                    {
                        tempRay = new int[2] { x + 2, y + 1 };
                        possibleMoves.Add(tempRay);
                    }
                }
                if (y == 6)
                {
                    if (!currentBoard[y + 1, x + 2])
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
                    if (!currentBoard[y - 2, x + 1])
                    {
                        tempRay = new int[2] { x + 1, y - 2 };
                        possibleMoves.Add(tempRay);
                    }
                }
                if (y < 6)
                {
                    if (!currentBoard[y + 2, x + 1])
                    {
                        tempRay = new int[2] { x + 1, y + 2 };
                        possibleMoves.Add(tempRay);
                    }

                }
            }

            return possibleMoves;
        }

        //Highlight all possible Bishop moves
    }
}

