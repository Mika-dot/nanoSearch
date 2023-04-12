using agentAStar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agentCalculationFormula
{
    static class calculationFormula // Нютон
    {
        static public float[,] AStarSearch { get; set; } = { { 0, 0 }, { 1, 1 }, { 2, 2 }, { 3, 3 } };

        static public float[,] Height { get; set; } = { { 0, 0 }, { 1, 1 }, { 2, 2 }, { 3, 3 } };

        static public float[,] Corner { get; set; } = { { 0, 0 }, { 1, 1 }, { 2, 2 }, { 3, 3 } };

        static public float[,] Length { get; set; } = { { 0, 0 }, { 1, 1 }, { 2, 2 }, { 3, 3 } };

        static public float[,] AngleOfRotation { get; set; } = { { 0, 0 }, { 1, 1 }, { 2, 2 }, { 3, 3 } };

    }
}
