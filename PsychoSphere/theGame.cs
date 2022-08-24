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
        public List<SceneObjects> DrawableList = new List<SceneObjects>();
        bool goLeft, goRight, jump;
        int force = 8;
        int playerSpeed = 10;
        int backgroundspeed = 8;
       


        private Image playerimage = Properties.Resources.player_01 as Image;
        public Player player = new Player(0, 0); //Napraviv nov objekt kade sto kje gi sodrzi tie koordinati 


        public System.Drawing.Graphics Graphics { get; } //Ova e za paint

        public int CanavasSlider = 0;
        public theGame()
        {
            InitializeComponent();
            player.image = playerimage;



        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            if (goLeft == true)
            {
                player.dx += playerSpeed;
            }

            if (goRight == true)
            {
                player.dx -= playerSpeed;
            }



            Stage.Location = new Point(CanavasSlider, 0);

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
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
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

        }
        private void Stage_Paint(object sender, PaintEventArgs e)
        {
            Stage.BackgroundImage = Properties.Resources.dvizecka_pozadina;
            Stage.Invalidate();
         

            foreach (SceneObjects o in DrawableList)
            {

                o.Draw(e.Graphics);

            }

        }


    }
}
