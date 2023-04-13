using agentAStar;
using agentCalculationFormula;
using agentCoefficient;
using agentConfiguration;
using agentMathematics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agentGradient
{
    class gradient : mathematics
    {
        public (float, bool[]) gradientDescent(Point cordinatMy, Point cordinatYour, Point historyPosition)
        {
            PointZ cordinat = new PointZ(cordinatMy, cordinatYour);
            // невебическая формула от 5*2 параметров
            int aStarSearch = AStarSearch(cordinatYour); // а-звезда от новой точки
            (int value, bool flag) height = Height(cordinat); // высота до новой точки 
            ((float value, bool flag) complex, bool flag) corner = Corner(cordinat); // угол вертикали
            (float value, bool flag) length = Length(cordinat); // длина
            (float value, bool flag) angleOfRotation = AngleOfRotation(historyPosition, cordinat); // угол поворота

            float grad =
                FunctionEvaluation(aStarSearch, calculationFormula.AStarSearch) * coefficient.AStarSearch +
                FunctionEvaluation(height.value , calculationFormula.Height) * coefficient.Height +
                FunctionEvaluation(corner.complex.value, calculationFormula.Corner) * coefficient.Corner +
                FunctionEvaluation(length.value, calculationFormula.Length) * coefficient.Length +
                FunctionEvaluation(angleOfRotation.value, calculationFormula.AngleOfRotation) * coefficient.AngleOfRotation;

            return (grad, new bool[] { height.flag, corner.complex.flag, corner.flag, length .flag, angleOfRotation.flag});
        }


        private int AStarSearch(Point start)
        {
            int count = 0;
            //List<Point> FinalPoints = new List<Point>();
            AStarSearch startInstance = new AStarSearch(configuration.grid, start, configuration.end);
            Point p = configuration.end;
            while (p != start)
            {
                count++;
                //FinalPoints.Add(p);
                p = startInstance.cameFrom[p];
            }
            count++;
            //FinalPoints.Add(p);
            return count;
        }

        private (int, bool) Height(PointZ cordinat) // высота
        {
            return Range(configuration.AltitudeMin, configuration.AltitudeMax, configuration.Map[cordinat.My.X, cordinat.My.Y] - configuration.Map[cordinat.Your.X, cordinat.Your.Y]);
        }
        private ((float, bool), bool) Corner(PointZ cordinat) // угол вертикали
        {
            (int value, bool flag) height = Height(cordinat);
            return (Range(configuration.CornerMin, configuration.CornerMax, Cos(cordinat, height.value)), height.flag);
        }

        private (float, bool) Length(PointZ cordinat)
        {
            return Range(0, configuration.lengthMax, EuclideanDistance(cordinat));
        }

        public (float, bool) AngleOfRotation(Point historyPosition, PointZ cordinat)
        {
            return Range(configuration.cornerMin, 0, AnglePoint(historyPosition, cordinat.My, cordinat.Your));
        }
    }
}
