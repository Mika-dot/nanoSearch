using AgentSmith.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSmith
{
    public class Tuning
    {
        public enum CriterionName : int
        {
            AStar,
            Height,
            Corner,
            Length,
            AngleOfRotation,
        }

        public enum Border : int
        {
            AltitudeMin,
            AltitudeMax,
            CornerHeightsMin,
            CornerHeightsMax,
            LengthMax,
            CornerMin,
        }

        public Tuning Criterion(CriterionName name, float coefficient = 1 )
        {
            switch (name)
            {
                case CriterionName.AStar :
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

        public Tuning NonlinearFunction(CriterionName name, float[,] points = null)
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

        public Tuning BorderValuesFlags(Border name, float value)
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

        //Configuration
    }
}
