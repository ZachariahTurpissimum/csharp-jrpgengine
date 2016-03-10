using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using csharp_jrpengine.Sys;
using csharp_jrpengine.Drawing;

namespace csharp_jrpengine
{
    public class Game
    {
        frmGame gameWindow;

        Map map;
        GUI gui;
        public  FrameCounter fps = new FrameCounter();
        
        public Surface Background { get { return gameWindow.getLayer(0); } set { gameWindow.setLayer(0, value); } } // the background (tiles)
        public Surface Sprites1 { get { return gameWindow.getLayer(1); } set { gameWindow.setLayer(1, value); } } // sprites drawn onto this layer are 
        public Surface Sprites2 { get { return gameWindow.getLayer(2); } set { gameWindow.setLayer(2, value); } } // sprites drawn onto this layer are on the same level as the player
        public Surface Sprites3 { get { return gameWindow.getLayer(3); } set { gameWindow.setLayer(3, value); } } // sprites drawn onto this layer are on the same level as the player
        public Surface Gui { get { return gameWindow.getLayer(4); } set { gameWindow.setLayer(4, value); } } // sprites drawn onto this layer are above the player
        public Surface Foreground { get { return gameWindow.getLayer(5); } set { gameWindow.setLayer(5, value); } } // effects layer

        Sprite stonePath = new Sprite("stonePath1", new Point(0,0));

        public Game(frmGame gameWindow)
        {
            this.gameWindow = gameWindow;
            this.gameWindow.setupLayers(6);
            this.gameWindow.SetGame(this);

            map = new Map(this);
            gui = new GUI(this);
        }

        public void Update()
        {
            fps.Update();

            gui.Update();

            stonePath.move(1, 1);
        }

        public void Draw()
        {
            map.Draw();
            gui.Draw();
            stonePath.Draw(Sprites1);
        }
    }
}
