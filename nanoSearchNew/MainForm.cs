using SharpGL;
using SharpGL.SceneGraph.Raytracing;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Security.Cryptography;
using Newtonsoft.Json;
using agentMathematics;
using SharpGL.SceneGraph.Primitives;

namespace nanoSearchNew
{
    public partial class MainForm : Form
    {
        #region "Данные"
        float AngleX = 0, AngleY = 0;
        double POSX = 2, POSY = 5, POSZ = 10;

        const float Rad = 3.14f / 180f;

        public WorldStruct DATA;
        int xC = 0;//Количество точек по х
        int zC = 0;//Количество точек по y
        int[,] points;//массив высот, 
        public static int[,] newPoints;//массив высот,
        List<Point> FinalPoints = new List<Point>();
        bool Writen = false;
        private int maxHeightMap = 100;//максимальная высота гор с 
        float[] dimensions = new float[3] { 3.9f, 3.9f, 3.9f };
        bool b = false;
        int lX = -1, lY = -1;
        const int SCALE = 5;
        const int STEP = 6;

        private PolygonS polygon;

        public struct House
        {
            public Vector2 Pos;
            public Vector3 Size;
            public float Angle;
        }
        public struct Polygon
        {
            public byte Type;
            public Vector2[] Points;
        }
        public struct Road
        {
            public Vector3 Start, End;
            public float Width;
        }
        public struct LEP
        {
            public Vector2 Pos;
            public int[] Connections;
            public float Height;
        }
        public struct WorldStruct
        {
            public House[] Houses;
            public Polygon[] Polygons;
            public LEP[] LEPs;
            public LEP[] GASs;
            public Road[] RoadsSHCO;
            public Road[] RoadsASPHALT;
            public Road[] RoadsGROUND;
            public Road[] Rivers;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            //LoadDATA();
            var bmp = new Bitmap("1.png", true);//Берем изображение шума из ресурсов
            xC = bmp.Width;
            zC = bmp.Height;
            points = new int[xC, zC];
            for (int i = 0; i < xC; i++)
                for (int j = 0; j < zC; j++)
                {
                    points[i, j] = (int)(bmp.GetPixel(i, j).GetBrightness() * maxHeightMap);//Генерируем карту высот по яркости пикселем
                }
            OpenGL gl = openglControl1.OpenGL;
            //gl.Enable(OpenGL.GL_CULL_FACE);
            gl.Enable(OpenGL.GL_DEPTH_TEST);
            LoadDATA();

            newPoints = new int[xC, zC];
            for (int i = 0; i < xC; i++)
                for (int j = 0; j < zC; j++)
                    newPoints[i, j] = 0;//points[i, j];
        }

        public void LoadDATA()
        {
            if (!File.Exists("DATA.json")) SaveDATA();
            DATA = JsonConvert.DeserializeObject<WorldStruct>(File.ReadAllText("DATA.json"));
            //for (int i = 0; i < DATA.RoadsSHCO.Length; i++)
            //{
            //    var start = DATA.RoadsSHCO[i].Start;
            //    var end = DATA.RoadsSHCO[i].End;
            //    MessageBox.Show(points[(int)start.X, (int)start.Y] + " " + points[(int)end.X, (int)end.Y]);
            //}
        }
        public void SaveDATA()
        {
            if (DATA.Houses == null) DATA.Houses = new House[1];
            if (DATA.RoadsSHCO == null) DATA.RoadsSHCO = new Road[1];
            if (DATA.RoadsASPHALT == null) DATA.RoadsASPHALT = new Road[1];
            if (DATA.RoadsGROUND == null) DATA.RoadsGROUND = new Road[1];
            if (DATA.Rivers == null) DATA.Rivers = new Road[1];
            if (DATA.LEPs == null)
            {
                DATA.LEPs = new LEP[1];
                DATA.LEPs[0].Connections = new int[0];
            }
            if (DATA.GASs == null)
            {
                DATA.GASs = new LEP[1];
                DATA.GASs[0].Connections = new int[0];
            }
            if (DATA.Polygons == null)
            {
                DATA.Polygons = new Polygon[1];
                DATA.Polygons[0].Points = new Vector2[1];
            }
            File.WriteAllText("DATA.json", JsonConvert.SerializeObject(DATA));
        }
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        #region "Отрисовка"
        private void openglControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            //  Возьмём OpenGL объект
            OpenGL gl = openglControl1.OpenGL;

            //  Очищаем буфер цвета и глубины
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //  Загружаем единичную матрицу
            gl.LoadIdentity();

            // Сдвигаем перо вправо от центра и вглубь экрана, но уже дальше
            gl.Translate(0.0f, 0.0f, 0.0f);

