using System.Drawing;

namespace AgentSmith
{
    public class Mathematics
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
            float lenghtA = MathF.Sqrt(MathF.Pow(b.X - a.X, 2) + MathF.Pow(b.Y - a.Y, 2));
            float lenghtB = MathF.Sqrt(MathF.Pow(c.X - b.X, 2) + MathF.Pow(c.Y - b.Y, 2));
            float lenghtC = MathF.Sqrt(MathF.Pow(c.X - a.X, 2) + MathF.Pow(c.Y - a.Y, 2));

            float calc = ((lenghtA * lenghtA) + (lenghtB * lenghtB) - (lenghtC * lenghtC)) / (2 * lenghtA * lenghtB);
            return (float.IsNaN(calc)) ? 180f : MathF.Acos(calc) * 180f / MathF.PI;
        }

        public float Cos(PointZ cordinat, float height)
        {
            return (MathF.Atan(MathF.Abs(height) / EuclideanDistance(cordinat)) * 180f / MathF.PI);
        }
        public float EuclideanDistance(PointZ cordinat)
        {
            return MathF.Sqrt(MathF.Pow(cordinat.My.X - cordinat.Your.X, 2) + MathF.Pow(cordinat.My.Y - cordinat.Your.Y, 2));
        }

        public static float LagrangeInterpolation(float[] x, float[] y, float xval)
        {
            float yval = 0;
            float Products = y[0];
            for (int i = 0; i < x.Length; i++)
            {
                Products = y[i];
                for (int j = 0; j < x.Length; j++)
                {
                    if (i != j)
                    {
                        Products *= (xval - x[j]) / (x[i] - x[j]);
                    }
                }
                yval += Products;
            }
            return yval;
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

            //return Newton(value, method.GetLength(0), X, Y, step);
            return LagrangeInterpolation(X, Y, value);
        }

        public static Point[] Resize(int size)
        {
            Point[] points = new Point[size * 2 * 4];
            int j = 0;
            for (int i = 0; i < size * 2 + 1; i++, j += 2)
            {
                points[j] = new Point(0 - size, i - size);
                points[j + 1] = new Point(size * 2 - size, i - size);
            }
            for (int i = 1; i < size * 2; i++, j += 2)
            {
                points[j] = new Point(i - size, 0 - size);
                points[j + 1] = new Point(i - size, size * 2 - size);
            }
            return points;
        }
    }
}
