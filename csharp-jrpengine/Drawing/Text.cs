using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace csharp_jrpengine.Drawing
{
    public class Text : Surface
    {
        string text;
        Font font;
        Color color;

        public Text(string text, Font font, Color color, Point location) : base ((Image)null, location)
        {
            this.font = font;
            this.color = color;
            UpdateText(text);
        }

        public void UpdateText(string text)
        {
            if (text.Length == 0)
                text += " ";
            this.text = text;

            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            SizeF textSize = drawing.MeasureString(text, font);

            img.Dispose();
            drawing.Dispose();

            img = new Bitmap((int)textSize.Width, (int)textSize.Height);
            drawing = Graphics.FromImage(img);
            drawing.Clear(Color.Transparent);

            Brush textBrush = new SolidBrush(color);

            drawing.DrawString(text, font, textBrush, 0, 0);
            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            this.img = img;
        }
    }
}
