
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
            ((System.ComponentModel.ISupportInitialize)(this.DisplayViewImage)).BeginInit();
            this.SuspendLayout();
            // 
            // DisplayViewImage
            // 
            this.DisplayViewImage.Location = new System.Drawing.Point(12, 12);
            this.DisplayViewImage.Name = "DisplayViewImage";
            this.DisplayViewImage.Size = new System.Drawing.Size(516, 271);
            this.DisplayViewImage.TabIndex = 0;
            this.DisplayViewImage.TabStop = false;
            // 
            // RotRight
            // 
            this.RotRight.Location = new System.Drawing.Point(151, 289);
            this.RotRight.Name = "RotRight";
            this.RotRight.Size = new System.Drawing.Size(63, 23);
            this.RotRight.TabIndex = 1;
            this.RotRight.Text = "Rotate ->";
            this.RotRight.UseVisualStyleBackColor = true;
            // 
            // RotLeft
            // 
            this.RotLeft.Location = new System.Drawing.Point(15, 289);
            this.RotLeft.Name = "RotLeft";
            this.RotLeft.Size = new System.Drawing.Size(63, 23);
            this.RotLeft.TabIndex = 2;
            this.RotLeft.Text = "<- Rotate";
            this.RotLeft.UseVisualStyleBackColor = true;
            // 
            // DispScale
            // 
            this.DispScale.Location = new System.Drawing.Point(139, 363);
            this.DispScale.Name = "DispScale";
            this.DispScale.Size = new System.Drawing.Size(75, 23);
            this.DispScale.TabIndex = 3;
            this.DispScale.Text = "Scale";
            this.DispScale.UseVisualStyleBackColor = true;
            this.DispScale.Click += new System.EventHandler(this.button1_Click);
            // 
            // ScaleInput
            // 
            this.ScaleInput.Location = new System.Drawing.Point(73, 363);
            this.ScaleInput.Name = "ScaleInput";
            this.ScaleInput.Size = new System.Drawing.Size(60, 20);
            this.ScaleInput.TabIndex = 4;
            this.ScaleInput.Text = "Amount";
            // 
            // DispExit
            // 
            this.DispExit.Location = new System.Drawing.Point(350, 415);
            this.DispExit.Name = "DispExit";
            this.DispExit.Size = new System.Drawing.Size(75, 23);
            this.DispExit.TabIndex = 5;
            this.DispExit.Text = "Return";
            this.DispExit.UseVisualStyleBackColor = true;
            // 
            // DispSave
            // 
            this.DispSave.Location = new System.Drawing.Point(453, 415);
            this.DispSave.Name = "DispSave";
            this.DispSave.Size = new System.Drawing.Size(75, 23);
            this.DispSave.TabIndex = 6;
            this.DispSave.Text = "Save File";
            this.DispSave.UseVisualStyleBackColor = true;
            // 
            // DisplayView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 450);
            this.Controls.Add(this.DispSave);
            this.Controls.Add(this.DispExit);
            this.Controls.Add(this.ScaleInput);
            this.Controls.Add(this.DispScale);
            this.Controls.Add(this.RotLeft);
            this.Controls.Add(this.RotRight);
            this.Controls.Add(this.DisplayViewImage);
            this.Name = "DisplayView";
            this.Text = "DisplayView";
            ((System.ComponentModel.ISupportInitialize)(this.DisplayViewImage)).EndInit();
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
    }
}