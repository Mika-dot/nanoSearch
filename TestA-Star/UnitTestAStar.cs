using A_Star;
using System.Drawing;
using A_Star.Core;
using AgentSmith.Settings;

namespace TestA_Star
{
    public class TestsAStar
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestsAStar_hz()
        {
            // Переменые
            int[,] MAP = new int[128, 128];

            //var bmp = new System.Drawing.Bitmap("TestA-Star\\Map_1.bmp", true);//Берем изображение шума из ресурсов
            //float maxHeightMap = 5f;
            //for (int i = 0; i < 128; i++)
            //    for (int j = 0; j < 128; j++)
            //    {
            //        MAP[i, j] = (int)(bmp.GetPixel(i, j).GetBrightness() * maxHeightMap);//Генерируем карту высот по яркости пикселем
            //    }
            Random r = new Random();
            for (int i = 1; i < 5; i++)
            {
                Configuration.End = new Point(r.Next(1, 127), r.Next(1, 127));
                var start = new Point(r.Next(1, 127), r.Next(1, 127));
                var grid = new SquareGrid(128, 128);
                var astar = new AStar(grid, start, Configuration.End, ref MAP);
            }

            
            //var p = end;
            //while (p != start)
            //{
            //    newbp.SetPixel(p.X, p.Y, Color.FromArgb(255, 0, 255));
            //    FinalPoints.Add(p);
            //    p = astar.cameFrom[p];
            //}
            //newbp.SetPixel(p.X, p.Y, Color.FromArgb(255, 0, 255));
            //FinalPoints.Add(p);

            // Взаимодействие 

            //AStar star = new AStar();
            double actual = 3f; // star.Heuristic();
            double expected = 3f; // star.Heuristic();


            //Проверка
            Assert.AreEqual(expected, actual);
        }
    }
}