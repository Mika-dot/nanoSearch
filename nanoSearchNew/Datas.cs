using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SharpGL.SceneGraph.Primitives;
using AgentSmith.Settings;
using AgentSmith;
using System.Numerics;
using GraphicArts;

namespace nanoSearchNew
{
    public class Datas
    {
        public PolygonS polygon;

        public struct House
        {
            public Vector2 Pos;
            public Vector3 Size;
            public float Angle;
        }
        public struct Polygon
        {
            public byte Type;
            public Vector2[] Points;
        }
        public struct Road
        {
            public Vector3 Start, End;
            public float Width;
        }
        public struct LEP
        {
            public Vector2 Pos;
            public int[] Connections;
            public float Height;
        }
        public struct WorldStruct
        {
            public House[] Houses;
            public Polygon[] Polygons;
            public LEP[] LEPs;
            public LEP[] GASs;
            public Road[] RoadsSHCO;
            public Road[] RoadsASPHALT;
            public Road[] RoadsGROUND;
            public Road[] Rivers;
        }

    }
}
