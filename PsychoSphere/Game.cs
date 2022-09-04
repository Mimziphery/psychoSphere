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
        public bool gameOver;
        public int highScore;


        private List<GameSprite> platforms;
        private List<GameSprite> stones;
        private List<GameSprite> lifes;
        private List<GameSprite> asterioids;


        private Boolean collision;
        private int score;
     
      

        public Size Resolution { get; set; }

        public void LoadStones() //load stones
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
        public void LoadAsteroids() //load asterioids
        {
            Random randomDistance = new Random();
            int number = randomDistance.Next(2,5); //each scene has random number of asteroids between 2 and 5
            int distance = 0;
            for (int i = 0; i < number; i++)
            {

                GameSprite temp = new GameSprite();
                temp.Height = 30;
                temp.Width = 30;


                temp.X = 1452;
                temp.Y = distance;

                temp.SpriteImage = Properties.Resources.stone;

                if (temp.Y > 500) //dont draw on the bottom interface
                {
                    temp.Y = randomDistance.Next(100, 200);
                }

                asterioids.Add(temp);
                distance += randomDistance.Next(100, 200); //asteroids are on a random distance between each other 
                
                
            }
        }
        public void LoadLifes() //load lifes
        {
            int distance = 0;
            for (int i = 0; i < 3; i++) //each game we have 4 lifes
            {
                
                GameSprite temp = new GameSprite();
                temp.Height = 30;
                temp.Width = 30;

               
                temp.X = 480 + distance;
                temp.Y = 625;

                temp.SpriteImage = Properties.Resources.lives;

                lifes.Add(temp);
                distance += 40;
            }

        }


        public void LoadPlatforms() //load platforms on a random number - algorithm 
        {
            Random heightANDdistance = new Random();
            int randPlatform;
            int distance;
            int height;
            int x = 50;
            int y = 0;
            for (int i=0; i<10; i++) //for each scene, 10 platforms
            {
                randPlatform = heightANDdistance.Next(0, 100); //generate random number
                distance = heightANDdistance.Next(105, 205); // generate random distance between 105 and 205
                height = heightANDdistance.Next(200, 550); // generate random height

                y = 632 - height;

                GameSprite temp = new GameSprite();
                temp.X = x; //set the width and height from the random functions above 
                temp.Y = y;
                
                if (randPlatform % 3 == 0) //function for the random platforms sprites, so we can choose one of the three platforms
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
                    

                platforms.Add(temp); //add them on the list 
                x += distance; //add the starter point for the next platform

            }

        }

        private void LoadPlayer()
        {
            // Load player image
            playerSprite.SpriteImage = Properties.Resources.player_01;

            // Set player player sprite height & width in pixels
            playerSprite.Width = 60;
            playerSprite.Height = 85;


            // Set player sprite coodinates

            GameSprite platform = platforms[0];
            playerSprite.X = platform.X;
            playerSprite.Y = platform.Y - playerSprite.Height * 2;
            collision = true;

            // Set sprite Velocity
            playerSprite.Velocity = 300;

        }
        public void Load() //Load game and its sprites
        {
            // Load new sprite class
            playerSprite = new GameSprite();
            platforms = new List<GameSprite>();
            stones = new List<GameSprite>();
            lifes = new List<GameSprite>();
            asterioids = new List<GameSprite>();

            // Load game variables
            isJumping = false;
            collision = false;
            gameOver = false;
            score = 0;
            highScore = Properties.Settings.Default.HighScore; //highscore per user

            //Add platforms
            LoadPlatforms();

            //Add stones
            LoadStones();

            //Load lifes
            LoadLifes();

            //Load Asteroids
            LoadAsteroids();

            //Load game sprites
            LoadPlayer();
        }

        public int getScore() //get score so the theGame Form can write it
        {
            return this.score;
        }

        public void Unload()
        {
            // Clear all lists
            stones.Clear();
            platforms.Clear();
            asterioids.Clear();
        }

        private void MoveAsteroids() 
        {
            foreach (GameSprite asteroid in asterioids.ToList())
            {
                asteroid.X -= 5; //move them to the left by 5
            }
            if (asterioids.Count == 0)
            {
                LoadAsteroids();
            }
            else if (asterioids[0].X <= 1)
            {
                asterioids.Clear();
                LoadAsteroids();
            }
        }
        private void UpdatePictures() // update player pictures based on his movement directions or actions
        {
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
        public void Update(TimeSpan gameTime)
        {
            // Gametime elapsed
            double gameTimeElapsed = gameTime.TotalMilliseconds / 1000;

            // Calculate sprite movement based on Sprite Velocity and GameTimeElapsed
            int moveDistance = (int)(playerSprite.Velocity * gameTimeElapsed);

            MoveAsteroids(); // Update movement of the enemies
            

            UpdateMovement(moveDistance); //Update movement of the player

            UpdatePictures(); //change pictures for player movement animation

            CheckCollision();

        }

       
        private void CheckCollision()
        {
            RectangleF playerRect = new RectangleF(playerSprite.X, playerSprite.Y, playerSprite.Width, playerSprite.Height);
            foreach (GameSprite platform in platforms)
            {
                RectangleF platformRect = new RectangleF(platform.X, platform.Y, platform.Width, platform.Height);
                if (playerRect.IntersectsWith(platformRect))
                {

                    if (platform.Y > playerSprite.Y + playerSprite.Height - 10)
                    {
                        
                        collision = true;
                        break;

                    }


                }
                else
                    collision = false;
            }

            foreach (GameSprite asteroid in asterioids.ToList())
            {
                RectangleF asteroidRect = new RectangleF(asteroid.X, asteroid.Y, asteroid.Width, asteroid.Height);
               
                if (playerRect.IntersectsWith(asteroidRect))
                {
                    asterioids.Remove(asteroid);
                    if (lifes.Count == 0)
                    {
                        if (score > highScore)
                        {
                            Properties.Settings.Default.HighScore = score;
                            Properties.Settings.Default.Save();
                        }
                        Stop();
                        gameOver = true;

                    }
                    else
                        lifes.RemoveAt(0);

                }
            }
            foreach (GameSprite stone in stones.ToList())
            {
                RectangleF stoneRect = new RectangleF(stone.X, stone.Y, stone.Width, stone.Height);
                if (playerRect.IntersectsWith(stoneRect))
                {
                    stones.Remove(stone);
                    score++;

                }

            }
        }

        bool moveLeft = false;
        bool moveRight = false;

        bool flagLeft = true; //variables for UpdateMovement function
        bool flagRight = true;

        private void UpdateMovement(int moveDistance)
        {
            moveRight = false; //in each frame executed they will be refreshed
            moveLeft = false;
           

            // Move player sprite, when Arrow Keys are pressed on Keyboard
            if ((Keyboard.GetKeyStates(Key.Right) & KeyStates.Down) > 0)
            {
                playerSprite.X += moveDistance; 
                moveRight = true;

            }
            if ((Keyboard.GetKeyStates(Key.Left) & KeyStates.Down) > 0 & playerSprite.X > 10) //chek if the player come to the left end
            {
                playerSprite.X -= moveDistance;
                moveLeft = true;

            }
            if ((Keyboard.GetKeyStates(Key.Space) & KeyStates.Down) > 0) //player jump
            {
                playerSprite.Y -= moveDistance;

                isJumping = true;
                
            }
            
            else if(playerSprite.Y + playerSprite.Height > 550) //check if player touched the ground
            {

                lifes.RemoveAt(0);
                LoadPlayer();

            }
            else if (collision) //check if player had collision with platforms or the ground
            {
             
                isJumping = false;
            }
            else
            {
                playerSprite.Y += moveDistance; //go down


            }
            if (playerSprite.X >= 1500 - playerSprite.Width) // check if played comed to the right end, refresh scene
            {

                RefreshScene();
                
            }

        }
        private void RefreshScene()
        {
            playerSprite.X = 0;
            Unload();
            LoadPlatforms();
            LoadStones();
            LoadAsteroids();
        }


        public void Draw(Graphics gfx)
        {
            // Draw Player Sprite
            RectangleF playerRect = new RectangleF(playerSprite.X, playerSprite.Y, playerSprite.Width, playerSprite.Height);

            gfx.DrawImage(playerSprite.SpriteImage, playerRect);

            // Draw asterioids
            foreach (GameSprite asteroid in asterioids.ToList())
            {
                RectangleF asteroidRect = new RectangleF(asteroid.X, asteroid.Y, asteroid.Width, asteroid.Height);

                gfx.DrawImage(asteroid.SpriteImage, asteroidRect);
            }

            // Draw lifes 
            foreach (GameSprite life in lifes.ToList())
            {
                RectangleF lifeRect = new RectangleF(life.X, life.Y, life.Width, life.Height);

                gfx.DrawImage(life.SpriteImage, lifeRect);

            }

            // Draw platforms
            foreach (GameSprite platform in platforms)
            {
                RectangleF platformRect = new RectangleF(platform.X, platform.Y, platform.Width, platform.Height);

                gfx.DrawImage(platform.SpriteImage, platformRect);

            }

            //Draw stones
            foreach (GameSprite stone in stones)
            {
                RectangleF stoneRect = new RectangleF(stone.X, stone.Y, stone.Width, stone.Height);

                gfx.DrawImage(stone.SpriteImage, stoneRect);

            }
        }

    }
}
