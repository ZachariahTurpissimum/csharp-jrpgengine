using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using csharp_jrpengine.Drawing;

namespace csharp_jrpengine.Sys
{
    public class Tileset
    {
        List<Sprite> tiles = new List<Sprite>();

        public Sprite this[int id]
        {
            get
            {
                return tiles[id];
            }

            set
            {
                if (id < tiles.Count)
                    tiles[id] = value;
                else
                {
                    tiles.Insert(id, value);
                }
            }
        }
    }
}
