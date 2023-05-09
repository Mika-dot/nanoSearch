using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AgentSmith.Settings;
using AgentSmith;
using System.IO;

namespace Architect
{
    public class Recursion
    {

        public static (List<Point>, List<(Point, bool[])>) Path(Agent Smith)
        {
            var Start = Configuration.Start;
            var curr = Start;
            List<Point> Result = new List<Point>();
            List<(Point, bool[])> BrokenList = new List<(Point, bool[])>();

            while (curr != Configuration.End)
            {
                var res_here = Smith.AgentActions(curr, Start);
                if (res_here == null) break;
                Start = curr; // Текущая стала предыдущей
                curr = res_here.Value.Item1; // В текущую записан результат
                Result.Add(curr);
                if (res_here.Value.Item2.Any(x => x))
                {
                    // Какой-то из критериев сломался, добавляем это в выколотую точку
                    Configuration.Map[curr.X, curr.Y] = null;
                    BrokenList.Add((curr, res_here.Value.Item2));
                }
            }
            return (Result, BrokenList);
        }

        public static List<(List<Point>, List<(Point, bool[])>)> Recursions(Agent Smith, int longs = 100)
        {
            List<(List<Point>, List<(Point, bool[])>)> AllPaths = new();
            for(int i = 0; i < longs; i++) 
            {
                Console.WriteLine($"stage {i + 1} / {longs}");
                var path = Path(Smith);
                var X = Configuration.Map.GetLength(0);
                var Y = Configuration.Map.GetLength(1);
                var newbp = new Bitmap(X, Y);
                var newbp2 = new Bitmap(X, Y);
                int max = Configuration.Map.Cast<int?>().Where(x => x.HasValue).Select(x => x.Value).Max();
                for (int i2 = 0; i2 < X; i2++)
                    for (int j = 0; j < Y; j++)
                    {
                        if (!Configuration.Map[i2, j].HasValue)
                        {
                            newbp.SetPixel(i2, j, Color.FromArgb(255, 0, 0)); // Помечаем белым
                        }
                        else
                        {
                            if (path.Item1.Contains(new Point(i2, j))) newbp.SetPixel(i2, j, Color.FromArgb(255, 255, 0));
                            else
                            {
                                int rgb = max == 0 ? 0 : (int)(255f * Configuration.Map[i2, j] / max);
                                newbp.SetPixel(i2, j, Color.FromArgb(rgb, rgb, rgb));
                            }
                        }
                    }


                newbp.Save("res.png", System.Drawing.Imaging.ImageFormat.Png);

                if (path.Item1.Count == 0)
                {
                    break;
                }
                AllPaths.Add(path);
                if (path.Item2.Count == 0)
                {
                    break;
                }
            }

            return AllPaths;
        }
    }
}