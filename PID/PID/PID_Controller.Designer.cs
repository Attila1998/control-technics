namespace PID
{
    partial class PID_Controller
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.inputChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.outputChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.controlTimer = new System.Windows.Forms.Timer(this.components);
            this.manCheckBox = new System.Windows.Forms.CheckBox();
            this.haltCheckBox = new System.Windows.Forms.CheckBox();
            this.pinCheckBox = new System.Windows.Forms.CheckBox();
            this.iinCheckBox = new System.Windows.Forms.CheckBox();
            this.dinCheckBox = new System.Windows.Forms.CheckBox();
            this.donpvCheckBox = new System.Windows.Forms.CheckBox();
            this.gainTextBox = new System.Windows.Forms.TextBox();
            this.tiTextBox = new System.Windows.Forms.TextBox();
            this.tdTextBox = new System.Windows.Forms.TextBox();
            this.tdlagTextBox = new System.Windows.Forms.TextBox();
            this.ymaxTextBox = new System.Windows.Forms.TextBox();
            this.yminTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ymanTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inputChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ymanTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // inputChart
            // 
            this.inputChart.BorderlineColor = System.Drawing.SystemColors.WindowText;
            chartArea1.AxisX.Title = "Time";
            chartArea1.AxisY.Title = "Value";
            chartArea1.Name = "ChartArea1";
            this.inputChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.inputChart.Legends.Add(legend1);
            this.inputChart.Location = new System.Drawing.Point(0, 0);
            this.inputChart.Name = "inputChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.Name = "input";
            this.inputChart.Series.Add(series1);
            this.inputChart.Size = new System.Drawing.Size(1200, 250);
            this.inputChart.TabIndex = 0;
            this.inputChart.Text = "chart1";
            title1.Name = "Input Chart";
            title1.Text = "Input";
            this.inputChart.Titles.Add(title1);
            // 
            // outputChart
            // 
            this.outputChart.BorderlineColor = System.Drawing.SystemColors.WindowText;
            chartArea2.AxisX.Title = "Time";
            chartArea2.AxisY.Title = "Value";
            chartArea2.Name = "ChartArea1";
            this.outputChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.outputChart.Legends.Add(legend2);
            this.outputChart.Location = new System.Drawing.Point(0, 250);
            this.outputChart.Name = "outputChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Legend = "Legend1";
            series2.Name = "output";
            this.outputChart.Series.Add(series2);
            this.outputChart.Size = new System.Drawing.Size(1200, 250);
            this.outputChart.TabIndex = 1;
            this.outputChart.Text = "chart1";
            title2.Name = "Output Chart";
            title2.Text = "Output ";
            this.outputChart.Titles.Add(title2);
            // 
            // controlTimer
            // 
            this.controlTimer.Tick += new System.EventHandler(this.controlTimer_Tick);
            // 
            // manCheckBox
            // 
            this.manCheckBox.AutoSize = true;
            this.manCheckBox.Location = new System.Drawing.Point(13, 518);
            this.manCheckBox.Name = "manCheckBox";
            this.manCheckBox.Size = new System.Drawing.Size(90, 17);
            this.manCheckBox.TabIndex = 2;
            this.manCheckBox.Text = "Manual mode";
            this.manCheckBox.UseVisualStyleBackColor = true;
            // 
            // haltCheckBox
            // 
            this.haltCheckBox.AutoSize = true;
            this.haltCheckBox.Location = new System.Drawing.Point(13, 541);
            this.haltCheckBox.Name = "haltCheckBox";
            this.haltCheckBox.Size = new System.Drawing.Size(117, 17);
            this.haltCheckBox.TabIndex = 3;
            this.haltCheckBox.Text = "Halt operating mide";
            this.haltCheckBox.UseVisualStyleBackColor = true;
            // 
            // pinCheckBox
            // 
            this.pinCheckBox.AutoSize = true;
            this.pinCheckBox.Location = new System.Drawing.Point(13, 564);
            this.pinCheckBox.Name = "pinCheckBox";
            this.pinCheckBox.Size = new System.Drawing.Size(73, 17);
            this.pinCheckBox.TabIndex = 4;
            this.pinCheckBox.Text = "P-comp in";
            this.pinCheckBox.UseVisualStyleBackColor = true;
            // 
            // iinCheckBox
            // 
            this.iinCheckBox.AutoSize = true;
            this.iinCheckBox.Location = new System.Drawing.Point(13, 587);
            this.iinCheckBox.Name = "iinCheckBox";
            this.iinCheckBox.Size = new System.Drawing.Size(69, 17);
            this.iinCheckBox.TabIndex = 5;
            this.iinCheckBox.Text = "I-comp in";
            this.iinCheckBox.UseVisualStyleBackColor = true;
            // 
            // dinCheckBox
            // 
            this.dinCheckBox.AutoSize = true;
            this.dinCheckBox.Location = new System.Drawing.Point(13, 610);
            this.dinCheckBox.Name = "dinCheckBox";
            this.dinCheckBox.Size = new System.Drawing.Size(74, 17);
            this.dinCheckBox.TabIndex = 6;
            this.dinCheckBox.Text = "D-comp in";
            this.dinCheckBox.UseVisualStyleBackColor = true;
            // 
            // donpvCheckBox
            // 
            this.donpvCheckBox.AutoSize = true;
            this.donpvCheckBox.Location = new System.Drawing.Point(13, 633);
            this.donpvCheckBox.Name = "donpvCheckBox";
            this.donpvCheckBox.Size = new System.Drawing.Size(62, 17);
            this.donpvCheckBox.TabIndex = 7;
            this.donpvCheckBox.Text = "d on pv";
            this.donpvCheckBox.UseVisualStyleBackColor = true;
            // 
            // gainTextBox
            // 
            this.gainTextBox.Location = new System.Drawing.Point(222, 515);
            this.gainTextBox.Name = "gainTextBox";
            this.gainTextBox.Size = new System.Drawing.Size(100, 20);
            this.gainTextBox.TabIndex = 8;
            this.gainTextBox.Text = "1";
            // 
            // tiTextBox
            // 
            this.tiTextBox.Location = new System.Drawing.Point(222, 541);
            this.tiTextBox.Name = "tiTextBox";
            this.tiTextBox.Size = new System.Drawing.Size(100, 20);
            this.tiTextBox.TabIndex = 9;
            this.tiTextBox.Text = "1";
            // 
            // tdTextBox
            // 
            this.tdTextBox.Location = new System.Drawing.Point(222, 567);
            this.tdTextBox.Name = "tdTextBox";
            this.tdTextBox.Size = new System.Drawing.Size(100, 20);
            this.tdTextBox.TabIndex = 10;
            this.tdTextBox.Text = "1";
            // 
            // tdlagTextBox
            // 
            this.tdlagTextBox.Location = new System.Drawing.Point(222, 593);
            this.tdlagTextBox.Name = "tdlagTextBox";
            this.tdlagTextBox.Size = new System.Drawing.Size(100, 20);
            this.tdlagTextBox.TabIndex = 11;
            this.tdlagTextBox.Text = "1";
            // 
            // ymaxTextBox
            // 
            this.ymaxTextBox.Location = new System.Drawing.Point(222, 619);
            this.ymaxTextBox.Name = "ymaxTextBox";
            this.ymaxTextBox.Size = new System.Drawing.Size(100, 20);
            this.ymaxTextBox.TabIndex = 12;
            this.ymaxTextBox.Text = "15";
            // 
            // yminTextBox
            // 
            this.yminTextBox.Location = new System.Drawing.Point(222, 645);
            this.yminTextBox.Name = "yminTextBox";
            this.yminTextBox.Size = new System.Drawing.Size(100, 20);
            this.yminTextBox.TabIndex = 13;
            this.yminTextBox.Text = "-15";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1070, 506);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 761);
            this.splitter1.TabIndex = 15;
            this.splitter1.TabStop = false;
            // 
            // ymanTrackBar
            // 
            this.ymanTrackBar.Location = new System.Drawing.Point(222, 680);
            this.ymanTrackBar.Name = "ymanTrackBar";
            this.ymanTrackBar.Size = new System.Drawing.Size(104, 45);
            this.ymanTrackBar.TabIndex = 16;
            this.ymanTrackBar.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 680);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "YMAN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 619);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "YMAX";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 645);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "YMIN";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1070, 541);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 515);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "GAIN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 542);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "TI";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 567);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "TD";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(167, 593);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "TD_LAG";
            // 
            // PID_Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ymanTrackBar);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.yminTextBox);
            this.Controls.Add(this.ymaxTextBox);
            this.Controls.Add(this.tdlagTextBox);
            this.Controls.Add(this.tdTextBox);
            this.Controls.Add(this.tiTextBox);
            this.Controls.Add(this.gainTextBox);
            this.Controls.Add(this.donpvCheckBox);
            this.Controls.Add(this.dinCheckBox);
            this.Controls.Add(this.iinCheckBox);
            this.Controls.Add(this.pinCheckBox);
            this.Controls.Add(this.haltCheckBox);
            this.Controls.Add(this.manCheckBox);
            this.Controls.Add(this.outputChart);
            this.Controls.Add(this.inputChart);
            this.Name = "PID_Controller";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.PID_Controller_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inputChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ymanTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart inputChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart outputChart;
        private System.Windows.Forms.Timer controlTimer;
        private System.Windows.Forms.CheckBox manCheckBox;
        private System.Windows.Forms.CheckBox haltCheckBox;
        private System.Windows.Forms.CheckBox pinCheckBox;
        private System.Windows.Forms.CheckBox iinCheckBox;
        private System.Windows.Forms.CheckBox dinCheckBox;
        private System.Windows.Forms.CheckBox donpvCheckBox;
        private System.Windows.Forms.TextBox gainTextBox;
        private System.Windows.Forms.TextBox tiTextBox;
        private System.Windows.Forms.TextBox tdTextBox;
        private System.Windows.Forms.TextBox tdlagTextBox;
        private System.Windows.Forms.TextBox ymaxTextBox;
        private System.Windows.Forms.TextBox yminTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TrackBar ymanTrackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

