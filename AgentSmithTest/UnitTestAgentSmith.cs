namespace AgentSmithTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
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