            // 1. Карта
            for (int x = 0; x < xC - 1; x++)
            {
                for (int z = 0; z < zC - 1; z++)
                {
                    var xZo = x * SCALE;
                    var zZo = z * SCALE;

                    gl.Begin(OpenGL.GL_TRIANGLES);

                    setColor(points[x, z], gl);
                    gl.Vertex(xZo, points[x, z], zZo);
                    setColor(points[x + 1, z], gl);
                    gl.Vertex(xZo + SCALE, points[x + 1, z], zZo);
                    setColor(points[x, z + 1], gl);
                    gl.Vertex(xZo, points[x, z + 1], zZo + SCALE);
                    gl.End();

                    gl.Begin(OpenGL.GL_TRIANGLES);
                    setColor(points[x + 1, z], gl);
                    gl.Vertex(xZo + SCALE, points[x + 1, z], zZo);
                    setColor(points[x + 1, z + 1], gl);
                    gl.Vertex(xZo + SCALE, points[x + 1, z + 1], zZo + SCALE);
                    setColor(points[x, z + 1], gl);
                    gl.Vertex(xZo, points[x, z + 1], zZo + SCALE);
                    gl.End();

                    if (!Writen)
                    {
                        newPoints[x, z] = points[x, z] * Convert.ToInt32(textBox1.Text);
                    }

                }
            }

            // 2. Полигоны, это границы
            for (int i = 0; i < DATA.Polygons.Length; i++)
            {
                var type = DATA.Polygons[i].Type;
                var ps = DATA.Polygons[i].Points;
                for (int j = 0; j < ps.Length; j++)
                {
                    var v = j + 1;
                    if (v == ps.Length) v = 0;
                    gl.Begin(OpenGL.GL_LINES);
                    switch (type)
                    {
                        case 0: { gl.Color(0, 1.0, 0); break; }
                        case 1: { gl.Color(0, 0.5, 0); break; }
                        default: { gl.Color(0, 0, 0); break; }
                    }
                    gl.Vertex(ps[j].X * SCALE, points[(int)ps[j].X, (int)ps[j].Y] + 1, ps[j].Y * SCALE);
                    gl.Vertex(ps[v].X * SCALE, points[(int)ps[v].X, (int)ps[v].Y] + 1, ps[v].Y * SCALE);
                    gl.End();

                    int x_min = (int)ps.Min(N => N.X);
                    int x_max = (int)ps.Max(N => N.X);

                    int y_min = (int)ps.Min(N => N.Y);
                    int y_max = (int)ps.Max(N => N.Y);

                    polygon = new PolygonS(ps);

                    if (!Writen)
                    {
                        for (int X = x_min; X < x_max; X++)
                        {
                            for (int Y = y_min; Y < y_max; Y++)
                            {
                                if (touch(polygon, new Point(X, Y)))
                                {
                                    newPoints[X, Y] += Convert.ToInt32(textBox2.Text);
                                }
                            }
                        }
                    }

                    if (type == 0 || type == 1)
                    {
                        for (int X = x_min; X < x_max; X += STEP)
                        {
                            for (int Y = y_min; Y < y_max; Y += STEP)
                            {
                                if (touch(polygon, new Point(X, Y)))
                                {
                                    tree(gl, new float[] { X * SCALE, points[X, Y], Y * SCALE }, dimensions, 3 + type * 2, 3 + type * 2);
                                }
                            }
                        }
                    }

                }
            }

            // 3. ЛЭПы
            for (int i = 0; i < DATA.LEPs.Length; i++)
            {
                var lep = DATA.LEPs[i];
                var h = lep.Height;
                var ps = lep.Pos;
                DrawLEP(gl, 0.25f, h, new float[] { 0.0f, 0.0f, 0.0f }, ps.X * SCALE, points[(int)ps.X, (int)ps.Y], ps.Y * SCALE);
                for (int j = 0; j < lep.Connections.Length; j++)
                {
                    var ps2 = DATA.LEPs[lep.Connections[j]].Pos;
                    var h2 = DATA.LEPs[lep.Connections[j]].Height;
                    gl.Begin(OpenGL.GL_LINES);
                    gl.Color(0, 0, 0);
                    gl.Vertex(ps.X * SCALE, points[(int)ps.X, (int)ps.Y] + h, ps.Y * SCALE);
                    gl.Vertex(ps2.X * SCALE, points[(int)ps2.X, (int)ps2.Y] + h2, ps2.Y * SCALE);
                    gl.End();
                }
            }

