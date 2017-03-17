using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turn_based_MM2
{
    // List of MapTiles fills whole map, PIXELS_PER_MOVE should be passed around too I think.
    // 
    class MapTile
    {
        public PictureBox PicBox { get; private set; }
        public bool Passable { get; private set; }
        bool Plantable { get; }

        /// <summary>
        /// The PictureBox inside still needs to be declared (SetPos(), SetImage()) then added to this.Controls.Add(MapTile.PicBox);
        /// </summary>
        /// <param name="passable"></param>
        /// <param name="plantable"></param>
        public MapTile(bool passable, bool plantable)
        {
            PicBox = new PictureBox();
            PicBox.Size = new Size(Constants.TILE_WIDTH, Constants.TILE_HEIGHT);
            // Set image is shrunk or stretched to fit size.
            PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            Passable = passable;
            Plantable = plantable;
            
        }
        /// <summary>
        /// Sets MapTile position to passed Point.
        /// </summary>
        /// <param name="tilePosition"></param>
        public void SetPos(Point tilePosition)
        {
            PicBox.Location = tilePosition;
        }
        /// <summary>
        /// Sets MapTile position to passed x and y coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetPos(int x, int y)
        {
            Point tilePosition = new Point(x * Constants.PIXELS_PER_TILE, y * Constants.PIXELS_PER_TILE);
            PicBox.Location = tilePosition;
            
        }
        /// <summary>
        /// Sets image to passed filePath.
        /// </summary>
        /// <param name="filePath"></param>
        public void SetImage(string filePath)
        {
            PicBox.ImageLocation = filePath;
        }

    }
}
