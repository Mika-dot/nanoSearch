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
                if (res_here.Value.Item2.Any(x => !x))
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