using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turn_based_MM2
{
    class EnemyBasic
    {
        public PictureBox PictureBox { get; set; }
        public Tuple<int, int>[] MovementTiles { get; private set; }
        bool ReverseMovement = false;

        public EnemyBasic()
        {
            PictureBox.Image = Image.FromFile(Constants.FILEPATH_ENEMY_HEXAGON_BASIC_GRASS);
        }
        /// <summary>
        /// Sets movement logic for enemy.
        /// </summary>
        /// <param name="tilesAmount"></param>
        /// <param name="tuples"></param>
        public void setMovementLogic(int tilesAmount, Tuple<int, int>[] tuples)
        {
            MovementTiles = new Tuple<int, int>[tilesAmount];
            for (int i = 0; i < tilesAmount; i++)
            {
                MovementTiles[i] = tuples[i];
            }
            // Shows enemy after movement logic is set.
            PictureBox.Location = Services.ConvertTupleToPoint(MovementTiles[0]);
        }
        /// <summary>
        /// Executes a movement tick for given enemy.
        /// </summary>
        public void movementTick() {

        }

    }
}