            // 4. Домики
            for (int i = 0; i < DATA.Houses.Length; i++)
            {
                var hous = DATA.Houses[i];
                var ps = hous.Pos;
                var coordinates = new float[] { ps.X * SCALE, points[(int)ps.X, (int)ps.Y], ps.Y * SCALE };
                var sz = hous.Size;
                var dimensions = new float[] { sz.X, sz.Y, sz.Z };
                // рисуем дом
                HOUSE(gl, coordinates, dimensions, 1, hous.Angle);

                var pss = new Vector2[]
                {
                    new Vector2(ps.X * SCALE + sz.X, ps.Y * SCALE + sz.Y),
                    new Vector2(ps.X * SCALE - sz.X, ps.Y * SCALE + sz.Y),
                    new Vector2(ps.X * SCALE + sz.X, ps.Y * SCALE - sz.Y),
                    new Vector2(ps.X * SCALE - sz.X, ps.Y * SCALE - sz.Y)
                };
                polygon = new PolygonS(pss);

                int x_min = (int)pss.Min(N => N.X);
                int x_max = (int)pss.Max(N => N.X);
                int y_min = (int)pss.Min(N => N.Y);
                int y_max = (int)pss.Max(N => N.Y);

                if (!Writen)
                {
                    for (int X = x_min; X < x_max; X++)
                    {
                        for (int Y = y_min; Y < y_max; Y++)
                        {
                            if (touch(polygon, new Point(X, Y)))
                            {
                                newPoints[X / SCALE, Y / SCALE] += Convert.ToInt32(textBox3.Text);
                            }
                        }
                    }
                }



                //if (!Writen)
                //{
                //    newPoints[(int)ps.X, (int)ps.Y] += 100;
                //}
            }

            // SCALE. ГАЗы
            for (int i = 0; i < DATA.GASs.Length; i++)
            {
                var lep = DATA.GASs[i];
                var h = lep.Height;
                var ps = lep.Pos;
                DrawLEP(gl, 0.25f, h, new float[] { 1.0f, 1.0f, 0.0f }, ps.X * SCALE, points[(int)ps.X, (int)ps.Y] - h, ps.Y * SCALE);
                for (int j = 0; j < lep.Connections.Length; j++)
                {
                    var ps2 = DATA.GASs[lep.Connections[j]].Pos;
                    var h2 = DATA.GASs[lep.Connections[j]].Height;
                    gl.Begin(OpenGL.GL_LINES);
                    gl.Color(1.0, 1.0, 0);
                    gl.Vertex(ps.X * SCALE, points[(int)ps.X, (int)ps.Y] - h, ps.Y * SCALE);
                    gl.Vertex(ps2.X * SCALE, points[(int)ps2.X, (int)ps2.Y] - h2, ps2.Y * SCALE);
                    gl.End();
                }
            }

            // 6. Дороги шоссе
            for (int i = 0; i < DATA.RoadsSHCO.Length; i++)
            {
                var road = DATA.RoadsSHCO[i];
                var start = road.Start;
                var end = road.End;
                var angle = (Math.Atan2(end.Y - start.Y, end.X - start.X) * 180f / Math.PI - 90f) * Math.PI / 180.0;
                var offset = new Vector2((float)(road.Width * Math.Cos(angle)), (float)(road.Width * Math.Sin(angle)));
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(1.0, 0.0, 0.0);
                gl.Vertex(start.X * SCALE - offset.X, start.Z, start.Y * SCALE - offset.Y);
                gl.Vertex(start.X * SCALE + offset.X, start.Z, start.Y * SCALE + offset.Y);
                gl.Vertex(end.X * SCALE + offset.X, end.Z, end.Y * SCALE + offset.Y);
                gl.Vertex(end.X * SCALE - offset.X, end.Z, end.Y * SCALE - offset.Y);
                gl.End();

                var ps = new Vector2[]
                {
                    new Vector2(start.X * SCALE - offset.X, start.Y * SCALE - offset.Y),
                    new Vector2(start.X * SCALE + offset.X, start.Y * SCALE + offset.Y),
                    new Vector2(end.X * SCALE + offset.X, end.Y * SCALE + offset.Y),
                    new Vector2(end.X * SCALE - offset.X, end.Y * SCALE - offset.Y)
                };

                polygon = new PolygonS(ps);

                int x_min = (int)ps.Min(N => N.X);
                int x_max = (int)ps.Max(N => N.X);

                int y_min = (int)ps.Min(N => N.Y);
                int y_max = (int)ps.Max(N => N.Y);

                for (int X = x_min; X < x_max; X++)
                {
                    for (int Y = y_min; Y < y_max; Y++)
                    {
                        if (touch(polygon, new Point(X, Y)))
                        {
                            //points[X / SCALE, Y / SCALE] = (int)Math.Min(start.Z, end.Z);
                            if (!Writen) newPoints[X / SCALE, Y / SCALE] += Convert.ToInt32(textBox4.Text);
                        }
                    }
                }
            }

