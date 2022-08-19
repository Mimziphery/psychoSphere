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
    public partial class theGame : Form
    {

        bool goLeft, goRight, jump;
        int force = 8;
        int playerSpeed = 10;
        int backgroundspeed = 8;

        private Image backgroundImage;
        public theGame()
        {
            InitializeComponent();
            backgroundImage = this.BackgroundImage;
        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            if (goLeft == true)
            {
                player.Left += playerSpeed;
            }

            if (goRight == true)
            {
                player.Left -= playerSpeed;
            }


        }

        private void theGame_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer,
            true);

        }

        private void theGame_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if(e.KeyCode == Keys.Space && jump == false)
            {
                jump = true;
            }

        }

        private void theGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (jump == true)
            {
                jump = false;
            }
        }
    }
}
