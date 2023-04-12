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

        public (float, bool) Range(float min, float max, float value)
        {
            if ((min < value) && (value < max)) return (value, false);
            return (value, true);
        }
        public (int, bool) Range(float min, float max, int value)
        {
            if ((min < value) && (value < max)) return (value, false);
            return (value, true);
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

        private float Newton(float x, int n, float[] MasX, float[] MasY, float step)
        {
            float[,] mas = new float[n + 2, n + 1];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    if (i == 0)
                        mas[i, j] = MasX[j];
                    else if (i == 1)
                        mas[i, j] = MasY[j];
                }
            }
            int m = n;
            for (int i = 2; i < n + 2; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mas[i, j] = mas[i - 1, j + 1] - mas[i - 1, j];
                }
                m--;
            }

            float[] dy0 = new float[n + 1];

            for (int i = 0; i < n + 1; i++)
            {
                dy0[i] = mas[i + 1, 0];
            }

            float res = dy0[0];
            float[] xn = new float[n];
            xn[0] = x - mas[0, 0];

            for (int i = 1; i < n; i++)
            {
                float ans = xn[i - 1] * (x - mas[0, i]);
                xn[i] = ans;
                ans = 0;
            }

            int m1 = n + 1;
            int fact = 1;
            for (int i = 1; i < m1; i++)
            {
                fact = fact * i;
                res = res + (dy0[i] * xn[i - 1]) / (fact * MathF.Pow(step, i));
            }

            return res;
        }

        public float FunctionEvaluation(float value, float[,] method, float step = 1)
        {
            float[] X = new float[method.GetLength(0)];
            float[] Y = new float[method.GetLength(0)];
            for (int i = 0; i < method.GetLength(0); i++)
            {
                X[i] = method[i, 0];
                Y[i] = method[i, 1];
            }

            return Newton(value, method.GetLength(0), X, Y, step);
        }

        public static Point[] Resize(int size)
        {
            Point[] points = new Point[size * 2 * 4];
            for (int i = 0, j = 0; i < size * 2 + 1; i++, j+=4)
            {
                points[j] = new Point(0 - size, i - size);
                points[j + 1] = new Point(size * 2 + 1 - size, i - size);
                points[j + 2] = new Point(i - size, 0 - size);
                points[j + 3] = new Point(i - size, size * 2 + 1 - size);
            }
            return points;
        }
    }

}