            // 6. Дороги асфальт
            for (int i = 0; i < DATA.RoadsASPHALT.Length; i++)
            {
                var road = DATA.RoadsASPHALT[i];
                var start = road.Start;
                var end = road.End;
                var angle = (Math.Atan2(end.Y - start.Y, end.X - start.X) * 180f / Math.PI - 90f) * Math.PI / 180.0;
                var offset = new Vector2((float)(road.Width * Math.Cos(angle)), (float)(road.Width * Math.Sin(angle)));

                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(1.0, 0.4, 0.0);
                gl.Vertex(start.X * SCALE - offset.X, points[(int)start.X, (int)start.Y], start.Y * SCALE - offset.Y);
                gl.Vertex(start.X * SCALE + offset.X, points[(int)start.X, (int)start.Y], start.Y * SCALE + offset.Y);
                gl.Vertex(end.X * SCALE + offset.X, points[(int)end.X, (int)end.Y], end.Y * SCALE + offset.Y);
                gl.Vertex(end.X * SCALE - offset.X, points[(int)end.X, (int)end.Y], end.Y * SCALE - offset.Y);
                gl.End();

                if (!Writen)
                {
                    var ps = new Vector2[]
                    {
                    new Vector2(start.X * SCALE - offset.X, start.Y * SCALE - offset.Y),
                    new Vector2(start.X * SCALE + offset.X, start.Y * SCALE + offset.Y),
                    new Vector2(end.X * SCALE + offset.X, end.Y * SCALE + offset.Y),
                    new Vector2(end.X * SCALE - offset.X, end.Y * SCALE - offset.Y)
                    };

                    polygon = new PolygonS(ps);

                    int x_min = (int)ps.Min(N => N.X);
                    int x_max = (int)ps.Max(N => N.X);

                    int y_min = (int)ps.Min(N => N.Y);
                    int y_max = (int)ps.Max(N => N.Y);

                    for (int X = x_min; X < x_max; X++)
                    {
                        for (int Y = y_min; Y < y_max; Y++)
                        {
                            if (touch(polygon, new Point(X, Y)))
                            {
                                newPoints[X / SCALE, Y / SCALE] += Convert.ToInt32(textBox5.Text);
                            }
                        }
                    }
                }
            }

            // 6. Дороги грунт
            for (int i = 0; i < DATA.RoadsGROUND.Length; i++)
            {
                var road = DATA.RoadsGROUND[i];
                var start = road.Start;
                var end = road.End;
                var angle = (Math.Atan2(end.Y - start.Y, end.X - start.X) * 180f / Math.PI - 90f) * Math.PI / 180.0;
                var offset = new Vector2((float)(road.Width * Math.Cos(angle)), (float)(road.Width * Math.Sin(angle)));

                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(0.5, 0.28, 0.0);
                gl.Vertex(start.X * SCALE - offset.X, points[(int)start.X, (int)start.Y], start.Y * SCALE - offset.Y);
                gl.Vertex(start.X * SCALE + offset.X, points[(int)start.X, (int)start.Y], start.Y * SCALE + offset.Y);
                gl.Vertex(end.X * SCALE + offset.X, points[(int)end.X, (int)end.Y], end.Y * SCALE + offset.Y);
                gl.Vertex(end.X * SCALE - offset.X, points[(int)end.X, (int)end.Y], end.Y * SCALE - offset.Y);
                gl.End();

                if (!Writen)
                {
                    var ps = new Vector2[]
                    {
                    new Vector2(start.X * SCALE - offset.X, start.Y * SCALE - offset.Y),
                    new Vector2(start.X * SCALE + offset.X, start.Y * SCALE + offset.Y),
                    new Vector2(end.X * SCALE + offset.X, end.Y * SCALE + offset.Y),
                    new Vector2(end.X * SCALE - offset.X, end.Y * SCALE - offset.Y)
                    };

                    polygon = new PolygonS(ps);

                    int x_min = (int)ps.Min(N => N.X);
                    int x_max = (int)ps.Max(N => N.X);

                    int y_min = (int)ps.Min(N => N.Y);
                    int y_max = (int)ps.Max(N => N.Y);

                    for (int X = x_min; X < x_max; X++)
                    {
                        for (int Y = y_min; Y < y_max; Y++)
                        {
                            if (touch(polygon, new Point(X, Y)))
                            {
                                newPoints[X / SCALE, Y / SCALE] += Convert.ToInt32(textBox6.Text);
                            }
                        }
                    }
                }
            }

