using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Grapher
{
    public partial class Form1 : Form
    {
        // (sin(x*2)+cos(y*2))*8 - (x^2+y^2-100)
        // (x^2 + y ^ 2) / 5 - (x^2 + y ^ 4) / 200
        // sin(x)*5+y^2/2 - 20
        // cos(x+y)*sin(x+y^2)

        BinNode<string> binTree;
        BinNodeOps<string> ops = new BinNodeOps<string>();

        Graphics g;
        Pen graphPen = new Pen(Color.Black, 2);
        Pen xPen = new Pen(Color.Blue, 2);
        Pen yPen = new Pen(Color.Red, 2);
        Pen gridPen = new Pen(Color.FromArgb(190, 190, 190));

        const int INDICATOR_WIDTH = 4;
        double angle, res, res3D, zoom, range3D;
        double xStretch = 1, yStretch = 0.6;
        double maxHeight = -100, minHeight = 100;

        Point drawPoint;
        Point[] graphPoints;
        double[,] xx;
        double[,] yy;
        double[,] zz;

        public string[] stringToArray(string input)
        {
            input = input.ToLower();
            string[] function = new string[0];
            int parCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].ToString() == " ")
                    continue;

                #region parentheses stuff
                if (i + 1 < input.Length && input[i].ToString() == "s" && input[i + 1].ToString() == "i") // reading "sin"
                {
                    if (i + 3 < input.Length && input[i + 2].ToString() == "n" && input[i + 3].ToString() == "(")
                    {
                        Array.Resize(ref function, function.Length + 1);
                        function[function.Length - 1] = "sin(";
                        i += 3;
                        continue;
                    }
                    else return null;
                }
                if (i + 1 < input.Length && input[i].ToString() == "s" && input[i + 1].ToString() == "q") // reading "sqrt"
                {
                    if (i + 4 < input.Length && input[i + 2].ToString() == "r" && input[i + 3].ToString() == "t" && input[i + 4].ToString() == "(")
                    {
                        Array.Resize(ref function, function.Length + 1);
                        function[function.Length - 1] = "sqrt(";
                        i += 4;
                        continue;
                    }
                    else return null;
                }
                if (input[i].ToString() == "c") // reading "cos"
                {
                    if (i + 3 < input.Length && input[i + 1].ToString() == "o" && input[i + 2].ToString() == "s" && input[i + 3].ToString() == "(")
                    {
                        Array.Resize(ref function, function.Length + 1);
                        function[function.Length - 1] = "cos(";
                        i += 3;
                        continue;
                    }
                    else return null;
                }
                if (input[i].ToString() == "t") // reading "tan"
                {
                    if (i + 3 < input.Length && input[i + 1].ToString() == "a" && input[i + 2].ToString() == "n" && input[i + 3].ToString() == "(")
                    {
                        Array.Resize(ref function, function.Length + 1);
                        function[function.Length - 1] = "tan(";
                        i += 3;
                        continue;
                    }
                    else return null;
                }
                if (input[i].ToString() == "(")
                {
                    Array.Resize(ref function, function.Length + 1);
                    function[function.Length - 1] = "(";
                    continue;
                }
                if (input[i].ToString() == ")")
                {
                    Array.Resize(ref function, function.Length + 1);
                    function[function.Length - 1] = ")";
                    continue;
                }
                #endregion

                #region number
                else if ((int)input[i] >= 48 && (int)input[i] <= 57)
                {
                    Array.Resize(ref function, function.Length + 1);
                    function[function.Length - 1] = input[i].ToString();
                    if (i < input.Length - 1)
                    {
                        i++;
                        while (i < input.Length && (int)input[i] >= 48 && (int)input[i] <= 57)
                        {
                            function[function.Length - 1] += input[i].ToString();
                            i++;
                        }
                        i--;
                    }
                    continue;
                }
                #endregion

                #region operator
                if (input[i].ToString() == "+" ||
                    input[i].ToString() == "-" ||
                    input[i].ToString() == "*" ||
                    input[i].ToString() == "/" ||
                    input[i].ToString() == "^")
                {

                    // checking if there's no adjacent operations that aren't + or -
                    int j = i + 1;
                    while (!((int)input[j] >= 48 && (int)input[j] <= 57))
                    {
                        if (input[j].ToString() == " ")
                        {
                            j++;
                            continue;
                        }
                        if (input[j].ToString() == "+" ||
                            input[j].ToString() == "-" ||
                            input[j].ToString() == "*" ||
                            input[j].ToString() == "/" ||
                            input[j].ToString() == "^")
                        {
                            return null;
                        }
                        break;
                    }

                    // adding the current operator
                    Array.Resize(ref function, function.Length + 1);
                    function[function.Length - 1] = input[i].ToString();

                    continue;
                }
                #endregion

                #region variables
                if (input[i].ToString() == "x")
                {
                    Array.Resize(ref function, function.Length + 1);
                    function[function.Length - 1] = "x";
                    continue;
                }
                if (input[i].ToString() == "y")
                {
                    Array.Resize(ref function, function.Length + 1);
                    function[function.Length - 1] = "y";
                    continue;
                }
                #endregion

                return null;
            }

            foreach (string s in function)
            {
                if (s.Contains("("))
                    parCount++;
                if (s == ")")
                    parCount--;
                if (parCount < 0)
                    return null;
            }
            if (parCount != 0)
                return null;

            return function;
        }

        public void ChangeTheme()
        {
            if (themes.SelectedIndex == 0) // standard
            {
                canvas.BackColor = Color.LightGray;
                gridPen.Color = Color.FromArgb(190, 190, 190);
                graphPen.Color = Color.Black;
                yPen.Color = Color.Red;
                xPen.Color = Color.Blue;
            }
            else if (themes.SelectedIndex == 1) // magical
            {
                canvas.BackColor = Color.FromArgb(240, 73, 163);
                gridPen.Color = Color.FromArgb(220, 53, 143);
                graphPen.Color = Color.FromArgb(122, 165, 243);
                xPen.Color = Color.FromArgb(13, 16, 88);
                yPen.Color = Color.FromArgb(13, 16, 88);
            }
            else if (themes.SelectedIndex == 2) // dark
            {
                canvas.BackColor = Color.FromArgb(4, 12, 14);
                gridPen.Color = Color.FromArgb(14, 22, 24);
                graphPen.Color = Color.FromArgb(190, 144, 99);
                xPen.Color = Color.FromArgb(164, 151, 142);
                yPen.Color = Color.FromArgb(82, 91, 86);
            }
            else if (themes.SelectedIndex == 3) // fluffy
            {
                canvas.BackColor = Color.FromArgb(255, 165, 220);
                gridPen.Color = Color.FromArgb(255, 125, 255);
                graphPen.Color = Color.FromArgb(255, 250, 250);
                xPen.Color = Color.FromArgb(0, 141, 225);
                yPen.Color = Color.FromArgb(0, 181, 245);
            }
            else if (themes.SelectedIndex == 4) // satanic
            {
                canvas.BackColor = Color.FromArgb(135, 0, 0);
                gridPen.Color = Color.FromArgb(150, 15, 15);
                graphPen.Color = Color.FromArgb(255, 0, 35);
                xPen.Color = Color.FromArgb(0, 0, 0);
                yPen.Color = Color.FromArgb(0, 0, 0);
            }
            else if (themes.SelectedIndex == 5) // nature
            {
                canvas.BackColor = Color.FromArgb(109, 127, 4);
                gridPen.Color = Color.FromArgb(109, 107, 0);
                graphPen.Color = Color.FromArgb(112, 68, 4);
                xPen.Color = Color.FromArgb(6, 48, 1);
                yPen.Color = Color.FromArgb(48, 66, 1);
            }
            else if (themes.SelectedIndex == 6) // clay
            {
                canvas.BackColor = Color.FromArgb(255, 204, 62);
                gridPen.Color = Color.FromArgb(235, 184, 42);
                graphPen.Color = Color.FromArgb(192, 56, 64);
                xPen.Color = Color.FromArgb(65, 20, 74);
                yPen.Color = Color.FromArgb(0, 61, 115);
            }
        }

        public Form1()
        {
            InitializeComponent();

            res = (double)resUpDown.Value * 5;
            res3D = (double)resUpDown.Value;
            angle = (double)angleUpDown.Value * Math.PI / 180;
            zoom = (double)scaleUpDown.Value;
            range3D = (double)rangeUpDown.Value;

            g = canvas.CreateGraphics();
            themes.SelectedItem = themes.Items[2];
            themes.Text = themes.Items[2].ToString();
            themes.SelectedIndexChanged += Themes_SelectedIndexChanged;
            ChangeTheme();
            this.KeyPress += Form1_KeyPress;
            graphPoints = new Point[(int)res * 2 + 1];
            xx = new double[(int)res3D * 2 + 1, (int)res3D * 2 + 1];
            yy = new double[(int)res3D * 2 + 1, (int)res3D * 2 + 1];       
            zz = new double[(int)res3D * 2 + 1, (int)res3D * 2 + 1];
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'w')
                yStretch += 2;
            if (e.KeyChar == 's')
                yStretch -= 2;
            if (e.KeyChar == 'a')
                xStretch += 2;
            if (e.KeyChar == 'd')
                xStretch -= 2;
            canvas.Refresh();
        }

        private void Themes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeTheme();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CalcButton_Click(object sender, EventArgs e)
        {
            string[] function = stringToArray(textBox1.Text);
            minHeight = 0;
            maxHeight = 0;

            #region 2D
            if (!do3D.Checked)
            {
                if (function != null)
                {
                    graphPoints = new Point[(int)res * 2 + 1];

                    binTree = ops.ToTree(function);

                    int i = 0;
                    for (double x = -res; x <= res; x++)
                    {
                        double mathX = x * (canvas.Width / zoom) / res;
                        double mathY = ops.Result(binTree, mathX, 1);

                        if (!double.IsInfinity(mathY) && mathY < 5000 && mathY > -5000)
                        {   
                            int drawX = (int)(mathX * zoom);
                            int drawY = (int)(mathY * zoom);
                            drawPoint.Y = canvas.Height - drawY;
                            drawPoint.X = drawX;

                            drawPoint.X += canvas.Width / 2;
                            drawPoint.Y -= canvas.Height / 2;

                            graphPoints[i] = drawPoint;
                        }
                        else
                        {
                            drawPoint.Y = 5001;
                            graphPoints[i] = drawPoint;
                        }
                        i++;
                    }
                    canvas.Refresh();
                }
                else
                {
                    MessageBox.Show("Couldn't analyze input");
                }
            }
            #endregion

            #region 3D
            else
            {
                if (function != null)
                {
                    xx = new double[(int)res3D * 2 + 1, (int)res3D * 2 + 1];
                    yy = new double[(int)res3D * 2 + 1, (int)res3D * 2 + 1];
                    zz = new double[(int)res3D * 2 + 1, (int)res3D * 2 + 1];
                    
                    binTree = ops.ToTree(function);

                    //for (double y = -range3D / res3D; y <= range3D / res3D; y++)
                    for (double y = -res3D; y <= res3D; y++)
                    {
                        for (double x = -res3D; x <= res3D; x++)
                        {
                            double mathX = x / res3D * range3D;
                            double mathY = y / res3D * range3D;
                            double mathZ = ops.Result(binTree, mathX, mathY);

                            if (mathZ < minHeight)
                                minHeight = mathZ;
                            else if (mathZ > maxHeight)
                                maxHeight = mathZ;

                            if (!double.IsInfinity(mathZ) && mathZ < 5000 && mathZ > -5000)
                            {
                                xx[(int)(x + res3D), (int)(y + res3D)] = mathX;
                                yy[(int)(x + res3D), (int)(y + res3D)] = mathY;
                                zz[(int)(x + res3D), (int)(y + res3D)] = mathZ;
                            }
                        }
                    }
                    canvas.Refresh();
                }
                else
                {
                    MessageBox.Show("Couldn't analyze input");
                }
            }
            #endregion
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            #region 3D
            if (do3D.Checked)
            {              
                // drawing axises
                //g.DrawLine(yPen, new Point(canvas.Width / 2, 0), new Point(canvas.Width / 2, canvas.Height));
                //g.DrawLine(xPen, new Point(0, canvas.Height / 2), new Point(canvas.Width, canvas.Height / 2));

                Pen pen = new Pen(Color.FromArgb(255, 0 , 0));
                // drawing graph
                for (int i = xx.GetLength(0) - 2; i > 0; i--)
                {
                    for (int j = 0; j < xx.GetLength(0) - 2; j++)
                    {
                        if (xx != null && graphPoints.GetLength(0) > 1)
                        {                         
                            Point[] points = new Point[4];

                            points[0] = new Point(
                                (int)((yy[j, i] + xx[j, i] * Math.Cos(angle)) * xStretch * zoom) + canvas.Width / 2,
                                canvas.Height / 2 - (int)((zz[j, i] * yStretch - xx[j, i] * Math.Sin(angle)) * zoom)
                                );

                            points[1] = new Point(
                                (int)((yy[j, i + 1] + xx[j, i + 1] * Math.Cos(angle)) * xStretch * zoom) + canvas.Width / 2,
                                canvas.Height / 2 - (int)((zz[j, i + 1] * yStretch - xx[j, i + 1] * Math.Sin(angle)) * zoom)
                                );

                            points[2] = new Point(
                                (int)((yy[j + 1, i + 1] + xx[j + 1, i + 1] * Math.Cos(angle)) * xStretch * (int)zoom) + canvas.Width / 2,
                                canvas.Height / 2 - (int)((zz[j + 1, i + 1] * yStretch - xx[j + 1, i + 1] * Math.Sin(angle)) * zoom)
                                );   

                            points[3] = new Point(
                                (int)((yy[j + 1, i] + xx[j + 1, i] * Math.Cos(angle)) * xStretch * (int)zoom) + canvas.Width / 2,
                                canvas.Height / 2 - (int)((zz[j + 1, i] * yStretch - xx[j + 1, i] * Math.Sin(angle)) * zoom)
                                );

                            int color = 0;
                            int blueTone = 0;
                            if (maxHeight - minHeight != 0)
                            {
                                color = (int)(255 * (zz[j, i] - minHeight) / (maxHeight - minHeight));
                                blueTone = (int)(255 * (2 * res3D - j) / (2 * res3D));
                            }

                            g.FillPolygon(
                                new SolidBrush(Color.FromArgb(255 - color, color, blueTone)), 
                                points
                                );
                        }
                    }
                }
            }
            #endregion

            #region 2D
            else
            {
                #region drawing small x-axis lines 
                for (double x = 0; x <= (canvas.Width / 2) / zoom; x++)
                {
                    g.DrawLine(gridPen,
                        new Point((int)(x * zoom) + canvas.Width / 2, 0),
                        new Point((int)(x * zoom) + canvas.Width / 2, canvas.Height));
                    if (zoom > 5)
                        g.DrawLine(new Pen(xPen.Color),
                            new Point((int)(x * zoom) + canvas.Width / 2, canvas.Height / 2 - INDICATOR_WIDTH),
                            new Point((int)(x * zoom) + canvas.Width / 2, canvas.Height / 2 + INDICATOR_WIDTH));
                }
                for (double x = 0; x >= -(canvas.Width / 2) / zoom; x--)
                {
                    g.DrawLine(gridPen,
                        new Point((int)(x * zoom) + canvas.Width / 2, 0),
                        new Point((int)(x * zoom) + canvas.Width / 2, canvas.Height));
                    if (zoom > 5)
                        g.DrawLine(new Pen(xPen.Color),
                            new Point((int)(x * zoom) + canvas.Width / 2, canvas.Height / 2 - INDICATOR_WIDTH),
                            new Point((int)(x * zoom) + canvas.Width / 2, canvas.Height / 2 + INDICATOR_WIDTH));
                }
                #endregion

                #region drawing small y-axis lines
                for (double y = 0; y <= (canvas.Width / 2) / zoom; y++)
                {
                    g.DrawLine(gridPen,
                        new Point(0, (int)(y * zoom) + canvas.Height / 2),
                        new Point(canvas.Width, (int)(y * zoom) + canvas.Height / 2));
                    if (zoom > 5)
                        g.DrawLine(new Pen(yPen.Color),
                            new Point(canvas.Width / 2 - INDICATOR_WIDTH, (int)(y * zoom) + canvas.Height / 2),
                            new Point(canvas.Width / 2 + INDICATOR_WIDTH, (int)(y * zoom) + canvas.Height / 2));
                }
                for (double y = 0; y >= -(canvas.Width / 2) / zoom; y--)
                {
                    g.DrawLine(gridPen,
                        new Point(0, (int)(y * zoom) + canvas.Height / 2),
                        new Point(canvas.Width, (int)(y * zoom) + canvas.Height / 2));
                    if (zoom > 5)
                        g.DrawLine(new Pen(yPen.Color),
                            new Point(canvas.Width / 2 - INDICATOR_WIDTH, (int)(y * zoom) + canvas.Height / 2),
                            new Point(canvas.Width / 2 + INDICATOR_WIDTH, (int)(y * zoom) + canvas.Height / 2));
                }
                #endregion

                // drawing axises
                g.DrawLine(yPen, new Point(canvas.Width / 2, 0), new Point(canvas.Width / 2, canvas.Height));
                g.DrawLine(xPen, new Point(0, canvas.Height / 2), new Point(canvas.Width, canvas.Height / 2));

                // drawing graph
                for (int i = 0; i < graphPoints.GetLength(0) - 1; i++)
                {
                    if (graphPoints != null && graphPoints.Length > 1 && 
                        !((graphPoints[i].Y < -canvas.Height || graphPoints[i].Y > canvas.Height * 2) || (graphPoints[i + 1].Y < -canvas.Height || graphPoints[i + 1].Y > canvas.Height * 2)))
                    {
                        g.DrawLine(graphPen, graphPoints[i], graphPoints[i + 1]);
                    }
                }
            }
            #endregion
        }

        private void resUpDown_ValueChanged(object sender, EventArgs e)
        {
            res = (double)resUpDown.Value * 5;
            res3D = (double)resUpDown.Value;
        }

        private void rangeUpDown_ValueChanged(object sender, EventArgs e)
        {
            range3D = (double)rangeUpDown.Value;
        }

        private void angleUpDown_ValueChanged(object sender, EventArgs e)
        {
            angle = (double)angleUpDown.Value * Math.PI / 180;
        }

        private void scaleUpDown_ValueChanged(object sender, EventArgs e)
        {
            zoom = (double)scaleUpDown.Value;
            if (zoom < 10)
                graphPen.Width = 1;
            else
                graphPen.Width = 2;
        }

        private void xDown_Click(object sender, EventArgs e)
        {
            xStretch = Math.Max(0.1, xStretch - 0.1);
        }

        private void yDown_Click(object sender, EventArgs e)
        {
            yStretch = Math.Max(0.1, yStretch - 0.1);
        }

        private void yUp_Click(object sender, EventArgs e)
        {
            yStretch = Math.Min(10, yStretch + 0.1);
        }

        private void xUp_Click(object sender, EventArgs e)
        {
            xStretch = Math.Min(10, xStretch + 0.1);
        }
    }
}
