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
        private Image player_01;
        private Image player = Properties.Resources.player_01 as Image;

        private bool isJumpingPlayer;  //Proverka za dali skoka ili ne 
        private bool Stop_Horizontal_Movement { get; set; }

        private int height;
        private int dy { get; set; }

        private int dx { get; set; }

        public int nextPlatform { get; set; }

        public Player(int X, int Y) : base(X, Y)
        {
            //Deklaracija na bool promenlivi
            isJumpingPlayer = false;
            Stop_Horizontal_Movement = false;

            //Deklaracija na int promenlivi
            height = 50;
            dy = 0;
            dx = 0;
            nextPlatform = 1;
        }

        public override void Draw(Graphics g)
        {

        }

        public void Jump(GamePanel stage, SpringNinja form)  //Ova e kodot od SpringNinja i se naogja kaj Ninja.cs no rabotata e sto imaat i GamePanel otvaram i nema nisto. Proveri go ova ako mozes 
        {
            dy += 1; // Namaluvanje na zabrzuvanjeto (the velocity).

            this.Y += dy; // Zabrzuvanje po y-oskata.

            if (!Stop_Horizontal_Movement)
            {
                this.X += dx;  // Logikata e treba da se  dvizi ninjata po X oskata ako i samo ako ne se udril od strana so nekoja platforma. Zatoa ovoj test .
                form.CanavasSlider -= dx;

            }

        }

    }
}
