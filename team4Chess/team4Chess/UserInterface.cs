using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace team4Chess
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UIsinglePlayer secondPage = new UIsinglePlayer();
            secondPage.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 multiGame = new Form1();
            multiGame.ShowDialog();
        }
    }
}
