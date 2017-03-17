using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_based_MM2
{
    class Services
    {
        /// <summary>
        /// Converts Map X Y coords to Point.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Point ConvertMapXYToPoint(int x, int y)
        {
            Point point = new Point(x * Constants.TILE_WIDTH, y * Constants.TILE_HEIGHT);
            return point;
        }

        

    }
}
