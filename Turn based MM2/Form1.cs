/* To do:
 * Logika ekrano ribom+++
 * Map'as++ (papildomos ribos, CanMove() metodas tikrintu vienu metu.+++
 * STUCK. Passing MapTile[,] to CanMoveMapTile logic.
 * Rewrite Map as a class.
 * Rewrite Map as a class.
 * Enemies (with AI)
 * Rewrite Player as a class (possible multiplayer)
*/

// Map as a class (MapTile[], PlayerPos)
// Declare Map List
// Add Map method (Services.cs)
// Shown Map method (Services.cs)
// Move most logic to methods(Services.cs, Map.cs, Form1.cs) like IntendedPos

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Turn_based_MM2
{
    public partial class Form1 : Form
    {
        List<Map> maps;

        public Form1()
        {
            // w/e
            InitializeComponent();
            // changes pictureBox1 size (makes it so win10 doesn't mess with sizes)
            Size size = new Size(Constants.PLAYER_WIDTH, Constants.PLAYER_HEIGHT);
            pictureBox1.Size = size;
            // moves to top left    
            // Can change when loading map if required.
            // Seems like a good idea to implement before it's even needed
            Point pointBlank = new Point(0,0);
            pictureBox1.Location = pointBlank;
            // deletes background
            //pictureBox1.BackColor = Color.Transparent;

            //Load map file
            string execDirectory = GetExecLocation();
            string mapFilePath = Path.Combine(execDirectory, @"\Resources\Maps\Map1.txt");
            FileLoadMap(mapFilePath, out mapTiles);
            // so keys reach Form1 before they reach control; 
            this.KeyPreview = true;
            // Kviecia metoda handlindamas keyPress'a?      Seems so
            // kodel += ?
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);

            

        }


        /// <summary>
        /// Handles pressed key.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if 'A' or 'a'    ASCII decimal
            if (e.KeyChar == Constants.KEYCHAR_A_UPPERCASE || e.KeyChar == Constants.KEYCHAR_A_LOWERCASE)
            {
                //pictureBox1.Location.Offset(-25, 0); kodel neveikė?
                MovePictureBox(ref pictureBox1, -Constants.PIXELS_PER_MOVE, true);
            }   // 'D' or 'd'
            else if (e.KeyChar == Constants.KEYCHAR_D_UPPERCASE || e.KeyChar == Constants.KEYCHAR_D_LOWERCASE)
            {
                MovePictureBox(ref pictureBox1, Constants.PIXELS_PER_MOVE, true);
            }   // 'S' or 's'
            else if (e.KeyChar == Constants.KEYCHAR_S_UPPERCASE || e.KeyChar == Constants.KEYCHAR_S_LOWERCASE)
            {
                MovePictureBox(ref pictureBox1, Constants.PIXELS_PER_MOVE, false);
            }   // 'W' or 'w'
            else if (e.KeyChar == Constants.KEYCHAR_W_UPPERCASE || e.KeyChar == Constants.KEYCHAR_W_LOWERCASE)
            {
                MovePictureBox(ref pictureBox1, -Constants.PIXELS_PER_MOVE, false);
            }
            ////for test purposes 'H' or 'h'
            //else if (e.KeyChar == 72 || e.KeyChar == 104)
            //{
            //    //test
            //    // initializing PictureBox outside Form1
            //    InitializePictureBox();
            //}
        }
        [Obsolete("Used for testing.")]
        /// <summary>
        /// Displays passed string.
        /// </summary>
        /// <param name="display"></param>
        void Form1_CallMessageBox(string display)
        {
            MessageBox.Show(display);
        }
        [Obsolete("Used for testing.")]
        /// <summary>
        /// Displays passed char.
        /// </summary>
        /// <param name="display"></param>
        void Form1_CallMessageBox(char display)
        {
            MessageBox.Show(display.ToString());
        }
        /// <summary>
        /// Moves passed PictureBox the passed amount, x or y axis.
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="pixelsToMove"></param>
        /// <param name="xAxis"></param>
        void MovePictureBox(ref PictureBox pictureBox, int pixelsToMove, bool xAxis)
        {
            if (CanMove(pictureBox1, pixelsToMove, xAxis, mapTiles))
            {
                int x = pictureBox.Location.X;
                int y = pictureBox.Location.Y;
                if (xAxis)
                {
                    pictureBox.Location = new Point(x + pixelsToMove, y);
                }
                else
                {
                    pictureBox.Location = new Point(x, y + pixelsToMove);
                }
            }

        }
        /// <summary>
        /// Sets passed picBox position to passed x,y coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void MovePictureBox(ref PictureBox picBox, int x, int y)
        {
            picBox.Location = new Point(x * Constants.TILE_WIDTH, y * Constants.TILE_HEIGHT);
        }
        /// <summary>
        /// Checks if pictureBox can move where it's intending to.
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="pixelsToMove"></param>
        /// <param name="xAxis"></param>
        /// <returns></returns>
        bool CanMove(PictureBox pictureBox, int pixelsToMove, bool xAxis, MapTile[,] mapTiles)
        {
            // more logic in the future.

            return CanMoveWindowBoundary(pictureBox, pixelsToMove, xAxis) &&
                CanMoveMapTile(pictureBox.Location, pixelsToMove, xAxis);
        }

        // is this one hard to read?
        [Obsolete("Shouldn't be needed in the future.")]
        /// <summary>
        /// Figures out if pictureBox is moving inside the window.
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <returns></returns>
        bool CanMoveWindowBoundary(PictureBox pictureBox, int pixelsToMove, bool xAxis)
        {
            // grabs X or Y, whichever is relevant.
            int coordinateToCheck;
            if (xAxis)
            {
                coordinateToCheck = pictureBox.Location.X;
            }
            else
            {
                coordinateToCheck = pictureBox.Location.Y;
            }
            // calcs intended position.
            int intendedPos = coordinateToCheck + pixelsToMove;
            // checks if there's space to move.
            bool canMove;
            int lowerBoundary = 0;
            int higherBoundary = WindowBoundary(xAxis);
            if (lowerBoundary <= intendedPos && intendedPos <= higherBoundary)
            {
                canMove = true;
            }
            else
            {
                canMove = false;
            }
            return canMove;
        }
        /// <summary>
        /// Checks if intended tile to move to is available.
        /// </summary>
        /// <param name="currentLocation"></param>
        /// <param name="pixelsToMove"></param>
        /// <param name="xAxis"></param>
        /// <returns></returns>
        bool CanMoveMapTile(Point currentLocation, int pixelsToMove, bool xAxis)
        {
            Point intendedLocation;
            if (xAxis)
            {
                intendedLocation = new Point(currentLocation.X + pixelsToMove, currentLocation.Y);
            }
            else
            {
                intendedLocation = new Point(currentLocation.X, currentLocation.Y + pixelsToMove);
            }

            int intendedX = intendedLocation.X / Constants.TILE_WIDTH;
            int intendedY = intendedLocation.Y / Constants.TILE_HEIGHT;

            //map tile

            return mapTiles[intendedX, intendedY].Passable;
            // rewrite Player positioning ? While Player.Size == MapTile.Size it's ok.
        }
        /// <summary>
        /// Returns higher window boundary (window size) X or Y axis.
        /// </summary>
        /// <returns></returns>
        int WindowBoundary(bool xAxis)
        {
            if (xAxis)
            {
                return ClientRectangle.Width-pictureBox1.Size.Width;
            }
            else
            {
                return ClientRectangle.Bottom-pictureBox1.Size.Height;
            }
        }
        /// <summary>
        /// Loads Map from passed filePath.
        /// </summary>
        /// <param name="filePath"></param>
        void FileLoadMap(string filePath, out MapTile[,] mapTiles)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                // First file line: {xMapBoundary},{yMapBoundary} to initialize map size as a rectangle.
                // Second file line: {xPos},{yPos} to get starting Player Position.
                // Reads map size
                int xMapBoundary, yMapBoundary;
                FileGetMapSize(out xMapBoundary, out yMapBoundary, reader);
                // Reads starting Player Pos
                int xStartingPos, yStartingPos;
                FileGetStartingPlayerPos(out xStartingPos, out yStartingPos, reader);
                // Sets player position to starting one.
                MovePictureBox(ref pictureBox1, xStartingPos, yStartingPos);
                // Initializes MapTiles while file has readable lines.
                mapTiles = new MapTile[xMapBoundary, yMapBoundary];
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    // Expected MapTile format: {x coordinate},{y coordinate},
                    //  { bool Passable},{bool Plantable}
                    string[] tileInfo = line.Split(',');
                    DeclareMapTile(Convert.ToInt32(tileInfo[0]), Convert.ToInt32(tileInfo[1]),
                        Convert.ToBoolean(tileInfo[2]), Convert.ToBoolean(tileInfo[3]), mapTiles);
                }
            }

        }
        /// <summary>
        /// Gets map size from passed StreamReader.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="filePath"></param>
        void FileGetMapSize(out int x, out int y, StreamReader reader)
        {
            // ar be ref reader sugriztu i pirma eilute? test soon ^^
            // tas pats ir del FileGetStartingPlayerPos
            string[] mapInfo = reader.ReadLine().Split(',');
            x = Convert.ToInt32(mapInfo[0]);
            y = Convert.ToInt32(mapInfo[1]);

        }
        /// <summary>
        /// Gets starting Player Pos from passed StreamReader.
        /// </summary>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <param name="reader"></param>
        void FileGetStartingPlayerPos(out int xPos, out int yPos, StreamReader reader)
        {
            string[] mapInfo = reader.ReadLine().Split(',');
            xPos = Convert.ToInt32(mapInfo[0]);
            yPos = Convert.ToInt32(mapInfo[1]);
        }
        /// <summary>
        /// Initializes MapTile with passed parameters.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="passable"></param>
        /// <param name="plantable"></param>
        void DeclareMapTile(int x, int y, bool passable, bool plantable, MapTile[,] mapTiles)
        {
            mapTiles[x, y] = new MapTile(passable, plantable);
            mapTiles[x, y].SetPos(x, y);
            // gets needed filePath to image.
            string filePath = Path.Combine(GetExecLocation(), GetImageLocation(passable, plantable));
            // sets MapTile's PictureBox Image to it.
            mapTiles[x, y].SetImage(filePath);
            // adds declared MapTile's PictureBox to Controls.
            this.Controls.Add(mapTiles[x, y].PicBox);

            /* set image, logic for image (possbily more passed parameters to find texture)
             * Worked around this atm. Might add variables for a variety of textures.
             * Would make fileMap bigger and pass it to DeclareMapTile(), then MapTile.SetImage().
            */
        }
        /// <summary>
        /// Returns exec directory as a string.
        /// </summary>
        /// <returns></returns>
        string GetExecLocation()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
        /// <summary>
        /// Gets wanted image path. Intended to combine with execLocation.
        /// </summary>
        /// <param name="passable"></param>
        /// <param name="plantable"></param>
        /// <returns></returns>
        string GetImageLocation(bool passable, bool plantable)
        {
            if (passable)
            {
                if (plantable)
                {
                    return @"\Resources\plantable.png";
                }
                else
                {
                    return @"\Resources\path.png";
                }
            }
            else
            {
                return @"\Resources\wall.png";
            }
        }

        





        /// <summary>
        /// for testing purposes
        /// </summary>
        void TEST_InitializePictureBox()
        {
            // works!
            PictureBox[] picture = new PictureBox[3];
            picture[0] = new PictureBox();
            picture[0].Location = new Point(100, 100);
            picture[0].ImageLocation = @"C:\Dirbam\KCS\Pictures\Hexagon.png";
            this.Controls.Add(picture[0]);
            
        }


    }
}
