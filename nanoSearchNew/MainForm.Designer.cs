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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
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
            ((System.ComponentModel.ISupportInitialize)openglControl1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
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
            button1.Size = new Size(82, 37);
            button1.TabIndex = 1;
            button1.Text = "Начало";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(129, 49);
            textBox1.Margin = new Padding(5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(74, 27);
            textBox1.TabIndex = 2;
            textBox1.Text = "1";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(129, 89);
            textBox2.Margin = new Padding(5);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(74, 27);
            textBox2.TabIndex = 3;
            textBox2.Text = "0";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(129, 133);
            textBox3.Margin = new Padding(5);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(74, 27);
            textBox3.TabIndex = 4;
            textBox3.Text = "0";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(129, 169);
            textBox4.Margin = new Padding(5);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(74, 27);
            textBox4.TabIndex = 5;
            textBox4.Text = "0";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(129, 204);
            textBox5.Margin = new Padding(5);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(74, 27);
            textBox5.TabIndex = 6;
            textBox5.Text = "0";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(129, 244);
            textBox6.Margin = new Padding(5);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(74, 27);
            textBox6.TabIndex = 10;
            textBox6.Text = "0";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(129, 277);
            textBox7.Margin = new Padding(5);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(74, 27);
            textBox7.TabIndex = 9;
            textBox7.Text = "0";
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
            label3.Location = new Point(11, 137);
            label3.Name = "label3";
            label3.Size = new Size(47, 20);
            label3.TabIndex = 13;
            label3.Text = "Дома";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 173);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 14;
            label4.Text = "Шоссе";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 212);
            label5.Name = "label5";
            label5.Size = new Size(66, 20);
            label5.TabIndex = 15;
            label5.Text = "Асфальт";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 245);
            label6.Name = "label6";
            label6.Size = new Size(47, 20);
            label6.TabIndex = 16;
            label6.Text = "Грунт";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 281);
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
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(textBox1);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(textBox3);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(textBox4);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(textBox5);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(textBox7);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(textBox6);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(792, 418);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Настройки";
            tabPage2.UseVisualStyleBackColor = true;
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
            ResumeLayout(false);
        }

        #endregion

        private SharpGL.OpenGLControl openglControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
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
    }
}