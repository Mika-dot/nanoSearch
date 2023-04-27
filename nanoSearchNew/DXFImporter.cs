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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DXFImport
{
    public class Importer
    {

        public static void Everything()
        {
            DxfDocument dxf = DxfDocument.Load("Трасса_Автодороги3.dxf", new List<string> { @".\Support" });
            var l = dxf.Layers["ИИ_Растительность"];
            var found = dxf.Entities.All.Where(x => x.Layer == l);
            //(dxf.Entities.Hatches.ElementAt(0).BoundaryPaths.ElementAt(0).Entities.ElementAt(0) as Polyline2D).Vertexes//.Edges.ElementAt(0).
            var c = found.Count();
            //MessageBox.Show(c.ToString());
            var DATA2 = new nanoSearchNew.Datas.WorldStruct();
            DATA2.Polygons = new nanoSearchNew.Datas.Polygon[c];
            int cc = 0;
            foreach (var o in found)
            {
                if (o.Type == EntityType.Hatch)
                {
                    var hatch = (o as Hatch);
                    var paths = hatch.BoundaryPaths.SelectMany(x => x.Entities.SelectMany(y => (y as Polyline2D).Vertexes)).ToArray();
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

                        DATA2.Polygons[cc].Points = poses_loc.Distinct().ToArray();
                    }
                    cc++;
                }
                //MessageBox.Show(

                //    o.Type + ", " + o.CodeName + ", "
                //    + string.Join(


                //        ";\r\n==\r\n", o.XData.Select(

                //            x => x.Key + ":\r\n" + string.Join(

                //                "\r\n", x.Value.XDataRecord.Select(

                //                    y => y.Code + " >> " + y.Value.ToString()

                //                    )

                //                )

                //            )

                //        )

                //    );
                //    MessageBox.Show($"{o.Name}; References count: {dxf.Layers.GetReferences(o).Count}");
                //    if (o.Name == "ИИ_Растительность")
                //    {
                //        var objs = dxf.Layers.GetReferences(o);
                //        foreach (var obj in objs)
                //        {
                //            obj.XData["ddf"].
                //        }
                //        objs[0].XData.Values.ElementAt(0).
                //    }
                //    //Debug.Assert(ReferenceEquals(o.Linetype, dxf.Linetypes[o.Linetype.Name]), "Object reference not equal.");
            }
            File.WriteAllText("DATA 2.json", JsonConvert.SerializeObject(DATA2, Formatting.Indented));
        }
    }
}