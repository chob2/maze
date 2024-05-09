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
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.solveTime = new System.Windows.Forms.Label();
            this.btnSolve = new System.Windows.Forms.Button();
            this.time = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gridSizeInput = new System.Windows.Forms.TextBox();
            this.mazeContainer = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.wallR = new System.Windows.Forms.TextBox();
            this.wallG = new System.Windows.Forms.TextBox();
            this.wallB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.backB = new System.Windows.Forms.TextBox();
            this.backG = new System.Windows.Forms.TextBox();
            this.backR = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.solveTime);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.btnSolve);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.time);
            this.groupBox1.Controls.Add(this.buttonGenerate);
            this.groupBox1.Controls.Add(this.gridSizeInput);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(963, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 175);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maze Controls";
            // 
            // solveTime
            // 
            this.solveTime.AutoSize = true;
            this.solveTime.Location = new System.Drawing.Point(7, 143);
            this.solveTime.Name = "solveTime";
            this.solveTime.Size = new System.Drawing.Size(55, 13);
            this.solveTime.TabIndex = 5;
            this.solveTime.Text = "solveTime";
            this.solveTime.Visible = false;
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(178, 125);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 4;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Visible = false;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "(2  to 300)";
            // 
            // gridSizeInput
            // 
            this.gridSizeInput.Location = new System.Drawing.Point(110, 17);
            this.gridSizeInput.Name = "gridSizeInput";
            this.gridSizeInput.Size = new System.Drawing.Size(83, 20);
            this.gridSizeInput.TabIndex = 0;
            // 
            // mazeContainer
            // 
            this.mazeContainer.BackColor = System.Drawing.Color.White;
            this.mazeContainer.Location = new System.Drawing.Point(27, 22);
            this.mazeContainer.Margin = new System.Windows.Forms.Padding(0);
            this.mazeContainer.Name = "mazeContainer";
            this.mazeContainer.Size = new System.Drawing.Size(900, 900);
            this.mazeContainer.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1114, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Size:";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Background:";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(178, 106);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 146);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(172, 23);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Visible = false;
            // 
            // wallR
            // 
            this.wallR.Location = new System.Drawing.Point(87, 13);
            this.wallR.Name = "wallR";
            this.wallR.Size = new System.Drawing.Size(25, 20);
            this.wallR.TabIndex = 5;
            this.wallR.Text = "0";
            // 
            // wallG
            // 
            this.wallG.Location = new System.Drawing.Point(127, 13);
            this.wallG.Name = "wallG";
            this.wallG.Size = new System.Drawing.Size(25, 20);
            this.wallG.TabIndex = 8;
            this.wallG.Text = "0";
            // 
            // wallB
            // 
            this.wallB.Location = new System.Drawing.Point(166, 13);
            this.wallB.Name = "wallB";
            this.wallB.Size = new System.Drawing.Size(25, 20);
            this.wallB.TabIndex = 9;
            this.wallB.Text = "0";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(112, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "G";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(152, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "B";
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(72, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "R";
            // 
            // backB
            // 
            this.backB.Location = new System.Drawing.Point(166, 33);
            this.backB.Name = "backB";
            this.backB.Size = new System.Drawing.Size(25, 20);
            this.backB.TabIndex = 15;
            this.backB.Text = "255";
            // 
            // backG
            // 
            this.backG.Location = new System.Drawing.Point(127, 33);
            this.backG.Name = "backG";
            this.backG.Size = new System.Drawing.Size(25, 20);
            this.backG.TabIndex = 14;
            this.backG.Text = "255";
            // 
            // backR
            // 
            this.backR.Location = new System.Drawing.Point(87, 33);
            this.backR.Name = "backR";
            this.backR.Size = new System.Drawing.Size(25, 20);
            this.backR.TabIndex = 13;
            this.backR.Text = "255";
            // 
            // groupBox2
            // 
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(192, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "(0 to 255)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1234, 1041);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mazeContainer);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox gridSizeInput;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Panel mazeContainer;
        private System.Windows.Forms.Label solveTime;
        private System.Windows.Forms.Button button1;
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
    }
}

