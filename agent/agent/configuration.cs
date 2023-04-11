using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agentConfiguration
{
    static class configuration
    {
        static public int AltitudeMin { get; set; } = -10;// выстора критерий
        static public int AltitudeMax { get; set; } = 10;

        static public float CornerMin { get; set; } = -45;// угол критерий
        static public float CornerMax { get; set; } = 45;

        static public float lengthMax { get; set; } = 5;// максимальный длина

        static public float cornerMin { get; set; } = 45;// минимальный угол

        static public Point end { get; set; } = new Point(80, 50);

        static public SquareGrid? grid { get; set; } = new SquareGrid(Map.GetLength(0), Map.GetLength(0));

        static public int[,] Map;
    }

}
