﻿using A_Star.Core;
using System.Drawing;

namespace AgentSmith
{
    public class Tuples
    {
        public static TupleMy Steve(Point position, int i, int lengthMap, Gradient gradient, Point historyPosition)
        {
            Point offset = new Point(Cof.DIRS[i].X, Cof.DIRS[i].Y);
            Point res = new(position.X + offset.X, position.Y + offset.Y);
            if (res.X < 0 || res.Y < 0 || res.X >= lengthMap || res.Y >= lengthMap) ;
            (float value, bool[] flags) flres = gradient.GradientDescent(position, res, historyPosition);

            return new TupleMy(flres.value, flres.flags);
        }
    }
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
