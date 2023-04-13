using agentConfiguration;
using agentCoefficient;
using agentGradient;
using agentMathematics;
using agentAStar;


using System.Drawing;


class agent
{
    public agent(int[,] Maps)
    {
        configuration.Map = Maps;
         
    }
    public int[,] changes
    {
        get => configuration.Map;
        set => configuration.Map = value;
    }
    public (Point, bool[]) AgentActions(Point position, Point historyPosition)
    {
        gradient gr = new gradient();
        Point offset;
        int Best = -1;
        bool[] Flags = null;
        float BestF = float.MaxValue;
        var l = configuration.Map.GetLength(0);
        float[] fff = new float[SquareGrid.DIRS.Length];
        for (int i = 0; i < SquareGrid.DIRS.Length; i++)
        {
            offset = new Point(SquareGrid.DIRS[i].X, SquareGrid.DIRS[i].Y);
            Point res = new Point(position.X + offset.X, position.Y + offset.Y);
            if (res.X < 0 || res.Y < 0 || res.X >= l || res.Y >= l) continue;
            (float value, bool[] flags) flres = gr.gradientDescent(position, res, historyPosition);
            fff[i] = flres.value;
            if (flres.value < BestF)
            {
                Best = i;
                Flags = flres.flags;
                BestF = flres.value;
            }
        }
        offset = new Point(SquareGrid.DIRS[Best].X, SquareGrid.DIRS[Best].Y);
        
        return (new Point(position.X + offset.X, position.Y + offset.Y), Flags);
    }

}



