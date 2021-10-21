using System;
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
        Button[,] buttonBoard;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChessBoard chessBoard = new ChessBoard();
            buttonBoard = new Button[8, 8] { { A8, B8, C8, D8, E8, F8, G8, H8 }, { A7, B7, C7, D7, E7, F7, G7, H7 }, { A6, B6, C6, D6, E6, F6, G6, H6 }, { A5, B5, C5, D5, E5, F5, G5, H5 }, { A4, B4, C4, D4, E4, F4, G4, H4 }, { A3, B3, C3, D3, E3, F3, G3, H3 }, { A2, B2, C2, D2, E2, F2, G2, H2 }, { A1, B1, C1, D1, E1, F1, G1, H1 } };

        }
    }
}
