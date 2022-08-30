using System;
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
        private GameSprite platform1Sprite;
        private GameSprite platform2Sprite;
        private GameSprite platform3Sprite;
        private Boolean collision;
        

        public Size Resolution { get; set; }

        public void Load()
        {
            // Load new sprite class
            playerSprite = new GameSprite();
            platform1Sprite = new GameSprite();
            platform2Sprite = new GameSprite();
            platform3Sprite = new GameSprite();
            platforms = new List<GameSprite>();
            isJumping = false;
            collision = false;
            



            // Load sprite image
            playerSprite.SpriteImage = Properties.Resources.player_01;

            platform1Sprite.SpriteImage = Properties.Resources.platform1;
            platform2Sprite.SpriteImage = Properties.Resources.platform2;
            platform3Sprite.SpriteImage = Properties.Resources.platform3;

            // Set sprite height & width in pixels
            playerSprite.Width = 60;
            playerSprite.Height = 85;

            
            platform1Sprite.Width = 60;
            platform1Sprite.Height = 85;

            platform2Sprite.Width = 60;
            platform2Sprite.Height = 85;

            platform3Sprite.Width = 60;
            platform3Sprite.Height = 85;


            // Set sprite coodinates
            playerSprite.X = 0;
            playerSprite.Y = 200;

            platform1Sprite.X = 600;
            platform1Sprite.Y = 300;

            platform2Sprite.X = 400;
            platform2Sprite.Y = 400;

            platform3Sprite.X = 500;
            platform3Sprite.Y = 100;


            // Set sprite Velocity
            playerSprite.Velocity = 300;

            //Add platforms to list
            platforms.Add(platform1Sprite);
            platforms.Add(platform2Sprite);
            platforms.Add(platform3Sprite);

        }

        public void Unload()
        {
            // Unload graphics
            // Turn off game music

        }

        public void Update(TimeSpan gameTime)
        {
            // Gametime elapsed
            double gameTimeElapsed = gameTime.TotalMilliseconds / 1000;
            // Calculate sprite movement based on Sprite Velocity and GameTimeElapsed
            int moveDistance = (int)(playerSprite.Velocity * gameTimeElapsed);

            UpdateMovement(moveDistance);



        }

        private void UpdateMovement(int moveDistance)
        {
            // Move player sprite, when Arrow Keys are pressed on Keyboard
            if ((Keyboard.GetKeyStates(Key.Right) & KeyStates.Down) > 0)
            {
                playerSprite.X += moveDistance;

            }
            else if ((Keyboard.GetKeyStates(Key.Left) & KeyStates.Down) > 0)
            {
                playerSprite.X -= moveDistance;
            }
            else if ((Keyboard.GetKeyStates(Key.Space) & KeyStates.Down) > 0)
            {
                playerSprite.Y -= moveDistance; //go up
                collision = false;
            }
            else if(playerSprite.Y + playerSprite.Height > 550) //check if played touched the ground
            {

                //snap the player's bottom to the ground's position
                playerSprite.Y = 550 - playerSprite.Height;
                collision = true;

                //allow jumping again
                isJumping = false;
            }
            else if (collision)
            {
                playerSprite.Y += 0;
            }
            else
            {
                playerSprite.Y += moveDistance; //go down

            }
       

            
            
            

        }
        private void Restart()
        {
            Stop();

        }

        public void Draw(Graphics gfx)
        {
            // Draw Player Sprite
            

            //playerSprite.Draw(gfx);
            RectangleF playerRect = new RectangleF(playerSprite.X, playerSprite.Y, playerSprite.Width, playerSprite.Height);

            gfx.DrawImage(playerSprite.SpriteImage, playerRect);

            foreach (GameSprite platform in platforms)
            {
                RectangleF platformRect = new RectangleF(platform.X, platform.Y, platform.Width, platform.Height);

                gfx.DrawImage(platform.SpriteImage, platformRect);

              
                if (playerRect.IntersectsWith(platformRect))
                {
                    if (platform.Y > playerSprite.Y + playerSprite.Height / 2)
                    {
                        
                       
                        playerSprite.Y = platform.Y - playerSprite.Height; //put the player on that platform
                        collision = true;
                        break;

                    }

                }
               
            }
            

        }

    }
}
