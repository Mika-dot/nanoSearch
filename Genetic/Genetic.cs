using AgentSmith;
using System.Drawing;
using static AgentSmith.Agent;
using Architect;
using System.Collections.Generic;
using AgentSmith.Settings;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Genetic
{
    public class Genetic
    {


        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }


        [Serializable]
        public class genom
        {
            public float[] Coefficent;
            public float[][,] CalculationFormulas;
        }
        public static genom LastGenom;
        public static List<Point> LastBestPoints = null;

        public static void Execute(int?[,] Map, Point start, Point end)
        {
            // Задаем начальные параметры
            LastGenom.Coefficent = new float[] { 1, 0, 0, 0, 0 };
            var Count = LastGenom.Coefficent.Length;
            LastGenom.CalculationFormulas = new float[Count][,];
            for (int i = 0; i < Count; i++)
                LastGenom.CalculationFormulas[i] = new float[,] { { 0, 0 }, { 1, 1 }, { 2, 2 }, { 3, 3 } };
            LastBestPoints = shortLife(LastGenom, Map, start, end);
            Random r = new();
            for (int i = 0; i < 5000; i++) // n-ное количество поколений
            {
                var GenomCopy = DeepClone<genom>(LastGenom);
                // Производим мутации и изменения в геноме
                bool b1 = false;
                if (r.NextDouble() > 0.5)
                {
                    // Проводим изменения в коэффициенте
                    GenomCopy.Coefficent[r.Next(0, Count)] = (float)r.NextDouble();
                    b1 = true;
                }
                if (b1 || r.NextDouble() > 0.5)
                {
                    // Проводим изменения в ланграже
                    var dim = GenomCopy.CalculationFormulas[r.Next(0, Count)].GetLength(0);
                    GenomCopy.CalculationFormulas[r.Next(0, Count)][r.Next(0, dim), r.Next(0, 2)] = (float)r.Next(0, 200);
                }
            }
        }

        public float price(genom Genom, int?[,] Map, Point start, Point end, List<Point> put)
        {
            List<Point> genomHod = shortLife(Genom, Map, start, end);

            // Тут нужно написать функцию оценки пути. Через интегралы и т.д.

            return 1f;
        }


        /// <summary>
        /// Превращает геном в значения привычные для Смита и запускает его
        /// </summary>
        /// <param name="Genom">Геном алогитма</param>
        /// <param name="Map">Карта по которому теститца геном</param>
        /// <param name="start">Точка старта на карте</param>
        /// <param name="end">Точка финиша на карте</param>
        /// <returns>Точки моршрута по гиному</returns>
        static List<Point> shortLife(genom Genom, int?[,] Map, Point start, Point end)
        {
            var res = Recursion.Recursions(
                        new Agent(Map, start, end)
                        .Criterion(CriterionName.AngleOfRotation, Genom.Coefficent[0]).NonlinearFunction(CriterionName.AngleOfRotation, Genom.CalculationCalculationFormulass[0])
                        .Criterion(CriterionName.AStar, Genom.Coefficent[1]).NonlinearFunction(CriterionName.AStar, Genom.CalculationFormulas[1])
                        .Criterion(CriterionName.Height, Genom.Coefficent[2]).NonlinearFunction(CriterionName.Height, Genom.CalculationFormulas[2])
                        .Criterion(CriterionName.Length, Genom.Coefficent[3]).NonlinearFunction(CriterionName.Length, Genom.CalculationFormulas[3])
                        .Criterion(CriterionName.Corner, Genom.Coefficent[4]).NonlinearFunction(CriterionName.Corner, Genom.CalculationFormulas[4])
                        , 1);
            return res[^1].Item1;
        }
    }
}