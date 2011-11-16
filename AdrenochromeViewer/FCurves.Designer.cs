namespace AdrenochromeViewer
{
    partial class FCurves
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.numBendGreen = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numBendBlend = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numKnee = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.c3 = new AdrenochromeViewer.CurveControl();
            this.c2 = new AdrenochromeViewer.CurveControl();
            this.c1 = new AdrenochromeViewer.CurveControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBendGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBendBlend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKnee)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Controls.Add(this.numBendGreen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numBendBlend);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numKnee);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 831);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 59);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(215, 28);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(35, 23);
            this.btnApply.TabIndex = 6;
            this.btnApply.Text = "!";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // numBendGreen
            // 
            this.numBendGreen.Location = new System.Drawing.Point(109, 31);
            this.numBendGreen.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBendGreen.Name = "numBendGreen";
            this.numBendGreen.Size = new System.Drawing.Size(42, 20);
            this.numBendGreen.TabIndex = 5;
            this.numBendGreen.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Böj 2";
            // 
            // numBendBlend
            // 
            this.numBendBlend.Location = new System.Drawing.Point(57, 32);
            this.numBendBlend.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBendBlend.Name = "numBendBlend";
            this.numBendBlend.Size = new System.Drawing.Size(42, 20);
            this.numBendBlend.TabIndex = 3;
            this.numBendBlend.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Böj 1";
            // 
            // numKnee
            // 
            this.numKnee.Location = new System.Drawing.Point(9, 32);
            this.numKnee.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numKnee.Name = "numKnee";
            this.numKnee.Size = new System.Drawing.Size(42, 20);
            this.numKnee.TabIndex = 1;
            this.numKnee.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Knä";
            // 
            // c3
            // 
            this.c3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.c3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.c3.Location = new System.Drawing.Point(12, 536);
            this.c3.MaximumSize = new System.Drawing.Size(256, 256);
            this.c3.MinimumSize = new System.Drawing.Size(256, 256);
            this.c3.Name = "c3";
            this.c3.Size = new System.Drawing.Size(256, 256);
            this.c3.TabIndex = 2;
            this.c3.CurveChanged += new System.EventHandler(this.curveChanged);
            // 
            // c2
            // 
            this.c2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.c2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.c2.Location = new System.Drawing.Point(12, 274);
            this.c2.MaximumSize = new System.Drawing.Size(256, 256);
            this.c2.MinimumSize = new System.Drawing.Size(256, 256);
            this.c2.Name = "c2";
            this.c2.Size = new System.Drawing.Size(256, 256);
            this.c2.TabIndex = 1;
            this.c2.CurveChanged += new System.EventHandler(this.curveChanged);
            // 
            // c1
            // 
            this.c1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.c1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.c1.Location = new System.Drawing.Point(12, 12);
            this.c1.MaximumSize = new System.Drawing.Size(256, 256);
            this.c1.MinimumSize = new System.Drawing.Size(256, 256);
            this.c1.Name = "c1";
            this.c1.Size = new System.Drawing.Size(256, 256);
            this.c1.TabIndex = 0;
            this.c1.CurveChanged += new System.EventHandler(this.curveChanged);
            // 
            // FCurves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 902);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.c3);
            this.Controls.Add(this.c2);
            this.Controls.Add(this.c1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FCurves";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Blandare";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBendGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBendBlend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKnee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CurveControl c1;
        private CurveControl c2;
        private CurveControl c3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.NumericUpDown numBendGreen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numBendBlend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numKnee;
        private System.Windows.Forms.Label label1;
    }
}