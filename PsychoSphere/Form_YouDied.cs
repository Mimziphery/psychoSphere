using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PsychoSphere
{
    public partial class youDiedForm : Form
    {
        public youDiedForm()
        {
            InitializeComponent();
            lblHighScore.Text = Properties.Settings.Default.HighScore.ToString();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            theGame gamewindow = new theGame();
            gamewindow.ShowDialog();
            this.Close();
        }

        private void youDiedForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        
    }
}
