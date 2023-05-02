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
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)openglControl1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
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
            // numericUpDown10
            // 
            numericUpDown10.DecimalPlaces = 2;
            numericUpDown10.Location = new Point(573, 191);
            numericUpDown10.Name = "numericUpDown10";
            numericUpDown10.Size = new Size(108, 27);
            numericUpDown10.TabIndex = 36;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(456, 193);
            label12.Name = "label12";
            label12.Size = new Size(84, 20);
            label12.TabIndex = 35;
            label12.Text = "Повороты:";
            // 
            // numericUpDown9
            // 
            numericUpDown9.DecimalPlaces = 2;
            numericUpDown9.Location = new Point(573, 158);
            numericUpDown9.Name = "numericUpDown9";
            numericUpDown9.Size = new Size(108, 27);
            numericUpDown9.TabIndex = 34;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(456, 160);
            label11.Name = "label11";
            label11.Size = new Size(59, 20);
            label11.TabIndex = 33;
            label11.Text = "Длины:";
            // 
            // numericUpDown8
            // 
            numericUpDown8.DecimalPlaces = 2;
            numericUpDown8.Location = new Point(573, 125);
            numericUpDown8.Name = "numericUpDown8";
            numericUpDown8.Size = new Size(108, 27);
            numericUpDown8.TabIndex = 32;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(456, 127);
            label10.Name = "label10";
            label10.Size = new Size(46, 20);
            label10.TabIndex = 31;
            label10.Text = "Углы:";
            // 
            // numericUpDown7
            // 
            numericUpDown7.DecimalPlaces = 2;
            numericUpDown7.Location = new Point(573, 92);
            numericUpDown7.Name = "numericUpDown7";
            numericUpDown7.Size = new Size(108, 27);
            numericUpDown7.TabIndex = 30;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(456, 94);
            label9.Name = "label9";
            label9.Size = new Size(65, 20);
            label9.TabIndex = 29;
            label9.Text = "Высоты:";
            // 
            // numericUpDown6
            // 
            numericUpDown6.DecimalPlaces = 2;
            numericUpDown6.Location = new Point(573, 59);
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(108, 27);
            numericUpDown6.TabIndex = 28;
            numericUpDown6.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(456, 61);
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
            numericUpDown5.DecimalPlaces = 2;
            numericUpDown5.Location = new Point(125, 257);
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(108, 27);
            numericUpDown5.TabIndex = 25;
            numericUpDown5.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown4
            // 
            numericUpDown4.DecimalPlaces = 2;
            numericUpDown4.Location = new Point(125, 224);
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(108, 27);
            numericUpDown4.TabIndex = 24;
            numericUpDown4.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown3
            // 
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown3.Location = new Point(125, 191);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(108, 27);
            numericUpDown3.TabIndex = 23;
            numericUpDown3.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown2
            // 
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown2.Location = new Point(125, 158);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(108, 27);
            numericUpDown2.TabIndex = 22;
            numericUpDown2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Location = new Point(125, 125);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(108, 27);
            numericUpDown1.TabIndex = 21;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numPoly2
            // 
            numPoly2.DecimalPlaces = 2;
            numPoly2.Location = new Point(239, 92);
            numPoly2.Name = "numPoly2";
            numPoly2.Size = new Size(108, 27);
            numPoly2.TabIndex = 20;
            numPoly2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numPoly1
            // 
            numPoly1.DecimalPlaces = 2;
            numPoly1.Location = new Point(125, 92);
            numPoly1.Name = "numPoly1";
            numPoly1.Size = new Size(108, 27);
            numPoly1.TabIndex = 19;
            numPoly1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numKHeight
            // 
            numKHeight.DecimalPlaces = 2;
            numKHeight.Location = new Point(125, 59);
            numKHeight.Name = "numKHeight";
            numKHeight.Size = new Size(108, 27);
            numKHeight.TabIndex = 18;
            numKHeight.Value = new decimal(new int[] { 1, 0, 0, 0 });
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
    }
}