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


        Model stem = new Model();
        public MainForm()
        {
            ImportExport.MainLoader();
            //stem.LoadFromObj(new StreamReader(Link.Road)).Transformation(0.01f, new Vector3(0, 0f, 0f), new Vector3(0, 0, 0), new float[] { 1f, 0, 0 });
            //stem.LoadFromObj(new StreamReader(Link.House)).Transformation(0.01f, new Vector3(0, 0f, 0f), new Vector3(0, 0, 0), new float[] { 1f, 0, 0 });
            stem.LoadFromObj(new StreamReader(Link.House)).Transformation(0.01f, new Vector3(0, 0f, 0f), new Vector3(0, 0, 0), new float[] { 1f, 0, 0 });
            
            InitializeComponent();

            MapCalculator.MapHelper.CalculateEverything(); // ������ ��� ��������� ��������

            MapCalculator.MapHelper.CalculatePathOnMap(); // � �������� ������� ���� ����
        }

        #region "���������"

        private void openglControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            //  ������ OpenGL ������
            OpenGL gl = openglControl1.OpenGL;

            //  ������� ����� ����� � �������
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //  ��������� ��������� �������
            gl.LoadIdentity();

            // �������� ���� ������ �� ������ � ������ ������, �� ��� ������
            gl.Translate(0.0f, 0.0f, 0.0f);

            //stem.stlOutputOBJ(gl, stem, 0, 0, 0);

            MapCalculator.MapHelper.JustRenderEverything(gl);


            MapCalculator.MapHelper.RenderPath(gl);
            // �������� ������ ��������� ���������� �����������
            gl.Flush();
        }
        private void openglControl1_Resized(object sender, EventArgs e)
        {
            //  ������ OpenGL ������
            OpenGL gl = openglControl1.OpenGL;

            //  ������� ������� ��������
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  ��������� ������� ��� ����������� ��������������
            gl.LoadIdentity();

            //  ��������������
            gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 1000.0);


            //  ������ ������� ��������� ���������� ������ � � ���������
            CameraMove.RenderHelp(gl);

            //  ������� ������ �����������
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }
        private void openglControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            //  ������ OpenGL ������
            OpenGL gl = openglControl1.OpenGL;

            //  ������� ���� �� ��������� (� ������ ������ ���� �������)
            gl.ClearColor(0.1f, 0.5f, 1.0f, 0);
        }
        #endregion

        #region "����������"
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