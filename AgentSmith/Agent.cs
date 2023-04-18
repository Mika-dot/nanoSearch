using A_Star;
using A_Star.Core;
using AgentSmith.Settings;
using System.Drawing;


namespace AgentSmith
{
    public class Agent
    {
        public Agent(int[,] Maps)
        {
            Configuration.Map = Maps;
        }
        public int[,] changes
        {
            get => Configuration.Map;
            set => Configuration.Map = value;
        }
        public (Point, bool[]) AgentActions(Point position, Point historyPosition)
        {
            Gradient gradient = new Gradient();
            int lengthMap = Configuration.Map.GetLength(0);
            Task<Tuple>[]Johnson = new Task<Tuple>[Cof.DIRS.Length];
            for (int i = 0; i < Johnson.Length; i++)
            {
                int n = i;
                Johnson[n] = new Task<Tuple>(() => Tuples.Steve(position, i, lengthMap, gradient, historyPosition));
                Johnson[i].Start();
            }

            int Best = -1;
            bool[] Flags = new bool[5];

            float dot = float.MaxValue;
            foreach (var agents in Johnson)
            {
                Tuple result = agents.Result;
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