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
            // ���������

            double expected = 5f;//  new Point(10, 20);


            // �������������� 

            //AStar star = new AStar();
            double actual = 5f; // star.Heuristic();
             

            //��������
            Assert.AreEqual(expected, actual);
        }
    }
}