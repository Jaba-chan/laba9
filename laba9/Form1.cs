using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace laba9
{
    public partial class Form1 : Form
    {
        double f(double x, double b)
        {
            return 9 * (x + 15 * Math.Pow(Math.Pow(x, 3) + Math.Pow(b, 3), 1 / 2));
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = (-2.4).ToString();
            textBox2.Text = (1.0).ToString();
            textBox3.Text = (0.2).ToString();
            textBox4.Text = (2.5).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x0 = double.Parse(textBox1.Text);
            double xk = double.Parse(textBox2.Text);
            double dx = double.Parse(textBox3.Text);
            double b = double.Parse(textBox4.Text);
            int step = (int)Math.Ceiling((xk - x0) / dx) + 1;
            double delta = (xk - x0) / step;
            double[] x_array = new double[step];
            double[] y_array = new double[step];
            for (int i = 0; i < step; i++)
            {
                x_array[i] = x0 + delta*i;
                Debug.WriteLine(delta);
                Debug.WriteLine(x_array[i]);
                y_array[i] = f(x_array[i], b);
            }
            chart1.ChartAreas[0].AxisX.Minimum = x0;
            chart1.ChartAreas[0].AxisX.Maximum = xk;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = step;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series[0].Points.DataBindXY(x_array, y_array);
        }
    }
}
