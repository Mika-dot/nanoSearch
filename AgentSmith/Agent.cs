using A_Star;
using A_Star.Core;
using AgentSmith.Settings;
using System.Drawing;
using System.Reflection;


namespace AgentSmith
{
    public class Agent
    {

        /// <summary>
        /// Конструктор экземпляра агента как логике
        /// </summary>
        /// <param name="Maps">Веса карты как массив</param>
        /// <param name="end">Точка финиша, куда будет стремиться алгоритм</param>
        public Agent(int?[,] Maps, Point end, Point Start)
        {
            Configuration.Map = Maps;
            Configuration.End = end;
            Configuration.Start = Start;
        }

        /// <summary>
        /// Названия фильтра оценки критерия алгоритма
        /// </summary>
        public enum CriterionName : int
        {
            AStar,
            Height,
            Corner,
            Length,
            AngleOfRotation,
        }

        /// <summary>
        /// Название критериев краев, нарушения условий
        /// </summary>
        public enum Border : int
        {
            AltitudeMin,
            AltitudeMax,
            CornerHeightsMin,
            CornerHeightsMax,
            LengthMax,
            CornerMin,
        }

        /// <summary>
        /// Основной метод выдающий оптимальную позицию для перемещения
        /// </summary>
        /// <param name="position">Текущая позиция</param>
        /// <param name="historyPosition">Старая позиция</param>
        /// <returns></returns>
        public (Point, bool[])? AgentActions(Point position, Point historyPosition)
        {
            Gradient gradient = new Gradient();
            int lengthMap = Configuration.Map.GetLength(0);
            Task<TupleMy>[]Johnson = new Task<TupleMy>[Cof.DIRS.Length];
            for (int i = 0; i < Johnson.Length; i++)
            {
                var n = i;
                Johnson[n] = new Task<TupleMy>(() => Tuples.AgentMorris(position, n, lengthMap, gradient, historyPosition));
                Johnson[n].Start();
            }

            Task.WaitAll(Johnson);

            int Best = -1;
            bool[] Flags = new bool[5];

            float dot = float.MaxValue;
            for (int i = 0; i < Johnson.Length; i++)
            {
                var agents = Johnson[i];
                TupleMy result = agents.Result;
                if (result.Value() < dot)
                {
                    Best = i;
                    Flags = result.Flags();
                    dot = result.Value();
                    if (dot == 0) // оператор "раннего выхода"
                        break;
                }
            }

            if (Best == -1) return null;

            Point offset = new Point(Cof.DIRS[Best].X, Cof.DIRS[Best].Y);

            return (new Point(position.X + offset.X, position.Y + offset.Y), Flags);
        }

        /// <summary>
        /// Создания фильтра оценки стоимости следующей клетки. Список смотреть в CriterionName.
        /// </summary>
        /// <param name="name">Названия критерия</param>
        /// <param name="coefficient">Необязательный параметр, коффицент значимости фильтра</param>
        /// <returns>Позволят сделать последовательный набор фильтров подряд</returns>
        public Agent Criterion(CriterionName name, float coefficient = 1)
        {
            switch (name)
            {
                case CriterionName.AStar:
                    Coefficient.AStarSearch = coefficient;
                    NonlinearFunction(CriterionName.AStar);
                    break;
                case CriterionName.Height:
                    Coefficient.Height = coefficient;
                    NonlinearFunction(CriterionName.Height);
                    break;
                case CriterionName.Corner:
                    Coefficient.Corner = coefficient;
                    NonlinearFunction(CriterionName.Corner);
                    break;
                case CriterionName.Length:
                    Coefficient.Length = coefficient;
                    NonlinearFunction(CriterionName.Length);
                    break;
                case CriterionName.AngleOfRotation:
                    Coefficient.AngleOfRotation = coefficient;
                    NonlinearFunction(CriterionName.AngleOfRotation);
                    break;
            }
            return this;
        }

        /// <summary>
        /// Создания плавоющей оценки фильтра
        /// </summary>
        /// <param name="name">Названия критерия</param>
        /// <param name="points">Необязательный массив параметров, коффиценты для интрополянта Ньютона</param>
        /// <returns>Позволят сделать последовательный набор фильтров подряд</returns>
        public Agent NonlinearFunction(CriterionName name, float[,] points = null)
        {
            points ??= new float[,] { { 0, 0 }, { 1, 1 }, { 2, 2 }, { 3, 3 } };

            switch (name)
            {
                case CriterionName.AStar:
                    calculationFormula.AStarSearch = points;
                    break;
                case CriterionName.Height:
                    calculationFormula.Height = points;
                    break;
                case CriterionName.Corner:
                    calculationFormula.Corner = points;
                    break;
                case CriterionName.Length:
                    calculationFormula.Length = points;
                    break;
                case CriterionName.AngleOfRotation:
                    calculationFormula.AngleOfRotation = points;
                    break;
            }
            return this;
        }

        /// <summary>
        /// Краевые фильтра пограничных условий
        /// </summary>
        /// <param name="name">Названия критерия</param>
        /// <param name="value">Значения пограничных условий</param>
        /// <returns></returns>
        public Agent BorderValuesFlags(Border name, float value)
        {
            switch (name)
            {
                case Border.AltitudeMin:
                    Configuration.AltitudeMin = (int)value;
                    break;
                case Border.AltitudeMax:
                    Configuration.AltitudeMax = (int)value;
                    break;
                case Border.CornerHeightsMin:
                    Configuration.CornerHeightsMin = value;
                    break;
                case Border.CornerHeightsMax:
                    Configuration.CornerHeightsMax = value;
                    break;
                case Border.LengthMax:
                    Configuration.LengthMax = value;
                    break;
                case Border.CornerMin:
                    Configuration.CornerMin = value;
                    break;
            }
            return this;
        }

    }
}