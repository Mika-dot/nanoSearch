using agentConfiguration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agentAStar
{

    class SquareGrid
    {
        // Примечания по реализации: для удобства я сделал поля публичными,
        // но в реальном проекте, возможно, стоит следовать стандартному
        // стилю и сделать их скрытыми.

        public static readonly Point[] DIRS = new[]
            {
            new Point(-2, 2),
            new Point(-1, 2),
            new Point(0, 2),
            new Point(1, 2),
            new Point(2, 2),

            new Point(-2, -2),
            new Point(-1, -2),
            new Point(0, -2),
            new Point(1, -2),
            new Point(2, -2),

            new Point(-2, 1),
            new Point(-2, 0),
            new Point(-2, -1),

            new Point(2, 1),
            new Point(2, 0),
            new Point(2, -1),
        };

        public int width, height;
        public SquareGrid(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public bool InBounds(Point id)
        {
            return 0 <= id.X && id.X < width
                && 0 <= id.Y && id.Y < height;
        }

        public double Cost(Point a)
        {
            return configuration.Map[a.X, a.Y];//forests.Contains(a) ? 5 : 1;
        }

        public IEnumerable<Point> Neighbors(Point id)
        {
            foreach (var dir in DIRS)
            {
                Point next = new Point(id.X + dir.X, id.Y + dir.Y);
                if (InBounds(next))// && Passable(next))
                {
                    yield return next;
                }
            }
        }
    }

    class PriorityQueue<T>
    {
        // В этом примере я использую несортированный массив, но в идеале
        // это должна быть двоичная куча. Существует открытый запрос на добавление
        // двоичной кучи к стандартной библиотеке C#: https://github.com/dotnet/corefx/issues/574
        //
        // Но пока её там нет, можно использовать класс двоичной кучи:
        // * https://github.com/BlueRaja/High-Speed-Priority-Queue-for-C-Sharp
        // * http://visualstudiomagazine.com/articles/2012/11/01/priority-queues-with-c.aspx
        // * http://xfleury.github.io/graphsearch.html
        // * http://stackoverflow.com/questions/102398/priority-queue-in-net

        private List<(T, double)> elements = new List<(T, double)>();

        public int Count
        {
            get { return elements.Count; }
        }

        public void Enqueue(T item, double priority)
        {
            elements.Add((item, priority));
        }

        public T Dequeue()
        {
            int bestIndex = 0;

            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].Item2 < elements[bestIndex].Item2)
                {
                    bestIndex = i;
                }
            }

            T bestItem = elements[bestIndex].Item1;
            elements.RemoveAt(bestIndex);
            return bestItem;
        }
    }

    class AStarSearch
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

        public AStarSearch(SquareGrid graph, Point start, Point goal)
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
                    double newCost = costSoFar[current]
                        //+ graph.Cost(current, next);
                        + graph.Cost(next);
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
