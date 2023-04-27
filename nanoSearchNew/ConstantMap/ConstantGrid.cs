using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nanoSearchNew.ConstantMap
{
    /// <summary>
    /// Обекты на карте
    /// </summary>
    public class ConstantGrid
    {
        static public float HeightMap { get; set; } = 1f;
        static public Type[] Road { get; set; } = { new Type(1, 1f), new Type(2, 2f), new Type(3, 3f), new Type(4, 3f) };
        static public Type[] Polygon { get; set; } = { new Type(1, 10), new Type(2, 20), new Type(3, 30) };
        static public Type[] Home { get; set; } = { new Type(1, 1f), new Type(2, 2f), new Type(3, 3f) };
        static public Type[] ElectroTowers { get; set; } = { new Type(1, 1f), new Type(2, 2f), new Type(3, 3f) };
        static public Type[] Gas { get; set; } = { new Type(1, 1f), new Type(2, 2f), new Type(3, 3f) };

    }

    public struct Type
    {
        public int TypeS { get; }
        public float Value { get; }
        public Type(int type, float value)
        {
            TypeS = type;
            Value = value;
        }
    }

}
