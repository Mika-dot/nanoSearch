using A_Star;
using A_Star.Core;
using AgentSmith.Settings;
using System.Drawing;

namespace UnitTest_Constants
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
    
        }

        [Test]
        public void CalculationFormula_ChangeAccess()
        {
            // Переменые
            float[,] expected = { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };

            calculationFormula.AStarSearch = expected;
            calculationFormula.Height = expected;
            calculationFormula.Corner = expected;
            calculationFormula.Length = expected;
            calculationFormula.AngleOfRotation = expected;

            //Проверка
            Assert.AreEqual(expected, calculationFormula.AStarSearch);
            Assert.AreEqual(expected, calculationFormula.Height);
            Assert.AreEqual(expected, calculationFormula.Corner);
            Assert.AreEqual(expected, calculationFormula.Length);
            Assert.AreEqual(expected, calculationFormula.AngleOfRotation);
        }


        [Test]
        public void Coefficient_ChangeAccess()
        {
            // Переменые
            float expected = 2;

            Coefficient.AStarSearch = expected;
            Coefficient.Height = expected;
            Coefficient.Corner = expected;
            Coefficient.Length = expected;
            Coefficient.AngleOfRotation = expected;

            //Проверка
            Assert.AreEqual(expected, Coefficient.AStarSearch);
            Assert.AreEqual(expected, Coefficient.Height);
            Assert.AreEqual(expected, Coefficient.Corner);
            Assert.AreEqual(expected, Coefficient.Length);
            Assert.AreEqual(expected, Coefficient.AngleOfRotation);
        }

        [Test]
        public void Configuration_ChangeAccess()
        {
            // Переменые
            int expected_int = 2;
            float expected_float = 2;
            Point point = new Point(1, 1);
            int size_core = 2;
            int map_size = 10;


            Configuration.AltitudeMin = expected_int;
            Configuration.AltitudeMax = expected_int;
            Configuration.CornerHeightsMin = expected_float;
            Configuration.CornerHeightsMax = expected_float;
            Configuration.LengthMax = expected_float;
            Configuration.CornerMin = expected_float;
            Configuration.End = point;
            Configuration.Size = size_core;
            Configuration.Map = new int?[map_size, map_size];

            //Проверка
            Assert.AreEqual(expected_int, Configuration.AltitudeMin);
            Assert.AreEqual(expected_int, Configuration.AltitudeMax);
            Assert.AreEqual(expected_float, Configuration.CornerHeightsMin);
            Assert.AreEqual(expected_float, Configuration.CornerHeightsMax);
            Assert.AreEqual(expected_float, Configuration.LengthMax);
            Assert.AreEqual(expected_float, Configuration.CornerMin);
            Assert.AreEqual(point, Configuration.End);
            Assert.AreEqual(size_core, Configuration.Size);
            Assert.AreEqual(16, Cof.DIRS.Length);
            Assert.AreEqual(new int[map_size, map_size].Length, Configuration.Map.Length);
        }

    }
}