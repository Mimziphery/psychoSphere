using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace PsychoSphere
{

    //Kreirame klasa PLayer
    public class Player : SceneObjects
    {
        
        public Bitmap image;

        private bool isJumpingPlayer;  //Proverka za dali skoka ili ne 
        private bool Stop_Horizontal_Movement { get; set; }

        private int height;
        private int dy { get; set; }

        public int dx { get; set; }

        public int nextPlatform { get; set; }

        public Player(int X, int Y) : base(X, Y)
        {
            //Deklaracija na bool promenlivi
            isJumpingPlayer = false;
            Stop_Horizontal_Movement = false;

            //Deklaracija na int promenlivi
            width = 100;
            height = 100;
            dy = 0;
            dx = 0;
            nextPlatform = 1;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(image, this.X, this.Y, this.width, this.height);

        }

        

    }
}
