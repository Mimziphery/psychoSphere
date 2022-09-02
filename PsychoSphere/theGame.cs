﻿using System;
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
        Game myGame;
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
                lblScore.Text = gameLoop._myGame.getScore().ToString();
                if (gameLoop._myGame.gameOver)
                {
                    graphicsTimer.Stop();
                    this.Hide();
                    youDiedForm newWindow = new youDiedForm();
                    newWindow.ShowDialog();
                    this.Close();
                }
            }
        }

        private void GraphicsTimer_Tick(object sender, EventArgs e)
        {
            // Refresh Form1 graphics
            Invalidate();
        }

        
    }
}

