﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessConsole;

namespace team4Chess
{
    public partial class Form1 : Form
    {
        //The class variable EventHandler is used to override the OnClick method of buttons
        //The buttonGrid class variable is the visual representation of the board
        //The pieceSelected class variable is used to determine whether the player is deciding a piece to move or about to move a piece.
        public event EventHandler ControlClick;
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
            ChessBoard chessBoard = new ChessBoard();
            buttonGrid = new Button[8, 8] { { A8, B8, C8, D8, E8, F8, G8, H8 }, { A7, B7, C7, D7, E7, F7, G7, H7 }, { A6, B6, C6, D6, E6, F6, G6, H6 }, { A5, B5, C5, D5, E5, F5, G5, H5 }, { A4, B4, C4, D4, E4, F4, G4, H4 }, { A3, B3, C3, D3, E3, F3, G3, H3 }, { A2, B2, C2, D2, E2, F2, G2, H2 }, { A1, B1, C1, D1, E1, F1, G1, H1 } };
            for (int i = 0; i<8; i++)
            {
                for (int j = 0; j<8; j++)
                {
                    //Initial update board will set up the board for the start of the game
                    UpdateBoard(i, j);
                    //Sets the buttons default OnClick method to the custom default
                    this.buttonGrid[i, j].Click += OnClick;
                }
            }
        }

        //The update board method gets the piece type from the ChessBoard and uses that to display the proper image.
        private Image UpdateBoard(int xCoord, int yCoord)
        {
            int type = 0;
            //type = ChessBoard.GetType(xCoord, yCoord)
            switch (type)
            {
                case 0:
                    return null;
                case 1:
                    return team4Chess.Properties.Resources.chessBlackPawn;
                case 2:
                    return team4Chess.Properties.Resources.chessBlackKnight;
                case 3:
                    return team4Chess.Properties.Resources.chessBlackBishop;
                case 4:
                    return team4Chess.Properties.Resources.chessBlackRook;
                case 5:
                    return team4Chess.Properties.Resources.chessBlackQueen;
                case 6:
                    return team4Chess.Properties.Resources.chessBlackKing;
                case 7:
                    return team4Chess.Properties.Resources.chessWhitePawn;
                case 8:
                    return team4Chess.Properties.Resources.chessWhiteKnight;
                case 9:
                    return team4Chess.Properties.Resources.chessWhiteBishop;
                case 10:
                    return team4Chess.Properties.Resources.chessWhiteRook;
                case 11:
                    return team4Chess.Properties.Resources.chessWhiteQueen;
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

            //Code for the new default OnClick method
            if (!pieceSelected)
            {
                for(int i = 0; i<8; i++)
                {
                    for(int j = 0; j<8; j++)
                    {
                        buttonGrid[i, j].Enabled = false;
                    }
                }
            }

        }
    }
}
