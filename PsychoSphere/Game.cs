﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace PsychoSphere
{
    class Game : GameLoop
    {

        public GameSprite playerSprite;
        public static bool isJumping;
        private List<GameSprite> platforms;
        private List<GameSprite> stones;
        private List<GameSprite> lifes;
        private Boolean collision;
        private int score;

        public Size Resolution { get; set; }

        public void LoadStones()
        {
            Random randomPlatform = new Random();
            int randPlatform;
            for (int i=0; i<5; i++)
            {
                randPlatform = randomPlatform.Next(0, 10);
                GameSprite temp = new GameSprite();
                temp.Height = 40;
                temp.Width = 40;

                GameSprite platform = platforms[randPlatform];
                temp.X = platform.X + 20;
                temp.Y = platform.Y - 50;

                temp.SpriteImage = Properties.Resources.time;

                stones.Add(temp);
            }

        }

        public void LoadLifes()
        {
            int distance = 0;
            for (int i = 0; i < 3; i++)
            {
                
                GameSprite temp = new GameSprite();
                temp.Height = 30;
                temp.Width = 30;

               
                temp.X = 480 + distance;
                temp.Y = 625;

                temp.SpriteImage = Properties.Resources.lives;

                stones.Add(temp);
                distance += 40;
            }

        }


        public void LoadPlatforms()
        {
            Random heightANDdistance = new Random();
            int randPlatform;
            int distance;
            int height;
            int x = 50;
            int y = 0;
            for (int i=0; i<10; i++)
            {
                randPlatform = heightANDdistance.Next(0, 100);
                distance = heightANDdistance.Next(105, 205);
                height = heightANDdistance.Next(200, 550);

                y = 632 - height;

                GameSprite temp = new GameSprite();
                temp.X = x;
                temp.Y = y;
                
                if (randPlatform % 3 == 0)
                {
                    temp.SpriteImage = Properties.Resources.platform1;
                    temp.Height = 50;
                    temp.Width = 80;
                }
                else if(randPlatform % 3 == 1)
                {
                    temp.SpriteImage = Properties.Resources.platform2;
                    temp.Height = 100;
                    temp.Width = 80;
                }
                else
                {
                    temp.SpriteImage = Properties.Resources.platform3;
                    temp.Height = 40;
                    temp.Width = 80;
                }
                    

                platforms.Add(temp);
                x += distance;

            }

        }
        public void Load()
        {
            // Load new sprite class
            playerSprite = new GameSprite();
            platforms = new List<GameSprite>();
            stones = new List<GameSprite>();
            lifes = new List<GameSprite>();
            isJumping = false;
            collision = false;
            score = 0;
            // Load sprite image
            playerSprite.SpriteImage = Properties.Resources.player_01;

            // Set sprite height & width in pixels
            playerSprite.Width = 60;
            playerSprite.Height = 85;


            // Set sprite coodinates
            playerSprite.X = 0;
            playerSprite.Y = 200;

            // Set sprite Velocity
            playerSprite.Velocity = 300;

            //Add platforms
            LoadPlatforms();

            //Add stones
            LoadStones();

            LoadLifes();



        }

        public int getScore()
        {
            return this.score;
        }

        public void Unload()
        {
            // Unload graphics
            // Turn off game music
            stones.Clear();
            platforms.Clear();
        }

        public void Update(TimeSpan gameTime)
        {
            // Gametime elapsed
            double gameTimeElapsed = gameTime.TotalMilliseconds / 1000;
            // Calculate sprite movement based on Sprite Velocity and GameTimeElapsed
            int moveDistance = (int)(playerSprite.Velocity * gameTimeElapsed);

            UpdateMovement(moveDistance);



        }

        bool moveLeft = false;
        bool moveRight = false;

        bool flagLeft = true;
        bool flagRight = true;
        private void UpdateMovement(int moveDistance)
        {
            moveRight = false;
            moveLeft = false;
            isJumping = false;

            // Move player sprite, when Arrow Keys are pressed on Keyboard
           

            if ((Keyboard.GetKeyStates(Key.Right) & KeyStates.Down) > 0)
            {
                playerSprite.X += moveDistance;
                moveRight = true;

                moveLeft = false;

            }
            if ((Keyboard.GetKeyStates(Key.Left) & KeyStates.Down) > 0 & playerSprite.X > 10)
            {
                playerSprite.X -= moveDistance;
                moveLeft = true;

                moveRight = false;
            }
            if ((Keyboard.GetKeyStates(Key.Space) & KeyStates.Down) > 0)
            {
                playerSprite.Y -= moveDistance; //go up
                isJumping = true;

                collision = false;
                
            }
            else if(playerSprite.Y + playerSprite.Height > 550) //check if played touched the ground
            {

                //snap the player's bottom to the ground's position
                
                collision = true;

                //allow jumping again
                isJumping = false;
            }
            else if (collision)
            {
                playerSprite.Y += 0;
                isJumping = false;
            }
            else
            {
                playerSprite.Y += moveDistance; //go down

            }


            if (moveLeft)
            {
                if (flagLeft)
                {
                    playerSprite.SpriteImage = Properties.Resources.odenjeFLIPPED;
                    flagLeft = false;
                }
                else
                {
                    playerSprite.SpriteImage = Properties.Resources.odenje2FLIPPED;
                    flagLeft = true;
                }
            }
            if (moveRight)
            {
                if (flagRight)
                {
                    playerSprite.SpriteImage = Properties.Resources.odenje;
                    flagRight = false;
                }
                else
                {
                    playerSprite.SpriteImage = Properties.Resources.odenje2;
                    flagRight = true;
                }
            }
            if (isJumping)
            {
                if (moveLeft)
                {
                    playerSprite.SpriteImage = Properties.Resources.skokanjeFLIPPED;

                }
                else
                {
                    playerSprite.SpriteImage = Properties.Resources.skokanje;

                }

            }
           



        }
        private void Restart()
        {
            Stop();

        }

        public void Draw(Graphics gfx)
        {
            // Draw Player Sprite
            if (playerSprite.X >= 1500 - playerSprite.Width)
            {
                playerSprite.X = 0;
                Unload();
                LoadPlatforms();
                LoadStones();
                LoadLifes();
            }
                


            //playerSprite.Draw(gfx);
            RectangleF playerRect = new RectangleF(playerSprite.X, playerSprite.Y, playerSprite.Width, playerSprite.Height);

            gfx.DrawImage(playerSprite.SpriteImage, playerRect);

          
            foreach(GameSprite platform in platforms)
            {
                RectangleF platformRect = new RectangleF(platform.X, platform.Y, platform.Width, platform.Height);
                if (playerRect.IntersectsWith(platformRect))
                {

                    if (platform.Y > playerSprite.Y + playerSprite.Height - 10)
                    {
                         //put the player on that platform
                        collision = true;
                        break;

                    }
                    

                }
                else 
                    collision = false;
            }
            foreach (GameSprite stone in stones.ToList())
            {
                RectangleF stoneRect = new RectangleF(stone.X, stone.Y, stone.Width, stone.Height);
                if (playerRect.IntersectsWith(stoneRect))
                {
                    stones.Remove(stone);
                    score ++;
                    
                }
                
                   
            }
            foreach (GameSprite life in lifes.ToList())
            {
                RectangleF lifeRect = new RectangleF(life.X, life.Y, life.Width, life.Height);

                gfx.DrawImage(life.SpriteImage, lifeRect);

            }

            foreach (GameSprite platform in platforms)
            {
                RectangleF platformRect = new RectangleF(platform.X, platform.Y, platform.Width, platform.Height);

                gfx.DrawImage(platform.SpriteImage, platformRect);

            }
            foreach (GameSprite stone in stones)
            {
                RectangleF stoneRect = new RectangleF(stone.X, stone.Y, stone.Width, stone.Height);

                gfx.DrawImage(stone.SpriteImage, stoneRect);

            }


        }

    }
}
