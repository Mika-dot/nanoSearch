using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agentMathematics
{
    class mathematics
    {
        public struct PointZ
        {
            public Point My, Your;

            public PointZ(Point My, Point Your)
            {
                this.My = My;
                this.Your = Your;
            }
        }

        public float? Range(float min, float max, float value)
        {
            if ((min < value) && (value < max)) return value;
            return null;
        }

        public float AnglePoint(Point a, Point b, Point c)
        {
            float x1 = a.X - b.X, x2 = c.X - b.X;
            float y1 = a.Y - b.Y, y2 = c.Y - b.Y;
            float d1 = MathF.Sqrt(x1 * x1 + y1 * y1);
            float d2 = MathF.Sqrt(x2 * x2 + y2 * y2);
            return (MathF.Acos((x1 * x2 + y1 * y2) / (d1 * d2)) * 180f) * MathF.PI;
        }

        public float Cos(PointZ cordinat, int height)
        {
            return (MathF.Acos(EuclideanDistance(cordinat) / height) * 180f) / MathF.PI;
        }
        public float EuclideanDistance(PointZ cordinat)
        {
            return MathF.Sqrt(MathF.Pow(cordinat.My.X - cordinat.Your.X, 2) + MathF.Pow(cordinat.My.Y - cordinat.Your.Y, 2));
        }
    }

}
