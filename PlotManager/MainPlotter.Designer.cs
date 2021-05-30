
namespace PlotManager
{
    partial class MainPlotter
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
            this.lstTemps = new System.Windows.Forms.ListBox();
            this.lstOuts = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddTemp = new System.Windows.Forms.Button();
            this.bttnRemoveTemp = new System.Windows.Forms.Button();
            this.btnRemoveOutput = new System.Windows.Forms.Button();
            this.btnAddOutput = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudThreads = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudBuffer = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudKSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudPlotsTemp = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.nudPlotsPhase1 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.lstRunningPlots = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLogProg = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBuffer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKSize)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlotsTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlotsPhase1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // lstTemps
            // 
            this.lstTemps.FormattingEnabled = true;
            this.lstTemps.ItemHeight = 15;
            this.lstTemps.Location = new System.Drawing.Point(6, 42);
            this.lstTemps.Name = "lstTemps";
            this.lstTemps.Size = new System.Drawing.Size(268, 139);
            this.lstTemps.TabIndex = 0;
            // 
            // lstOuts
            // 
            this.lstOuts.FormattingEnabled = true;
            this.lstOuts.ItemHeight = 15;
            this.lstOuts.Location = new System.Drawing.Point(314, 42);
            this.lstOuts.Name = "lstOuts";
            this.lstOuts.Size = new System.Drawing.Size(268, 139);
            this.lstOuts.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Temp folders";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Output folders";
            // 
            // btnAddTemp
            // 
            this.btnAddTemp.Location = new System.Drawing.Point(280, 42);
            this.btnAddTemp.Name = "btnAddTemp";
            this.btnAddTemp.Size = new System.Drawing.Size(27, 23);
            this.btnAddTemp.TabIndex = 7;
            this.btnAddTemp.Text = "+";
            this.btnAddTemp.UseVisualStyleBackColor = true;
            this.btnAddTemp.Click += new System.EventHandler(this.btnAddTemp_Click);
            // 
            // bttnRemoveTemp
            // 
            this.bttnRemoveTemp.Location = new System.Drawing.Point(280, 71);
            this.bttnRemoveTemp.Name = "bttnRemoveTemp";
            this.bttnRemoveTemp.Size = new System.Drawing.Size(27, 23);
            this.bttnRemoveTemp.TabIndex = 8;
            this.bttnRemoveTemp.Text = "-";
            this.bttnRemoveTemp.UseVisualStyleBackColor = true;
            // 
            // btnRemoveOutput
            // 
            this.btnRemoveOutput.Location = new System.Drawing.Point(588, 71);
            this.btnRemoveOutput.Name = "btnRemoveOutput";
            this.btnRemoveOutput.Size = new System.Drawing.Size(27, 23);
            this.btnRemoveOutput.TabIndex = 10;
            this.btnRemoveOutput.Text = "-";
            this.btnRemoveOutput.UseVisualStyleBackColor = true;
            // 
            // btnAddOutput
            // 
            this.btnAddOutput.Location = new System.Drawing.Point(588, 42);
            this.btnAddOutput.Name = "btnAddOutput";
            this.btnAddOutput.Size = new System.Drawing.Size(27, 23);
            this.btnAddOutput.TabIndex = 9;
            this.btnAddOutput.Text = "+";
            this.btnAddOutput.UseVisualStyleBackColor = true;
            this.btnAddOutput.Click += new System.EventHandler(this.btnAddOutput_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnRemoveOutput);
            this.groupBox1.Controls.Add(this.lstTemps);
            this.groupBox1.Controls.Add(this.btnAddOutput);
            this.groupBox1.Controls.Add(this.lstOuts);
            this.groupBox1.Controls.Add(this.bttnRemoveTemp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAddTemp);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(621, 190);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Folders";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudThreads);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.nudBuffer);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.nudKSize);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(639, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(199, 116);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parameters";
            // 
            // nudThreads
            // 
            this.nudThreads.Location = new System.Drawing.Point(131, 80);
            this.nudThreads.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.nudThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThreads.Name = "nudThreads";
            this.nudThreads.Size = new System.Drawing.Size(57, 23);
            this.nudThreads.TabIndex = 10;
            this.nudThreads.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Threads";
            // 
            // nudBuffer
            // 
            this.nudBuffer.Location = new System.Drawing.Point(131, 51);
            this.nudBuffer.Maximum = new decimal(new int[] {
            16000,
            0,
            0,
            0});
            this.nudBuffer.Minimum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.nudBuffer.Name = "nudBuffer";
            this.nudBuffer.Size = new System.Drawing.Size(57, 23);
            this.nudBuffer.TabIndex = 8;
            this.nudBuffer.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Buffer";
            // 
            // nudKSize
            // 
            this.nudKSize.Location = new System.Drawing.Point(131, 22);
            this.nudKSize.Maximum = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.nudKSize.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nudKSize.Name = "nudKSize";
            this.nudKSize.Size = new System.Drawing.Size(57, 23);
            this.nudKSize.TabIndex = 6;
            this.nudKSize.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "K-Size";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudPlotsTemp);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.nudPlotsPhase1);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.nudInterval);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(844, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 116);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Programming";
            // 
            // nudPlotsTemp
            // 
            this.nudPlotsTemp.Location = new System.Drawing.Point(130, 80);
            this.nudPlotsTemp.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.nudPlotsTemp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPlotsTemp.Name = "nudPlotsTemp";
            this.nudPlotsTemp.Size = new System.Drawing.Size(57, 23);
            this.nudPlotsTemp.TabIndex = 11;
            this.nudPlotsTemp.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "Max plots per temp:";
            // 
            // nudPlotsPhase1
            // 
            this.nudPlotsPhase1.Location = new System.Drawing.Point(130, 51);
            this.nudPlotsPhase1.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.nudPlotsPhase1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPlotsPhase1.Name = "nudPlotsPhase1";
            this.nudPlotsPhase1.Size = new System.Drawing.Size(57, 23);
            this.nudPlotsPhase1.TabIndex = 9;
            this.nudPlotsPhase1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Max plots in phase 1:";
            // 
            // nudInterval
            // 
            this.nudInterval.Location = new System.Drawing.Point(130, 22);
            this.nudInterval.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(57, 23);
            this.nudInterval.TabIndex = 7;
            this.nudInterval.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Min interval";
            // 
            // lstRunningPlots
            // 
            this.lstRunningPlots.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lstRunningPlots.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstRunningPlots.HideSelection = false;
            this.lstRunningPlots.Location = new System.Drawing.Point(12, 241);
            this.lstRunningPlots.Name = "lstRunningPlots";
            this.lstRunningPlots.Size = new System.Drawing.Size(1032, 186);
            this.lstRunningPlots.TabIndex = 14;
            this.lstRunningPlots.UseCompatibleStateImageBehavior = false;
            this.lstRunningPlots.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Start date";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Phase";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Last log";
            this.columnHeader3.Width = 300;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Temp";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Output";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Status";
            this.columnHeader6.Width = 120;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(639, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 68);
            this.button1.TabIndex = 15;
            this.button1.Text = "Run programmer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(844, 134);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 68);
            this.button2.TabIndex = 16;
            this.button2.Text = "Stop programmer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Running plots";
            // 
            // txtLogProg
            // 
            this.txtLogProg.Location = new System.Drawing.Point(12, 472);
            this.txtLogProg.Multiline = true;
            this.txtLogProg.Name = "txtLogProg";
            this.txtLogProg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogProg.Size = new System.Drawing.Size(1032, 139);
            this.txtLogProg.TabIndex = 18;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 433);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "Clear finished plots";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(156, 433);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(138, 23);
            this.button4.TabIndex = 20;
            this.button4.Text = "Pause/resume plot";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(906, 433);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(138, 23);
            this.button5.TabIndex = 21;
            this.button5.Text = "Kill all plots";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(762, 433);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(138, 23);
            this.button6.TabIndex = 22;
            this.button6.Text = "Kill selected plot";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // MainPlotter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 632);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtLogProg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstRunningPlots);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainPlotter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plot Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainPlotter_FormClosing);
            this.Load += new System.EventHandler(this.MainPlotter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBuffer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKSize)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlotsTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlotsPhase1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstTemps;
        private System.Windows.Forms.ListBox lstOuts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddTemp;
        private System.Windows.Forms.Button bttnRemoveTemp;
        private System.Windows.Forms.Button btnRemoveOutput;
        private System.Windows.Forms.Button btnAddOutput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudKSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudThreads;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudBuffer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudPlotsTemp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudPlotsPhase1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudInterval;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lstRunningPlots;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLogProg;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}

