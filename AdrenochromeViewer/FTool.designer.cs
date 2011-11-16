namespace AdrenochromeViewer
{
    partial class FTool
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
            this.btnApply = new System.Windows.Forms.Button();
            this.trackTolLo = new System.Windows.Forms.TrackBar();
            this.trackTolHi = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackSoften = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.cboForeground = new System.Windows.Forms.ComboBox();
            this.cboBackground = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnForeground = new System.Windows.Forms.Button();
            this.btnBackground = new System.Windows.Forms.Button();
            this.lblSpread = new System.Windows.Forms.Label();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.chkBlender = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.optSoft1 = new System.Windows.Forms.RadioButton();
            this.optSoft2 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.trackTolLo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTolHi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSoften)).BeginInit();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(263, 213);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(82, 23);
            this.btnApply.TabIndex = 7;
            this.btnApply.Text = "&Verkställ";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // trackTolLo
            // 
            this.trackTolLo.LargeChange = 1;
            this.trackTolLo.Location = new System.Drawing.Point(71, 60);
            this.trackTolLo.Maximum = 40;
            this.trackTolLo.Name = "trackTolLo";
            this.trackTolLo.Size = new System.Drawing.Size(274, 45);
            this.trackTolLo.TabIndex = 5;
            this.trackTolLo.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackTolLo.Value = 2;
            // 
            // trackTolHi
            // 
            this.trackTolHi.LargeChange = 1;
            this.trackTolHi.Location = new System.Drawing.Point(71, 111);
            this.trackTolHi.Maximum = 40;
            this.trackTolHi.Name = "trackTolHi";
            this.trackTolHi.Size = new System.Drawing.Size(274, 45);
            this.trackTolHi.TabIndex = 6;
            this.trackTolHi.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackTolHi.Value = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tol låg";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tol hög";
            // 
            // trackSoften
            // 
            this.trackSoften.LargeChange = 1;
            this.trackSoften.Location = new System.Drawing.Point(71, 162);
            this.trackSoften.Maximum = 40;
            this.trackSoften.Name = "trackSoften";
            this.trackSoften.Size = new System.Drawing.Size(274, 45);
            this.trackSoften.TabIndex = 10;
            this.trackSoften.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackSoften.Value = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Motiv";
            // 
            // cboForeground
            // 
            this.cboForeground.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboForeground.FormattingEnabled = true;
            this.cboForeground.Location = new System.Drawing.Point(71, 6);
            this.cboForeground.Name = "cboForeground";
            this.cboForeground.Size = new System.Drawing.Size(233, 21);
            this.cboForeground.TabIndex = 14;
            this.cboForeground.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cbo_Format);
            // 
            // cboBackground
            // 
            this.cboBackground.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBackground.FormattingEnabled = true;
            this.cboBackground.Location = new System.Drawing.Point(71, 33);
            this.cboBackground.Name = "cboBackground";
            this.cboBackground.Size = new System.Drawing.Size(233, 21);
            this.cboBackground.TabIndex = 16;
            this.cboBackground.SelectedIndexChanged += new System.EventHandler(this.cboBackground_SelectedIndexChanged);
            this.cboBackground.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cbo_Format);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Bakgrund";
            // 
            // btnForeground
            // 
            this.btnForeground.Location = new System.Drawing.Point(310, 6);
            this.btnForeground.Name = "btnForeground";
            this.btnForeground.Size = new System.Drawing.Size(35, 21);
            this.btnForeground.TabIndex = 17;
            this.btnForeground.Text = "...";
            this.btnForeground.UseVisualStyleBackColor = true;
            this.btnForeground.Click += new System.EventHandler(this.btnForeground_Click);
            // 
            // btnBackground
            // 
            this.btnBackground.Location = new System.Drawing.Point(310, 33);
            this.btnBackground.Name = "btnBackground";
            this.btnBackground.Size = new System.Drawing.Size(35, 21);
            this.btnBackground.TabIndex = 18;
            this.btnBackground.Text = "...";
            this.btnBackground.UseVisualStyleBackColor = true;
            this.btnBackground.Click += new System.EventHandler(this.btnBackground_Click);
            // 
            // lblSpread
            // 
            this.lblSpread.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpread.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSpread.Location = new System.Drawing.Point(15, 294);
            this.lblSpread.Name = "lblSpread";
            this.lblSpread.Size = new System.Drawing.Size(330, 23);
            this.lblSpread.TabIndex = 20;
            this.lblSpread.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstHistory
            // 
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.Location = new System.Drawing.Point(15, 213);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(128, 69);
            this.lstHistory.TabIndex = 19;
            this.lstHistory.SelectedIndexChanged += new System.EventHandler(this.lstHistory_SelectedIndexChanged);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(263, 242);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(82, 23);
            this.btnSaveAs.TabIndex = 21;
            this.btnSaveAs.Text = "&Spara som...";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // chkBlender
            // 
            this.chkBlender.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkBlender.Location = new System.Drawing.Point(177, 242);
            this.chkBlender.Name = "chkBlender";
            this.chkBlender.Size = new System.Drawing.Size(80, 23);
            this.chkBlender.TabIndex = 22;
            this.chkBlender.Text = "&Blandare";
            this.chkBlender.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkBlender.UseVisualStyleBackColor = true;
            this.chkBlender.CheckedChanged += new System.EventHandler(this.chkBlender_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(179, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // optSoft1
            // 
            this.optSoft1.AutoSize = true;
            this.optSoft1.Location = new System.Drawing.Point(15, 162);
            this.optSoft1.Name = "optSoft1";
            this.optSoft1.Size = new System.Drawing.Size(53, 17);
            this.optSoft1.TabIndex = 24;
            this.optSoft1.Text = "Soft 1";
            this.optSoft1.UseVisualStyleBackColor = true;
            // 
            // optSoft2
            // 
            this.optSoft2.AutoSize = true;
            this.optSoft2.Checked = true;
            this.optSoft2.Location = new System.Drawing.Point(15, 185);
            this.optSoft2.Name = "optSoft2";
            this.optSoft2.Size = new System.Drawing.Size(53, 17);
            this.optSoft2.TabIndex = 25;
            this.optSoft2.TabStop = true;
            this.optSoft2.Text = "Soft 2";
            this.optSoft2.UseVisualStyleBackColor = true;
            // 
            // FTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 326);
            this.Controls.Add(this.optSoft2);
            this.Controls.Add(this.optSoft1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkBlender);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.lblSpread);
            this.Controls.Add(this.lstHistory);
            this.Controls.Add(this.btnBackground);
            this.Controls.Add(this.btnForeground);
            this.Controls.Add(this.cboBackground);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboForeground);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackSoften);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.trackTolHi);
            this.Controls.Add(this.trackTolLo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FTool";
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.trackTolLo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTolHi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSoften)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TrackBar trackTolLo;
        private System.Windows.Forms.TrackBar trackTolHi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackSoften;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboForeground;
        private System.Windows.Forms.ComboBox cboBackground;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnForeground;
        private System.Windows.Forms.Button btnBackground;
        private System.Windows.Forms.Label lblSpread;
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.CheckBox chkBlender;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton optSoft1;
        private System.Windows.Forms.RadioButton optSoft2;
    }
}