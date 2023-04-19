using System.Drawing;
using AgentSmith;
using AgentSmith.Settings;
using static AgentSmith.Mathematics;
using System.Drawing;
using NUnit.Framework;

namespace TestAgentSmith
{
    public class Tests
    {
        [SetUp]
        public int[,] Setup(string Map = "Map_1.bmp")
        {
            int[,] MAP = new int[128, 128];

            var bmp = new System.Drawing.Bitmap(Map, true);//Берем изображение шума из ресурсов
            float maxHeightMap = 5f;
            for (int i = 0; i < 128; i++)
                for (int j = 0; j < 128; j++)
                {
                    MAP[i, j] = (int)(bmp.GetPixel(i, j).GetBrightness() * maxHeightMap);//Генерируем карту высот по яркости пикселем
                }

            return MAP;
        }


        [Test]
        public void AngleOfRotation_180()
        {
            int x = 180;
            Configuration.Map = Setup();
           
            // Переменые
            Point historyPosition = new Point(0, 0);
            Point My = new Point(10, 0);
            Point Your = new Point(20, 0);

            // temp
            Coefficient.AStarSearch = 0;
            Coefficient.Height = 0;
            Coefficient.Length = 0;
            Coefficient.Corner = 0;
            //

            Gradient temp = new Gradient();
            (float, bool[]) actual = temp.GradientDescent(My, Your, historyPosition);


            //Проверка
            Assert.That(actual.Item1, Is.EqualTo(x));
            
        }

        [Test]
        public void AngleOfRotation_0()
        {
            int x = 0;
            Configuration.Map = Setup();
            // Переменые
            Point historyPosition = new Point(0, 0);
            Point My = new Point(10, 0);
            Point Your = new Point(0, 0);

            // temp
            Coefficient.AStarSearch = 0;
            Coefficient.Height = 0;
            Coefficient.Length = 0;
            Coefficient.Corner = 0;
            //

            Gradient temp = new Gradient();
            (float, bool[]) actual = temp.GradientDescent(My, Your, historyPosition);


            //Проверка
            Assert.That(actual.Item1, Is.EqualTo(x));

        }


        [Test]
        public void Height_M5()
        {
            int x = -5;
            Configuration.Map = Setup();
            // Переменые
            Point historyPosition = new Point(0, 0);
            Point My = new Point(10, 0);
            Point Your = new Point(0, 0);

            // temp
            Coefficient.AStarSearch = 0;
            Coefficient.AngleOfRotation = 0;
            Coefficient.Length = 0;
            Coefficient.Corner = 0;
            //

            Gradient temp = new Gradient();
            (float, bool[]) actual = temp.GradientDescent(My, Your, historyPosition);


            //Проверка
            Assert.That(actual.Item1, Is.EqualTo(x));
        }
        [Test]
        public void Height_P5()
        {
            int x = 5;
            Configuration.Map = Setup();
            // Переменые
            Point historyPosition = new Point(0, 0);
            Point My = new Point(10, 0);
            Point Your = new Point(0, 0);

            // temp
            Coefficient.AStarSearch = 0;
            Coefficient.AngleOfRotation = 0;
            Coefficient.Length = 0;
            Coefficient.Corner = 0;
            //

            Gradient temp = new Gradient();
            (float, bool[]) actual = temp.GradientDescent(My, Your, historyPosition);


            //Проверка
            Assert.That(actual.Item1, Is.EqualTo(x));
        }

        [Test]
        public void Length()
        {
            int x = 10;
            Configuration.Map = Setup();
            // Переменые
            Point historyPosition = new Point(0, 0);
            Point My = new Point(10, 0);
            Point Your = new Point(0, 0);

            // temp
            Coefficient.AStarSearch = 0;
            Coefficient.AngleOfRotation = 0;
            Coefficient.Height = 0;
            Coefficient.Corner = 0;
            //

            Gradient temp = new Gradient();
            (float, bool[]) actual = temp.GradientDescent(My, Your, historyPosition);


            //Проверка
            Assert.That(actual.Item1, Is.EqualTo(x));
        }

        [Test]
        public void Corner_M()
        {
            int x = -10;
            Configuration.Map = Setup();
            // Переменые
            Point historyPosition = new Point(0, 0);
            Point My = new Point(10, 0);
            Point Your = new Point(0, 0);

            // temp
            Coefficient.AStarSearch = 0;
            Coefficient.AngleOfRotation = 0;
            Coefficient.Height = 0;
            Coefficient.Length = 0;
            //

            Gradient temp = new Gradient();
            (float, bool[]) actual = temp.GradientDescent(My, Your, historyPosition);


            //Проверка
            Assert.That(actual.Item1, Is.EqualTo(x));
        }

        [Test]
        public void Corner_P()
        {
            int x = 10;
            Configuration.Map = Setup();
            // Переменые
            Point historyPosition = new Point(0, 0);
            Point My = new Point(10, 0);
            Point Your = new Point(0, 0);

            // temp
            Coefficient.AStarSearch = 0;
            Coefficient.AngleOfRotation = 0;
            Coefficient.Height = 0;
            Coefficient.Length = 0;
            //

            Gradient temp = new Gradient();
            (float, bool[]) actual = temp.GradientDescent(My, Your, historyPosition);


            //Проверка
            Assert.That(actual.Item1, Is.EqualTo(x));
        }
    }
}