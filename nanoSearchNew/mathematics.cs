using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
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
            float lenghtA = MathF.Sqrt(MathF.Pow(b.X - a.X, 2) + MathF.Pow(b.Y - a.Y, 2));
            float lenghtB = MathF.Sqrt(MathF.Pow(c.X - b.X, 2) + MathF.Pow(c.Y - b.Y, 2));
            float lenghtC = MathF.Sqrt(MathF.Pow(c.X - a.X, 2) + MathF.Pow(c.Y - a.Y, 2));

            float calc = ((lenghtA * lenghtA) + (lenghtB * lenghtB) - (lenghtC * lenghtC)) / (2 * lenghtA * lenghtB);

            return MathF.Acos(calc) * 180f / MathF.PI;
            //float x1 = a.X - b.X, x2 = c.X - b.X;
            //float y1 = a.Y - b.Y, y2 = c.Y - b.Y;
            //float d1 = MathF.Sqrt(x1 * x1 + y1 * y1);
            //float d2 = MathF.Sqrt(x2 * x2 + y2 * y2);
            //return MathF.Acos((x1 * x2 + y1 * y2) / (d1 * d2));//) * 180f / MathF.PI;
            ////return (x1 * x2 + y1 * y2) / (d1 * d2);//MathF.Acos();
        }

        public float Cos(PointZ cordinat, int height)
        {
            //return (height == 0) ? 0 : ((MathF.Acos(EuclideanDistance(cordinat) / height) * 180f) / MathF.PI);
            //if (height < 0) height *= -1;
            return (MathF.Atan(MathF.Abs(height) / EuclideanDistance(cordinat)) * 180f / MathF.PI);
        }
        public float EuclideanDistance(PointZ cordinat)
        {
            return MathF.Sqrt(MathF.Pow(cordinat.My.X - cordinat.Your.X, 2) + MathF.Pow(cordinat.My.Y - cordinat.Your.Y, 2));
        }

        //private float Newton(float x, int n, float[] MasX, float[] MasY, float step)
        //{
        //    float[,] mas = new float[n + 2, n + 1];
        //    for (int i = 0; i < 2; i++)
        //    {
        //        for (int j = 0; j < n + 1; j++)
        //        {
        //            if (i == 0)
        //                mas[i, j] = MasX[j];
        //            else if (i == 1)
        //                mas[i, j] = MasY[j];
        //        }
        //    }
        //    int m = n;
        //    for (int i = 2; i < n + 2; i++)
        //    {
        //        for (int j = 0; j < m; j++)
        //        {
        //            mas[i, j] = mas[i - 1, j + 1] - mas[i - 1, j];
        //        }
        //        m--;
        //    }

        //    float[] dy0 = new float[n + 1];

        //    for (int i = 0; i < n + 1; i++)
        //    {
        //        dy0[i] = mas[i + 1, 0];
        //    }

        //    float res = dy0[0];
        //    float[] xn = new float[n];
        //    xn[0] = x - mas[0, 0];

        //    for (int i = 1; i < n; i++)
        //    {
        //        float ans = xn[i - 1] * (x - mas[0, i]);
        //        xn[i] = ans;
        //        ans = 0;
        //    }

        //    int m1 = n + 1;
        //    int fact = 1;
        //    for (int i = 1; i < m1; i++)
        //    {
        //        fact = fact * i;
        //        res = res + (dy0[i] * xn[i - 1]) / (fact * MathF.Pow(step, i));
        //    }

        //    return res;
        //}

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
            return value;//LagrangeInterpolation(X, Y, value);
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


    class PolygonS
    {
        private Point[] points; //вершины многоугольника
        private GraphicsPath path; //служит для отрисовки многоугольника
        private int minX, maxX, minY, maxY;

        public PolygonS(Vector2[] poin)
        {
            int[] points = new int[poin.Length * 2];

            for (int i = 0, j = 0; i < poin.Length; i++)
            {
                points[j] = (int)poin[i].X;
                points[j + 1] = (int)poin[i].Y;
                j += 2;
            }

            if (points.Length < 6 || points.Length % 2 == 1)
                throw new Exception();

            minX = minY = int.MaxValue;
            maxX = maxY = int.MinValue;

            this.points = new Point[points.Length / 2];
            for (int i = 0; i < points.Length; i += 2)
            {
                minX = Math.Min(minX, points[i]);
                maxX = Math.Max(maxX, points[i]);
                minY = Math.Min(minY, points[i + 1]);
                maxY = Math.Max(maxY, points[i + 1]);

                this.points[i / 2] = new Point(points[i], points[i + 1]);
            }

            path = new GraphicsPath();
        }

        public Point[] getPoints()
        {
            return points;
        }

        public void fill(Graphics g, SolidBrush brush, float translateX, float translateY, float scale) //отрисовка многоугольника в точке (translateX, translateY) и масштабом scale
        {
            path.Reset();

            float lastX = (points[0].X - minX) * scale + translateX;
            float lastY = (points[0].Y - minY) * scale + translateY;

            for (int i = 1; i < points.Length; i++)
            {
                float x = (points[i].X - minX) * scale + translateX;
                float y = (points[i].Y - minY) * scale + translateY;

                path.AddLine(lastX, lastY, x, y);

                lastX = x;
                lastY = y;
            }

            g.FillPath(brush, path);
        }

        private PointOverEdge classify(Point p, Point v, Point w) //положение точки p относительно отрезка vw
        {
            //коэффициенты уравнения прямой
            int a = v.Y - w.Y;
            int b = w.X - v.X;
            int c = v.X * w.Y - w.X * v.Y;

            //подставим точку в уравнение прямой
            int f = a * p.X + b * p.Y + c;
            if (f > 0)
                return PointOverEdge.RIGHT; //точка лежит справа от отрезка
            if (f < 0)
                return PointOverEdge.LEFT; //слева от отрезка

            int minX = Math.Min(v.X, w.X);
            int maxX = Math.Max(v.X, w.X);
            int minY = Math.Min(v.Y, w.Y);
            int maxY = Math.Max(v.Y, w.Y);

            if (minX <= p.X && p.X <= maxX && minY <= p.Y && p.Y <= maxY)
                return PointOverEdge.BETWEEN; //точка лежит на отрезке
            return PointOverEdge.OUTSIDE; //точка лежит на прямой, но не на отрезке
        }

        private EdgeType edgeType(Point a, Point v, Point w) //тип ребра vw для точки a
        {
            switch (classify(a, v, w))
            {
                case PointOverEdge.LEFT:
                    return ((v.Y < a.Y) && (a.Y <= w.Y)) ? EdgeType.CROSSING : EdgeType.INESSENTIAL;
                case PointOverEdge.RIGHT:
                    return ((w.Y < a.Y) && (a.Y <= v.Y)) ? EdgeType.CROSSING : EdgeType.INESSENTIAL;
                case PointOverEdge.BETWEEN:
                    return EdgeType.TOUCHING;
                default:
                    return EdgeType.INESSENTIAL;
            }
        }

        public PointInPolygon pointInPolygon(Point a) //положение точки в многоугольнике
        {
            bool parity = true;
            for (int i = 0; i < points.Length; i++)
            {
                Point v = points[i];
                Point w = points[(i + 1) % points.Length];

                switch (edgeType(a, v, w))
                {
                    case EdgeType.TOUCHING:
                        return PointInPolygon.BOUNDARY;
                    case EdgeType.CROSSING:
                        parity = !parity;
                        break;
                }
            }

            return parity ? PointInPolygon.OUTSIDE : PointInPolygon.INSIDE;
        }

        public int MinX()
        {
            return minX;
        }

        public int MaxX()
        {
            return maxX;
        }

        public int MinY()
        {
            return minY;
        }

        public int MaxY()
        {
            return maxY;
        }

        public int width() //ширина
        {
            return maxX - minX;
        }

        public int height() //высота
        {
            return maxY - minY;
        }

        public enum PointInPolygon { INSIDE, OUTSIDE, BOUNDARY } //положение точки в многоугольнике

        private enum EdgeType { TOUCHING, CROSSING, INESSENTIAL } //положение ребра

        private enum PointOverEdge { LEFT, RIGHT, BETWEEN, OUTSIDE } //положение точки относительно отрезка

    }

}
