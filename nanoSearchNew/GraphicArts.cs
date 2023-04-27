using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GraphicArts
{
    public class Model
    {
        public static Model[] Houses;

        public Model StlOutputOBJ(OpenGL gl)
        {

            gl.Color(color[0], color[1], color[2]);
            for (int i = 0; i < Vertexes.Count; i += 3)
            {
                gl.Begin(OpenGL.GL_TRIANGLES);
                gl.Vertex(Vertexes[i + 0].X, Vertexes[i + 0].Y, Vertexes[i + 0].Z);
                gl.Vertex(Vertexes[i + 1].X, Vertexes[i + 1].Y, Vertexes[i + 1].Z);
                gl.Vertex(Vertexes[i + 2].X, Vertexes[i + 2].Y, Vertexes[i + 2].Z);
                gl.Vertex(Vertexes[i + 2].X, Vertexes[i + 2].Y, Vertexes[i + 2].Z);
                gl.End();
            }
            return this;
        }

        public List<Triangle> triangle = new List<Triangle>();
        public List<Vector3> Vertexes = new List<Vector3>();

        public float[] color = new float[3];

        public void coler(float[] colar)
        {
            //цвет
            this.color = colar;
        }

        public Model Transformation(float size, Vector3 corner, Vector3 position, float[] colar)
        {
            //матрица масштабирования
            var scaleM = Matrix4x4.CreateScale(size);
            //матрица вращения
            var rotateM = Matrix4x4.CreateFromYawPitchRoll(corner.X, corner.Y, corner.Z);
            //матрица переноса
            var translateM = Matrix4x4.CreateTranslation(position);
            //результирующая матрица
            var m = scaleM * rotateM * translateM;// * paneXY;

            //умножаем вектора на матрицу
            Vertexes = Vertexes.Select(v => Vector3.Transform(v, m)).ToList();

            //цвет
            this.color = colar;
            return this;
        }

        public Model LoadFromObj(TextReader tr)
        {
            string line;

            while ((line = tr.ReadLine()) != null)
            {
                var parts1 = line.Split(' ');
                if (parts1.Length == 0) continue;
                if (parts1.Length == 12 && parts1[6] == "vertex")
                {
                    var parts2 = tr.ReadLine().Split(' ');
                    var parts3 = tr.ReadLine().Split(' ');

                    triangle.Add(new Triangle(
                    new Vector3(float.Parse(parts1[9], CultureInfo.InvariantCulture),
                    float.Parse(parts1[10], CultureInfo.InvariantCulture),
                    float.Parse(parts1[11], CultureInfo.InvariantCulture)),

                    new Vector3(float.Parse(parts2[9], CultureInfo.InvariantCulture),
                    float.Parse(parts2[10], CultureInfo.InvariantCulture),
                    float.Parse(parts2[11], CultureInfo.InvariantCulture)),

                    new Vector3(float.Parse(parts3[9], CultureInfo.InvariantCulture),
                    float.Parse(parts3[10], CultureInfo.InvariantCulture),
                    float.Parse(parts3[11], CultureInfo.InvariantCulture))
                    )
                    );

                    Vertexes.Add(new Vector3(float.Parse(parts1[9], CultureInfo.InvariantCulture),
                    float.Parse(parts1[10], CultureInfo.InvariantCulture),
                    float.Parse(parts1[11], CultureInfo.InvariantCulture)));

                    Vertexes.Add(new Vector3(float.Parse(parts2[9], CultureInfo.InvariantCulture),
                    float.Parse(parts2[10], CultureInfo.InvariantCulture),
                    float.Parse(parts2[11], CultureInfo.InvariantCulture)));

                    Vertexes.Add(new Vector3(float.Parse(parts3[9], CultureInfo.InvariantCulture),
                    float.Parse(parts3[10], CultureInfo.InvariantCulture),
                    float.Parse(parts3[11], CultureInfo.InvariantCulture)));
                }
            }
            return this;
        }

        public struct Triangle
        {
            public Vector3 p1, p2, p3;

            public Triangle(Vector3 P1, Vector3 P2, Vector3 P3)
            {
                p1 = P1;
                p2 = P2;
                p3 = P3;
            }
        }

    }

    public class PolygonS
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
