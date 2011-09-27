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
            this.c3 = new AdrenochromeViewer.CurveControl();
            this.c2 = new AdrenochromeViewer.CurveControl();
            this.c1 = new AdrenochromeViewer.CurveControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
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
            // timer1
            // 
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FCurves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 840);
            this.ControlBox = false;
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
            this.ResumeLayout(false);

        }

        #endregion

        private CurveControl c1;
        private CurveControl c2;
        private CurveControl c3;
        private System.Windows.Forms.Timer timer1;
    }
}