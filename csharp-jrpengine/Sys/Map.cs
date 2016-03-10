using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using csharp_jrpengine.Drawing;
using System.Drawing;

namespace csharp_jrpengine.Sys
{
    public class Map
    {
        Game game;
        public Surface Background { get { return game.Background; } set { game.Background = value; } } // sprites drawn onto this layer are above the player
        public Surface Sprites1 { get { return game.Sprites1; } set { game.Sprites1 = value; } } // sprites drawn onto this layer are above the player
        public Surface Sprites2 { get { return game.Sprites2; } set { game.Sprites2 = value; } } // sprites drawn onto this layer are above the player
        public Surface Sprites3 { get { return game.Sprites3; } set { game.Sprites3 = value; } } // sprites drawn onto this layer are above the player

        public Tileset tileset = new Tileset();

        private List<List<Sprite>> tiles = new List<List<Sprite>>();

        int height = 19;
        int width = 25;

        public Map(Game game)
        {
            this.game = game;
            tileset[0] = (new Sprite("grass1", Point.Empty));
            tileset[1] = (new Sprite("stonePath1", Point.Empty));

            for (int i = 0; i < width; i++)
            {
                tiles.Add(new List<Sprite>(height));

                for (int j = 0; j < height; j++) {
                    tiles[i].Add(tileset[0]);
                }
            }

            
        }

        public void Draw()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    tiles[x][y].Draw(Background, new Point(x * 32, y*32));
                }
            }
        }
    }
}
