using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MccDaq;

namespace Temperature_Control
{
    public partial class Temperature_Control_Form : Form
    {
        Series temperatureSeries, ControlSignal; // tömbhöz hasonló változó, sornak nevezik
        Random rand = new Random(); // veletlen szam generalas
        const uint max_chart_axis_x = 100;

        MccDaq.MccBoard DaqBoard = new MccDaq.MccBoard(0);

        double delta = 0.5; // hiszterezis


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

            //Kartya kimenetkent valo beallitasa
            DaqBoard.DConfigPort(DigitalPortType.FirstPortA, DigitalPortDirection.DigitalOut);


            //idozito elinditasa
            controlTimer.Interval = 1000;
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
            //double temp = rand.Next(0, 100);
            //double control = rand.Next(-100, 100);

            //az analog atalakito ertekenek beolvasasa
            short ain_AD;
            DaqBoard.AIn(0,Range.Bip10Volts,out ain_AD);

            AD_textBox.Text = ain_AD.ToString();

            //skalazas
            double ain_volt = (20.0 / 4095.0) * (Convert.ToDouble(ain_AD) - 2048);
            double temp = (ain_volt - 2.7315) * 100;
            Temperature_textBox.Text = temp.ToString("F");


            //beavatkozo
            if(Manual_radioButton.Checked)
            {
                short doubt = 0;
                if(Heat_checkBox.Checked)
                {
                    doubt = 1;
                    Cool_checkBox.Checked = false;
                }
                if(Cool_checkBox.Checked)
                {
                    doubt = 2;
                    Heat_checkBox.Checked = false;
                }
                DaqBoard.DOut(DigitalPortType.FirstPortA, doubt);
            }
            else
            {
                if(Automat_radioButton.Checked)
                {
                    double reference = 0;
                    try
                    {
                        reference = Convert.ToDouble(Reference_textBox.Text);
                    }
                    catch
                    {
                        reference = 0;
                    }

                    double error = reference - temp;
                    /*
                    if(error > 0)
                    {
                        ControlSignal_textBox.Text = "Heating";
                        DaqBoard.DOut(DigitalPortType.FirstPortA, 1);
                    }
                    else
                    {
                        ControlSignal_textBox.Text = "Cooling";
                        DaqBoard.DOut(DigitalPortType.FirstPortA, 2);
                    }*/

                    // Hiszterezises szabalyozas
                    if(error > delta)
                    {
                        ControlSignal_textBox.Text = "Heating";
                        DaqBoard.DOut(DigitalPortType.FirstPortA, 1);
                    }
                    else if(error < delta)
                    {
                        ControlSignal_textBox.Text = "Cooling";
                        DaqBoard.DOut(DigitalPortType.FirstPortA, 2);
                    }


                }
                else
                {
                    Heat_checkBox.Checked = false;
                    Cool_checkBox.Checked = false;
                }
            }


            if (temperatureSeries.Points.Count > max_chart_axis_x)
            {
                temperatureSeries.Points.RemoveAt(0); 

            }

            //temperatureSeries.Points.Add(temp);
            Temperature_chart.ResetAutoValues();



            if(ControlSignal.Points.Count > max_chart_axis_x)
            {
                ControlSignal.Points.RemoveAt(0);
            }

            //ControlSignal.Points.Add(control);
            ControlSignal_chart.ResetAutoValues();



        }

        private void Temperature_Control_Form_FormClosed(object sender, FormClosedEventArgs ea)
        {
            //ez akkor hivodik meg amikor bezarjuk a grafikus feluletet
            DaqBoard.DOut(DigitalPortType.FirstPortA, 0);

        }
    }
}
