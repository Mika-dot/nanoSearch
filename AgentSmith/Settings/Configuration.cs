using A_Star;
using A_Star.Core;
using System.Drawing;

namespace AgentSmith.Settings
{
    static public class Configuration
    {
        static public int AltitudeMin { get; set; } = -10;// выстора критерий
        static public int AltitudeMax { get; set; } = 10;

        static public float CornerHeightsMin { get; set; } = -45;// угол критерий
        static public float CornerHeightsMax { get; set; } = 45;

        static public float LengthMax { get; set; } = 5;// максимальный длина

        static public float CornerMin { get; set; } = 45;// минимальный угол

        static public Point End { get; set; } = new Point(80, 50);

        static private int size;
        static public int Size
        {
            get => size;
            set
            {
                Cof.DIRS = Mathematics.Resize(value);
                size = value;
            }
        }

        static internal SquareGrid? grid { get; set; }

        static internal int[,] _map;
        static public int[,] Map
        {
            get => _map;
            set
            {
                _map = value;
                grid = new SquareGrid(_map.GetLength(0), _map.GetLength(0));
            }
        }
    }
}