            // 7. Реки
            for (int i = 0; i < DATA.Rivers.Length; i++)
            {
                var road = DATA.Rivers[i];
                var start = road.Start;
                var end = road.End;
                var angle = (Math.Atan2(end.Y - start.Y, end.X - start.X) * 180f / Math.PI - 90f) * Math.PI / 180.0;
                var offset = new Vector2((float)(road.Width * Math.Cos(angle)), (float)(road.Width * Math.Sin(angle)));

                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(0.0, 0.0, 1.0);
                gl.Vertex(start.X * SCALE - offset.X, start.Z, start.Y * SCALE - offset.Y);
                gl.Vertex(start.X * SCALE + offset.X, start.Z, start.Y * SCALE + offset.Y);
                gl.Vertex(end.X * SCALE + offset.X, end.Z, end.Y * SCALE + offset.Y);
                gl.Vertex(end.X * SCALE - offset.X, end.Z, end.Y * SCALE - offset.Y);
                gl.End();


                if (!Writen)
                {
                    var ps = new Vector2[]
                    {
                    new Vector2(start.X * SCALE - offset.X, start.Y * SCALE - offset.Y),
                    new Vector2(start.X * SCALE + offset.X, start.Y * SCALE + offset.Y),
                    new Vector2(end.X * SCALE + offset.X, end.Y * SCALE + offset.Y),
                    new Vector2(end.X * SCALE - offset.X, end.Y * SCALE - offset.Y)
                    };

                    polygon = new PolygonS(ps);

                    int x_min = (int)ps.Min(N => N.X);
                    int x_max = (int)ps.Max(N => N.X);

                    int y_min = (int)ps.Min(N => N.Y);
                    int y_max = (int)ps.Max(N => N.Y);

                    for (int X = x_min; X < x_max; X++)
                    {
                        for (int Y = y_min; Y < y_max; Y++)
                        {

                            if (touch(polygon, new Point(X, Y)) && points[X / SCALE, Y / SCALE] < Math.Max(start.Z, end.Z)) //  
                            {
                                newPoints[X / SCALE, Y / SCALE] += Convert.ToInt32(textBox7.Text);
                            }
                        }
                    }
                }
            }

            // Контроль полной отрисовки следующего изображения
            gl.Flush();

