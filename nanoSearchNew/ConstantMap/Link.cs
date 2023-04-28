using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nanoSearchNew.ConstantMap
{
    /// <summary>
    /// Путь до файлов с 3d моделями
    /// </summary>
    public class Link
    {
        public static string HouseTim { get; set; } = "null.stl";
        public static string House { get; set; } = "q.stl";
        public static string Road { get; set; } = "null.stl";
        public static string River { get; set; } = "null.stl";
        public static string Tree { get; set; } = "null.stl";
        public static string PowerLines { get; set; } = "null.stl";
        public static string GasPipes { get; set; } = "null.stl";

        public static string Map { get; set; } = "1.png";

        public static string DXFFile { get; set; } = "Трасса_Автодороги3.dxf";

        public static string Json { get; set; } = "DATA 2.json";

        public static string Res { get; set; } = "res.png";

        

    }
}
