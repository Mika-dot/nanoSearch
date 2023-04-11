using agentConfiguration;
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
        private float? gradientDescent(PointZ cordinat, Point historyPosition)
        {
            // невебическая формула от 5*2 параметров
            AStarSearch(cordinat.Your); // а-звезда от новой точки
            Height(cordinat); // высота до новой точки 
            Corner(cordinat); // угол вертикали
            Length(cordinat); // длина
            AngleOfRotation(historyPosition, cordinat); // угол поворота
            return null; // допилить 
        }


        private AStarSearch? AStarSearch(Point start)
        {
            return new AStarSearch(configuration.grid, start, configuration.end);
        }

        private int Height(PointZ cordinat)
        {
            return (int)Range(configuration.AltitudeMin, configuration.AltitudeMax, configuration.Map[cordinat.My.X, cordinat.My.Y] - configuration.Map[cordinat.Your.X, cordinat.Your.Y]);
        }
        private float? Corner(PointZ cordinat)
        {
            int? height = Height(cordinat);
            if (!height.HasValue) return null;
            return Range(configuration.CornerMin, configuration.CornerMax, Cos(cordinat, height.Value));
        }

        private float Length(PointZ cordinat)
        {
            return (float)Range(0, configuration.lengthMax, EuclideanDistance(cordinat));
        }

        public float AngleOfRotation(Point historyPosition, PointZ cordinat)
        {
            return (float)Range(configuration.cornerMin, 0, AnglePoint(historyPosition, cordinat.My, cordinat.Your));
        }
    }
}
