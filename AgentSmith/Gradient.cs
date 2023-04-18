using A_Star;
using AgentSmith.Settings;
using System.Drawing;

namespace AgentSmith
{
    public class Gradient : Mathematics
    {
        public (float, bool[]) GradientDescent(Point cordinatMy, Point cordinatYour, Point historyPosition)
        {
            PointZ cordinat = new(cordinatMy, cordinatYour);
            // невебическая формула от 5*2 параметров
            float aStarSearch = AStarSearch(cordinatYour); // а-звезда от новой точки
            (int value, bool flag) height = Height(cordinat); // высота до новой точки 
            ((float value, bool flag) complex, bool flag) corner = Corner(cordinat); // угол вертикали
            (float value, bool flag) length = Length(cordinat); // длина
            (float value, bool flag) angleOfRotation = AngleOfRotation(historyPosition, cordinat); // угол поворота

            float grad =
                FunctionEvaluation(aStarSearch, calculationFormula.AStarSearch) * Coefficient.AStarSearch +
                FunctionEvaluation(height.value, calculationFormula.Height) * Coefficient.Height +
                FunctionEvaluation(corner.complex.value, calculationFormula.Corner) * Coefficient.Corner +
                FunctionEvaluation(length.value, calculationFormula.Length) * Coefficient.Length +
                FunctionEvaluation(angleOfRotation.value, calculationFormula.AngleOfRotation) * Coefficient.AngleOfRotation;

            return (grad, new bool[] { height.flag, corner.complex.flag, corner.flag, length.flag, angleOfRotation.flag });
        }


        private float AStarSearch(Point start)
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
            return result;

        }

        private (int, bool) Height(PointZ cordinat) // высота
        {
            return Range(Configuration.AltitudeMin, Configuration.AltitudeMax, Configuration.Map[cordinat.My.X, cordinat.My.Y] - Configuration.Map[cordinat.Your.X, cordinat.Your.Y]);
        }
        private ((float, bool), bool) Corner(PointZ cordinat) // угол вертикали
        {
            (int value, bool flag) height = Height(cordinat);
            return (Range(Configuration.CornerHeightsMin, Configuration.CornerHeightsMax, Cos(cordinat, height.value)), height.flag);
        }

        private (float, bool) Length(PointZ cordinat)
        {
            return Range(0, Configuration.LengthMax, EuclideanDistance(cordinat));
        }

        public (float, bool) AngleOfRotation(Point historyPosition, PointZ cordinat)
        {
            return Range(Configuration.CornerMin, 0, AnglePoint(historyPosition, cordinat.My, cordinat.Your));
        }
    }
}
