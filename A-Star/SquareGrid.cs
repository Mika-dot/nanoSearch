using A_Star.Core;
using System.Drawing;

namespace A_Star
{
    public class SquareGrid
    {
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

        public double Cost(Point a, int[,] Map)
        {
            return Map[a.X, a.Y];//forests.Contains(a) ? 5 : 1;
        }

        public IEnumerable<Point> Neighbors(Point id)
        {
            foreach (var dir in Cof.DIRS)
            {
                Point next = new Point(id.X + dir.X, id.Y + dir.Y);
                if (InBounds(next))// && Passable(next))
                {
                    yield return next;
                }
            }
        }
    }
}
