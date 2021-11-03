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

        public List<int[]> PawnMoves(bool[,] currentBoard, int y, int x, bool whitePiece)
        {
            List < int[] > possibleMoves = new List<int[]>();
            //int[] tempRay;
            if (whitePiece)
            {
                if (y > 0)
                {
                    if (currentBoard[x, y-1]==false)
                    {
                        int[] tempRay = new int[2] { x, y-1 };
                        possibleMoves.Add(tempRay);
                    }
                    if (y == 6)
                    {
                        if (!currentBoard[x, y-2]) 
                        {
                            int[] tempRay = new int[2] { x, y-2 };
                            possibleMoves.Add(tempRay); 
                        }
                    }
                    if (x<7)
                    {
                        if (currentBoard[x + 1, y - 1])
                        {
                            int[] tempRay = new int[2] { x + 1, y - 1 };
                            possibleMoves.Add(tempRay);
                        }
                    }
                    if (x > 0)
                    {
                        if (currentBoard[x - 1, y - 1])
                        {
                            int[] tempRay = new int[2] { x - 1, y - 1 };
                            possibleMoves.Add(tempRay);
                        }
                    }
                }
            }
            /*else
            {
                if (y < 7)
                {
                    if (!currentBoard[x, y + 1])
                    {
                        int[] tempRay = new int[2] { x, y + 1 };
                        possibleMoves.Add(tempRay);
                    }
                    if (y == 1)
                    {
                        if (!currentBoard[x, y + 2])
                        {
                            int[] tempRay = new int[2] { x, y + 2 };
                            possibleMoves.Add(tempRay);
                        }
                    }
                    if (x < 7)
                    {
                        if (currentBoard[x + 1, y + 1])
                        {
                            int[] tempRay = new int[2] { x + 1, y + 1 };
                            possibleMoves.Add(tempRay);
                        }
                    }
                    if (x > 0)
                    {
                        if (currentBoard[x - 1, y + 1])
                        {
                            int[] tempRay = new int[2] { x - 1, y + 1 };
                            possibleMoves.Add(tempRay);
                        }
                    }
                }
            }*/

            return possibleMoves;
        }

        // Recalculates the possible moves and updates potential hits
        /*public abstract void Recalculate();

        public abstract bool IsBlockedIfMove(Board.Cell from, Board.Cell to, Board.Cell blocked);

        public abstract char Char { get; }

        protected virtual bool canHit(Board.Cell cell)
        {
            return cell != null && cell.Piece != null && cell.Piece.Color != Color;
        }*/
    }
}

