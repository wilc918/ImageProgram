
namespace ImageProgram
{
    partial class DisplayView
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
            this.DisplayViewImage = new System.Windows.Forms.PictureBox();
            this.RotRight = new System.Windows.Forms.Button();
            this.RotLeft = new System.Windows.Forms.Button();
            this.DispScale = new System.Windows.Forms.Button();
            this.ScaleInput = new System.Windows.Forms.TextBox();
            this.DispExit = new System.Windows.Forms.Button();
            this.DispSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayViewImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // DisplayViewImage
            // 
            this.DisplayViewImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisplayViewImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DisplayViewImage.Location = new System.Drawing.Point(12, 12);
            this.DisplayViewImage.Name = "DisplayViewImage";
            this.DisplayViewImage.Size = new System.Drawing.Size(660, 482);
            this.DisplayViewImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DisplayViewImage.TabIndex = 0;
            this.DisplayViewImage.TabStop = false;
            // 
            // RotRight
            // 
            this.RotRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RotRight.Location = new System.Drawing.Point(151, 500);
            this.RotRight.Name = "RotRight";
            this.RotRight.Size = new System.Drawing.Size(75, 40);
            this.RotRight.TabIndex = 1;
            this.RotRight.Text = "Rotate ->";
            this.RotRight.UseVisualStyleBackColor = true;
            this.RotRight.Click += new System.EventHandler(this.ImageRotateRight);
            // 
            // RotLeft
            // 
            this.RotLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RotLeft.Location = new System.Drawing.Point(15, 500);
            this.RotLeft.Name = "RotLeft";
            this.RotLeft.Size = new System.Drawing.Size(75, 40);
            this.RotLeft.TabIndex = 2;
            this.RotLeft.Text = "<- Rotate";
            this.RotLeft.UseVisualStyleBackColor = true;
            this.RotLeft.Click += new System.EventHandler(this.ImageRotateLeft);
            // 
            // DispScale
            // 
            this.DispScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DispScale.Location = new System.Drawing.Point(151, 577);
            this.DispScale.Name = "DispScale";
            this.DispScale.Size = new System.Drawing.Size(75, 40);
            this.DispScale.TabIndex = 3;
            this.DispScale.Text = "Scale";
            this.DispScale.UseVisualStyleBackColor = true;
            this.DispScale.Click += new System.EventHandler(this.ImageScale);
            // 
            // ScaleInput
            // 
            this.ScaleInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ScaleInput.Location = new System.Drawing.Point(15, 588);
            this.ScaleInput.Name = "ScaleInput";
            this.ScaleInput.Size = new System.Drawing.Size(75, 20);
            this.ScaleInput.TabIndex = 4;
            this.ScaleInput.Text = "Amount";
            // 
            // DispExit
            // 
            this.DispExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DispExit.Location = new System.Drawing.Point(494, 626);
            this.DispExit.Name = "DispExit";
            this.DispExit.Size = new System.Drawing.Size(75, 23);
            this.DispExit.TabIndex = 5;
            this.DispExit.Text = "Return";
            this.DispExit.UseVisualStyleBackColor = true;
            this.DispExit.Click += new System.EventHandler(this.DisplayReturn);
            // 
            // DispSave
            // 
            this.DispSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DispSave.Location = new System.Drawing.Point(597, 626);
            this.DispSave.Name = "DispSave";
            this.DispSave.Size = new System.Drawing.Size(75, 23);
            this.DispSave.TabIndex = 6;
            this.DispSave.Text = "Save File";
            this.DispSave.UseVisualStyleBackColor = true;
            this.DispSave.Click += new System.EventHandler(this.ImageSave);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(80, 626);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Flip";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ImageFlip);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown1.Location = new System.Drawing.Point(0, 562);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 8;
            // 
            // DisplayView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DispSave);
            this.Controls.Add(this.DispExit);
            this.Controls.Add(this.ScaleInput);
            this.Controls.Add(this.DispScale);
            this.Controls.Add(this.RotLeft);
            this.Controls.Add(this.RotRight);
            this.Controls.Add(this.DisplayViewImage);
            this.MinimumSize = new System.Drawing.Size(400, 350);
            this.Name = "DisplayView";
            this.Text = "DisplayView";
            ((System.ComponentModel.ISupportInitialize)(this.DisplayViewImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DisplayViewImage;
        private System.Windows.Forms.Button RotRight;
        private System.Windows.Forms.Button RotLeft;
        private System.Windows.Forms.Button DispScale;
        private System.Windows.Forms.TextBox ScaleInput;
        private System.Windows.Forms.Button DispExit;
        private System.Windows.Forms.Button DispSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}