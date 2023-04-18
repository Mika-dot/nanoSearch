using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSmith.Settings
{
    static public class calculationFormula // Нютон
    {
        static public float[,] AStarSearch { get; set; } = { { 0, 0 }, { 1, 1 }, { 2, 2 }, { 3, 3 } };

        static public float[,] Height { get; set; } = { { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 1 } };

        static public float[,] Corner { get; set; } = { { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 1 } };

        static public float[,] Length { get; set; } = { { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 1 } };

        static public float[,] AngleOfRotation { get; set; } = { { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 1 } };

    }
}
