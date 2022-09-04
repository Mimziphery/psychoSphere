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
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();
        }

        private void startButton_MouseHover(object sender, EventArgs e)
        {
            startButton.Image = Properties.Resources.start_hover;
        }

        private void startButton_MouseLeave(object sender, EventArgs e)
        {
            startButton.Image = Properties.Resources.start_01;
        }

        private void optionsButton_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void optionsButton_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void exitButton_MouseHover(object sender, EventArgs e)
        {
            exitButton.Image = Properties.Resources.exit_hover;
        }

        private void exitButton_MouseLeave(object sender, EventArgs e)
        {
            exitButton.Image = Properties.Resources.exit_01;
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Use arrow keys to move left and right. Use space for jumping.");
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            exitPage exitPage = new exitPage();
            exitPage.ShowDialog();
            this.Close();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            theGame gamewindow = new theGame();
            gamewindow.ShowDialog();
            this.Close();
        }
    }
}
