using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace PsychoSphere
{
    public partial class theGame : Form
    {
        Timer graphicsTimer;
        GameLoop gameLoop = null;
        GameSprite player;



        public theGame()
        {
            InitializeComponent();
            // Initialize Paint Event
            Paint += theGame_Paint;
            // Initialize graphicsTimer
            graphicsTimer = new Timer();
            graphicsTimer.Interval = 1000 / 120;
            graphicsTimer.Tick += GraphicsTimer_Tick;
            
        }


        private void theGame_Load(object sender, EventArgs e)
        {
            Rectangle resolution = Screen.PrimaryScreen.Bounds;

            // Initialize Game
            Game myGame = new Game();
            myGame.Resolution = new Size(resolution.Width, resolution.Height);
            player = new GameSprite();
            player.SpriteImage = Properties.Resources.player_01;
            player.Width = 60;
            player.Height = 85;
            player.X = 100;
            player.Y = 100;


            // Initialize & Start GameLoop
            gameLoop = new GameLoop();
            gameLoop.Load(myGame);
            gameLoop.Start();

            // Start Graphics Timer
            graphicsTimer.Start();
        }

        private void theGame_Paint(object sender, PaintEventArgs e)
        {
            if (gameLoop != null)
            {
                // Draw game graphics on Form1
                gameLoop.Draw(e.Graphics);
            }
        }

        private void GraphicsTimer_Tick(object sender, EventArgs e)
        {
            // Refresh Form1 graphics
            Invalidate();
        }

       
    }
}

