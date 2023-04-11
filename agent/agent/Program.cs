using agentConfiguration;
using agentCoefficient;
using agentGradient;
using agentMathematics;
using agentAStar;


using System.Drawing;


class agent
{
    public agent(int[,] Map)
    {
        configuration.Map = Map;
    }
    public int[,] changes
    {
        get => configuration.Map;
        set => configuration.Map = value;
    }
    public Point? AgentActions(Point position, Point historyPosition)
    {
        // длиный код
        // следующего действия
        // ход по сетки 16
        return null;
    }

}



