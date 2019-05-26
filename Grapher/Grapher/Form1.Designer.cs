namespace Grapher
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.resLabel = new System.Windows.Forms.Label();
            this.resUpDown = new System.Windows.Forms.NumericUpDown();
            this.xLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.yDown = new System.Windows.Forms.Button();
            this.yUp = new System.Windows.Forms.Button();
            this.xDown = new System.Windows.Forms.Button();
            this.xUp = new System.Windows.Forms.Button();
            this.angleLabel = new System.Windows.Forms.Label();
            this.angleUpDown = new System.Windows.Forms.NumericUpDown();
            this.do3D = new System.Windows.Forms.CheckBox();
            this.themeLabel = new System.Windows.Forms.Label();
            this.themes = new System.Windows.Forms.ComboBox();
            this.scaleLabel = new System.Windows.Forms.Label();
            this.scaleUpDown = new System.Windows.Forms.NumericUpDown();
            this.CalcButton = new System.Windows.Forms.Button();
            this.FunctionLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.canvas = new System.Windows.Forms.Panel();
            this.rangeLabel = new System.Windows.Forms.Label();
            this.rangeUpDown = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.rangeLabel);
            this.panel1.Controls.Add(this.rangeUpDown);
            this.panel1.Controls.Add(this.resLabel);
            this.panel1.Controls.Add(this.resUpDown);
            this.panel1.Controls.Add(this.xLabel);
            this.panel1.Controls.Add(this.yLabel);
            this.panel1.Controls.Add(this.yDown);
            this.panel1.Controls.Add(this.yUp);
            this.panel1.Controls.Add(this.xDown);
            this.panel1.Controls.Add(this.xUp);
            this.panel1.Controls.Add(this.angleLabel);
            this.panel1.Controls.Add(this.angleUpDown);
            this.panel1.Controls.Add(this.do3D);
            this.panel1.Controls.Add(this.themeLabel);
            this.panel1.Controls.Add(this.themes);
            this.panel1.Controls.Add(this.scaleLabel);
            this.panel1.Controls.Add(this.scaleUpDown);
            this.panel1.Controls.Add(this.CalcButton);
            this.panel1.Controls.Add(this.FunctionLabel);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 45);
            this.panel1.TabIndex = 0;
            // 
            // resLabel
            // 
            this.resLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resLabel.AutoSize = true;
            this.resLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resLabel.ForeColor = System.Drawing.Color.White;
            this.resLabel.Location = new System.Drawing.Point(675, 16);
            this.resLabel.Name = "resLabel";
            this.resLabel.Size = new System.Drawing.Size(33, 13);
            this.resLabel.TabIndex = 17;
            this.resLabel.Text = "Res:";
            // 
            // resUpDown
            // 
            this.resUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resUpDown.Location = new System.Drawing.Point(711, 13);
            this.resUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.resUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.resUpDown.Name = "resUpDown";
            this.resUpDown.Size = new System.Drawing.Size(42, 20);
            this.resUpDown.TabIndex = 16;
            this.resUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.resUpDown.ValueChanged += new System.EventHandler(this.resUpDown_ValueChanged);
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel.ForeColor = System.Drawing.Color.White;
            this.xLabel.Location = new System.Drawing.Point(441, 15);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(44, 13);
            this.xLabel.TabIndex = 15;
            this.xLabel.Text = "Width:";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yLabel.ForeColor = System.Drawing.Color.White;
            this.yLabel.Location = new System.Drawing.Point(367, 15);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(48, 13);
            this.yLabel.TabIndex = 14;
            this.yLabel.Text = "Height:";
            // 
            // yDown
            // 
            this.yDown.Location = new System.Drawing.Point(417, 24);
            this.yDown.Name = "yDown";
            this.yDown.Size = new System.Drawing.Size(21, 18);
            this.yDown.TabIndex = 13;
            this.yDown.Text = "-";
            this.yDown.UseVisualStyleBackColor = true;
            this.yDown.Click += new System.EventHandler(this.yDown_Click);
            // 
            // yUp
            // 
            this.yUp.Location = new System.Drawing.Point(417, 3);
            this.yUp.Name = "yUp";
            this.yUp.Size = new System.Drawing.Size(21, 21);
            this.yUp.TabIndex = 12;
            this.yUp.Text = "+";
            this.yUp.UseVisualStyleBackColor = true;
            this.yUp.Click += new System.EventHandler(this.yUp_Click);
            // 
            // xDown
            // 
            this.xDown.Location = new System.Drawing.Point(487, 23);
            this.xDown.Name = "xDown";
            this.xDown.Size = new System.Drawing.Size(21, 19);
            this.xDown.TabIndex = 10;
            this.xDown.Text = "-";
            this.xDown.UseVisualStyleBackColor = true;
            this.xDown.Click += new System.EventHandler(this.xDown_Click);
            // 
            // xUp
            // 
            this.xUp.Location = new System.Drawing.Point(487, 3);
            this.xUp.Name = "xUp";
            this.xUp.Size = new System.Drawing.Size(21, 20);
            this.xUp.TabIndex = 9;
            this.xUp.Text = "+";
            this.xUp.UseVisualStyleBackColor = true;
            this.xUp.Click += new System.EventHandler(this.xUp_Click);
            // 
            // angleLabel
            // 
            this.angleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.angleLabel.AutoSize = true;
            this.angleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.angleLabel.ForeColor = System.Drawing.Color.White;
            this.angleLabel.Location = new System.Drawing.Point(763, 16);
            this.angleLabel.Name = "angleLabel";
            this.angleLabel.Size = new System.Drawing.Size(43, 13);
            this.angleLabel.TabIndex = 8;
            this.angleLabel.Text = "Angle:";
            // 
            // angleUpDown
            // 
            this.angleUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.angleUpDown.Location = new System.Drawing.Point(809, 13);
            this.angleUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.angleUpDown.Name = "angleUpDown";
            this.angleUpDown.Size = new System.Drawing.Size(42, 20);
            this.angleUpDown.TabIndex = 7;
            this.angleUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.angleUpDown.ValueChanged += new System.EventHandler(this.angleUpDown_ValueChanged);
            // 
            // do3D
            // 
            this.do3D.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do3D.AutoSize = true;
            this.do3D.Checked = true;
            this.do3D.CheckState = System.Windows.Forms.CheckState.Checked;
            this.do3D.ForeColor = System.Drawing.Color.White;
            this.do3D.Location = new System.Drawing.Point(524, 16);
            this.do3D.Name = "do3D";
            this.do3D.Size = new System.Drawing.Size(40, 17);
            this.do3D.TabIndex = 6;
            this.do3D.Text = "3D";
            this.do3D.UseVisualStyleBackColor = true;
            // 
            // themeLabel
            // 
            this.themeLabel.AutoSize = true;
            this.themeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themeLabel.ForeColor = System.Drawing.Color.White;
            this.themeLabel.Location = new System.Drawing.Point(235, 16);
            this.themeLabel.Name = "themeLabel";
            this.themeLabel.Size = new System.Drawing.Size(49, 13);
            this.themeLabel.TabIndex = 5;
            this.themeLabel.Text = "Theme:";
            // 
            // themes
            // 
            this.themes.FormattingEnabled = true;
            this.themes.Items.AddRange(new object[] {
            "Standard",
            "Magical",
            "Dark",
            "Fluffy",
            "Satanic",
            "Nature",
            "Clay"});
            this.themes.Location = new System.Drawing.Point(284, 11);
            this.themes.Name = "themes";
            this.themes.Size = new System.Drawing.Size(69, 21);
            this.themes.TabIndex = 4;
            // 
            // scaleLabel
            // 
            this.scaleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scaleLabel.AutoSize = true;
            this.scaleLabel.BackColor = System.Drawing.Color.Transparent;
            this.scaleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleLabel.ForeColor = System.Drawing.Color.White;
            this.scaleLabel.Location = new System.Drawing.Point(856, 16);
            this.scaleLabel.Name = "scaleLabel";
            this.scaleLabel.Size = new System.Drawing.Size(43, 13);
            this.scaleLabel.TabIndex = 3;
            this.scaleLabel.Text = "Scale:";
            // 
            // scaleUpDown
            // 
            this.scaleUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scaleUpDown.Location = new System.Drawing.Point(902, 12);
            this.scaleUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.scaleUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scaleUpDown.Name = "scaleUpDown";
            this.scaleUpDown.Size = new System.Drawing.Size(41, 20);
            this.scaleUpDown.TabIndex = 2;
            this.scaleUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.scaleUpDown.ValueChanged += new System.EventHandler(this.scaleUpDown_ValueChanged);
            // 
            // CalcButton
            // 
            this.CalcButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CalcButton.Location = new System.Drawing.Point(957, 3);
            this.CalcButton.Name = "CalcButton";
            this.CalcButton.Size = new System.Drawing.Size(61, 39);
            this.CalcButton.TabIndex = 2;
            this.CalcButton.Text = "Calculate";
            this.CalcButton.UseVisualStyleBackColor = true;
            this.CalcButton.Click += new System.EventHandler(this.CalcButton_Click);
            // 
            // FunctionLabel
            // 
            this.FunctionLabel.AutoSize = true;
            this.FunctionLabel.BackColor = System.Drawing.Color.Transparent;
            this.FunctionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FunctionLabel.ForeColor = System.Drawing.Color.White;
            this.FunctionLabel.Location = new System.Drawing.Point(12, 15);
            this.FunctionLabel.Name = "FunctionLabel";
            this.FunctionLabel.Size = new System.Drawing.Size(60, 13);
            this.FunctionLabel.TabIndex = 1;
            this.FunctionLabel.Text = "Function:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(74, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 20);
            this.textBox1.TabIndex = 0;
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.LightGray;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 45);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1024, 507);
            this.canvas.TabIndex = 1;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // rangeLabel
            // 
            this.rangeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rangeLabel.AutoSize = true;
            this.rangeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rangeLabel.ForeColor = System.Drawing.Color.White;
            this.rangeLabel.Location = new System.Drawing.Point(571, 16);
            this.rangeLabel.Name = "rangeLabel";
            this.rangeLabel.Size = new System.Drawing.Size(48, 13);
            this.rangeLabel.TabIndex = 19;
            this.rangeLabel.Text = "Range:";
            // 
            // rangeUpDown
            // 
            this.rangeUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rangeUpDown.Location = new System.Drawing.Point(622, 13);
            this.rangeUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.rangeUpDown.Name = "rangeUpDown";
            this.rangeUpDown.Size = new System.Drawing.Size(42, 20);
            this.rangeUpDown.TabIndex = 18;
            this.rangeUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.rangeUpDown.ValueChanged += new System.EventHandler(this.rangeUpDown_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 552);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label FunctionLabel;
        private System.Windows.Forms.Button CalcButton;
        private System.Windows.Forms.Label scaleLabel;
        private System.Windows.Forms.NumericUpDown scaleUpDown;
        private System.Windows.Forms.ComboBox themes;
        private System.Windows.Forms.CheckBox do3D;
        private System.Windows.Forms.Label themeLabel;
        private System.Windows.Forms.Label angleLabel;
        private System.Windows.Forms.NumericUpDown angleUpDown;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Button yDown;
        private System.Windows.Forms.Button yUp;
        private System.Windows.Forms.Button xDown;
        private System.Windows.Forms.Button xUp;
        private System.Windows.Forms.Label resLabel;
        private System.Windows.Forms.NumericUpDown resUpDown;
        private System.Windows.Forms.Label rangeLabel;
        private System.Windows.Forms.NumericUpDown rangeUpDown;
    }
}

