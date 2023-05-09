using Microsoft.AspNetCore.Mvc;
using nanoSearchWebAPI;
using NLog;
using NLog.Fluent;
using System.Xml.Linq;
using Architect;
using AgentSmith.Settings;
using AgentSmith;
using System.Drawing;
using System.Net;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/{id}", (string id) =>
//{
//    Looger.Logger.Trace("Запрос: {id}", id);
//    return Results.Json(id);
//});
app.MapGet("/calc", (
    [FromQuery] string bitmap_path,
    [FromQuery] int StartX,
    [FromQuery] int StartY,
    [FromQuery] int EndX,
    [FromQuery] int EndY,
    [FromQuery] int? longs,
    [FromQuery] float? angle,
    //[FromQuery] float? corner,
    [FromQuery] int? size,

    // Готовы
    [FromQuery] int? AltitudeMin,
    [FromQuery] int? AltitudeMax,
    [FromQuery] float? CornerHeightsMin,
    [FromQuery] float? CornerHeightsMax,
    [FromQuery] float? LengthMax,
    [FromQuery] float? CornerMin,

    // Готовы
    [FromQuery] string? AStarSearch,
    [FromQuery] string? Height,
    [FromQuery] string? Corner,
    [FromQuery] string? Length,
    [FromQuery] string? AngleOfRotation,

    // Готовы
    [FromQuery] float? CoefficientAStarSearch,
    [FromQuery] float? CoefficientHeight,
    [FromQuery] float? CoefficientCorner,
    [FromQuery] float? CoefficientLength,
    [FromQuery] float? CoefficientAngleOfRotation
    ) =>
{

    WebClient webClient = new WebClient();
    byte[] imageData = webClient.DownloadData(bitmap_path);

    // Создаем Bitmap из загруженных байтов
    Bitmap bitmap;
    using (var stream = new MemoryStream(imageData))
    {
        bitmap = new Bitmap(stream);
    }
    int?[,] points = new int?[bitmap.Width, bitmap.Height];
    for (int x = 0; x < bitmap.Width; x++)
        for (int y = 0; y < bitmap.Height; y++)
            points[x, y] = bitmap.GetPixel(x, y).R;

    Configuration.Size = size ?? Configuration.Size;
    Configuration.AltitudeMin = AltitudeMin ?? Configuration.AltitudeMin;
    Configuration.AltitudeMax = AltitudeMax ?? Configuration.AltitudeMax;
    Configuration.CornerHeightsMin = CornerHeightsMin ?? Configuration.CornerHeightsMin;
    Configuration.CornerHeightsMax = CornerHeightsMax ?? Configuration.CornerHeightsMax;
    Configuration.CornerMin = CornerMin ?? Configuration.CornerMin;
    Configuration.LengthMax = LengthMax ?? Configuration.LengthMax;

    Coefficient.AStarSearch = CoefficientAStarSearch ?? Coefficient.AStarSearch;
    Coefficient.Height = CoefficientHeight ?? Coefficient.Height;
    Coefficient.Corner = CoefficientCorner ?? Coefficient.Corner;
    Coefficient.Length = CoefficientLength ?? Coefficient.Length;
    Coefficient.AngleOfRotation = CoefficientAngleOfRotation ?? Coefficient.AngleOfRotation;


    void ParseThis(string? what, ref float[,] where)
    {
        if (what?.Length > 0)
        {
            var SS = what.Split(',');
            var pointsA = new float[SS.Length / 2, 2];
            for (int i = 0; i < SS.Length; i += 2)
            {
                pointsA[i / 2, 0] = float.Parse(SS[i]);
                pointsA[i / 2, 1] = float.Parse(SS[i + 1]);
            }
            where = pointsA; // на случай кривого парсинга оставляем это на конец
        }
    }

    ParseThis(AStarSearch, ref calculationFormula.AStarSearch);
    ParseThis(Height, ref calculationFormula.Height);
    ParseThis(Corner, ref calculationFormula.Corner);
    ParseThis(Length, ref calculationFormula.Length);
    ParseThis(AngleOfRotation, ref calculationFormula.AngleOfRotation);

    var smith = new Agent(points, new Point(StartX, StartY), new Point(EndX, EndY));
    List<(List<Point> Path, List<(Point Point, bool[] Flags)> PathWithErrors)> result;
    if (longs.HasValue)
        result = Recursion.Recursions(smith, longs.Value);
    else
        result = Recursion.Recursions(smith);
    //Looger.Logger.Trace($"Запрос на создание: {id} {shift}");
    return Results.Text(JsonConvert.SerializeObject(result));//$"Запрос на создание: {StartX} {StartY} ---> {EndX} {EndY}");
});

app.MapGet("/", () => "Инструкция /n напишите /Bookodd/5 или /Tennisi/4");

app.Run();
