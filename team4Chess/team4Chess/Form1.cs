using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessBoardModel2;

namespace team4Chess
{
    public partial class Form1 : Form
    {
        //The class variable EventHandler is used to override the OnClick method of buttons
        //The buttonGrid class variable is the visual representation of the board
        //The pieceSelected class variable is used to determine whether the player is deciding a piece to move or about to move a piece.
        public event EventHandler ControlClick;
        Board chessBoard;
        Button[,] buttonGrid;
        bool pieceSelected = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Upon loading we need to have a chessboard to handle the back end of things and some additional form variables
            //for displaying the chess game properly.
            //0,0 = A8 making the top left corner of the board our start of the 2D array
            chessBoard = new Board();
            buttonGrid = new Button[8, 8] { { A8, B8, C8, D8, E8, F8, G8, H8 }, { A7, B7, C7, D7, E7, F7, G7, H7 }, { A6, B6, C6, D6, E6, F6, G6, H6 }, { A5, B5, C5, D5, E5, F5, G5, H5 }, { A4, B4, C4, D4, E4, F4, G4, H4 }, { A3, B3, C3, D3, E3, F3, G3, H3 }, { A2, B2, C2, D2, E2, F2, G2, H2 }, { A1, B1, C1, D1, E1, F1, G1, H1 } };
            for (int i = 0; i<8; i++)
            {
                for (int j = 0; j<8; j++)
                {
                    //Initial update board will set up the board for the start of the game
                    buttonGrid[i,j].Image = UpdateButton(i, j);
                    UpdateBoard();
                    //Sets the buttons default OnClick method to the custom default
                    this.buttonGrid[i, j].Click += OnClick;
                    buttonGrid[i, j].Tag = new Point(i, j);
                }
            }
        }

        //The update board method gets the piece type from the ChessBoard and uses that to display the proper image.
        private Image UpdateButton(int xCoord, int yCoord)
        {
            int type = chessBoard.GetType(xCoord, yCoord);
            switch (type)
            {
                case 0:
                    return null;
                case 1:
                    return team4Chess.Properties.Resources.chessBlackPawn;
                case 2:
                    return team4Chess.Properties.Resources.chessWhitePawn;
                case 3:
                    return team4Chess.Properties.Resources.chessBlackKnight;
                case 4:
                    return team4Chess.Properties.Resources.chessWhiteKnight;
                case 5:
                    return team4Chess.Properties.Resources.chessBlackBishop;
                case 6:
                    return team4Chess.Properties.Resources.chessWhiteBishop;
                case 7:
                    return team4Chess.Properties.Resources.chessBlackRook;
                case 8:
                    return team4Chess.Properties.Resources.chessWhiteRook;
                case 9:
                    return team4Chess.Properties.Resources.chessBlackQueen;
                case 10:
                    return team4Chess.Properties.Resources.chessWhiteQueen;
                case 11:
                    return team4Chess.Properties.Resources.chessBlackKing;
                case 12:
                    return team4Chess.Properties.Resources.chessWhiteKing;
                default:
                    MessageBox.Show("Error");
                    return null;
            }
        }

        private void OnClick(object sender, EventArgs e)
        {
            //Checks for if the original component has its own on-click method to run.
            ControlClick?.Invoke(sender, e);

            //Get the coordinate of the button that was clicked
            Button pressedButton = (Button)sender;
            Point location = (Point) pressedButton.Tag;

            //Code for the new default OnClick method
            if (!pieceSelected)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        buttonGrid[i, j].Enabled = false;
                    }
                }
            }

            List<int[]> legalMoves = new List<int[]>();
            legalMoves = chessBoard.QueueMoves(location.X, location.Y);
            foreach (int[] ray in legalMoves)
            {
                buttonGrid[ray[1], ray[0]].Enabled = true;
            }
        }

        private void UpdateBoard()
        {
            for(int i=0; i<8; i++)
            {
                for(int j=0; j<8; j++)
                {
                    buttonGrid[i, j].Enabled = true;
                    if(buttonGrid[i,j].Image == null) { buttonGrid[i, j].Enabled = false; }
                }
            }
        }
    }
}
