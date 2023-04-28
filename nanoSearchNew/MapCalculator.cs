using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SharpGL;
using nanoSearchNew;
using static nanoSearchNew.Datas;
using GraphicArts;
using nanoSearchNew.ConstantMap;
using AgentSmith.Settings;
using AgentSmith;

namespace MapCalculator
{
    public class MapHelper
    {
        public static WorldStruct DATA;
        public static int xC = 0;//Количество точек по х
        public static int zC = 0;//Количество точек по y
        public static int OffsetX = 0;
        public static int OffsetY = 0;
        public static int MaxX = 0;
        public static int MaxY = 0;
        public static int[,] points;//массив высот, 
        public static int[,] newPoints;//массив высот,
        public static List<Point> FinalPoints = new List<Point>();
        public static int maxHeightMap = 100;//максимальная высота гор с 

        public static int SCALE = 1;


        public static void CalculateEverything()
        {
            newPoints = new int[xC, zC];
            for (int i = 0; i < xC; i++)
                for (int j = 0; j < zC; j++)
                    newPoints[i, j] = 0;//points[i, j];

            // считаем цены

            // 1. Карта
            for (int x = 0; x < xC - 1; x++)
            {
                for (int z = 0; z < zC - 1; z++)
                {
                    newPoints[x, z] = points[x, z] * (int)ConstantGrid.HeightMap;//Convert.ToInt32(textBox1.Text);
                }
            }

            // 2. Полигоны, это границы
            for (int i = 0; i < DATA.Polygons.Length; i++)
            {
                var ps = DATA.Polygons[i].Points;

                int x_min = (int)ps.Min(N => N.X);
                int x_max = (int)ps.Max(N => N.X);

                int y_min = (int)ps.Min(N => N.Y);
                int y_max = (int)ps.Max(N => N.Y);

                var polygon = new PolygonS(ps);

                for (int X = x_min; X < x_max; X++)
                {
                    for (int Y = y_min; Y < y_max; Y++)
                    {
                        if (touch(polygon, new Point(X, Y)))
                        {
                            newPoints[X, Y] += (int)ConstantGrid.Polygon[DATA.Polygons[i].Type].Value;//Convert.ToInt32(textBox2.Text);
                        }
                    }
                }
            }

            // 4. Домики
            if (DATA.Houses != null)
                for (int i = 0; i < DATA.Houses.Length; i++)
                {
                    var hous = DATA.Houses[i];
                    var ps = hous.Pos;
                    var sz = hous.Size;
                    var pss = new Vector2[]
                    {
                    new Vector2(ps.X * SCALE + sz.X, ps.Y * SCALE + sz.Y),
                    new Vector2(ps.X * SCALE - sz.X, ps.Y * SCALE + sz.Y),
                    new Vector2(ps.X * SCALE + sz.X, ps.Y * SCALE - sz.Y),
                    new Vector2(ps.X * SCALE - sz.X, ps.Y * SCALE - sz.Y)
                    };
                    var polygon = new PolygonS(pss);

                    int x_min = (int)pss.Min(N => N.X);
                    int x_max = (int)pss.Max(N => N.X);
                    int y_min = (int)pss.Min(N => N.Y);
                    int y_max = (int)pss.Max(N => N.Y);

                    for (int X = x_min; X < x_max; X++)
                    {
                        for (int Y = y_min; Y < y_max; Y++)
                        {
                            if (touch(polygon, new Point(X, Y)))
                            {
                                newPoints[X / SCALE, Y / SCALE] += (int)ConstantGrid.Home[0].Value;//Convert.ToInt32(textBox3.Text);
                            }
                        }
                    }
                }

            // 6. Дороги шоссе
            if (DATA.RoadsSHCO != null)
                for (int i = 0; i < DATA.RoadsSHCO.Length; i++)
                {
                    var road = DATA.RoadsSHCO[i];
                    var start = road.Start;
                    var end = road.End;
                    var angle = (Math.Atan2(end.Y - start.Y, end.X - start.X) * 180f / Math.PI - 90f) * Math.PI / 180.0;
                    var offset = new Vector2((float)(road.Width * Math.Cos(angle)), (float)(road.Width * Math.Sin(angle)));
                    var ps = new Vector2[]
                    {
                        new Vector2(start.X * SCALE - offset.X, start.Y * SCALE - offset.Y),
                        new Vector2(start.X * SCALE + offset.X, start.Y * SCALE + offset.Y),
                        new Vector2(end.X * SCALE + offset.X, end.Y * SCALE + offset.Y),
                        new Vector2(end.X * SCALE - offset.X, end.Y * SCALE - offset.Y)
                    };

                    var polygon = new PolygonS(ps);

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
                                newPoints[X / SCALE, Y / SCALE] += (int)ConstantGrid.Road[0].Value;//Convert.ToInt32(textBox4.Text);
                            }
                        }
                    }
                }

            // 6. Дороги асфальт
            if (DATA.RoadsASPHALT != null)
                for (int i = 0; i < DATA.RoadsASPHALT.Length; i++)
                {
                    var road = DATA.RoadsASPHALT[i];
                    var start = road.Start;
                    var end = road.End;
                    var angle = (Math.Atan2(end.Y - start.Y, end.X - start.X) * 180f / Math.PI - 90f) * Math.PI / 180.0;
                    var offset = new Vector2((float)(road.Width * Math.Cos(angle)), (float)(road.Width * Math.Sin(angle)));

                    var ps = new Vector2[]
                    {
                    new Vector2(start.X * SCALE - offset.X, start.Y * SCALE - offset.Y),
                    new Vector2(start.X * SCALE + offset.X, start.Y * SCALE + offset.Y),
                    new Vector2(end.X * SCALE + offset.X, end.Y * SCALE + offset.Y),
                    new Vector2(end.X * SCALE - offset.X, end.Y * SCALE - offset.Y)
                    };

                    var polygon = new PolygonS(ps);

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
                                newPoints[X / SCALE, Y / SCALE] += (int)ConstantGrid.Road[1].Value;//Convert.ToInt32(textBox5.Text);
                            }
                        }
                    }
                }

            // 6. Дороги грунт
            if (DATA.RoadsGROUND != null)
                for (int i = 0; i < DATA.RoadsGROUND.Length; i++)
                {
                    var road = DATA.RoadsGROUND[i];
                    var start = road.Start;
                    var end = road.End;
                    var angle = (Math.Atan2(end.Y - start.Y, end.X - start.X) * 180f / Math.PI - 90f) * Math.PI / 180.0;
                    var offset = new Vector2((float)(road.Width * Math.Cos(angle)), (float)(road.Width * Math.Sin(angle)));

                    var ps = new Vector2[]
                    {
                    new Vector2(start.X * SCALE - offset.X, start.Y * SCALE - offset.Y),
                    new Vector2(start.X * SCALE + offset.X, start.Y * SCALE + offset.Y),
                    new Vector2(end.X * SCALE + offset.X, end.Y * SCALE + offset.Y),
                    new Vector2(end.X * SCALE - offset.X, end.Y * SCALE - offset.Y)
                    };

                    var polygon = new PolygonS(ps);

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
                                newPoints[X / SCALE, Y / SCALE] += (int)ConstantGrid.Road[2].Value;//Convert.ToInt32(textBox6.Text);
                            }
                        }
                    }
                }


            // 7. Реки
            if (DATA.Rivers != null)
                for (int i = 0; i < DATA.Rivers.Length; i++)
                {
                    var road = DATA.Rivers[i];
                    var start = road.Start;
                    var end = road.End;
                    var angle = (Math.Atan2(end.Y - start.Y, end.X - start.X) * 180f / Math.PI - 90f) * Math.PI / 180.0;
                    var offset = new Vector2((float)(road.Width * Math.Cos(angle)), (float)(road.Width * Math.Sin(angle)));


                    var ps = new Vector2[]
                    {
                    new Vector2(start.X * SCALE - offset.X, start.Y * SCALE - offset.Y),
                    new Vector2(start.X * SCALE + offset.X, start.Y * SCALE + offset.Y),
                    new Vector2(end.X * SCALE + offset.X, end.Y * SCALE + offset.Y),
                    new Vector2(end.X * SCALE - offset.X, end.Y * SCALE - offset.Y)
                    };

                    var polygon = new PolygonS(ps);

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
                                newPoints[X / SCALE, Y / SCALE] += (int)ConstantGrid.Road[3].Value;//Convert.ToInt32(textBox7.Text);
                            }
                        }
                    }
                }
        }

        static bool touch(PolygonS polygon, Point a) //проверка попадания точки в Polygon
        {
            PolygonS.PointInPolygon touch = polygon.pointInPolygon(a);
            return touch == PolygonS.PointInPolygon.INSIDE || touch == PolygonS.PointInPolygon.BOUNDARY;
        }

        public static void setColor(int val, OpenGL gl)
        {
            double col = (double)val / (double)maxHeightMap * 0.8f;//цвет вершин чем выше тем светлее 
            gl.Color(col, col, col);
        }

        public static void JustRenderEverything(OpenGL gl)
        {
            // 1. Карта
            if (!CameraMove.CameraUsed) for (int x = 0; x < MaxX - OffsetX - 1; x++)
                {
                    for (int z = 0; z < MaxY - OffsetY - 1; z++)
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
                    //if (type == 0 || type == 1)
                    //{
                    //    for (int X = x_min; X < x_max; X += STEP)
                    //    {
                    //        for (int Y = y_min; Y < y_max; Y += STEP)
                    //        {
                    //            if (touch(polygon, new Point(X, Y)))
                    //            {
                    //                tree(gl, new float[] { X * SCALE, points[X, Y], Y * SCALE }, dimensions, 3 + type * 2, 3 + type * 2);
                    //            }
                    //        }
                    //    }
                    //}

                }
            }

            // 3. ЛЭПы
            if (DATA.LEPs != null)
                for (int i = 0; i < DATA.LEPs.Length; i++)
                {
                    var lep = DATA.LEPs[i];
                    var h = lep.Height;
                    var ps = lep.Pos;
                    //DrawLEP(gl, 0.25f, h, new float[] { 0.0f, 0.0f, 0.0f }, ps.X * SCALE, points[(int)ps.X, (int)ps.Y], ps.Y * SCALE);
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
            if (DATA.Houses != null)
                for (int i = 0; i < DATA.Houses.Length; i++)
                {
                    var hous = DATA.Houses[i];
                    var ps = hous.Pos;
                    var coordinates = new float[] { ps.X * SCALE, points[(int)ps.X, (int)ps.Y], ps.Y * SCALE };
                    var sz = hous.Size;
                    var dimensions = new float[] { sz.X, sz.Y, sz.Z };
                    MainForm.Houses[i].StlOutputOBJ(gl);
                    // рисуем дом
                    //HOUSE(gl, coordinates, dimensions, 1, hous.Angle);

                    //MainForm.Ho

                    //GraphicArts.Model.StlOutputOBJ(gl, stem, coordinates, dimensions);
                    //stlOutputOBJ(gl, stem, coordinates);
                    //if (!Writen)
                    //{
                    //    newPoints[(int)ps.X, (int)ps.Y] += 100;
                    //}
                }

            // SCALE. ГАЗы
            if (DATA.GASs != null)
                for (int i = 0; i < DATA.GASs.Length; i++)
                {
                    var lep = DATA.GASs[i];
                    var h = lep.Height;
                    var ps = lep.Pos;
                    //DrawLEP(gl, 0.25f, h, new float[] { 1.0f, 1.0f, 0.0f }, ps.X * SCALE, points[(int)ps.X, (int)ps.Y] - h, ps.Y * SCALE);
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
            if (DATA.RoadsSHCO != null)
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
                }

            // 6. Дороги асфальт
            if (DATA.RoadsASPHALT != null)
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
                }

            // 6. Дороги грунт
            if (DATA.RoadsGROUND != null)
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
                }

            // 7. Реки
            if (DATA.Rivers != null)
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
                }

        }
    
        public static void CalculatePathOnMap(Point start, Point end)
        {

            var newbp = new Bitmap(xC, zC);
            int max = newPoints.Cast<int>().Max();
            for (int i = 0; i < xC; i++)
                for (int j = 0; j < zC; j++)
                {
                    int rgb = max == 0 ? 0 : (int)(255f * newPoints[i, j] / max);
                    newbp.SetPixel(i, j, Color.FromArgb(rgb, rgb, rgb));
                }

            var curr = start;
            //curr.Y++;
            Configuration.Size = 1;
            //Configuration.End = end;// end = new Point(80, 50);
            var agent = new Agent(newPoints, end).Criterion(Agent.CriterionName.AStar); // Создаём агента
            FinalPoints.Clear();
            FinalPoints.Add(start);
            FinalPoints.Add(curr);
            int COUnter = 10;
            while (curr != Configuration.End)// || agentAStar.AStarSearch.Heuristic(curr, end) <= agentConfiguration.configuration.Size * 2
            {
                var res_here = agent.AgentActions(curr, start);

                //var p = end;
                //while (p != res_here.Item1)
                //{
                //    newbp.SetPixel(p.X, p.Y, Color.FromArgb(255, 0, 255));
                //    FinalPoints.Add(p);
                //}
                //newbp.SetPixel(p.X, p.Y, Color.FromArgb(255, 0, 255));
                //FinalPoints.Add(p);
                COUnter--;
                if (COUnter == 0)
                {
                    newbp.Save(Link.Res, System.Drawing.Imaging.ImageFormat.Png);
                    COUnter = 10;
                }

                start = curr; // Текущая стала предыдущей
                curr = res_here.Value.Item1; // В текущую записан результат
                newbp.SetPixel(curr.X, curr.Y, Color.FromArgb(255, 0, 0)); // Помечаем белым
                FinalPoints.Add(curr);
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

            newbp.Save(Link.Res, System.Drawing.Imaging.ImageFormat.Png);
        }

        public static void RenderPath(OpenGL gl)
        {
            if (FinalPoints.Count > 0)
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

    }
}