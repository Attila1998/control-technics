using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PID
{
    public partial class PID_Controller : Form
    {

        Series inputSeries;
        Series outputSeries;
        Random rand = new Random();
        ControlPID pid = new ControlPID();
        int i;


        public PID_Controller()
        {
            InitializeComponent();
        }

        private void PID_Controller_Load(object sender, EventArgs e)
        {
            
            inputSeries = inputChart.Series["input"];
            outputSeries = outputChart.Series["output"];
            ymanTrackBar.Maximum = int.Parse(ymaxTextBox.Text);
            ymanTrackBar.Minimum = int.Parse(yminTextBox.Text);
            i = 0;
            controlTimer.Start();
        }

        private void controlTimer_Tick(object sender, EventArgs e)
        {
            pid.yman = ymanTrackBar.Value;
            pid.calculateError(i);
            inputSeries.Points.Add(pid.sp[i]);
            outputSeries.Points.Add(pid.start(i));
            if (inputSeries.Points.Count >= 40)
            {
                inputSeries.Points.RemoveAt(0);
            }
            if (outputSeries.Points.Count >= 40)
            {
                outputSeries.Points.RemoveAt(0);
            }
            inputChart.ResetAutoValues();
            outputChart.ResetAutoValues();
            if (i == pid.sp.Length-1)
            {
                i = 0;
            }
            else
            {
                i++;
            }
            pid.para_pid.ymax = double.Parse(ymaxTextBox.Text);
            pid.para_pid.ymin = double.Parse(yminTextBox.Text);
            pid.mode_pid.man = manCheckBox.Checked;
            pid.mode_pid.halt = haltCheckBox.Checked;
            pid.mode_pid.en_p = pinCheckBox.Checked;
            pid.mode_pid.en_i = iinCheckBox.Checked;
            pid.mode_pid.en_d = dinCheckBox.Checked;
            pid.mode_pid.d_on_pv = donpvCheckBox.Checked;
            pid.para_pid.gain = double.Parse(gainTextBox.Text);
            pid.para_pid.ti = double.Parse(tiTextBox.Text);
            pid.para_pid.td = double.Parse(tdTextBox.Text);
            pid.para_pid.td_lag = double.Parse(tdlagTextBox.Text);
            pid.yman = ymanTrackBar.Value;

            pid.start(i);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i = 0;
            pid.mode_pid.en_p = pinCheckBox.Checked;
            pid.mode_pid.en_i = iinCheckBox.Checked;
            pid.mode_pid.en_d = dinCheckBox.Checked;
            pid.mode_pid.d_on_pv = donpvCheckBox.Checked;
            pid.para_pid.gain = double.Parse(gainTextBox.Text);
            pid.para_pid.ti = double.Parse(tiTextBox.Text);
            pid.para_pid.td = double.Parse(tdTextBox.Text);
            pid.para_pid.td_lag = double.Parse(tdlagTextBox.Text);
            //pid.para_pid.gain = 1;
            //pid.para_pid.ti = 1;
            //pid.para_pid.td = 1;
            //pid.para_pid.td_lag = 1;

            controlTimer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controlTimer.Stop();
        }

    
    }

}
