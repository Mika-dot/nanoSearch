using A_Star;
using A_Star.Core;
using System.Drawing;

namespace AgentSmith.Settings
{
    /// <summary>
    /// Оценка пограничных значений
    /// </summary>
    static public class Configuration
    {
        [Obsolete]
        static public int AltitudeMin { get; set; } = -10;// выстора критерий
        [Obsolete]
        static public int AltitudeMax { get; set; } = 10;

        [Obsolete]
        static public float CornerHeightsMin { get; set; } = -45;// угол критерий
        [Obsolete]
        static public float CornerHeightsMax { get; set; } = 45;

        [Obsolete]
        static public float LengthMax { get; set; } = 5;// максимальный длина

        [Obsolete]
        static public float CornerMin { get; set; } = 45;// минимальный угол

        [Obsolete]
        static public Point End { get; set; } = new Point(80, 50);

        static private int size = 2;
        static public int Size
        {
            get => size;
            set
            {
                Cof.DIRS = Mathematics.Resize(value);
                size = value;
            }
        }

        [Obsolete]
        static internal SquareGrid? grid { get; set; }

        static internal int[,] _map;

        [Obsolete]
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
