using System.Drawing;

namespace A_Star.Core
{
    public static class Cof
    {
        public static Point[] DIRS = new[]
        {
            new Point(-2, 2),
            new Point(-1, 2),
            new Point(0, 2),
            new Point(1, 2),
            new Point(2, 2),

            new Point(2, 1),
            new Point(2, 0),
            new Point(2, -1),

            new Point(2, -2),
            new Point(1, -2),
            new Point(0, -2),
            new Point(-1, -2),
            new Point(-2, -2),

            new Point(-2, -1),
            new Point(-2, 0),
            new Point(-2, 1),

        };
    }
}
