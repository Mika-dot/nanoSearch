using A_Star.Core;
using AgentSmith.Settings;
using System.Drawing;

namespace AgentSmith
{
    /// <summary>
    /// Агент оценки хода точки (поиск лучшего направления из данной точки)
    /// </summary>
    public class Tuples
    {
        public static TupleMy AgentMorris(Point position, int i, int lengthMap, Gradient gradient, Point historyPosition)
        {
            Point offset = new Point(Cof.DIRS[i].X, Cof.DIRS[i].Y);
            Point res = new(position.X + offset.X, position.Y + offset.Y);
            if (res.X < 0 || res.Y < 0 || res.X >= lengthMap || res.Y >= lengthMap || !Configuration.Map[res.X, res.Y].HasValue) return new TupleMy(float.MaxValue, new bool[5]);
            (float value, bool[] flags) flres = gradient.GradientDescent(position, res, historyPosition);

            return new TupleMy(flres.value, flres.flags);
        }
    }

    /// <summary>
    /// Возвращаемый тип из таска. Значение клетки и массив нарушений у фильтров
    /// </summary>
    public class TupleMy
    {
        float value { get; set; }
        bool[] flags { get; set; }
        public TupleMy(float value, bool[] flags)
        {
            this.value = value;
            this.flags = flags;
        }

        public float Value()
        {
            return value;
        }
        public bool[] Flags()
        {
            return flags;
        }

        ~TupleMy() { }
    }
}
