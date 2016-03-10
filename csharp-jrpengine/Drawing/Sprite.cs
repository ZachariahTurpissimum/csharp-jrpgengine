using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace csharp_jrpengine.Drawing
{
    public class Sprite : Surface
    {
        public Sprite(string file, Point point)
            : base(file, point)
        {

        }

        public void move(int x, int y)
        {
            this.Location = new Point(Location.X + x, Location.Y + y);
        }
    }
}
