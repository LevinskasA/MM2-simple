using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_based_MM2
{
    public class Constants
    {
        // Sizes in pixels
        public const int PIXELS_PER_MOVE = 40;
        public const int PIXELS_PER_TILE = 40;
        public const int TILE_WIDTH = 40;
        public const int TILE_HEIGHT = 40;
        public const int PLAYER_WIDTH = 40;
        public const int PLAYER_HEIGHT = 40;
        // Keychar values
        public const int KEYCHAR_A_UPPERCASE = 65;
        public const int KEYCHAR_A_LOWERCASE = 97;
        public const int KEYCHAR_D_UPPERCASE = 68;
        public const int KEYCHAR_D_LOWERCASE = 100;
        public const int KEYCHAR_S_UPPERCASE = 83;
        public const int KEYCHAR_S_LOWERCASE = 115;
        public const int KEYCHAR_W_UPPERCASE = 87;
        public const int KEYCHAR_W_LOWERCASE = 119;
        // File paths
        public const string FILEPATH_MAP1 = @"\Resources\Maps\Map1.txt";
        public const string FILEPATH_HEXAGONGRASS = @"Resources\HexagonGrass.png";
        public const string FILEPATH_HEXAGONBLANK = @"Resources\HexagonBlank.png";
        public const string FILEPATH_HEXAGONPLANTABLE = @"Resources\HexagonPlantable.png";

    }
}
