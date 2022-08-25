﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PsychoSphere
{
    class Game
    {

        public GameSprite playerSprite;
        private GameSprite platform1Sprite;
        private GameSprite platform2Sprite;
        private GameSprite platform3Sprite;

        public Size Resolution { get; set; }

        public void Load()
        {
            // Load new sprite class
            playerSprite = new GameSprite();
            platform1Sprite = new GameSprite();
            platform2Sprite = new GameSprite();
            platform3Sprite = new GameSprite();


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
            playerSprite.X = 300;
            playerSprite.Y = 300;

            platform1Sprite.X = 600;
            platform1Sprite.Y = 300;

            platform2Sprite.X = 400;
            platform2Sprite.Y = 400;

            platform3Sprite.X = 500;
            platform3Sprite.Y = 100;


            // Set sprite Velocity
            playerSprite.Velocity = 300;
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

            // Move player sprite, when Arrow Keys are pressed on Keyboard
            if ((Keyboard.GetKeyStates(Key.Right) & KeyStates.Down) > 0)
            {
                playerSprite.X += moveDistance;
            }
            else if ((Keyboard.GetKeyStates(Key.Left) & KeyStates.Down) > 0)
            {
                playerSprite.X -= moveDistance;
            }
            else if ((Keyboard.GetKeyStates(Key.Up) & KeyStates.Down) > 0)
            {
                playerSprite.Y -= moveDistance;
            }
            else if ((Keyboard.GetKeyStates(Key.Down) & KeyStates.Down) > 0)
            {
                playerSprite.Y += moveDistance;
            }
        }

        public void Draw(Graphics gfx)
        {
            // Draw Player Sprite
            playerSprite.Draw(gfx);
            platform1Sprite.Draw(gfx);
            platform2Sprite.Draw(gfx);
            platform3Sprite.Draw(gfx);
            
        }

    }
}