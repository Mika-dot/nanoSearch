using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSmith.Settings
{
    /// <summary>
    /// Кофиценты значимости
    /// </summary>
    static public class Coefficient
    {
        [Obsolete]
        static public float AStarSearch { get; set; } = 0;
        [Obsolete]
        static public float Height { get; set; } = 0;
        [Obsolete]
        static public float Corner { get; set; } = 0;
        [Obsolete]
        static public float Length { get; set; } = 0;
        [Obsolete]
        static public float AngleOfRotation { get; set; } = 0;

    }
}
