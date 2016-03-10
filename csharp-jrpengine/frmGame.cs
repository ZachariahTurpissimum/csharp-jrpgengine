using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using csharp_jrpengine.Sys;
using csharp_jrpengine.Drawing;

namespace csharp_jrpengine
{
    public partial class frmGame : Form
    {
        private List<Surface> layers;
        private Game game;
        public int maxFPS = 60;
        public int cWidth { get { return ClientSize.Width; } set { ClientSize = new Size(value, ClientSize.Height); } }
        public int cHeight { get { return ClientSize.Height; } set { ClientSize = new Size(ClientSize.Height, value); } }

        Surface screenSurface;

        public frmGame()
        {
            InitializeComponent();
            Setup();
        }

        public void Setup()
        {
            ClientSize = new Size(800, 600);
            this.Size = new System.Drawing.Size(816, 639);
            screen.Image = new Bitmap(cWidth, cHeight);
            screenSurface = new Surface(screen.Image, Point.Empty);
        }

        public void SetGame(Game game)
        {
            this.game = game;
        }

        #region LayersMethods
        public void setupLayers(int amountOfLayers = 2)
        {
            if (amountOfLayers < 2)
                throw new Exception("Error: Game needs to have two layers");

            layers = new List<Surface>(amountOfLayers);

            for (int l = 0; l < amountOfLayers; l++)
            {
                Image img = new Bitmap(cWidth, cHeight);
                Graphics device = Graphics.FromImage(img);
                if (l == 0)
                    device.FillRectangle(Brushes.Black, new Rectangle(Point.Empty, ClientSize));
                else
                    device.FillRectangle(Brushes.Transparent, new Rectangle(Point.Empty, ClientSize));

                Surface surface = new Surface(img, Point.Empty);
                layers.Insert(l, surface);
            }
        }

        public Surface getLayer(int l)
        {
            return layers[l];
        }

        public void setLayer(int i, Surface surface)
        {
            layers[i] = surface;
        }
        #endregion

        // This is so the game runs at real time
        // all game logic should be kept in the Game class or any of its subset objects
        // code obtained from http://blogs.msdn.com/b/shawnhar/archive/2010/12/06/when-winforms-met-game-loop.aspx
        #region GameLogic Drawing Updating

        public new void Update()
        {
            game.Update();

            base.Update();
        }

        public void Draw()
        {
            ClearAll();

            game.Draw();

            foreach (Surface layer in layers)
            {
                Graphics device = Graphics.FromImage(screen.Image);

                layer.Draw(screenSurface);
            }

            Image _screenImg = new Bitmap(cWidth, cHeight);
            Graphics graphics = Graphics.FromImage(_screenImg);
            graphics.DrawImage(screenSurface.img, new RectangleF(0, 0, cWidth, cHeight));

            screen.Image = _screenImg;

            Invalidate();
        }

        private void ClearAll()
        {
            for (int l = 0; l < layers.Count; l++)
            {
                Graphics device = null;

                if (l == 0) // background / tiles layer
                {
                    Clear(device, l, Color.Black);
                }
                else
                {
                    Clear(device, l, Color.Transparent);
                }
            }
        }

        private void Clear(Graphics device, int l, Color color)
        {
            device = Graphics.FromImage(layers[l].img);
            device.Clear(color);
        }
        #endregion

        private void frmGame_Resize(object sender, EventArgs e)
        {
            if (screenSurface != null)
            {
                screen.Width = cWidth;
                screen.Height = cHeight;
            }
        }
    }
}
