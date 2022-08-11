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
    public partial class exitPage : Form
    {
        public exitPage()
        {
            InitializeComponent();
        }

        private void yesButton_MouseHover(object sender, EventArgs e)
        {
            yesButton.Image = Properties.Resources.yes_hover;
        }

        private void yesButton_MouseLeave(object sender, EventArgs e)
        {
            yesButton.Image = Properties.Resources.yes_button;
        }

        private void noButton_MouseHover(object sender, EventArgs e)
        {
            noButton.Image = Properties.Resources.no_hover;
        }

        private void noButton_MouseLeave(object sender, EventArgs e)
        {
            noButton.Image = Properties.Resources.no_button;
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainMenu mainForm = new mainMenu();
            mainForm.ShowDialog();
            this.Close();
        }
    }
}