            if (!Writen)
            {

                var newbp = new Bitmap(xC, zC);
                int max = newPoints.Cast<int>().Max();
                for (int i = 0; i < xC; i++)
                    for (int j = 0; j < zC; j++)
                    {
                        int rgb = max == 0 ? 0 : (int)(255f * newPoints[i, j] / max);
                        newbp.SetPixel(i, j, Color.FromArgb(rgb, rgb, rgb));
                    }

                agentCoefficient.coefficient.AStarSearch = 1;
                agentCoefficient.coefficient.Height = 0;
                agentCoefficient.coefficient.Length = 0;
                agentCoefficient.coefficient.AngleOfRotation = 0;
                agentCoefficient.coefficient.Corner = 0;
                agentConfiguration.configuration.Size = 1;
                var start = new Point(4, 10);
                var curr = start;
                //curr.Y++;
                var end = new Point(80, 50);
                var agent = new agent(newPoints); // Создаём агента
                FinalPoints.Clear();
                FinalPoints.Add(start);
                FinalPoints.Add(curr);
                var grid = new agentAStar.SquareGrid(xC, zC);
                while (curr != end)// || agentAStar.AStarSearch.Heuristic(curr, end) <= agentConfiguration.configuration.Size * 2
                {
                    var res_here = agent.AgentActions(curr, start);

                    var grid2 = new agentAStar.SquareGrid(xC, zC);
                    var astar = new agentAStar.AStarSearch(grid2, res_here.Item1, end);

                    var p = end;
                    while (p != res_here.Item1)
                    {
                        newbp.SetPixel(p.X, p.Y, Color.FromArgb(255, 0, 255));
                        FinalPoints.Add(p);
                        p = astar.cameFrom[p];
                    }
                    newbp.SetPixel(p.X, p.Y, Color.FromArgb(255, 0, 255));
                    FinalPoints.Add(p);

                    start = curr; // Текущая стала предыдущей
                    curr = res_here.Item1; // В текущую записан результат
                    newbp.SetPixel(curr.X, curr.Y, Color.FromArgb(255, 0, 0)); // Помечаем белым
                    //FinalPoints.Add(curr);
                }

                //start = new Point(4, 10);
                //var grid = new agentAStar.SquareGrid(xC, zC);
                //var astar = new agentAStar.AStarSearch(grid, start, end);

                //var p = end;
                //while (p != start)
                //{
                //    newbp.SetPixel(p.X, p.Y, Color.FromArgb(255, 0, 255));
                //    FinalPoints.Add(p);
                //    p = astar.cameFrom[p];
                //}
                //newbp.SetPixel(p.X, p.Y, Color.FromArgb(255, 0, 255));
                //FinalPoints.Add(p);

                newbp.Save("res.png", System.Drawing.Imaging.ImageFormat.Png);

                //Form ifrm = new Form1();
                //ifrm.Show();
                Writen = true;
            }
            else
            {
                for (int i = 0; i < FinalPoints.Count - 1; i++)
                {
                    var p1 = FinalPoints[i];
                    var p2 = FinalPoints[i + 1];
                    gl.Begin(OpenGL.GL_LINES);
                    gl.Color(1.0, 1.0, 1.0);
                    gl.Vertex(p1.X * SCALE, points[(int)p1.X, (int)p1.Y] + 5, p1.Y * SCALE);
                    gl.Vertex(p2.X * SCALE, points[(int)p2.X, (int)p2.Y] + 5, p2.Y * SCALE);
                    gl.End();
                }
            }
        }
        bool touch(PolygonS polygon, Point a) //проверка попадания точки в Polygon
        {
            PolygonS.PointInPolygon touch = polygon.pointInPolygon(a);
            return touch == PolygonS.PointInPolygon.INSIDE || touch == PolygonS.PointInPolygon.BOUNDARY;
        }
        void DrawLEP(OpenGL gl, float SIZE_LEP, float size, float[] Color, params float[] coordinates)
        {
            // рисуем куб
            //gl.Begin(OpenGL.GL_TRIANGLES);
            //var size = 2SCALEf;
            gl.Begin(OpenGL.GL_QUADS);

            // Top
            gl.Color(Color);
            gl.Vertex(SIZE_LEP + coordinates[0], size + coordinates[1], -SIZE_LEP + coordinates[2]);
            gl.Vertex(-SIZE_LEP + coordinates[0], size + coordinates[1], -SIZE_LEP + coordinates[2]);
            gl.Vertex(-SIZE_LEP + coordinates[0], size + coordinates[1], SIZE_LEP + coordinates[2]);
            gl.Vertex(SIZE_LEP + coordinates[0], size + coordinates[1], SIZE_LEP + coordinates[2]);
            // Front
            gl.Vertex(SIZE_LEP + coordinates[0], size + coordinates[1], SIZE_LEP + coordinates[2]);
            gl.Vertex(-SIZE_LEP + coordinates[0], size + coordinates[1], SIZE_LEP + coordinates[2]);
            gl.Vertex(-SIZE_LEP + coordinates[0], coordinates[1], SIZE_LEP + coordinates[2]);
            gl.Vertex(SIZE_LEP + coordinates[0], coordinates[1], SIZE_LEP + coordinates[2]);
            // Back
            gl.Vertex(SIZE_LEP + coordinates[0], coordinates[1], -SIZE_LEP + coordinates[2]);
            gl.Vertex(-SIZE_LEP + coordinates[0], coordinates[1], -SIZE_LEP + coordinates[2]);
            gl.Vertex(-SIZE_LEP + coordinates[0], size + coordinates[1], -SIZE_LEP + coordinates[2]);
            gl.Vertex(SIZE_LEP + coordinates[0], size + coordinates[1], -SIZE_LEP + coordinates[2]);
            // Left
            gl.Vertex(-SIZE_LEP + coordinates[0], size + coordinates[1], SIZE_LEP + coordinates[2]);
            gl.Vertex(-SIZE_LEP + coordinates[0], size + coordinates[1], -SIZE_LEP + coordinates[2]);
            gl.Vertex(-SIZE_LEP + coordinates[0], coordinates[1], -SIZE_LEP + coordinates[2]);
            gl.Vertex(-SIZE_LEP + coordinates[0], coordinates[1], SIZE_LEP + coordinates[2]);
            // Right
            gl.Vertex(SIZE_LEP + coordinates[0], size + coordinates[1], -SIZE_LEP + coordinates[2]);
            gl.Vertex(SIZE_LEP + coordinates[0], size + coordinates[1], SIZE_LEP + coordinates[2]);
            gl.Vertex(SIZE_LEP + coordinates[0], coordinates[1], SIZE_LEP + coordinates[2]);
            gl.Vertex(SIZE_LEP + coordinates[0], coordinates[1], -SIZE_LEP + coordinates[2]);

            gl.End();
        }
        void tree(OpenGL gl, float[] coordinates, float[] dimensions, int quantity, float height)
        {
            for (int i = 0; i < quantity; i++)
            {

                gl.Begin(OpenGL.GL_TRIANGLES);

                gl.Color(0f, 0.2f, 0.0f);
                gl.Vertex(coordinates[0], coordinates[1] + dimensions[1] + height + (height * i), coordinates[2]);
                gl.Vertex(coordinates[0] + dimensions[0], coordinates[1] + (dimensions[1]) + (height * i), coordinates[2] - dimensions[2]);
                gl.Vertex(coordinates[0] + dimensions[0], coordinates[1] + (dimensions[1]) + (height * i), coordinates[2] + dimensions[2]);

                gl.Color(0f, 0.3f, 0.0f);
                gl.Vertex(coordinates[0] - dimensions[0], coordinates[1] + (dimensions[1]) + (height * i), coordinates[2] - dimensions[2]);
                gl.Vertex(coordinates[0] - dimensions[0], coordinates[1] + (dimensions[1]) + (height * i), coordinates[2] + dimensions[2]);
                gl.Vertex(coordinates[0], coordinates[1] + dimensions[1] + height + (height * i), coordinates[2]);

                gl.Color(0f, 0.4f, 0.0f);
                gl.Vertex(coordinates[0], coordinates[1] + dimensions[1] + height + (height * i), coordinates[2]);
                gl.Vertex(coordinates[0] + dimensions[0], coordinates[1] + (dimensions[1]) + (height * i), coordinates[2] - dimensions[2]);
                gl.Vertex(coordinates[0] - dimensions[0], coordinates[1] + (dimensions[1]) + (height * i), coordinates[2] - dimensions[2]);

                gl.Color(0f, 0.1f, 0.0f);
                gl.Vertex(coordinates[0], coordinates[1] + dimensions[1] + height + (height * i), coordinates[2]);
                gl.Vertex(coordinates[0] - dimensions[0], coordinates[1] + (dimensions[1]) + (height * i), coordinates[2] + dimensions[2]);
                gl.Vertex(coordinates[0] + dimensions[0], coordinates[1] + (dimensions[1]) + (height * i), coordinates[2] + dimensions[2]);

                gl.End();
            }

        }
        void HOUSE(OpenGL gl, float[] coordinates, float[] dimensions, float roofHeight, float turn)
        {
            //dimensions = Turn_y(dimensions, turn);
            //coordinates[0] += res[0];
            //coordinates[1] += res[1];
            //coordinates[2] += res[2];

            // передняя часть дома
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(1f, 1f, 0f);
            gl.Vertex(coordinates[0] + dimensions[0], coordinates[1] + dimensions[1], coordinates[2] - dimensions[2]);
            gl.Vertex(coordinates[0] + dimensions[0], coordinates[1], coordinates[2] - dimensions[2]);
            gl.Vertex(coordinates[0] - dimensions[0], coordinates[1], coordinates[2] - dimensions[2]);
            gl.Vertex(coordinates[0] - dimensions[0], coordinates[1] + dimensions[1], coordinates[2] - dimensions[2]);
            gl.End();

            // правая часть дома
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(1f, 0.8f, 0f);
            gl.Vertex(coordinates[0] + dimensions[0], coordinates[1], coordinates[2] - dimensions[2]);
            gl.Vertex(coordinates[0] + dimensions[0], coordinates[1], coordinates[2] + dimensions[2]);
            gl.Vertex(coordinates[0] + dimensions[0], coordinates[1] + dimensions[1], coordinates[2] + dimensions[2]);
            gl.Vertex(coordinates[0] + dimensions[0], coordinates[1] + dimensions[1], coordinates[2] - dimensions[2]);
            gl.End();

            // задняя часть дома
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(1f, 0.7f, 0f);
            gl.Vertex(coordinates[0] + dimensions[0], coordinates[1], coordinates[2] + dimensions[2]);
            gl.Vertex(coordinates[0] - dimensions[0], coordinates[1], coordinates[2] + dimensions[2]);
            gl.Vertex(coordinates[0] - dimensions[0], coordinates[1] + dimensions[1], coordinates[2] + dimensions[2]);
            gl.Vertex(coordinates[0] + dimensions[0], coordinates[1] + dimensions[1], coordinates[2] + dimensions[2]);
            gl.End();

            // левая часть дома
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(1f, 0.9f, 0f);
            gl.Vertex(coordinates[0] - dimensions[0], coordinates[1], coordinates[2] - dimensions[2]);
            gl.Vertex(coordinates[0] - dimensions[0], coordinates[1], coordinates[2] + dimensions[2]);
            gl.Vertex(coordinates[0] - dimensions[0], coordinates[1] + dimensions[1], coordinates[2] + dimensions[2]);
            gl.Vertex(coordinates[0] - dimensions[0], coordinates[1] + dimensions[1], coordinates[2] - dimensions[2]);
            gl.End();

            // крыша
            gl.Begin(OpenGL.GL_TRIANGLES);

            gl.Color(1f, 0.2f, 0.0f);
            gl.Vertex(coordinates[0], coordinates[1] + dimensions[1] + roofHeight, coordinates[2]);
            gl.Vertex(coordinates[0] + dimensions[0], coordinates[1] + (dimensions[1]), coordinates[2] - dimensions[2]);
            gl.Vertex(coordinates[0] + dimensions[0], coordinates[1] + (dimensions[1]), coordinates[2] + dimensions[2]);

            gl.Color(1f, 0.3f, 0.0f);
            gl.Vertex(coordinates[0] - dimensions[0], coordinates[1] + (dimensions[1]), coordinates[2] - dimensions[2]);
            gl.Vertex(coordinates[0] - dimensions[0], coordinates[1] + (dimensions[1]), coordinates[2] + dimensions[2]);
            gl.Vertex(coordinates[0], coordinates[1] + dimensions[1] + roofHeight, coordinates[2]);

            gl.Color(1f, 0.4f, 0.0f);
            gl.Vertex(coordinates[0], coordinates[1] + dimensions[1] + roofHeight, coordinates[2]);
            gl.Vertex(coordinates[0] + dimensions[0], coordinates[1] + (dimensions[1]), coordinates[2] - dimensions[2]);
            gl.Vertex(coordinates[0] - dimensions[0], coordinates[1] + (dimensions[1]), coordinates[2] - dimensions[2]);

            gl.Color(1f, 0.1f, 0.0f);
            gl.Vertex(coordinates[0], coordinates[1] + dimensions[1] + roofHeight, coordinates[2]);
            gl.Vertex(coordinates[0] - dimensions[0], coordinates[1] + (dimensions[1]), coordinates[2] + dimensions[2]);
            gl.Vertex(coordinates[0] + dimensions[0], coordinates[1] + (dimensions[1]), coordinates[2] + dimensions[2]);

            gl.End();

        }
        public void setColor(int val, OpenGL gl)
        {
            double col = (double)val / (double)maxHeightMap * 0.8f;//цвет вершин чем выше тем светлее 
            gl.Color(col, col, col);
        }
        private void openglControl1_Resized(object sender, EventArgs e)
        {
            //  Возьмём OpenGL объект
            OpenGL gl = openglControl1.OpenGL;

            //  Зададим матрицу проекции
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Единичная матрица для последующих преобразований
            gl.LoadIdentity();

            //  Преобразование
            gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 1000.0);


