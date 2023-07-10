namespace Temperature_Control
{
    partial class Temperature_Control_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        


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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Manual_GroupBox = new System.Windows.Forms.GroupBox();
            this.Cool_checkBox = new System.Windows.Forms.CheckBox();
            this.Heat_checkBox = new System.Windows.Forms.CheckBox();
            this.Automat_GroupBox = new System.Windows.Forms.GroupBox();
            this.controlLoop_pictureBox = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Temperature_textBox = new System.Windows.Forms.TextBox();
            this.ControlSignal_textBox = new System.Windows.Forms.TextBox();
            this.ControlError_textBox = new System.Windows.Forms.TextBox();
            this.Reference_textBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.AD_textBox = new System.Windows.Forms.TextBox();
            this.Automat_radioButton = new System.Windows.Forms.RadioButton();
            this.Manual_radioButton = new System.Windows.Forms.RadioButton();
            this.controlTimer = new System.Windows.Forms.Timer(this.components);
            this.Temperature_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ControlSignal_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Manual_GroupBox.SuspendLayout();
            this.Automat_GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlLoop_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Temperature_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControlSignal_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // Manual_GroupBox
            // 
            this.Manual_GroupBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Manual_GroupBox.Controls.Add(this.Cool_checkBox);
            this.Manual_GroupBox.Controls.Add(this.Heat_checkBox);
            this.Manual_GroupBox.Location = new System.Drawing.Point(316, 478);
            this.Manual_GroupBox.Name = "Manual_GroupBox";
            this.Manual_GroupBox.Size = new System.Drawing.Size(300, 53);
            this.Manual_GroupBox.TabIndex = 4;
            this.Manual_GroupBox.TabStop = false;
            this.Manual_GroupBox.Text = "Manual Control";
            // 
            // Cool_checkBox
            // 
            this.Cool_checkBox.AutoSize = true;
            this.Cool_checkBox.Location = new System.Drawing.Point(170, 20);
            this.Cool_checkBox.Name = "Cool_checkBox";
            this.Cool_checkBox.Size = new System.Drawing.Size(55, 17);
            this.Cool_checkBox.TabIndex = 1;
            this.Cool_checkBox.Text = "COOL";
            this.Cool_checkBox.UseVisualStyleBackColor = true;
            // 
            // Heat_checkBox
            // 
            this.Heat_checkBox.AutoSize = true;
            this.Heat_checkBox.Location = new System.Drawing.Point(29, 22);
            this.Heat_checkBox.Name = "Heat_checkBox";
            this.Heat_checkBox.Size = new System.Drawing.Size(55, 17);
            this.Heat_checkBox.TabIndex = 0;
            this.Heat_checkBox.Text = "HEAT";
            this.Heat_checkBox.UseVisualStyleBackColor = true;
            // 
            // Automat_GroupBox
            // 
            this.Automat_GroupBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Automat_GroupBox.Controls.Add(this.controlLoop_pictureBox);
            this.Automat_GroupBox.Controls.Add(this.label7);
            this.Automat_GroupBox.Controls.Add(this.label6);
            this.Automat_GroupBox.Controls.Add(this.label5);
            this.Automat_GroupBox.Controls.Add(this.label10);
            this.Automat_GroupBox.Controls.Add(this.Temperature_textBox);
            this.Automat_GroupBox.Controls.Add(this.ControlSignal_textBox);
            this.Automat_GroupBox.Controls.Add(this.ControlError_textBox);
            this.Automat_GroupBox.Controls.Add(this.Reference_textBox);
            this.Automat_GroupBox.Location = new System.Drawing.Point(8, 537);
            this.Automat_GroupBox.Name = "Automat_GroupBox";
            this.Automat_GroupBox.Size = new System.Drawing.Size(608, 202);
            this.Automat_GroupBox.TabIndex = 5;
            this.Automat_GroupBox.TabStop = false;
            this.Automat_GroupBox.Text = "Automatic Control";
            // 
            // controlLoop_pictureBox
            // 
            this.controlLoop_pictureBox.Image = global::Temperature_Control.Properties.Resources.control_loop;
            this.controlLoop_pictureBox.InitialImage = global::Temperature_Control.Properties.Resources.control_loop;
            this.controlLoop_pictureBox.Location = new System.Drawing.Point(7, 104);
            this.controlLoop_pictureBox.Name = "controlLoop_pictureBox";
            this.controlLoop_pictureBox.Size = new System.Drawing.Size(587, 87);
            this.controlLoop_pictureBox.TabIndex = 11;
            this.controlLoop_pictureBox.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Reference Signal  ( r )";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(283, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Control Signal ( u )";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Error Signal ( e )";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(444, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(163, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Output Signal - Temperature (  y )";
            // 
            // Temperature_textBox
            // 
            this.Temperature_textBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Temperature_textBox.Location = new System.Drawing.Point(447, 76);
            this.Temperature_textBox.Name = "Temperature_textBox";
            this.Temperature_textBox.ReadOnly = true;
            this.Temperature_textBox.Size = new System.Drawing.Size(100, 20);
            this.Temperature_textBox.TabIndex = 3;
            // 
            // ControlSignal_textBox
            // 
            this.ControlSignal_textBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ControlSignal_textBox.Location = new System.Drawing.Point(286, 76);
            this.ControlSignal_textBox.Name = "ControlSignal_textBox";
            this.ControlSignal_textBox.ReadOnly = true;
            this.ControlSignal_textBox.Size = new System.Drawing.Size(100, 20);
            this.ControlSignal_textBox.TabIndex = 2;
            // 
            // ControlError_textBox
            // 
            this.ControlError_textBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ControlError_textBox.Location = new System.Drawing.Point(137, 76);
            this.ControlError_textBox.Name = "ControlError_textBox";
            this.ControlError_textBox.ReadOnly = true;
            this.ControlError_textBox.Size = new System.Drawing.Size(100, 20);
            this.ControlError_textBox.TabIndex = 1;
            // 
            // Reference_textBox
            // 
            this.Reference_textBox.Location = new System.Drawing.Point(7, 76);
            this.Reference_textBox.Name = "Reference_textBox";
            this.Reference_textBox.Size = new System.Drawing.Size(100, 20);
            this.Reference_textBox.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(452, 549);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(151, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Output Signal - AD Conversion";
            // 
            // AD_textBox
            // 
            this.AD_textBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AD_textBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.AD_textBox.Location = new System.Drawing.Point(455, 568);
            this.AD_textBox.Name = "AD_textBox";
            this.AD_textBox.ReadOnly = true;
            this.AD_textBox.Size = new System.Drawing.Size(100, 20);
            this.AD_textBox.TabIndex = 7;
            // 
            // Automat_radioButton
            // 
            this.Automat_radioButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Automat_radioButton.AutoSize = true;
            this.Automat_radioButton.Location = new System.Drawing.Point(17, 498);
            this.Automat_radioButton.Name = "Automat_radioButton";
            this.Automat_radioButton.Size = new System.Drawing.Size(78, 17);
            this.Automat_radioButton.TabIndex = 9;
            this.Automat_radioButton.TabStop = true;
            this.Automat_radioButton.Text = "AUTOMAT";
            this.Automat_radioButton.UseVisualStyleBackColor = true;
            // 
            // Manual_radioButton
            // 
            this.Manual_radioButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Manual_radioButton.AutoSize = true;
            this.Manual_radioButton.Location = new System.Drawing.Point(182, 499);
            this.Manual_radioButton.Name = "Manual_radioButton";
            this.Manual_radioButton.Size = new System.Drawing.Size(70, 17);
            this.Manual_radioButton.TabIndex = 10;
            this.Manual_radioButton.TabStop = true;
            this.Manual_radioButton.Text = "MANUAL";
            this.Manual_radioButton.UseVisualStyleBackColor = true;
            // 
            // controlTimer
            // 
            this.controlTimer.Tick += new System.EventHandler(this.controlTimer_Tick);
            // 
            // Temperature_chart
            // 
            this.Temperature_chart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.Temperature_chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Temperature_chart.Legends.Add(legend1);
            this.Temperature_chart.Location = new System.Drawing.Point(15, 8);
            this.Temperature_chart.Name = "Temperature_chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.Temperature_chart.Series.Add(series1);
            this.Temperature_chart.Size = new System.Drawing.Size(600, 250);
            this.Temperature_chart.TabIndex = 11;
            this.Temperature_chart.Text = "chart";
            this.Temperature_chart.Click += new System.EventHandler(this.Temperature_chart_Click);
            // 
            // ControlSignal_chart
            // 
            this.ControlSignal_chart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.ControlSignal_chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ControlSignal_chart.Legends.Add(legend2);
            this.ControlSignal_chart.Location = new System.Drawing.Point(16, 267);
            this.ControlSignal_chart.Name = "ControlSignal_chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.ControlSignal_chart.Series.Add(series2);
            this.ControlSignal_chart.Size = new System.Drawing.Size(600, 250);
            this.ControlSignal_chart.TabIndex = 12;
            this.ControlSignal_chart.Text = "chart2";
            // 
            // Temperature_Control_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 745);
            this.Controls.Add(this.ControlSignal_chart);
            this.Controls.Add(this.Temperature_chart);
            this.Controls.Add(this.Manual_radioButton);
            this.Controls.Add(this.Automat_radioButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.AD_textBox);
            this.Controls.Add(this.Automat_GroupBox);
            this.Controls.Add(this.Manual_GroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Temperature_Control_Form";
            this.Text = "Temperature Control";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Temperature_Control_Form_FormClosed);
            this.Load += new System.EventHandler(this.Temperature_Control_Form_Load);
            this.Manual_GroupBox.ResumeLayout(false);
            this.Manual_GroupBox.PerformLayout();
            this.Automat_GroupBox.ResumeLayout(false);
            this.Automat_GroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlLoop_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Temperature_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControlSignal_chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Manual_GroupBox;
        private System.Windows.Forms.GroupBox Automat_GroupBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Temperature_textBox;
        private System.Windows.Forms.TextBox ControlSignal_textBox;
        private System.Windows.Forms.TextBox ControlError_textBox;
        private System.Windows.Forms.TextBox Reference_textBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox AD_textBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton Automat_radioButton;
        private System.Windows.Forms.RadioButton Manual_radioButton;
        private System.Windows.Forms.CheckBox Cool_checkBox;
        private System.Windows.Forms.CheckBox Heat_checkBox;
        private System.Windows.Forms.Timer controlTimer;
        private System.Windows.Forms.PictureBox controlLoop_pictureBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart Temperature_chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart ControlSignal_chart;
        private System.Windows.Forms.Timer timer1;
    }
}

