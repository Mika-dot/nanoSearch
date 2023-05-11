using System.Drawing;

namespace A_Star
{
    /// <summary>
    /// Алгоритм оценки пути по всей карте
    /// </summary>
    public class AStar
    {
        public Dictionary<Point, Point> cameFrom
            = new Dictionary<Point, Point>();
        public Dictionary<Point, double> costSoFar
            = new Dictionary<Point, double>();

        // Примечание: обобщённая версия A* абстрагируется от Point
        // и Heuristic
        static public double Heuristic(Point a, Point b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }

        /// <summary>
        /// Оценка пути по всей карте
        /// </summary>
        /// <param name="graph">Размеры иследуемой облости</param>
        /// <param name="start">Стартовая позиция</param>
        /// <param name="goal">Финишная позиция</param>
        /// <param name="Map">Цена карты в графе</param>
        public AStar(SquareGrid graph, Point start, Point goal, ref int?[,] Map, int cost)
        {
            var frontier = new PriorityQueue<Point>();
            frontier.Enqueue(start, 0);

            cameFrom[start] = start;
            costSoFar[start] = 0;

            while (frontier.Count > 0)
            {
                var current = frontier.Dequeue();

                if (current.Equals(goal))
                {
                    break;
                }

                foreach (var next in graph.Neighbors(current))
                {
                    if (Map[next.X, next.Y] == null) continue;
                    double newCost = costSoFar[current]
                        + graph.Cost(next, Map) + cost;
                    //+ Math.Abs(configuration.Map[next.X, next.Y] - configuration.Map[current.X, current.Y]);
                    if (!costSoFar.ContainsKey(next)
                        || newCost < costSoFar[next])
                    {
                        costSoFar[next] = newCost;
                        double priority = newCost + Heuristic(next, goal);
                        frontier.Enqueue(next, priority);
                        cameFrom[next] = current;
                    }
                }
            }
        }
    }
}