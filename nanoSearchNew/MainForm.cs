using SharpGL;
using SharpGL.SceneGraph.Raytracing;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Security.Cryptography;
using Newtonsoft.Json;
using SharpGL.SceneGraph.Primitives;
using AgentSmith.Settings;
using AgentSmith;
using DXFImport;
using System.Reflection;
using GraphicArts;
using nanoSearchNew.ConstantMap;

namespace nanoSearchNew
{

    public partial class MainForm : Form
    {

        private void MainForm_Load(object sender, EventArgs e)
        {
            OpenGL gl = openglControl1.OpenGL;
            //gl.Enable(OpenGL.GL_CULL_FACE);
            gl.Enable(OpenGL.GL_DEPTH_TEST);
        }

        Vector3 from_v2(ref Vector2 v, int z) => new Vector3(v.X, v.Y, z);
        public static Model[] Houses;
        public static Model[] LEPs;
        public static Model[] GASs;
        public MainForm()
        {
            ImportExport.MainLoader();

            Houses = new Model[MapCalculator.MapHelper.DATA.Houses?.Length ?? 0];
            for (int i = 0; i < Houses.Length; i++)
            {
                var POS = MapCalculator.MapHelper.DATA.Houses[i].Pos;
                Houses[i].LoadFromObj(new StreamReader(Link.House))
                    .Transformation(0.01f, new Vector3(0, 0f, 0f),
                    from_v2(ref POS, MapCalculator.MapHelper.points[(int)POS.X, (int)POS.Y]),
                    new float[] { 1f, 0, 0 });
            }

            LEPs = new Model[MapCalculator.MapHelper.DATA.LEPs?.Length ?? 0];
            if (LEPs.Length > 0) Load(ref MapCalculator.MapHelper.DATA.LEPs, Link.PowerLines, ref LEPs);
            GASs = new Model[MapCalculator.MapHelper.DATA.GASs?.Length ?? 0];
            if (GASs.Length > 0) Load(ref MapCalculator.MapHelper.DATA.GASs, Link.GasPipes, ref GASs);

            void Load(ref Datas.LEP[] from_where, string fromwhere, ref Model[] where)
            {
                for (int i = 0; i < from_where.Length; i++)
                {
                    var POS = from_where[i].Pos;
                    where[i].LoadFromObj(new StreamReader(fromwhere))
                        .Transformation(0.01f, new Vector3(0, 0f, 0f),
                        from_v2(ref POS, MapCalculator.MapHelper.points[(int)POS.X, (int)POS.Y]),
                        new float[] { 1f, 0, 0 });
                }
            }

            InitializeComponent();


            MapCalculator.MapHelper.CalculatePathOnMap(new Point(0, 150), new Point(120, 40)); // с готовыми данными ищем путь
        }

        #region "Отрисовка"

        private void openglControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            //  Возьмём OpenGL объект
            OpenGL gl = openglControl1.OpenGL;

            //  Очищаем буфер цвета и глубины
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //  Загружаем единичную матрицу
            gl.LoadIdentity();

            // Сдвигаем перо вправо от центра и вглубь экрана, но уже дальше
            gl.Translate(0.0f, 0.0f, 0.0f);

            //stem.stlOutputOBJ(gl, stem, 0, 0, 0);

            MapCalculator.MapHelper.JustRenderEverything(gl);


            MapCalculator.MapHelper.RenderPath(gl);
            // Контроль полной отрисовки следующего изображения
            gl.Flush();
        }
        private void openglControl1_Resized(object sender, EventArgs e)
        {
            //  Возьмём OpenGL объект
            OpenGL gl = openglControl1.OpenGL;

            //  Зададим матрицу проекции
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Единичная матрица для последующих преобразований
            gl.LoadIdentity();

            //  Преобразование
            gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 1000.0);


            //  Данная функция позволяет установить камеру и её положение
            CameraMove.RenderHelp(gl);

            //  Зададим модель отображения
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }
        private void openglControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            //  Возьмём OpenGL объект
            OpenGL gl = openglControl1.OpenGL;

            //  Фоновый цвет по умолчанию (в данном случае цвет голубой)
            gl.ClearColor(0.1f, 0.5f, 1.0f, 0);
        }
        #endregion

        #region "Управление"
        private void button1_Click(object sender, EventArgs e)
        {
            MapCalculator.MapHelper.CalculateEverything();
            //this.Hide();
        }
        private void openglControl1_MouseMove(object sender, MouseEventArgs e)
        {
            CameraMove.Move(new Point(e.X, e.Y), () => openglControl1_Resized(sender, e));
        }

        private void openglControl1_KeyDown(object sender, KeyEventArgs e)
        {
            CameraMove.KeyDown(e.KeyCode);
            //openGLControl.Invalidate();
            openglControl1_Resized(sender, e);
        }

        private void openglControl1_MouseDown(object sender, MouseEventArgs e) => CameraMove.CameraUsed = true;

        private void openglControl1_MouseUp(object sender, EventArgs e) => CameraMove.CameraUsed = false;

        #endregion

    }
}