            //  Данная функция позволяет установить камеру и её положение
            var dX = Math.Sin(AngleX * Rad) * Math.Cos(AngleY * Rad);
            var dY = Math.Sin(AngleY * Rad);
            var dZ = Math.Cos(AngleX * Rad) * Math.Cos(AngleY * Rad);
            gl.LookAt(POSX, POSY, POSZ,    // Позиция самой камеры
                      POSX + dX,
                      POSY + dY,
                      POSZ + dZ,     // Направление, куда мы смотрим
                       0, 1, 0);    // Верх камеры

            //  Зададим модель отображения
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }
        private void openglControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            //  Возьмём OpenGL объект
            OpenGL gl = openglControl1.OpenGL;

            //  Фоновый цвет по умолчанию (в данном случае цвет голубой)
            gl.ClearColor(0.1f, 0.5f, 1.0f, 0);
        }
        #endregion

        #region "Управление"
        private void button1_Click(object sender, EventArgs e)
        {
            Writen = false;
            //this.Hide();
        }
        private void openglControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (b)
            {
                if (lX != -1)
                {
                    AngleX += (lX - e.X) / 5f;
                }
                if (lY != -1) AngleY += (lY - e.Y) / 5f;
                //Console.WriteLine($"mouse {lX} {lY}");
                openglControl1_Resized(sender, e);
            }
            lX = e.X;
            lY = e.Y;
        }

        private void openglControl1_KeyDown(object sender, KeyEventArgs e)
        {
            double dX, dY, dZ;
            switch (e.KeyCode)
            {
                case Keys.W:
                    dX = Math.Sin(AngleX * Rad) * Math.Cos(AngleY * Rad);
                    dY = Math.Sin(AngleY * Rad);
                    dZ = Math.Cos(AngleX * Rad) * Math.Cos(AngleY * Rad);
                    POSX += dX;
                    POSY += dY;
                    POSZ += dZ;
                    break;
                case Keys.S:
                    dX = Math.Sin(AngleX * Rad) * Math.Cos(AngleY * Rad);
                    dY = Math.Sin(AngleY * Rad);
                    dZ = Math.Cos(AngleX * Rad) * Math.Cos(AngleY * Rad);
                    POSX -= dX;
                    POSY -= dY;
                    POSZ -= dZ;
                    break;

                case Keys.A:
                    dX = Math.Sin((AngleX + 90) * Rad) * Math.Cos(AngleY * Rad);
                    dZ = Math.Cos((AngleX + 90) * Rad) * Math.Cos(AngleY * Rad);
                    POSX += dX;
                    POSZ += dZ;
                    break;
                case Keys.D:
                    dX = Math.Sin((AngleX - 90) * Rad) * Math.Cos(AngleY * Rad);
                    dZ = Math.Cos((AngleX - 90) * Rad) * Math.Cos(AngleY * Rad);
                    POSX += dX;
                    POSZ += dZ;
                    break;
                case Keys.Space:
                    dX = Math.Sin(AngleX * Rad) * Math.Cos((AngleY - 90) * Rad);
                    dY = Math.Sin((AngleY - 90) * Rad);
                    dZ = Math.Cos(AngleX * Rad) * Math.Cos((AngleY - 90) * Rad);
                    POSX += dX;
                    POSY += dY;
                    POSZ += dZ;
                    break;
                case Keys.Shift:
                    dX = Math.Sin(AngleX * Rad) * Math.Cos((AngleY + 90) * Rad);
                    dY = Math.Sin((AngleY + 90) * Rad);
                    dZ = Math.Cos(AngleX * Rad) * Math.Cos((AngleY + 90) * Rad);
                    POSX += dX;
                    POSY += dY;
                    POSZ += dZ;
                    break;
            }
            //openGLControl.Invalidate();
            openglControl1_Resized(sender, e);
        }

        private void openglControl1_MouseDown(object sender, MouseEventArgs e) => b = true;

        private void openglControl1_MouseUp(object sender, EventArgs e) => b = false;

        #endregion

    }
}