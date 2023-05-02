using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using netDxf;
using netDxf.Blocks;
using netDxf.Collections;
using netDxf.Entities;
using GTE = netDxf.GTE;
using netDxf.Header;
using netDxf.Objects;
using netDxf.Tables;
using netDxf.Units;
using Attribute = netDxf.Entities.Attribute;
using FontStyle = netDxf.Tables.FontStyle;
using Image = netDxf.Entities.Image;
using Point = netDxf.Entities.Point;
using Trace = netDxf.Entities.Trace;
using Vector2 = netDxf.Vector2;
using Vector3 = netDxf.Vector3;
using Newtonsoft.Json;
//using static System.Runtime.InteropServices.JavaScript.JSType;
using nanoSearchNew.ConstantMap;

namespace DXFImport
{
    public class Importer
    {

        public static void Everything()
        {
            DxfDocument dxf = DxfDocument.Load(Link.DXFFile, new List<string> { @".\Support" });
            var l = dxf.Layers["ИИ_Растительность"];
            var found = dxf.Entities.All.Where(x => x.Layer == l);

            var l2 = dxf.Layers["ИИ_Границы_землепользования"];
            var found2 = dxf.Entities.All.Where(x => x.Layer == l2);

            var c = found.Count() + found2.Count();
            //MessageBox.Show(c.ToString());
            var DATA2 = new nanoSearchNew.Datas.WorldStruct();
            //DATA2.Polygons = new nanoSearchNew.Datas.Polygon[c];
            List<nanoSearchNew.Datas.Polygon> pols = new();
            //int cc = 0;
            void load_to_polys(ref IEnumerable<EntityObject> what, int type)
            {
                foreach (var o in what)
                {
                    if (o.Type == EntityType.Hatch || o.Type == EntityType.Polyline2D)
                    {
                        var hatch = (o as Hatch);
                        var poly = (o as Polyline2D);
                        var paths = o.Type == EntityType.Hatch ?
                            hatch.BoundaryPaths.SelectMany(x => x.Entities.SelectMany(y => (y as Polyline2D).Vertexes)).ToArray()
                            : poly.Vertexes.ToArray()
                            ;
                        if (paths.Length > 0)
                        {
                            List<System.Numerics.Vector2> poses_loc = new();
                            int last = 0;
                            poses_loc.Add(new System.Numerics.Vector2((int)(paths[0].Position.X / 100.0), (int)(paths[0].Position.Y / 100.0)));
                            int i = 1;
                            while (i < paths.Length)
                            {
                                if (i % 2 == 0)//Vector2.Distance(paths[i].Position, paths[last].Position) > 200f)
                                {
                                    poses_loc.Add(new System.Numerics.Vector2((int)(paths[i].Position.X / 100.0), (int)(paths[i].Position.Y / 100.0)));
                                    //last = i;
                                }
                                else
                                {

                                }
                                i++;
                            }
                            //MessageBox.Show($"Hatch, {poses_loc.Count}");
                            var pol = new nanoSearchNew.Datas.Polygon();
                            pol.Type = (byte)type;
                            pol.Points = poses_loc.Distinct().ToArray();
                            pols.Add(pol);
                        }
                    }
                    else MessageBox.Show(o.Type.ToString());

                }
            }
            load_to_polys(ref found, 0);
            load_to_polys(ref found2, 1);
            DATA2.Polygons = pols.ToArray();
            
            
            File.WriteAllText("DATA 2.json", JsonConvert.SerializeObject(DATA2, Formatting.Indented));
        }
    }
}