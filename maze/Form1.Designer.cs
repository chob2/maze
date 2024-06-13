namespace maze
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.controlContainer = new System.Windows.Forms.GroupBox();
            this.solveTime = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.backPreview = new System.Windows.Forms.PictureBox();
            this.wallPreview = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.wallG = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.wallB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.backB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.wallR = new System.Windows.Forms.TextBox();
            this.backG = new System.Windows.Forms.TextBox();
            this.backR = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.gridSizeInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mazeDisplay = new System.Windows.Forms.PictureBox();
            this.labelStart = new System.Windows.Forms.Label();
            this.labelEnd = new System.Windows.Forms.Label();
            this.controlContainer.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wallPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mazeDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(178, 146);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerate.TabIndex = 0;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // controlContainer
            // 
            this.controlContainer.Controls.Add(this.solveTime);
            this.controlContainer.Controls.Add(this.groupBox2);
            this.controlContainer.Controls.Add(this.progressBar1);
            this.controlContainer.Controls.Add(this.btnExport);
            this.controlContainer.Controls.Add(this.btnSolve);
            this.controlContainer.Controls.Add(this.label2);
            this.controlContainer.Controls.Add(this.time);
            this.controlContainer.Controls.Add(this.buttonGenerate);
            this.controlContainer.Controls.Add(this.gridSizeInput);
            this.controlContainer.Controls.Add(this.label1);
            this.controlContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.controlContainer.Location = new System.Drawing.Point(960, 0);
            this.controlContainer.MaximumSize = new System.Drawing.Size(259, 175);
            this.controlContainer.Name = "controlContainer";
            this.controlContainer.Size = new System.Drawing.Size(259, 175);
            this.controlContainer.TabIndex = 2;
            this.controlContainer.TabStop = false;
            this.controlContainer.Text = "Maze Controls";
            // 
            // solveTime
            // 
            this.solveTime.AutoSize = true;
            this.solveTime.Location = new System.Drawing.Point(6, 143);
            this.solveTime.Name = "solveTime";
            this.solveTime.Size = new System.Drawing.Size(55, 13);
            this.solveTime.TabIndex = 5;
            this.solveTime.Text = "solveTime";
            this.solveTime.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.backPreview);
            this.groupBox2.Controls.Add(this.wallPreview);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.wallG);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.wallB);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.backB);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.wallR);
            this.groupBox2.Controls.Add(this.backG);
            this.groupBox2.Controls.Add(this.backR);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(10, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 56);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Colours:";
            // 
            // backPreview
            // 
            this.backPreview.BackColor = System.Drawing.Color.Cyan;
            this.backPreview.Location = new System.Drawing.Point(196, 39);
            this.backPreview.Name = "backPreview";
            this.backPreview.Size = new System.Drawing.Size(43, 14);
            this.backPreview.TabIndex = 19;
            this.backPreview.TabStop = false;
            // 
            // wallPreview
            // 
            this.wallPreview.BackColor = System.Drawing.Color.Black;
            this.wallPreview.Location = new System.Drawing.Point(196, 13);
            this.wallPreview.Name = "wallPreview";
            this.wallPreview.Size = new System.Drawing.Size(43, 14);
            this.wallPreview.TabIndex = 18;
            this.wallPreview.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(193, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "(0 to 255)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(152, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "B";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Walls:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(112, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "G";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Background:";
            // 
            // wallG
            // 
            this.wallG.Location = new System.Drawing.Point(127, 13);
            this.wallG.Name = "wallG";
            this.wallG.Size = new System.Drawing.Size(25, 20);
            this.wallG.TabIndex = 8;
            this.wallG.Text = "0";
            this.wallG.TextChanged += new System.EventHandler(this.wallG_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(72, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "R";
            // 
            // wallB
            // 
            this.wallB.Location = new System.Drawing.Point(166, 13);
            this.wallB.Name = "wallB";
            this.wallB.Size = new System.Drawing.Size(25, 20);
            this.wallB.TabIndex = 9;
            this.wallB.Text = "0";
            this.wallB.TextChanged += new System.EventHandler(this.wallB_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "R";
            // 
            // backB
            // 
            this.backB.Location = new System.Drawing.Point(166, 33);
            this.backB.Name = "backB";
            this.backB.Size = new System.Drawing.Size(25, 20);
            this.backB.TabIndex = 15;
            this.backB.Text = "255";
            this.backB.TextChanged += new System.EventHandler(this.backB_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(112, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "G";
            // 
            // wallR
            // 
            this.wallR.Location = new System.Drawing.Point(87, 13);
            this.wallR.Name = "wallR";
            this.wallR.Size = new System.Drawing.Size(25, 20);
            this.wallR.TabIndex = 5;
            this.wallR.Text = "0";
            this.wallR.TextChanged += new System.EventHandler(this.wallR_TextChanged);
            // 
            // backG
            // 
            this.backG.Location = new System.Drawing.Point(127, 33);
            this.backG.Name = "backG";
            this.backG.Size = new System.Drawing.Size(25, 20);
            this.backG.TabIndex = 14;
            this.backG.Text = "255";
            this.backG.TextChanged += new System.EventHandler(this.backG_TextChanged);
            // 
            // backR
            // 
            this.backR.Location = new System.Drawing.Point(87, 33);
            this.backR.Name = "backR";
            this.backR.Size = new System.Drawing.Size(25, 20);
            this.backR.TabIndex = 13;
            this.backR.Text = "0";
            this.backR.TextChanged += new System.EventHandler(this.backR_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(152, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "B";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(4, 143);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(172, 26);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(178, 100);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(178, 123);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 4;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Visible = false;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Size:";
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(6, 156);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(72, 13);
            this.time.TabIndex = 2;
            this.time.Text = "generateTime";
            this.time.Visible = false;
            // 
            // gridSizeInput
            // 
            this.gridSizeInput.Location = new System.Drawing.Point(97, 17);
            this.gridSizeInput.Name = "gridSizeInput";
            this.gridSizeInput.Size = new System.Drawing.Size(83, 20);
            this.gridSizeInput.TabIndex = 0;
            this.gridSizeInput.Text = "50";
            this.gridSizeInput.TextChanged += new System.EventHandler(this.gridSizeInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "(2  to 200)";
            // 
            // mazeDisplay
            // 
            this.mazeDisplay.Location = new System.Drawing.Point(55, 25);
            this.mazeDisplay.Name = "mazeDisplay";
            this.mazeDisplay.Size = new System.Drawing.Size(901, 901);
            this.mazeDisplay.TabIndex = 4;
            this.mazeDisplay.TabStop = false;
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStart.Location = new System.Drawing.Point(12, 9);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(48, 13);
            this.labelStart.TabIndex = 5;
            this.labelStart.Text = "START";
            this.labelStart.Visible = false;
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnd.Location = new System.Drawing.Point(880, 929);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(33, 13);
            this.labelEnd.TabIndex = 6;
            this.labelEnd.Text = "END";
            this.labelEnd.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1219, 999);
            this.Controls.Add(this.labelEnd);
            this.Controls.Add(this.labelStart);
            this.Controls.Add(this.mazeDisplay);
            this.Controls.Add(this.controlContainer);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1235, 1038);
            this.Name = "Form1";
            this.Text = "Labyrinth";
            this.controlContainer.ResumeLayout(false);
            this.controlContainer.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wallPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mazeDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.GroupBox controlContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox gridSizeInput;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Label solveTime;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox wallG;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox wallB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox backB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox wallR;
        private System.Windows.Forms.TextBox backG;
        private System.Windows.Forms.TextBox backR;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox backPreview;
        private System.Windows.Forms.PictureBox wallPreview;
        private System.Windows.Forms.PictureBox mazeDisplay;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Label labelEnd;
    }
}

