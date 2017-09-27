namespace ParallaxStarfield
{
    partial class frmConfig
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
            this.fldStarCount = new System.Windows.Forms.NumericUpDown();
            this.lblStarCount = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblStarColor = new System.Windows.Forms.Label();
            this.btnStarColor = new System.Windows.Forms.Button();
            this.lblWarpFactor = new System.Windows.Forms.Label();
            this.tbWarpFactor = new System.Windows.Forms.TrackBar();
            this.lblWarpFactorValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fldStarCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbWarpFactor)).BeginInit();
            this.SuspendLayout();
            // 
            // fldStarCount
            // 
            this.fldStarCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fldStarCount.Location = new System.Drawing.Point(15, 30);
            this.fldStarCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.fldStarCount.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fldStarCount.Name = "fldStarCount";
            this.fldStarCount.Size = new System.Drawing.Size(197, 20);
            this.fldStarCount.TabIndex = 0;
            this.fldStarCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblStarCount
            // 
            this.lblStarCount.Location = new System.Drawing.Point(12, 9);
            this.lblStarCount.Name = "lblStarCount";
            this.lblStarCount.Size = new System.Drawing.Size(207, 18);
            this.lblStarCount.TabIndex = 1;
            this.lblStarCount.Text = "Star Count";
            this.lblStarCount.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(137, 166);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(56, 166);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblStarColor
            // 
            this.lblStarColor.Location = new System.Drawing.Point(12, 53);
            this.lblStarColor.Name = "lblStarColor";
            this.lblStarColor.Size = new System.Drawing.Size(207, 18);
            this.lblStarColor.TabIndex = 4;
            this.lblStarColor.Text = "Star Color";
            this.lblStarColor.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnStarColor
            // 
            this.btnStarColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStarColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStarColor.Location = new System.Drawing.Point(15, 74);
            this.btnStarColor.Name = "btnStarColor";
            this.btnStarColor.Size = new System.Drawing.Size(197, 23);
            this.btnStarColor.TabIndex = 5;
            this.btnStarColor.UseVisualStyleBackColor = true;
            this.btnStarColor.Click += new System.EventHandler(this.btnStarColor_Click);
            this.btnStarColor.Paint += new System.Windows.Forms.PaintEventHandler(this.btnStarColor_Paint);
            // 
            // lblWarpFactor
            // 
            this.lblWarpFactor.Location = new System.Drawing.Point(12, 100);
            this.lblWarpFactor.Name = "lblWarpFactor";
            this.lblWarpFactor.Size = new System.Drawing.Size(112, 18);
            this.lblWarpFactor.TabIndex = 6;
            this.lblWarpFactor.Text = "Warp Factor";
            this.lblWarpFactor.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbWarpFactor
            // 
            this.tbWarpFactor.AutoSize = false;
            this.tbWarpFactor.LargeChange = 10;
            this.tbWarpFactor.Location = new System.Drawing.Point(15, 122);
            this.tbWarpFactor.Maximum = 100;
            this.tbWarpFactor.Name = "tbWarpFactor";
            this.tbWarpFactor.Size = new System.Drawing.Size(204, 38);
            this.tbWarpFactor.TabIndex = 7;
            this.tbWarpFactor.TickFrequency = 10;
            this.tbWarpFactor.ValueChanged += new System.EventHandler(this.tbWarpFactor_ValueChanged);
            // 
            // lblWarpFactorValue
            // 
            this.lblWarpFactorValue.Location = new System.Drawing.Point(130, 101);
            this.lblWarpFactorValue.Name = "lblWarpFactorValue";
            this.lblWarpFactorValue.Size = new System.Drawing.Size(82, 18);
            this.lblWarpFactorValue.TabIndex = 8;
            this.lblWarpFactorValue.Text = "0.0 c";
            this.lblWarpFactorValue.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // frmConfig
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(224, 201);
            this.Controls.Add(this.lblWarpFactorValue);
            this.Controls.Add(this.tbWarpFactor);
            this.Controls.Add(this.lblWarpFactor);
            this.Controls.Add(this.btnStarColor);
            this.Controls.Add(this.lblStarColor);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblStarCount);
            this.Controls.Add(this.fldStarCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(240, 240);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(240, 240);
            this.Name = "frmConfig";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Parallax Starfield";
            ((System.ComponentModel.ISupportInitialize)(this.fldStarCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbWarpFactor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown fldStarCount;
        private System.Windows.Forms.Label lblStarCount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblStarColor;
        private System.Windows.Forms.Button btnStarColor;
        private System.Windows.Forms.Label lblWarpFactor;
        private System.Windows.Forms.TrackBar tbWarpFactor;
        private System.Windows.Forms.Label lblWarpFactorValue;
    }
}

