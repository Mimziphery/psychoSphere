using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PsychoSphere
{
    public abstract class SceneObjects
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int width { get; set; }

        public SceneObjects(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            width = 50;
        }

        abstract public void Draw(Graphics g);
    }
}
