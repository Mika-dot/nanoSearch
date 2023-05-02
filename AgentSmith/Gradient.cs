using A_Star;
using AgentSmith.Settings;
using System.Drawing;
using System.Reflection;

namespace AgentSmith
{
    public class Gradient : Mathematics
    {
        /// <summary>
        /// Функция расчета стоимости клетки, орентируясь по фильтрам
        /// </summary>
        /// <param name="cordinatMy">Моя текущая позиция</param>
        /// <param name="cordinatYour">Иследуемая координата</param>
        /// <param name="historyPosition">Историческа или придыдущая координата</param>
        /// <returns>Цена хода</returns>
        public (float, bool[]) GradientDescent(Point cordinatMy, Point cordinatYour, Point historyPosition)
        {

            //if (cordinatYour == null) { }

            PointZ cordinat = new(cordinatMy, cordinatYour);

            List<Tuple<float, bool>> aStarSearchList = new List<Tuple<float, bool>>();

            switch (Coefficient.AStarSearch)
            {
                case 0:
                    break;
                default:
                    (float value, bool flag) temp = AStarSearch(cordinatYour);
                    aStarSearchList.Add(Tuple.Create(FunctionEvaluation(temp.value, calculationFormula.AStarSearch) * Coefficient.AStarSearch, temp.flag));
                    break;
            }

            switch (Coefficient.Height)
            {
                case 0:
                    break;
                default:
                    (float value, bool flag) temp = Height(cordinat);
                    aStarSearchList.Add(Tuple.Create(FunctionEvaluation(temp.value, calculationFormula.Height) * Coefficient.Height, temp.flag));
                    break;
            }

            switch (Coefficient.Corner)
            {
                case 0:
                    break;
                default:
                    (float value, bool flag) temp = Corner(cordinat);
                    aStarSearchList.Add(Tuple.Create(FunctionEvaluation(temp.value, calculationFormula.Corner) * Coefficient.Corner, temp.flag));
                    break;
            }

            switch (Coefficient.Length)
            {
                case 0:
                    break;
                default:
                    (float value, bool flag) temp = Length(cordinat);
                    aStarSearchList.Add(Tuple.Create(FunctionEvaluation(temp.value, calculationFormula.Length) * Coefficient.Length, temp.flag));
                    break;
            }

            switch (Coefficient.AngleOfRotation)
            {
                case 0:
                    break;
                default:
                    (float value, bool flag) temp = AngleOfRotation(historyPosition, cordinat);
                    aStarSearchList.Add(Tuple.Create(FunctionEvaluation(temp.value, calculationFormula.AngleOfRotation) * Coefficient.AngleOfRotation, temp.flag));
                    break;
            }

            bool[] flag = new bool[aStarSearchList.Count];
            float sum = aStarSearchList.Sum(x => x.Item1);//.Where(t => t.Item2).Aggregate(0f, (acc, t) => acc + t.Item1);
            for (int i = 0; i < aStarSearchList.Count; i++) flag[i] = aStarSearchList[0].Item2;


            return (sum, flag);

        }

        /// <summary>
        /// Метод оценки пути
        /// </summary>
        /// <param name="start">Текущая позиция</param>
        /// <returns>Цена пути и нарушает ли он критерии</returns>
        private (float, bool) AStarSearch(Point start)
        {
            float result = 0;
            List<Point> FinalPoints = new List<Point>();
            AStar startInstance = new AStar(Configuration.grid, start, Configuration.End, ref Configuration._map);
            Point current = Configuration.End;
            while (current != start)
            {
                FinalPoints.Add(current);
                var past = startInstance.cameFrom[current];
                result += (float)AStar.Heuristic(current, past);
                current = past;
            }

            FinalPoints.Add(current);
            return (result, false);
        }

        /// <summary>
        /// Метод оценки разницы высот
        /// </summary>
        /// <param name="cordinat">Текущая позиция</param>
        /// <returns>Цена</returns>
        private (float, bool) Height(PointZ cordinat) // высота
        {
            return Range(Configuration.AltitudeMin, Configuration.AltitudeMax, Configuration.Map[cordinat.My.X, cordinat.My.Y].Value - Configuration.Map[cordinat.Your.X, cordinat.Your.Y].Value);
        }

        /// <summary>
        /// Метод оценки угла вертикали
        /// </summary>
        /// <param name="cordinat">Текущая позиция</param>
        /// <returns>Цена</returns>
        private (float, bool) Corner(PointZ cordinat) // угол вертикали
        {
            (float value, bool flag) height = Height(cordinat);
            return Range(Configuration.CornerHeightsMin, Configuration.CornerHeightsMax, Cos(cordinat, height.value));

        }

        /// <summary>
        /// Метод оценки растояния до следующей точки
        /// </summary>
        /// <param name="cordinat">Текущая позиция</param>
        /// <returns>Цена</returns>
        private (float, bool) Length(PointZ cordinat)
        {
            return Range(0, Configuration.LengthMax, EuclideanDistance(cordinat));
        }

        /// <summary>
        /// Метод оценки угла в плоскости
        /// </summary>
        /// <param name="historyPosition">Предыдущая кордината</param>
        /// <param name="cordinat"></param>
        /// <returns></returns>
        private (float, bool) AngleOfRotation(Point historyPosition, PointZ cordinat)
        {
            return Range(Configuration.CornerMin, 0, AnglePoint(historyPosition, cordinat.My, cordinat.Your));
        }
    }
}
