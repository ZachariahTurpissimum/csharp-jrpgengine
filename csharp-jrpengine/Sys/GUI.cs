using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using csharp_jrpengine.Drawing;
using System.Drawing;

namespace csharp_jrpengine.Sys
{
    public class GUI
    {
        Game game;

        public Surface Gui { get { return game.Gui; } set { game.Gui = value; } } // sprites drawn onto this layer are above the player
        public Text fpsText;

        public GUI(Game game)
        {
            this.game = game;
            fpsText = new Text("", new Font("Arial", 24), Color.Wheat, new Point(2, 2));
        }

        public void Update()
        {
            fpsText.UpdateText(String.Format("{0} fps", game.fps.LastFps));
        }

        public void OnKeyPress(object sender, KeyEventArgs key)
        {

        }

        public void OnKeyRelease(object sender, KeyEventArgs key)
        {

        }

        public void Draw()
        {
            fpsText.Draw(Gui);
        }
    }
}
