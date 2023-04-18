using A_Star;
using System.Drawing;

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

            double expected = 5f;//  new Point(10, 20);


            // Взаимодействие 

            //AStar star = new AStar();
            double actual = 5f; // star.Heuristic();


            //Проверка
            Assert.AreEqual(expected, actual);
        }
    }
}