using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Turn_based_MM2
{
    class Map
    {
        public MapTile[,] MapTiles { get; set; }
        public Point PlayerPos { get; set; }

        public Map(Point playerPos)
        {
            PlayerPos = playerPos;
        }


    }
}
