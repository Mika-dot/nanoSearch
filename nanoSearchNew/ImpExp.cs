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
using static MapCalculator.MapHelper;
using static nanoSearchNew.Datas;
using nanoSearchNew.ConstantMap;

namespace nanoSearchNew
{
    public class ImportExport
    {

        public static void MainLoader()
        {
            DXFImport.Importer.Everything();

            LoadDATA(Link.Json);

            //LoadDATA();
            var bmp = new Bitmap(Link.Map, true);//Берем изображение шума из ресурсов
            xC = bmp.Width;
            zC = bmp.Height;
            points = new int[xC, zC];
            for (int i = 0; i < xC; i++)
                for (int j = 0; j < zC; j++)
                {
                    points[i, j] = (int)(bmp.GetPixel(i, j).GetBrightness() * maxHeightMap);//Генерируем карту высот по яркости пикселем
                }

            CalculateEverything();
        }

        public static void LoadDATA(string f)
        {
            if (!File.Exists(f)) SaveDATA(f);
            DATA = JsonConvert.DeserializeObject<WorldStruct>(File.ReadAllText(f));

            OffsetX = int.MaxValue;
            OffsetY = int.MaxValue;
            foreach (var pol in DATA.Polygons)
            {
                foreach (var v in pol.Points)
                {
                    if (OffsetX > v.X) OffsetX = (int)v.X;
                    if (OffsetY > v.Y) OffsetY = (int)v.Y;

                    if (MaxX < v.X) MaxX = (int)v.X;
                    if (MaxY < v.Y) MaxY = (int)v.Y;
                }
            }

            for (int i = 0; i < DATA.Polygons.Length; i++)
            {
                for (int j = 0; j < DATA.Polygons[i].Points.Length; j++)
                    DATA.Polygons[i].Points[j] = new Vector2(DATA.Polygons[i].Points[j].X - OffsetX, DATA.Polygons[i].Points[j].Y - OffsetY);
            }
        }
        public static void SaveDATA(string f)
        {
            if (DATA.Houses == null) DATA.Houses = new House[1];
            if (DATA.RoadsSHCO == null) DATA.RoadsSHCO = new Road[1];
            if (DATA.RoadsASPHALT == null) DATA.RoadsASPHALT = new Road[1];
            if (DATA.RoadsGROUND == null) DATA.RoadsGROUND = new Road[1];
            if (DATA.Rivers == null) DATA.Rivers = new Road[1];
            if (DATA.LEPs == null)
            {
                DATA.LEPs = new LEP[1];
                DATA.LEPs[0].Connections = new int[0];
            }
            if (DATA.GASs == null)
            {
                DATA.GASs = new LEP[1];
                DATA.GASs[0].Connections = new int[0];
            }
            if (DATA.Polygons == null)
            {
                DATA.Polygons = new Datas.Polygon[1];
                DATA.Polygons[0].Points = new Vector2[1];
            }
            File.WriteAllText(f, JsonConvert.SerializeObject(DATA));
        }

    }
}