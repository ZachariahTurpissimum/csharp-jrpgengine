using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace csharp_jrpengine.Drawing
{
    public class Surface
    {
        internal Image img;
        public Point Location { get; set; }

        public Surface(Image img, Point point) {
            this.img = img;
            this.Location = point;
        }

        public Surface(string file, Point point)
        {
            this.img = new Bitmap("textures/" + file + ".png");
            this.Location = point;
        }

        /*public void DrawSurface(Surface surface) // draws a surface onto this
        {
            Graphics device = Graphics.FromImage(surface.img);
        }*/

        public void Draw(Surface surface) // draws this onto the surface
        {
            Graphics device = Graphics.FromImage(surface.img);
            device.DrawImage(img, Location);
        }
        
        public void Draw(Surface surface, Point point) // draws this onto the surface
        {
            Graphics device = Graphics.FromImage(surface.img);
            device.DrawImage(img, point);
        }

        public void Draw(Graphics device) // draws this onto the surface
        {
            device.DrawImage(img, Location);
        }
    }
}
