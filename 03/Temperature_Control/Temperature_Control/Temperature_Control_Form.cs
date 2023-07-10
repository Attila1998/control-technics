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

        MccDaq.MccBoard Kartya = new MccDaq.MccBoard(0); /// kimeneti kartya peldanyositasa
                                                         /// Azert zero, mert egy van, annak az indexe 0
                                                         /// Ezt hasznaljuk kimenet irasahoz, es bemenet olvasasahoz
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

            /// Digitalis kimenet A1

            Kartya.DConfigPort(DigitalPortType.FifthPortA, DigitalPortDirection.DigitalOut);


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
            double delta=0.7; /// a kesobbiekben majd beolvasva a frombol
                            /// a doboz mar kirakva

            /// ADC beolvasas
            short Analog_bemenet_0;
            Kartya.AIn(0, Range.Bip10Volts, out Analog_bemenet_0); /// +-10 volt olvashato, beolvasom az analog bemenetet 
            AD_textBox.Text = Analog_bemenet_0.ToString(); /// bemenet kirakasa az adott szovegdobozba

            if (temperatureSeries.Points.Count > max_chart_axis_x)
            {
                temperatureSeries.Points.RemoveAt(0);

            }

            /// Skalazas
            double bemenet_voltban = (20 / 4095.0) * (Convert.ToDouble(Analog_bemenet_0) - 2048); //skálázás
            double y_t = 100 * Analog_bemenet_0 - 273.15; //0 Kelvin = -273.15 Celsius
            Temperature_textBox.Text = y_t.ToString("F");

            double hiba=0;
            /// Checkboxok
            /// Beavatkozo
            /// Kezi uzemmod
            if (Manual_radioButton.Checked)
            {
                short kimenet_0=0;
                bool van_e_aktiv = false;

                if (Heat_checkBox.Checked && van_e_aktiv==false)
                {
                    kimenet_0 = 1; // ha melegitunk
                    van_e_aktiv = true;
                }
                if (Cool_checkBox.Checked && van_e_aktiv == false)
                {
                    kimenet_0 = 2; // ha hutunk
                    van_e_aktiv = true;
                }
                Kartya.DOut(DigitalPortType.FifthPortA, kimenet_0);
            }

            /// Automata uzemmod
            /// 
            else
            {
                if(Automat_radioButton.Checked) /// ha aktiv, szabalyzas
                {
                    double referencia = 0;
                    try
                    {
                        referencia = Convert.ToDouble(Reference_textBox.Text);

                    }
                    catch
                    {
                        referencia = 0;
                    }


                    if(!HISZTEREZIS.Checked)
                    {
                         hiba = referencia-y_t; //ref - jelenlegi hőmérséklet
                        if(hiba>0) /// melegitunk
                        {
                            Kartya.DOut(DigitalPortType.FifthPortA, 1);
                            ControlSignal_textBox.Text = "Melegites";
                        }
                        else
                        {
                            Kartya.DOut(DigitalPortType.FifthPortA, 2);
                            ControlSignal_textBox.Text = "Hutes";
                        }
                    }
                    else
                    {
                        if (hiba > delta)
                        {
                            ControlSignal_textBox.Text = "Melegites";
                            Kartya.DOut(DigitalPortType.FirstPortA, 1);
                        }
                        if (hiba < delta)
                        {
                            ControlSignal_textBox.Text = "Hutes";
                            Kartya.DOut(DigitalPortType.FirstPortA, 2);
                        }

                        if (hiba == delta)
                        {
                            Egyenlo.Text = "=";
                        }
                    }
                   
                }
                else
                {
                    Heat_checkBox.Checked = false; /// pipaval valo jatszadozas kiiktatasa
                    Cool_checkBox.Checked = false;
                }
            }


            if(temperatureSeries.Points.Count> max_chart_axis_x)
            {
                temperatureSeries.Points.RemoveAt(0); /// utolso torlese
            }
            
            if (ControlSignal.Points.Count > max_chart_axis_x)
            {
                ControlSignal.Points.RemoveAt(0); /// utolso torlese
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

        private void Manual_GroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void Automat_GroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void AD_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void ControlSignal_chart_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Automat_radioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Temperature_Control_Form_FormClosed(object sender, FormClosedEventArgs ea)
        {
            //ez akkor hivodik meg amikor bezarjuk a grafikus feluletet
            Kartya.DOut(DigitalPortType.FifthPortA, 0); /// szabalyzas kikapcsolasa

        }
    }
}
