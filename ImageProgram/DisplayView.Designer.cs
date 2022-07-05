
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
            this.DispExit = new System.Windows.Forms.Button();
            this.DispSave = new System.Windows.Forms.Button();
            this.FlipButton = new System.Windows.Forms.Button();
            this.PercentageNumeric = new System.Windows.Forms.NumericUpDown();
            this.PercentageScaleLabel = new System.Windows.Forms.Label();
            this.HeightNumeric = new System.Windows.Forms.NumericUpDown();
            this.HeightScaleLable = new System.Windows.Forms.Label();
            this.WidthNumeric = new System.Windows.Forms.NumericUpDown();
            this.WidthScaleLabel = new System.Windows.Forms.Label();
            this.setDimensionsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayViewImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PercentageNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthNumeric)).BeginInit();
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
            this.RotRight.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RotRight.Location = new System.Drawing.Point(404, 500);
            this.RotRight.Name = "RotRight";
            this.RotRight.Size = new System.Drawing.Size(75, 40);
            this.RotRight.TabIndex = 1;
            this.RotRight.Text = "Rotate ->";
            this.RotRight.UseVisualStyleBackColor = true;
            this.RotRight.Click += new System.EventHandler(this.ImageRotateRight);
            // 
            // RotLeft
            // 
            this.RotLeft.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RotLeft.Location = new System.Drawing.Point(220, 500);
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
            this.DispScale.Location = new System.Drawing.Point(139, 604);
            this.DispScale.Name = "DispScale";
            this.DispScale.Size = new System.Drawing.Size(43, 20);
            this.DispScale.TabIndex = 3;
            this.DispScale.Text = "Scale";
            this.DispScale.UseVisualStyleBackColor = true;
            this.DispScale.Click += new System.EventHandler(this.ImageScale);
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
            // FlipButton
            // 
            this.FlipButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.FlipButton.Location = new System.Drawing.Point(311, 509);
            this.FlipButton.Name = "FlipButton";
            this.FlipButton.Size = new System.Drawing.Size(75, 23);
            this.FlipButton.TabIndex = 7;
            this.FlipButton.Text = "Flip!";
            this.FlipButton.UseVisualStyleBackColor = true;
            this.FlipButton.Click += new System.EventHandler(this.ImageFlip);
            // 
            // PercentageNumeric
            // 
            this.PercentageNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PercentageNumeric.Location = new System.Drawing.Point(77, 606);
            this.PercentageNumeric.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.PercentageNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PercentageNumeric.Name = "PercentageNumeric";
            this.PercentageNumeric.Size = new System.Drawing.Size(45, 20);
            this.PercentageNumeric.TabIndex = 8;
            this.PercentageNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // PercentageScaleLabel
            // 
            this.PercentageScaleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PercentageScaleLabel.AutoSize = true;
            this.PercentageScaleLabel.Location = new System.Drawing.Point(14, 608);
            this.PercentageScaleLabel.Name = "PercentageScaleLabel";
            this.PercentageScaleLabel.Size = new System.Drawing.Size(65, 13);
            this.PercentageScaleLabel.TabIndex = 9;
            this.PercentageScaleLabel.Text = "Percentage:";
            // 
            // HeightNumeric
            // 
            this.HeightNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.HeightNumeric.InterceptArrowKeys = false;
            this.HeightNumeric.Location = new System.Drawing.Point(44, 550);
            this.HeightNumeric.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.HeightNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HeightNumeric.Name = "HeightNumeric";
            this.HeightNumeric.Size = new System.Drawing.Size(53, 20);
            this.HeightNumeric.TabIndex = 10;
            this.HeightNumeric.ThousandsSeparator = true;
            this.HeightNumeric.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // HeightScaleLable
            // 
            this.HeightScaleLable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.HeightScaleLable.AutoSize = true;
            this.HeightScaleLable.Location = new System.Drawing.Point(5, 552);
            this.HeightScaleLable.Name = "HeightScaleLable";
            this.HeightScaleLable.Size = new System.Drawing.Size(41, 13);
            this.HeightScaleLable.TabIndex = 11;
            this.HeightScaleLable.Text = "Height:";
            // 
            // WidthNumeric
            // 
            this.WidthNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WidthNumeric.Location = new System.Drawing.Point(44, 572);
            this.WidthNumeric.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.WidthNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WidthNumeric.Name = "WidthNumeric";
            this.WidthNumeric.Size = new System.Drawing.Size(53, 20);
            this.WidthNumeric.TabIndex = 12;
            this.WidthNumeric.ThousandsSeparator = true;
            this.WidthNumeric.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // WidthScaleLabel
            // 
            this.WidthScaleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WidthScaleLabel.AutoSize = true;
            this.WidthScaleLabel.Location = new System.Drawing.Point(8, 574);
            this.WidthScaleLabel.Name = "WidthScaleLabel";
            this.WidthScaleLabel.Size = new System.Drawing.Size(38, 13);
            this.WidthScaleLabel.TabIndex = 13;
            this.WidthScaleLabel.Text = "Width:";
            // 
            // setDimensionsButton
            // 
            this.setDimensionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.setDimensionsButton.Location = new System.Drawing.Point(103, 550);
            this.setDimensionsButton.Name = "setDimensionsButton";
            this.setDimensionsButton.Size = new System.Drawing.Size(79, 42);
            this.setDimensionsButton.TabIndex = 14;
            this.setDimensionsButton.Text = "Set Dimensions";
            this.setDimensionsButton.UseVisualStyleBackColor = true;
            this.setDimensionsButton.Click += new System.EventHandler(this.ImageResize);
            // 
            // DisplayView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.setDimensionsButton);
            this.Controls.Add(this.PercentageNumeric);
            this.Controls.Add(this.WidthNumeric);
            this.Controls.Add(this.WidthScaleLabel);
            this.Controls.Add(this.HeightNumeric);
            this.Controls.Add(this.HeightScaleLable);
            this.Controls.Add(this.PercentageScaleLabel);
            this.Controls.Add(this.FlipButton);
            this.Controls.Add(this.DispSave);
            this.Controls.Add(this.DispExit);
            this.Controls.Add(this.DispScale);
            this.Controls.Add(this.RotLeft);
            this.Controls.Add(this.RotRight);
            this.Controls.Add(this.DisplayViewImage);
            this.MinimumSize = new System.Drawing.Size(400, 350);
            this.Name = "DisplayView";
            this.Text = "DisplayView";
            ((System.ComponentModel.ISupportInitialize)(this.DisplayViewImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PercentageNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DisplayViewImage;
        private System.Windows.Forms.Button RotRight;
        private System.Windows.Forms.Button RotLeft;
        private System.Windows.Forms.Button DispScale;
        private System.Windows.Forms.Button DispExit;
        private System.Windows.Forms.Button DispSave;
        private System.Windows.Forms.Button FlipButton;
        private System.Windows.Forms.NumericUpDown PercentageNumeric;
        private System.Windows.Forms.Label PercentageScaleLabel;
        private System.Windows.Forms.NumericUpDown HeightNumeric;
        private System.Windows.Forms.Label HeightScaleLable;
        private System.Windows.Forms.NumericUpDown WidthNumeric;
        private System.Windows.Forms.Label WidthScaleLabel;
        private System.Windows.Forms.Button setDimensionsButton;
    }
}