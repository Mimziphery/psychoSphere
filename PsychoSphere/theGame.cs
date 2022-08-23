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

        private Image backgroundImage;
        // private Image player = Properties.Resources.player_01 as Image;
        public Player player = new Player(0, 0); //Napraviv nov objekt kade sto kje gi sodrzi tie koordinati 

        public System.Drawing.Graphics Graphics { get; } //Ova e za paint

        public int CanavasSlider = 0;
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

            if (Collision())
            {
                Timer.Stop();
                player.dy = 0;

                Stage.Location = new Point(CanavasSlider, 0);
                //player.Stop_Horizontal_Movement = false;

                return;

            }


            Stage.Location = new Point(CanavasSlider, 0);



            PlayerJump();

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

        public bool ShouldPressSpace(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && jump == false)
            {
                jump = true;
            }
            if (Timer.Enabled) return false;

            return true;
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
            if (!ShouldPressSpace(e)) return;
            Timer.Start();
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
            if (!ShouldPressSpace(e)) return;
            player.dy -= 1;
        }
        private void Stage_Paint(object sender, PaintEventArgs e)
        {

            foreach (SceneObjects o in DrawableList)
            {

                o.Draw(e.Graphics);

            }

        }

        public bool Collision()
        {

            int X = player.X;
            int Y = player.Y;

            for (int i = player.nextPlatform; i < DrawableList.Count - 1; i++)
            {
                Platform tmp = DrawableList[i] as Platform;

                if (tmp.Passed) continue;

                //Ova mislam se odnesuva na so kolkava brzina coveceto odi nagore po y oska odnosno dy i na ovoj nacin skoka po nekolku pikseli 
                //Detekcija na kolizija
                //Ovde treba da se promeni

                if (X + 35 >= tmp.X && X <= tmp.X + 29 && Y + 70 >= tmp.Y && Y + 10 <= tmp.Y)
                {

                    player.Y = tmp.Y - 50;

                    tmp.Passed = true;           //Ova go vrakjame coveceto nad platformata (pretpostavuvam ova koga kje bide game over no nasiot slucaj nema)
                    player.nextPlatform += 1;


                    return true;
                }
                if (X + player.width >= tmp.X && X <= tmp.X + 9 && Y + 50 >= tmp.Y) //Ova e slucaj koga coveceto kje se sudri so platformite koi visat
                {
                    player.Stop_Horizontal_Movement = true;
                    return false;

                }
            }
            player.nextPlatform = 1;
            return false;
        }
    }
}
