using A_Star;
using A_Star.Core;
using AgentSmith.Settings;
using System.Drawing;
using System.Reflection;


namespace AgentSmith
{
    public class Agent
    {
        public Agent(int[,] Maps, Point end)
        {
            Configuration.Map = Maps;
            Configuration.End = end;
        }

        public (Point, bool[])? AgentActions(Point position, Point historyPosition)
        {

            Type myClassCoefficient = typeof(Coefficient);
            MethodInfo[] methods = myClassCoefficient.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            bool flag = true;
            foreach (var method in methods)
            {
                if ((float)method.Invoke(null, null) == 0)
                {
                    continue;
                }
                flag = true; break;
            }
            if (flag) return null;

            Gradient gradient = new Gradient();
            int lengthMap = Configuration.Map.GetLength(0);
            Task<TupleMy>[]Johnson = new Task<TupleMy>[Cof.DIRS.Length];
            for (int i = 0; i < Johnson.Length; i++)
            {
                Johnson[i] = new Task<TupleMy>(() => Tuples.Steve(position, i, lengthMap, gradient, historyPosition));
                Johnson[i].Start();
            }

            Task.WaitAll(Johnson);

            int Best = -1;
            bool[] Flags = new bool[5];

            float dot = float.MaxValue;
            foreach (var agents in Johnson)
            {
                TupleMy result = agents.Result;
                if (result.Value() < dot)
                {
                    dot = result.Value();
                    Flags = result.Flags();
                }
                result = null;
            }

            Point offset = new Point(Cof.DIRS[Best].X, Cof.DIRS[Best].Y);

            return (new Point(position.X + offset.X, position.Y + offset.Y), Flags);
        }

    }
}