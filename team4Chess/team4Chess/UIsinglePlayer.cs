using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace team4Chess
{
    public partial class UIsinglePlayer : Form
    {
        public UIsinglePlayer()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 hardLoad = new Form1();
            hardLoad.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 easyLoad = new Form1();
            easyLoad.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mediumLoad = new Form1();
            mediumLoad.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 engineLoad = new Form1();
            engineLoad.ShowDialog();            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserInterface goBack = new UserInterface();
            goBack.ShowDialog();
        }
    }
}
