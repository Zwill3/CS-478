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
        //The chessBoard class variable allows the usage of board class methods
        //The moverX and moverY variables hold the location of piece that is attempting to be moved.
        public event EventHandler ControlClick;
        Board chessBoard;
        Button[,] buttonGrid;
        bool pieceSelected = false;
        int moverX;
        int moverY;
       
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Full screen
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(width, height);
            //Upon loading we need to have a chessboard to handle the back end of things and some additional form variables
            //for displaying the chess game properly.
            //0,0 = A8 making the top left corner of the board our start of the 2D array
            chessBoard = new Board();
            buttonGrid = new Button[8, 8] { { A8, A7, A6, A5, A4, A3, A2, A1 }, { B8, B7, B6, B5, B4, B3, B2, B1 }, { C8, C7, C6, C5, C4, C3, C2, C1 }, { D8, D7, D6, D5, D4, D3, D2, D1 }, { E8, E7, E6, E5, E4, E3, E2, E1 }, { F8, F7, F6, F5, F4, F3, F2, F1 }, { G8, G7, G6, G5, G4, G3, G2, G1 }, { H8, H7, H6, H5, H4, H3, H2, H1 } };
            for (int i = 0; i<8; i++)
            {
                for (int j = 0; j<8; j++)
                {
                    //Initial update board will set up the board for the start of the game
                    UpdateBoard();
                    //Sets the buttons default OnClick method to the custom default
                    this.buttonGrid[i, j].Click += OnClick;
                    buttonGrid[i, j].Tag = new Point(i, j);
                }
            }
        }

        //The UpdateButton method gets the piece type from the ChessBoard and uses that to display the proper image.
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
                //Change pieceSelected to ready the next part on the next click as well set the coords of the moving piece
                pieceSelected = true;
                moverX = location.X;
                moverY = location.Y;
                //Disable all buttons
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        buttonGrid[i, j].Enabled = false;
                    }
                }
                //Queue all the moves a piece can make
                List<int[]> legalMoves = new List<int[]>();
                legalMoves = chessBoard.QueueMoves(location.X, location.Y);
                //Enable all the buttons that a move can be made at in order to carry out a move
                foreach (int[] ray in legalMoves)
                {
                    buttonGrid[ray[0], ray[1]].Enabled = true;
                }
            }
            else
            {
                pieceSelected = false;
                if (!(moverX == location.X && moverY == location.Y))
                {
                    chessBoard.CompleteMove(moverX, moverY, location.X, location.Y);
                }
                UpdateBoard();
            }
        }

        private void UpdateBoard()
        {
            for(int i=0; i<8; i++)
            {
                for(int j=0; j<8; j++)
                {
                    buttonGrid[i, j].Image = UpdateButton(i, j);
                    buttonGrid[i, j].Enabled = true;
                    if(buttonGrid[i,j].Image == null) { buttonGrid[i, j].Enabled = false; }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserInterface menuReset = new UserInterface();
            menuReset.ShowDialog();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var MainMenu = new UserInterface();
            var chessboard = new Form1();
            Visible = false;
            MainMenu.Visible = true;


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}
