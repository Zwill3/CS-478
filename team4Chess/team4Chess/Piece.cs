using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClasses
{
    public abstract class Piece
    {
        public PieceColor Color
        {
            private set;
            get;
        }

        public bool Moved
        {
            protected set;
            get;
        }

        //Possible moves
        public abstract IEnumerable<Board.Cell> PossibleMoves
        {
            get;
        }

        //Legal Moves
        public List<Board.Cell> LegalMoves
        {
            private set;
            get;
        }

        public Board.Cell Parent
        {
            private set;
            get;
        }

        public Piece(PieceColor color)
        {
            Color = color;
            Moved = false;
            LegalMoves = new List<Board.Cell>();
        }

        // Called when the piece is first placed or when the piece is replaced after promotion.
        public void OnPlace(Board.Cell cell)
        {
            Parent = cell;
        }

        // Called when the piece is moved.
        public void OnMove(Board.Cell cell)
        {
            Parent = cell;
            Moved = true;
        }

        // Recalculates the possible moves and updates potential hits
        public abstract void Recalculate();

        public abstract bool IsBlockedIfMove(Board.Cell from, Board.Cell to, Board.Cell blocked);

        public abstract char Char { get; }

        protected virtual bool canHit(Board.Cell cell)
        {
            return cell != null && cell.Piece != null && cell.Piece.Color != Color;
        }
    }
}

