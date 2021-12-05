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
        public List<int[]> PawnMoves(bool[,] currentBoard, bool[,] oppColors, bool[,] pawns, bool[,] knights, bool[,] bishops, bool[,] rooks, bool[,] queens, bool[,] kings, int x, int y, bool whitePiece)
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
                        if (oppColors[x+1,y-1])
                        {
                            tempRay = new int[2] { x + 1, y - 1 };
                            possibleMoves.Add(tempRay);
                        }
                    }
                    if (x > 0)
                    {
                        if (oppColors[x - 1, y - 1])
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
                        if (oppColors[x + 1, y + 1])
                        {
                            tempRay = new int[2] { x + 1, y + 1 };
                            possibleMoves.Add(tempRay);
                        }
                    }
                    if (x > 0)
                    {
                        if (oppColors[x + 1, y-1])
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
        public List<int[]> KnightMoves(bool[,] currentBoard, bool[,] oppColors, bool[,] pawns, bool[,] knights, bool[,] bishops, bool[,] rooks, bool[,] queens, bool[,] kings, int x, int y)
        {
            List<int[]> possibleMoves = new List<int[]>();
            int[] tempRay;
            tempRay = new int[2] { x, y };
            possibleMoves.Add(tempRay);
            if (x > 1)
            {
                if (y > 1)
                {
                    if(!currentBoard[x-1, y-2] || oppColors[x - 1, y - 2])
                    {
                        tempRay = new int[2] { x - 1, y - 2 };
                        possibleMoves.Add(tempRay);
                    }
                    if (!currentBoard[x - 2, y - 1] || oppColors[x-2,y-1])
                    {
                        tempRay = new int[2] { x - 2, y - 1 };
                        possibleMoves.Add(tempRay);
                    }
                }
                if (y == 1)
                {
                    if (!currentBoard[x-2, y-1] || oppColors[x - 2, y - 1])
                    {
                        tempRay = new int[2] { x - 2, y - 1 };
                        possibleMoves.Add(tempRay);
                    }
                }

                if (y < 6)
                {
                    if(!currentBoard[x-1, y+2] || oppColors[x - 1, y + 2])
                    {
                        tempRay = new int[2] { x - 1, y + 2 };
                        possibleMoves.Add(tempRay);
                    }
                    if (!currentBoard[x-2, y+1] || oppColors[x - 2, y + 1])
                    {
                        tempRay = new int[2] { x - 2, y + 1 };
                        possibleMoves.Add(tempRay);
                    }
                }
                if (y == 6)
                {
                    if (!currentBoard[x-2, y+1] || oppColors[x - 2, y + 1])
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
                    if (!currentBoard[x-1, y-2] || oppColors[x - 1, y - 2])
                    {
                        tempRay = new int[2] { x - 1, y - 2 };
                        possibleMoves.Add(tempRay);
                    }
                }
                if (y < 6)
                {
                    if (!currentBoard[x-1, y+2] || oppColors[x - 1, y + 2])
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
                    if (!currentBoard[x+1, y-2] || oppColors[x + 1, y - 2])
                    {
                        tempRay = new int[2] { x + 1, y - 2 };
                        possibleMoves.Add(tempRay);
                    }
                    if (!currentBoard[x+2, y-1] || oppColors[x + 2, y - 1])
                    {
                        tempRay = new int[2] { x + 2, y - 1 };
                        possibleMoves.Add(tempRay);
                    }
                }
                if (y == 1)
                {
                    if (!currentBoard[x+2, y-1] || oppColors[x + 2, y - 1])
                    {
                        tempRay = new int[2] { x + 2, y - 1 };
                        possibleMoves.Add(tempRay);
                    }
                }

                if (y < 6)
                {
                    if (!currentBoard[x+1, y+2] || oppColors[x + 1, y + 2])
                    {
                        tempRay = new int[2] { x + 1, y + 2 };
                        possibleMoves.Add(tempRay);
                    }
                    if (!currentBoard[x+2, y+1] || oppColors[x + 2, y + 1])
                    {
                        tempRay = new int[2] { x + 2, y + 1 };
                        possibleMoves.Add(tempRay);
                    }
                }
                if (y == 6)
                {
                    if (!currentBoard[x+2, y+1] || oppColors[x + 2, y + 1])
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
                    if (!currentBoard[x+1, y-2] || oppColors[x + 1, y - 2])
                    {
                        tempRay = new int[2] { x + 1, y - 2 };
                        possibleMoves.Add(tempRay);
                    }
                }
                if (y < 6)
                {
                    if (!currentBoard[x+1, y+2] || oppColors[x + 1, y + 2])
                    {
                        tempRay = new int[2] { x + 1, y + 2 };
                        possibleMoves.Add(tempRay);
                    }

                }
            }

            return possibleMoves;
        }

        //Highlight all possible Bishop moves
        public List<int[]> BishopMoves(bool[,] currentBoard, bool[,] oppColor, bool[,] pawns, bool[,] knights, bool[,] bishops, bool[,] rooks, bool[,] queens, bool[,] kings, int x, int y)
        {
            List<int[]> possibleMoves = new List<int[]>();
            int[] tempRay;
            tempRay = new int[2] { x, y };
            possibleMoves.Add(tempRay);
            int tempX = x;
            int tempY = y;
            if (!isPinnedTRBL(currentBoard, oppColor, bishops, queens, kings, x, y) && !isPinnedHorizontal(currentBoard, oppColor, rooks, queens, kings, x, y) && !isPinnedVertical(currentBoard, oppColor, rooks, queens, kings, x, y))
            {
                while (tempX > 0 && tempY > 0 && !currentBoard[tempX, tempY])
                {
                    tempRay = new int[2] { tempX, tempY };
                    possibleMoves.Add(tempRay);
                    tempX--;
                    tempY--;
                }
                if (oppColor[tempX, tempY] || !currentBoard[tempX, tempY])
                {
                    tempRay = new int[2] { tempX, tempY };
                    possibleMoves.Add(tempRay);
                }

                tempX = x;
                tempY = y;
                while (tempX < 7 && tempY < 7 && !currentBoard[tempX, tempY])
                {
                    tempRay = new int[2] { tempX, tempY };
                    possibleMoves.Add(tempRay);
                    tempX++;
                    tempY++;
                }
                if (oppColor[tempX, tempY] || !currentBoard[tempX, tempY])
                {
                    tempRay = new int[2] { tempX, tempY };
                    possibleMoves.Add(tempRay);
                }

                tempX = x;
                tempY = y;
            }

            if (!isPinnedTLBR(currentBoard, oppColor, bishops, queens, kings, x, y) && !isPinnedHorizontal(currentBoard, oppColor, rooks, queens, kings, x, y) && !isPinnedVertical(currentBoard, oppColor, rooks, queens, kings, x, y))
            {
                while (tempX < 7 && tempY > 0 && !currentBoard[tempX, tempY])
                {
                    tempRay = new int[2] { tempX, tempY };
                    possibleMoves.Add(tempRay);
                    tempX++;
                    tempY--;
                }
                if (oppColor[tempX, tempY] || !currentBoard[tempX, tempY])
                {
                    tempRay = new int[2] { tempX, tempY };
                    possibleMoves.Add(tempRay);
                }

                tempX = x;
                tempY = y;
                while (tempX > 0 && tempY < 7 && !currentBoard[tempX, tempY])
                {
                    tempRay = new int[2] { tempX, tempY };
                    possibleMoves.Add(tempRay);
                    tempX--;
                    tempY++;
                }
                if (oppColor[tempX, tempY] || !currentBoard[tempX, tempY])
                {
                    tempRay = new int[2] { tempX, tempY };
                    possibleMoves.Add(tempRay);
                }
            }

            return possibleMoves;
        }

        //Highlight all possible Rook moves
        public List<int[]> RookMoves(bool[,] currentBoard, bool[,] oppColor, bool[,] pawns, bool[,] knights, bool[,] bishops, bool[,] rooks, bool[,] queens, bool[,] kings, int x, int y)
        {
            List<int[]> possibleMoves = new List<int[]>();
            int[] tempRay;
            tempRay = new int[2] { x, y };
            possibleMoves.Add(tempRay);
            int tempX = x;
            int tempY = y;

            if (!isPinnedVertical(currentBoard,oppColor,rooks,queens,kings,x,y) && !isPinnedTLBR(currentBoard, oppColor, bishops, queens, kings, x, y) && !isPinnedTRBL(currentBoard, oppColor, bishops, queens, kings, x, y))
            {
                while (tempX > 0 && !currentBoard[tempX, tempY])
                {
                    tempRay = new int[2] { tempX, tempY };
                    possibleMoves.Add(tempRay);
                    tempX--;
                }
                if (oppColor[tempX, tempY] || !currentBoard[tempX, tempY])
                {
                    tempRay = new int[2] { tempX, tempY };
                    possibleMoves.Add(tempRay);
                }

                tempX = x;
                while (tempX < 7 && !currentBoard[tempX, tempY])
                {
                    tempRay = new int[2] { tempX, tempY };
                    possibleMoves.Add(tempRay);
                    tempX++;
                }
                if (oppColor[tempX, tempY] || !currentBoard[tempX, tempY])
                {
                    tempRay = new int[2] { tempX, tempY };
                    possibleMoves.Add(tempRay);
                }

                tempX = x;
            }

            if (!isPinnedHorizontal(currentBoard,oppColor,rooks,queens,kings,x,y) && !isPinnedTLBR(currentBoard,oppColor,bishops,queens,kings,x,y) && !isPinnedTRBL(currentBoard,oppColor,bishops,queens,kings,x,y))
            {
                while (tempY > 0 && !currentBoard[tempX, tempY])
                {
                    tempRay = new int[2] { tempX, tempY };
                    possibleMoves.Add(tempRay);
                    tempY--;
                }
                if (oppColor[tempX, tempY] || !currentBoard[tempX, tempY])
                {
                    tempRay = new int[2] { tempX, tempY };
                    possibleMoves.Add(tempRay);
                }

                tempY = y;
                while (tempY < 7 && !currentBoard[tempX, tempY])
                {
                    tempRay = new int[2] { tempX, tempY };
                    possibleMoves.Add(tempRay);
                    tempY++;
                }
                if (oppColor[tempX, tempY] || !currentBoard[tempX, tempY])
                {
                    tempRay = new int[2] { tempX, tempY };
                    possibleMoves.Add(tempRay);
                }
            }

            return possibleMoves;
        }

        //Highlight all possible Queen moves
        public List<int[]> QueenMoves(bool[,] currentBoard, bool[,] oppColor, bool[,] pawns, bool[,] knights, bool[,] bishops, bool[,] rooks, bool[,] queens, bool[,] kings, int x, int y)
        {
            List<int[]> possibleMoves = new List<int[]>();
            //Because the queen is just diagonal and straight lines which has already been covered in the bishop and rook methods,
            //combining the outputs of the two gives all the queen's moves.
            List<int[]> diagonalMoves = BishopMoves(currentBoard, oppColor, pawns, knights, bishops, rooks, queens, kings, x, y);
            List<int[]> straightMoves = RookMoves(currentBoard, oppColor, pawns, knights, bishops, rooks, queens, kings, x, y);
            foreach(int[] viableSpace in diagonalMoves)
            {
                possibleMoves.Add(viableSpace);
            }
            foreach (int[] viableSpace in straightMoves)
            {
                possibleMoves.Add(viableSpace);
            }

            return possibleMoves;
        }

        //Returns all possible King Moves
        public List<int[]> KingMoves(bool[,] currentBoard, bool[,] oppColor, bool[,] pawns, bool[,] knights, bool[,] bishops, bool[,] rooks, bool[,] queens, bool[,] kings, bool[] castleStatus, int x, int y)
        {
            List<int[]> possibleMoves = new List<int[]>();
            int[] tempray;
            tempray = new int[2] { x, y };
            possibleMoves.Add(tempray);
            //The king is the most intricate piece as it has a technique known as castling and it also can never move into the state known as check.
            //The solution to check is to have a method that tests whether a square is currently attacked
            //First is to check for castles
            if(castleStatus[0] && castleStatus[1])
            {
                if(!isAttacked(currentBoard, oppColor, pawns, knights, bishops, rooks, queens, kings, x - 1, y) && !isAttacked(currentBoard, oppColor, pawns, knights, bishops, rooks, queens, kings, x - 2, y) && !currentBoard[x-1,y] && !currentBoard[x - 2, y])
                {
                    tempray = new int[2] { x - 2, y };
                    possibleMoves.Add(tempray);
                }
            }
            if(castleStatus[1] && castleStatus[2])
            {
                if (!isAttacked(currentBoard, oppColor, pawns, knights, bishops, rooks, queens, kings, x + 1, y) && !isAttacked(currentBoard, oppColor, pawns, knights, bishops, rooks, queens, kings, x + 2, y) && !currentBoard[x + 1, y] && !currentBoard[x + 2, y])
                {
                    tempray = new int[2] { x + 2, y };
                    possibleMoves.Add(tempray);
                }
            }

            if (x > 0)
            {
                if (!isAttacked(currentBoard, oppColor, pawns, knights, bishops, rooks, queens, kings, x -1, y) && (!currentBoard[x-1,y] || oppColor[x-1,y]))
                {
                    tempray = new int[2] { x - 1, y };
                    possibleMoves.Add(tempray);
                }

                if (y < 7)
                {
                    if (!isAttacked(currentBoard, oppColor, pawns, knights, bishops, rooks, queens, kings, x-1, y+1) && (!currentBoard[x - 1, y + 1] || oppColor[x - 1, y + 1]))
                    {
                        tempray = new int[2] { x - 1, y + 1 };
                        possibleMoves.Add(tempray);
                    }
                }

                if (y > 0)
                {
                    if (!isAttacked(currentBoard, oppColor, pawns, knights, bishops, rooks, queens, kings, x-1, y-1) && (!currentBoard[x - 1, y - 1] || oppColor[x - 1, y - 1]))
                    {
                        tempray = new int[2] { x - 1, y - 1 };
                        possibleMoves.Add(tempray);
                    }
                }
            }

            if (y < 7)
            {
                if (!isAttacked(currentBoard, oppColor, pawns, knights, bishops, rooks, queens, kings, x, y+1) && (!currentBoard[x, y + 1] || oppColor[x, y + 1]))
                {
                    tempray = new int[2] { x, y + 1 };
                    possibleMoves.Add(tempray);
                }
            }

            if (y > 0)
            {
                if (!isAttacked(currentBoard, oppColor, pawns, knights, bishops, rooks, queens, kings, x, y-1) && (!currentBoard[x, y - 1] || oppColor[x, y - 1]))
                {
                    tempray = new int[2] { x, y - 1 };
                    possibleMoves.Add(tempray);
                }
            }

            if (x < 7)
            {
                if (!isAttacked(currentBoard, oppColor, pawns, knights,bishops,rooks,queens,kings, x + 1, y) && (!currentBoard[x + 1, y] || oppColor[x + 1, y]))
                {
                    tempray = new int[2] { x + 1, y};
                    possibleMoves.Add(tempray);
                }
                if (y < 7)
                {
                    if (!isAttacked(currentBoard, oppColor, pawns, knights, bishops, rooks, queens, kings, x+1, y+1) && (!currentBoard[x + 1, y + 1] || oppColor[x + 1, y + 1]))
                    {
                        tempray = new int[2] { x + 1, y + 1 };
                        possibleMoves.Add(tempray);
                    }
                }

                if (y > 0)
                {
                    if (!isAttacked(currentBoard, oppColor, pawns, knights, bishops, rooks, queens, kings, x+1, y-1) && (!currentBoard[x + 1, y - 1] || oppColor[x + 1, y - 1]))
                    {
                        tempray = new int[2] { x + 1, y - 1 };
                        possibleMoves.Add(tempray);
                    }
                }
            }

            return possibleMoves;
        }

        //The isAttacked method is a method that checks for whether a certain coordinate is being attacked by a piece of the opposite color.
        //This is accomplished by tracing the movements a piece could do to attack the coordinate and the check if there's the piece there.
        public bool isAttacked(bool[,] currentBoard, bool[,] oppColor, bool[,] pawns, bool[,] knights, bool[,] bishops, bool[,] rooks, bool[,] queens, bool[,] kings, int x, int y)
        {
            //Check Straights for rooks or queens
            int tempX = x;
            int tempY = y;
            while(tempX>0 && !currentBoard[tempX, tempY])
            {
                tempX--;
            }
            if((queens[tempX,tempY] || rooks[tempX,tempY]) && oppColor[tempX, tempY])
            {
                return true;
            }
            tempX = x;
            while(tempX<7 && !currentBoard[tempX, tempY])
            {
                tempX++;
            }
            if ((queens[tempX, tempY] || rooks[tempX, tempY]) && oppColor[tempX, tempY])
            {
                return true;
            }
            tempX = x;
            while(tempY>0 && !currentBoard[tempX, tempY])
            {
                tempY--;
            }
            if ((queens[tempX, tempY] || rooks[tempX, tempY]) && oppColor[tempX, tempY])
            {
                return true;
            }
            tempY = y;
            while (tempY < 7 && !currentBoard[tempX, tempY])
            {
                tempY++;
            }
            if ((queens[tempX, tempY] || rooks[tempX, tempY]) && oppColor[tempX, tempY])
            {
                return true;
            }

            //Check diagonals for bishops and queens
            tempY = y;
            while(tempX>0 && tempY>0 && !currentBoard[tempX, tempY])
            {
                tempX--;
                tempY--;
            }
            if((queens[tempX,tempY] || bishops[tempX,tempY]) && oppColor[tempX, tempY])
            {
                return true;
            }
            tempX = x;
            tempY = y;
            while(tempX>0 && tempY<7 && !currentBoard[tempX, tempY])
            {
                tempX--;
                tempY++;
            }
            if ((queens[tempX, tempY] || bishops[tempX, tempY]) && oppColor[tempX, tempY])
            {
                return true;
            }
            tempX = x;
            tempY = y;
            while(tempX<7 && tempY > 0 && !currentBoard[tempX,tempY])
            {
                tempX++;
                tempY--;
            }
            if ((queens[tempX, tempY] || bishops[tempX, tempY]) && oppColor[tempX, tempY])
            {
                return true;
            }
            tempX = x;
            tempY = y;
            while(tempX<7 && tempY<7 && !currentBoard[tempX, tempY])
            {
                tempX++;
                tempY++;
            }
            if ((queens[tempX, tempY] || bishops[tempX, tempY]) && oppColor[tempX, tempY])
            {
                return true;
            }

            //Check all Knight coordinates of attack
            if (x > 1)
            {
                if (y > 1)
                {
                    if (knights[x - 1, y - 2] && oppColor[x - 1, y - 2])
                    {
                        return true;
                    }
                    if (knights[x - 2, y - 1] && oppColor[x - 2, y - 1])
                    {
                        return true;
                    }
                }
                if (y == 1)
                {
                    if (knights[x - 2, y - 1] && oppColor[x - 2, y - 1])
                    {
                        return true;
                    }
                }

                if (y < 6)
                {
                    if (knights[x - 1, y + 2] && oppColor[x - 1, y + 2])
                    {
                        return true;
                    }
                    if (knights[x - 2, y + 1] && oppColor[x - 2, y + 1])
                    {
                        return true;
                    }
                }
                if (y == 6)
                {
                    if (knights[x - 2, y + 1] && oppColor[x - 2, y + 1])
                    {
                        return true;
                    }
                }
            }

            if (x == 1)
            {
                if (y > 1)
                {
                    if (knights[x - 1, y - 2] && oppColor[x - 1, y - 2])
                    {
                        return true;
                    }
                }
                if (y < 6)
                {
                    if (knights[x - 1, y + 2] && oppColor[x - 1, y + 2])
                    {
                        return true;
                    }

                }
            }

            if (x < 6)
            {
                if (y > 1)
                {
                    if (knights[x + 1, y - 2] && oppColor[x + 1, y - 2])
                    {
                        return true;
                    }
                    if (knights[x + 2, y - 1] && oppColor[x + 2, y - 1])
                    {
                        return true;
                    }
                }
                if (y == 1)
                {
                    if (knights[x + 2, y - 1] && oppColor[x + 2, y - 1])
                    {
                        return true;
                    }
                }

                if (y < 6)
                {
                    if (knights[x + 1, y + 2] && oppColor[x + 1, y + 2])
                    {
                        return true;
                    }
                    if (knights[x + 2, y + 1] && oppColor[x + 2, y + 1])
                    {
                        return true;
                    }
                }
                if (y == 6)
                {
                    if (knights[x + 2, y + 1] && oppColor[x + 2, y + 1])
                    {
                        return true;
                    }
                }
            }

            if (x == 6)
            {
                if (y > 1)
                {
                    if (knights[x + 1, y - 2] && oppColor[x + 1, y - 2])
                    {
                        return true;
                    }
                }
                if (y < 6)
                {
                    if (knights[x + 1, y + 2] || oppColor[x + 1, y + 2])
                    {
                        return true;
                    }

                }
            }

            //check adjacencies for pawns and king
            if (x > 0)
            {
                if(kings[x-1,y] && oppColor[x - 1, y])
                {
                    return true;
                }
                if (y > 0)
                {
                    if((kings[x-1,y-1] || pawns[x-1,y-1]) && oppColor[x - 1, y - 1])
                    {
                        return true;
                    }
                }
                if (y < 7)
                {
                    if((kings[x-1,y+1] || pawns[x-1,y+1]) && oppColor[x - 1, y + 1])
                    {
                        return true;
                    }
                }
            }
            if (y > 0)
            {
                if (kings[x, y - 1] && oppColor[x, y - 1])
                {
                    return true;
                }
            }
            if (y < 7)
            {
                if (kings[x, y + 1] && oppColor[x, y + 1])
                {
                    return true;
                }
            }
            if (x < 7)
            {
                if (kings[x + 1, y] && oppColor[x + 1, y])
                {
                    return true;
                }
                if (y > 0)
                {
                    if ((kings[x + 1, y - 1] || pawns[x+1,y-1]) && oppColor[x + 1, y - 1])
                    {
                        return true;
                    }
                }
                if (y < 7)
                {
                    if ((kings[x + 1, y + 1] || pawns[x+1,y+1]) && oppColor[x + 1, y + 1])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        //The isPinned set of methods is used to make sure a piece cannot move in or out of check.  Pinned means a piece is in a position where moving would
        //put the king in check, and illegal move.  To determine if a piece is pinned we check along both sides of a direction of travel to see if there is
        //an attacking piece on one side, and the king on the other.
        public bool isPinnedVertical(bool[,] currentBoard, bool[,] oppColor, bool[,] rooks, bool[,] queens, bool[,] kings, int x, int y)
        {
            bool foundKing = new bool();
            bool foundAttacker = new bool();
            int tempX, tempY = new int();
            tempX = x;
            tempY = y;
            while(tempY > 0 && !currentBoard[tempX, tempY])
            {
                tempY--;
            }
            if((rooks[tempX,tempY] && oppColor[tempX, tempY]) || (queens[tempX,tempY] && oppColor[tempX,tempY]))
            {
                foundAttacker = true;
            }
            if(kings[tempX,tempY] && !oppColor[tempX, tempY])
            {
                foundKing = true;
            }

            tempY = y;
            while(tempY<7 && !currentBoard[tempX, tempY])
            {
                tempY++;
            }
            if ((rooks[tempX, tempY] && oppColor[tempX, tempY]) || (queens[tempX, tempY] && oppColor[tempX, tempY]))
            {
                foundAttacker = true;
            }
            if (kings[tempX, tempY] && !oppColor[tempX, tempY])
            {
                foundKing = true;
            }

            return (foundAttacker && foundKing);
        }

        public bool isPinnedHorizontal(bool[,] currentBoard, bool[,] oppColor, bool[,] rooks, bool[,] queens, bool[,] kings, int x, int y)
        {
            bool foundKing = new bool();
            bool foundAttacker = new bool();
            int tempX, tempY = new int();
            tempX = x;
            tempY = y;
            while (tempX > 0 && !currentBoard[tempX, tempY])
            {
                tempX--;
            }
            if ((rooks[tempX, tempY] && oppColor[tempX, tempY]) || (queens[tempX, tempY] && oppColor[tempX, tempY]))
            {
                foundAttacker = true;
            }
            if (kings[tempX, tempY] && !oppColor[tempX, tempY])
            {
                foundKing = true;
            }
            
            tempX = x;
            while (tempX < 7 && !currentBoard[tempX, tempY])
            {
                tempX++;
            }
            if ((rooks[tempX, tempY] && oppColor[tempX, tempY]) || (queens[tempX, tempY] && oppColor[tempX, tempY]))
            {
                foundAttacker = true;
            }
            if (kings[tempX, tempY] && !oppColor[tempX, tempY])
            {
                foundKing = true;
            }

            return (foundAttacker && foundKing);
        }

        public bool isPinnedTLBR(bool[,] currentBoard, bool[,] oppColor, bool[,] bishops, bool[,] queens, bool[,] kings, int x, int y)
        {
            bool foundKing = new bool();
            bool foundAttacker = new bool();
            int tempX, tempY = new int();
            tempX = x;
            tempY = y;
            while(tempX>0 && tempY>0 && !currentBoard[tempX, tempY])
            {
                tempX--;
                tempY--;
            }
            if ((bishops[tempX, tempY] && oppColor[tempX, tempY]) || (queens[tempX, tempY] && oppColor[tempX, tempY]))
            {
                foundAttacker = true;
            }
            if (kings[tempX, tempY] && !oppColor[tempX, tempY])
            {
                foundKing = true;
            }

            tempX = x;
            tempY = y;
            while(tempX<7 && tempY<7 && !currentBoard[tempX, tempY])
            {
                tempX++;
                tempY++;
            }
            if ((bishops[tempX, tempY] && oppColor[tempX, tempY]) || (queens[tempX, tempY] && oppColor[tempX, tempY]))
            {
                foundAttacker = true;
            }
            if (kings[tempX, tempY] && !oppColor[tempX, tempY])
            {
                foundKing = true;
            }

            return (foundAttacker && foundKing);
        }

        public bool isPinnedTRBL(bool[,] currentBoard, bool[,] oppColor, bool[,] bishops, bool[,] queens, bool[,] kings, int x, int y)
        {
            bool foundKing = new bool();
            bool foundAttacker = new bool();
            int tempX, tempY = new int();
            tempX = x;
            tempY = y;
            while (tempX > 0 && tempY < 7 && !currentBoard[tempX, tempY])
            {
                tempX--;
                tempY++;
            }
            if ((bishops[tempX, tempY] && oppColor[tempX, tempY]) || (queens[tempX, tempY] && oppColor[tempX, tempY]))
            {
                foundAttacker = true;
            }
            if (kings[tempX, tempY] && !oppColor[tempX, tempY])
            {
                foundKing = true;
            }

            tempX = x;
            tempY = y;
            while (tempX < 7 && tempY > 0 && !currentBoard[tempX, tempY])
            {
                tempX++;
                tempY--;
            }
            if ((bishops[tempX, tempY] && oppColor[tempX, tempY]) || (queens[tempX, tempY] && oppColor[tempX, tempY]))
            {
                foundAttacker = true;
            }
            if (kings[tempX, tempY] && !oppColor[tempX, tempY])
            {
                foundKing = true;
            }

            return (foundAttacker && foundKing);
        }
    }
}

