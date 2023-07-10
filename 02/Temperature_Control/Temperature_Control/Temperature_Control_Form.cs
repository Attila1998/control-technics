using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Temperature_Control
{
    public partial class Temperature_Control_Form : Form
    {
        Series temperatureSeries, ControlSignal; // tömbhöz hasonló változó, sornak nevezik
        Random rand = new Random(); // veletlen szam generalas
        const uint max_chart_axis_x = 100;



        public Temperature_Control_Form()
        {
            InitializeComponent();

            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, this.Height);
            this.MinimumSize = new Size(0, this.Height);
        }

        private void Temperature_Control_Form_Load(object sender, EventArgs ea)
        {
            // itt inicializáljuk a dolgokat

            Temperature_chart.Titles.Add("Controlled temperature"); // Grafikon elnevezése
            Temperature_chart.ChartAreas[0].AxisX.Title = "Time (s)"; // X tengely feliratának módosítása 
            Temperature_chart.ChartAreas[0].AxisY.Title = "Temperature (°C)"; // Y tengely feliratának módosítása
            Temperature_chart.ChartAreas[0].AxisY.Minimum = 0;
            Temperature_chart.ChartAreas[0].AxisY.Maximum = 100;

            Temperature_chart.Series.Clear();

            temperatureSeries = Temperature_chart.Series.Add("Temp.");
            temperatureSeries.ChartType = SeriesChartType.Spline;
            temperatureSeries.Color = Color.ForestGreen;

            controlTimer.Interval = 1000; //1000ms
            controlTimer.Start();

            

            ControlSignal_chart.Titles.Add("Controlled Output");
            ControlSignal_chart.ChartAreas[0].AxisX.Title = "Time (s)";
            ControlSignal_chart.ChartAreas[0].AxisY.Title = "Amplitude";
            ControlSignal_chart.ChartAreas[0].AxisY.Minimum = -100;
            ControlSignal_chart.ChartAreas[0].AxisY.Maximum = 100;

            ControlSignal_chart.Series.Clear();

            ControlSignal = ControlSignal_chart.Series.Add("Amplitude");
            ControlSignal.ChartType = SeriesChartType.Spline;
            ControlSignal.Color = Color.DarkBlue;


        }

        private void controlTimer_Tick(object sender, EventArgs ea)
        {
            double temp = rand.Next(0, 100);

            double control = rand.Next(-100, 100);

            if(temperatureSeries.Points.Count > max_chart_axis_x)
            {
                temperatureSeries.Points.RemoveAt(0);

            }

            temperatureSeries.Points.Add(temp);
            Temperature_chart.ResetAutoValues();



            if(ControlSignal.Points.Count > max_chart_axis_x)
            {
                ControlSignal.Points.RemoveAt(0);
            }

            ControlSignal.Points.Add(control);
            ControlSignal_chart.ResetAutoValues();



        }

        private void Temperature_chart_Click(object sender, EventArgs e)
        {

        }

        private void Temperature_Control_Form_FormClosed(object sender, FormClosedEventArgs ea)
        {
            //ez akkor hivodik meg amikor bezarjuk a grafikus feluletet

            
        }
    }
}
