using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSmith.Settings
{
    /// <summary>
    /// Значения для нютоновсой ценки 
    /// </summary>
    static public class calculationFormula // Нютон
    {
        [Obsolete]
        static public float[,] AStarSearch { get; set; } = null;
        [Obsolete]
        static public float[,] Height { get; set; } = null;
        [Obsolete]
        static public float[,] Corner { get; set; } = null;
        [Obsolete]
        static public float[,] Length { get; set; } = null;
        [Obsolete]
        static public float[,] AngleOfRotation { get; set; } = null;

    }
}
