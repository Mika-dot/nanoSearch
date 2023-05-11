namespace nanoSearchNew
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openglControl1 = new SharpGL.OpenGLControl();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            button4 = new Button();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
            numericUpDown17 = new NumericUpDown();
            label19 = new Label();
            numericUpDown16 = new NumericUpDown();
            label18 = new Label();
            numericUpDown11 = new NumericUpDown();
            label13 = new Label();
            numericUpDown12 = new NumericUpDown();
            label14 = new Label();
            numericUpDown13 = new NumericUpDown();
            label15 = new Label();
            numericUpDown14 = new NumericUpDown();
            label16 = new Label();
            numericUpDown15 = new NumericUpDown();
            label17 = new Label();
            button3 = new Button();
            numericUpDown10 = new NumericUpDown();
            label12 = new Label();
            numericUpDown9 = new NumericUpDown();
            label11 = new Label();
            numericUpDown8 = new NumericUpDown();
            label10 = new Label();
            numericUpDown7 = new NumericUpDown();
            label9 = new Label();
            numericUpDown6 = new NumericUpDown();
            label8 = new Label();
            button2 = new Button();
            numericUpDown5 = new NumericUpDown();
            numericUpDown4 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            numPoly2 = new NumericUpDown();
            numPoly1 = new NumericUpDown();
            numKHeight = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)openglControl1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown17).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown16).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown13).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown14).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown15).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPoly2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPoly1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numKHeight).BeginInit();
            SuspendLayout();
            // 
            // openglControl1
            // 
            openglControl1.BackColor = Color.Black;
            openglControl1.Dock = DockStyle.Fill;
            openglControl1.DrawFPS = true;
            openglControl1.FrameRate = 30;
            openglControl1.Location = new Point(3, 4);
            openglControl1.Margin = new Padding(5);
            openglControl1.Name = "openglControl1";
            openglControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            openglControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
            openglControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            openglControl1.Size = new Size(786, 410);
            openglControl1.TabIndex = 0;
            openglControl1.OpenGLInitialized += openglControl1_OpenGLInitialized;
            openglControl1.OpenGLDraw += openglControl1_OpenGLDraw;
            openglControl1.Resized += openglControl1_Resized;
            openglControl1.KeyDown += openglControl1_KeyDown;
            openglControl1.MouseDown += openglControl1_MouseDown;
            openglControl1.MouseMove += openglControl1_MouseMove;
            openglControl1.MouseUp += openglControl1_MouseUp;
            // 
            // button1
            // 
            button1.Location = new Point(8, 9);
            button1.Margin = new Padding(5);
            button1.Name = "button1";
            button1.Size = new Size(137, 37);
            button1.TabIndex = 1;
            button1.Text = "Построить карту";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 61);
            label1.Name = "label1";
            label1.Size = new Size(111, 20);
            label1.TabIndex = 11;
            label1.Text = "К. карты высот";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 99);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 12;
            label2.Text = "Полигоны";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 127);
            label3.Name = "label3";
            label3.Size = new Size(47, 20);
            label3.TabIndex = 13;
            label3.Text = "Дома";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 160);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 14;
            label4.Text = "Шоссе";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 193);
            label5.Name = "label5";
            label5.Size = new Size(66, 20);
            label5.TabIndex = 15;
            label5.Text = "Асфальт";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 226);
            label6.Name = "label6";
            label6.Size = new Size(47, 20);
            label6.TabIndex = 16;
            label6.Text = "Грунт";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 259);
            label7.Name = "label7";
            label7.Size = new Size(41, 20);
            label7.TabIndex = 17;
            label7.Text = "Реки";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 451);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(openglControl1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(792, 418);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Основное";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button4);
            tabPage2.Controls.Add(textBox5);
            tabPage2.Controls.Add(textBox4);
            tabPage2.Controls.Add(textBox3);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(textBox1);
            tabPage2.Controls.Add(label20);
            tabPage2.Controls.Add(label21);
            tabPage2.Controls.Add(label22);
            tabPage2.Controls.Add(label23);
            tabPage2.Controls.Add(label24);
            tabPage2.Controls.Add(numericUpDown17);
            tabPage2.Controls.Add(label19);
            tabPage2.Controls.Add(numericUpDown16);
            tabPage2.Controls.Add(label18);
            tabPage2.Controls.Add(numericUpDown11);
            tabPage2.Controls.Add(label13);
            tabPage2.Controls.Add(numericUpDown12);
            tabPage2.Controls.Add(label14);
            tabPage2.Controls.Add(numericUpDown13);
            tabPage2.Controls.Add(label15);
            tabPage2.Controls.Add(numericUpDown14);
            tabPage2.Controls.Add(label16);
            tabPage2.Controls.Add(numericUpDown15);
            tabPage2.Controls.Add(label17);
            tabPage2.Controls.Add(button3);
            tabPage2.Controls.Add(numericUpDown10);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(numericUpDown9);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(numericUpDown8);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(numericUpDown7);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(numericUpDown6);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(numericUpDown5);
            tabPage2.Controls.Add(numericUpDown4);
            tabPage2.Controls.Add(numericUpDown3);
            tabPage2.Controls.Add(numericUpDown2);
            tabPage2.Controls.Add(numericUpDown1);
            tabPage2.Controls.Add(numPoly2);
            tabPage2.Controls.Add(numPoly1);
            tabPage2.Controls.Add(numKHeight);
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(label1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(792, 418);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Настройки";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(600, 381);
            button4.Name = "button4";
            button4.Size = new Size(172, 29);
            button4.TabIndex = 66;
            button4.Text = "Применить массив";
            button4.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(356, 383);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(238, 27);
            textBox5.TabIndex = 65;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(356, 350);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(238, 27);
            textBox4.TabIndex = 64;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(356, 317);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(238, 27);
            textBox3.TabIndex = 63;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(356, 284);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(238, 27);
            textBox2.TabIndex = 62;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(356, 251);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(238, 27);
            textBox1.TabIndex = 61;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(266, 386);
            label20.Name = "label20";
            label20.Size = new Size(84, 20);
            label20.TabIndex = 60;
            label20.Text = "Повороты:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(266, 353);
            label21.Name = "label21";
            label21.Size = new Size(59, 20);
            label21.TabIndex = 58;
            label21.Text = "Длины:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(266, 320);
            label22.Name = "label22";
            label22.Size = new Size(46, 20);
            label22.TabIndex = 56;
            label22.Text = "Углы:";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(266, 287);
            label23.Name = "label23";
            label23.Size = new Size(65, 20);
            label23.TabIndex = 54;
            label23.Text = "Высоты:";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(266, 254);
            label24.Name = "label24";
            label24.Size = new Size(54, 20);
            label24.TabIndex = 52;
            label24.Text = "A-Star:";
            // 
            // numericUpDown17
            // 
            numericUpDown17.Location = new Point(642, 207);
            numericUpDown17.Name = "numericUpDown17";
            numericUpDown17.Size = new Size(108, 27);
            numericUpDown17.TabIndex = 51;
            numericUpDown17.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(534, 209);
            label19.Name = "label19";
            label19.Size = new Size(60, 20);
            label19.TabIndex = 50;
            label19.Text = "Размер";
            // 
            // numericUpDown16
            // 
            numericUpDown16.DecimalPlaces = 2;
            numericUpDown16.Location = new Point(642, 174);
            numericUpDown16.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown16.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericUpDown16.Name = "numericUpDown16";
            numericUpDown16.Size = new Size(108, 27);
            numericUpDown16.TabIndex = 49;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(525, 176);
            label18.Name = "label18";
            label18.Size = new Size(80, 20);
            label18.TabIndex = 48;
            label18.Text = "Мин. угол:";
            // 
            // numericUpDown11
            // 
            numericUpDown11.DecimalPlaces = 2;
            numericUpDown11.Location = new Point(642, 141);
            numericUpDown11.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown11.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericUpDown11.Name = "numericUpDown11";
            numericUpDown11.Size = new Size(108, 27);
            numericUpDown11.TabIndex = 47;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(525, 143);
            label13.Name = "label13";
            label13.Size = new Size(56, 20);
            label13.TabIndex = 46;
            label13.Text = "Длина:";
            // 
            // numericUpDown12
            // 
            numericUpDown12.DecimalPlaces = 2;
            numericUpDown12.Location = new Point(642, 108);
            numericUpDown12.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown12.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericUpDown12.Name = "numericUpDown12";
            numericUpDown12.Size = new Size(108, 27);
            numericUpDown12.TabIndex = 45;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(525, 110);
            label14.Name = "label14";
            label14.Size = new Size(106, 20);
            label14.TabIndex = 44;
            label14.Text = "Макс. угол (h):";
            // 
            // numericUpDown13
            // 
            numericUpDown13.DecimalPlaces = 2;
            numericUpDown13.Location = new Point(642, 75);
            numericUpDown13.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown13.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericUpDown13.Name = "numericUpDown13";
            numericUpDown13.Size = new Size(108, 27);
            numericUpDown13.TabIndex = 43;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(525, 77);
            label15.Name = "label15";
            label15.Size = new Size(102, 20);
            label15.TabIndex = 42;
            label15.Text = "Мин. угол (h):";
            // 
            // numericUpDown14
            // 
            numericUpDown14.DecimalPlaces = 2;
            numericUpDown14.Location = new Point(642, 42);
            numericUpDown14.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown14.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericUpDown14.Name = "numericUpDown14";
            numericUpDown14.Size = new Size(108, 27);
            numericUpDown14.TabIndex = 41;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(525, 44);
            label16.Name = "label16";
            label16.Size = new Size(89, 20);
            label16.TabIndex = 40;
            label16.Text = "Макс. Альт.:";
            // 
            // numericUpDown15
            // 
            numericUpDown15.DecimalPlaces = 2;
            numericUpDown15.Location = new Point(642, 9);
            numericUpDown15.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown15.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numericUpDown15.Name = "numericUpDown15";
            numericUpDown15.Size = new Size(108, 27);
            numericUpDown15.TabIndex = 39;
            numericUpDown15.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(525, 11);
            label17.Name = "label17";
            label17.Size = new Size(85, 20);
            label17.TabIndex = 38;
            label17.Text = "Мин. Альт.:";
            // 
            // button3
            // 
            button3.Location = new Point(302, 9);
            button3.Margin = new Padding(5);
            button3.Name = "button3";
            button3.Size = new Size(137, 37);
            button3.TabIndex = 37;
            button3.Text = "Рекурсию";
            button3.UseVisualStyleBackColor = true;
            // 
            // numericUpDown10
            // 
            numericUpDown10.DecimalPlaces = 2;
            numericUpDown10.Location = new Point(383, 193);
            numericUpDown10.Name = "numericUpDown10";
            numericUpDown10.Size = new Size(108, 27);
            numericUpDown10.TabIndex = 36;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(266, 195);
            label12.Name = "label12";
            label12.Size = new Size(84, 20);
            label12.TabIndex = 35;
            label12.Text = "Повороты:";
            // 
            // numericUpDown9
            // 
            numericUpDown9.DecimalPlaces = 2;
            numericUpDown9.Location = new Point(383, 160);
            numericUpDown9.Name = "numericUpDown9";
            numericUpDown9.Size = new Size(108, 27);
            numericUpDown9.TabIndex = 34;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(266, 162);
            label11.Name = "label11";
            label11.Size = new Size(59, 20);
            label11.TabIndex = 33;
            label11.Text = "Длины:";
            // 
            // numericUpDown8
            // 
            numericUpDown8.DecimalPlaces = 2;
            numericUpDown8.Location = new Point(383, 127);
            numericUpDown8.Name = "numericUpDown8";
            numericUpDown8.Size = new Size(108, 27);
            numericUpDown8.TabIndex = 32;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(266, 129);
            label10.Name = "label10";
            label10.Size = new Size(46, 20);
            label10.TabIndex = 31;
            label10.Text = "Углы:";
            // 
            // numericUpDown7
            // 
            numericUpDown7.DecimalPlaces = 2;
            numericUpDown7.Location = new Point(383, 94);
            numericUpDown7.Name = "numericUpDown7";
            numericUpDown7.Size = new Size(108, 27);
            numericUpDown7.TabIndex = 30;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(266, 96);
            label9.Name = "label9";
            label9.Size = new Size(65, 20);
            label9.TabIndex = 29;
            label9.Text = "Высоты:";
            // 
            // numericUpDown6
            // 
            numericUpDown6.DecimalPlaces = 2;
            numericUpDown6.Location = new Point(383, 61);
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(108, 27);
            numericUpDown6.TabIndex = 28;
            numericUpDown6.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(266, 63);
            label8.Name = "label8";
            label8.Size = new Size(54, 20);
            label8.TabIndex = 27;
            label8.Text = "A-Star:";
            // 
            // button2
            // 
            button2.Location = new Point(155, 9);
            button2.Margin = new Padding(5);
            button2.Name = "button2";
            button2.Size = new Size(137, 37);
            button2.TabIndex = 26;
            button2.Text = "Построить путь";
            button2.UseVisualStyleBackColor = true;
            // 
            // numericUpDown5
            // 
            numericUpDown5.Location = new Point(125, 257);
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(108, 27);
            numericUpDown5.TabIndex = 25;
            numericUpDown5.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(125, 224);
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(108, 27);
            numericUpDown4.TabIndex = 24;
            numericUpDown4.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(125, 191);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(108, 27);
            numericUpDown3.TabIndex = 23;
            numericUpDown3.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(125, 158);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(108, 27);
            numericUpDown2.TabIndex = 22;
            numericUpDown2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(125, 125);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(108, 27);
            numericUpDown1.TabIndex = 21;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numPoly2
            // 
            numPoly2.Location = new Point(196, 92);
            numPoly2.Name = "numPoly2";
            numPoly2.Size = new Size(59, 27);
            numPoly2.TabIndex = 20;
            numPoly2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numPoly1
            // 
            numPoly1.Location = new Point(125, 92);
            numPoly1.Name = "numPoly1";
            numPoly1.Size = new Size(65, 27);
            numPoly1.TabIndex = 19;
            numPoly1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numKHeight
            // 
            numKHeight.Location = new Point(125, 59);
            numKHeight.Name = "numKHeight";
            numKHeight.Size = new Size(108, 27);
            numKHeight.TabIndex = 18;
            numKHeight.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "nanoSearch";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)openglControl1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown17).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown16).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown11).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown12).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown13).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown14).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown15).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown10).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown9).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPoly2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPoly1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numKHeight).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SharpGL.OpenGLControl openglControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private NumericUpDown numKHeight;
        private NumericUpDown numPoly2;
        private NumericUpDown numPoly1;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown5;
        private NumericUpDown numericUpDown4;
        private NumericUpDown numericUpDown3;
        private Button button2;
        private NumericUpDown numericUpDown6;
        private Label label8;
        private NumericUpDown numericUpDown10;
        private Label label12;
        private NumericUpDown numericUpDown9;
        private Label label11;
        private NumericUpDown numericUpDown8;
        private Label label10;
        private NumericUpDown numericUpDown7;
        private Label label9;
        private Button button3;
        private NumericUpDown numericUpDown11;
        private Label label13;
        private NumericUpDown numericUpDown12;
        private Label label14;
        private NumericUpDown numericUpDown13;
        private Label label15;
        private NumericUpDown numericUpDown14;
        private Label label16;
        private NumericUpDown numericUpDown15;
        private Label label17;
        private NumericUpDown numericUpDown16;
        private Label label18;
        private NumericUpDown numericUpDown17;
        private Label label19;
        private Button button4;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
    }
}