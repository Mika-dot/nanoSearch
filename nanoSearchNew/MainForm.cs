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
            button1.Click += delegate
            {
                Task.Run(() =>
                {
                    MapCalculator.MapHelper.CalculateEverything();
                    MessageBox.Show("Карта отрисована.");
                });
            };
            button2.Click += delegate
            {
                Task.Run(() =>
                {
                    MapCalculator.MapHelper.CalculatePathOnMap(new Point(0, 150), new Point(120, 40));
                    MessageBox.Show("Путь построен.");
                }); // с готовыми данными ищем путь
            };

            button3.Click += delegate
            {
                Task.Run(() =>
                {
                    var res = Architect.Recursion.Recursions(new Agent(MapCalculator.MapHelper.newPoints, new Point(0, 150), new Point(120, 40)), 50);
                    MapCalculator.MapHelper.FinalPoints = res[^1].Item1;
                    MessageBox.Show("Рекурсивный путь построен.");
                }); // с готовыми данными ищем путь
            };
            numKHeight.ValueChanged += delegate
            {
                ConstantGrid.HeightMap = (float)numKHeight.Value;
            };
            numPoly1.ValueChanged += delegate
            {
                ConstantGrid.Polygon[0].Value = (float)numPoly1.Value;
            };
            numPoly2.ValueChanged += delegate
            {
                ConstantGrid.Polygon[1].Value = (float)numPoly2.Value;
            };
            numericUpDown1.ValueChanged += delegate
            {
                ConstantGrid.Home[0].Value = (float)numericUpDown1.Value;
            };

            numericUpDown2.ValueChanged += delegate
            {
                ConstantGrid.Road[0].Value = (float)numericUpDown2.Value;
            };
            numericUpDown3.ValueChanged += delegate
            {
                ConstantGrid.Road[1].Value = (float)numericUpDown3.Value;
            };
            numericUpDown4.ValueChanged += delegate
            {
                ConstantGrid.Road[2].Value = (float)numericUpDown4.Value;
            };
            numericUpDown5.ValueChanged += delegate
            {
                ConstantGrid.Road[3].Value = (float)numericUpDown5.Value;
            };

            numericUpDown6.ValueChanged += delegate
            {
                Coefficient.AStarSearch = (float)numericUpDown6.Value;
            };
            numericUpDown7.ValueChanged += delegate
            {
                Coefficient.Height = (float)numericUpDown7.Value;
            };
            numericUpDown8.ValueChanged += delegate
            {
                Coefficient.Corner = (float)numericUpDown8.Value;
            };
            numericUpDown9.ValueChanged += delegate
            {
                Coefficient.Length = (float)numericUpDown9.Value;
            };
            numericUpDown10.ValueChanged += delegate
            {
                Coefficient.AngleOfRotation = (float)numericUpDown10.Value;
            };

            numericUpDown15.Value = (decimal)Configuration.AltitudeMin;
            numericUpDown15.ValueChanged += delegate
            {
                Configuration.AltitudeMin = (float)numericUpDown15.Value;
            };

            numericUpDown14.Value = (decimal)Configuration.AltitudeMax;
            numericUpDown14.ValueChanged += delegate
            {
                Configuration.AltitudeMax = (float)numericUpDown14.Value;
            };

            numericUpDown13.Value = (decimal)Configuration.CornerHeightsMin;
            numericUpDown13.ValueChanged += delegate
            {
                Configuration.CornerHeightsMin = (float)numericUpDown13.Value;
            };

            numericUpDown12.Value = (decimal)Configuration.CornerHeightsMax;
            numericUpDown12.ValueChanged += delegate
            {
                Configuration.CornerHeightsMax = (float)numericUpDown12.Value;
            };

            numericUpDown11.Value = (decimal)Configuration.LengthMax;
            numericUpDown11.ValueChanged += delegate
            {
                Configuration.LengthMax = (float)numericUpDown11.Value;
            };

            numericUpDown16.Value = (decimal)Configuration.CornerMin;
            numericUpDown16.ValueChanged += delegate
            {
                Configuration.CornerMin = (float)numericUpDown16.Value;
            };


            numericUpDown17.Value = Configuration.Size;
            numericUpDown17.ValueChanged += delegate
            {
                Configuration.Size = (int)numericUpDown17.Value;
            };

            textBox1.Text = string.Join(", ", calculationFormula.AStarSearch.Cast<float>());
            textBox2.Text = string.Join(", ", calculationFormula.Height.Cast<float>());
            textBox3.Text = string.Join(", ", calculationFormula.Corner.Cast<float>());
            textBox4.Text = string.Join(", ", calculationFormula.Length.Cast<float>());
            textBox5.Text = string.Join(", ", calculationFormula.AngleOfRotation.Cast<float>());

            button4.Click += delegate
            {
                try
                {
                    ParseThis(textBox1.Text, ref calculationFormula.AStarSearch);
                }
                catch
                {
                    MessageBox.Show("1 AStar плох.");
                }
                try
                {
                    ParseThis(textBox2.Text, ref calculationFormula.Height);
                }
                catch
                {
                    MessageBox.Show("2 Height плох.");
                }
                try
                {
                    ParseThis(textBox3.Text, ref calculationFormula.Corner);
                }
                catch
                {
                    MessageBox.Show("3 Corner плох.");
                }
                try
                {
                    ParseThis(textBox4.Text, ref calculationFormula.Length);
                }
                catch
                {
                    MessageBox.Show("4 Length плох.");
                }
                try
                {
                    ParseThis(textBox5.Text, ref calculationFormula.AngleOfRotation);
                }
                catch
                {
                    MessageBox.Show("5 AngleOfRotation плох.");
                }
            };


            void ParseThis(string what, ref float[,] where)
            {
                if (what.Length > 0)
                {
                    var SS = what.Replace(" ", "").Split(',');
                    var pointsA = new float[SS.Length / 2, 2];
                    for (int i = 0; i < SS.Length; i += 2)
                    {
                        pointsA[i / 2, 0] = float.Parse(SS[i]);
                        pointsA[i / 2, 1] = float.Parse(SS[i + 1]);
                    }
                    where = pointsA; // на случай кривого парсинга оставляем это на конец
                }
            }

            //MapCalculator.MapHelper.CalculatePathOnMap(new Point(0, 150), new Point(120, 40)); // с готовыми данными ищем путь
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