namespace CoffeeRequest
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
            this.btnBrew = new System.Windows.Forms.Button();
            this.numCups = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numStrength = new System.Windows.Forms.NumericUpDown();
            this.numWarm = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkGrind = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numCups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWarm)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrew
            // 
            this.btnBrew.Location = new System.Drawing.Point(264, 27);
            this.btnBrew.Name = "btnBrew";
            this.btnBrew.Size = new System.Drawing.Size(80, 80);
            this.btnBrew.TabIndex = 0;
            this.btnBrew.Text = "Start Brew";
            this.btnBrew.UseVisualStyleBackColor = true;
            this.btnBrew.Click += new System.EventHandler(this.btnBrew_Click);
            // 
            // numCups
            // 
            this.numCups.Location = new System.Drawing.Point(132, 27);
            this.numCups.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numCups.Name = "numCups";
            this.numCups.Size = new System.Drawing.Size(46, 20);
            this.numCups.TabIndex = 1;
            this.numCups.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number of Cups:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Strength:";
            // 
            // numStrength
            // 
            this.numStrength.Location = new System.Drawing.Point(132, 57);
            this.numStrength.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numStrength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStrength.Name = "numStrength";
            this.numStrength.Size = new System.Drawing.Size(46, 20);
            this.numStrength.TabIndex = 8;
            this.numStrength.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numWarm
            // 
            this.numWarm.Location = new System.Drawing.Point(132, 87);
            this.numWarm.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numWarm.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numWarm.Name = "numWarm";
            this.numWarm.Size = new System.Drawing.Size(46, 20);
            this.numWarm.TabIndex = 10;
            this.numWarm.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Keep Warm:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Minutes";
            // 
            // chkGrind
            // 
            this.chkGrind.AutoSize = true;
            this.chkGrind.Checked = true;
            this.chkGrind.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGrind.Location = new System.Drawing.Point(132, 112);
            this.chkGrind.Name = "chkGrind";
            this.chkGrind.Size = new System.Drawing.Size(51, 17);
            this.chkGrind.TabIndex = 12;
            this.chkGrind.Text = "Grind";
            this.chkGrind.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 141);
            this.Controls.Add(this.chkGrind);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numWarm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numStrength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numCups);
            this.Controls.Add(this.btnBrew);
            this.Name = "Form1";
            this.Text = "Smart Coffee Brew App";
            ((System.ComponentModel.ISupportInitialize)(this.numCups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWarm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrew;
        private System.Windows.Forms.NumericUpDown numCups;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numStrength;
        private System.Windows.Forms.NumericUpDown numWarm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkGrind;
    }
}

