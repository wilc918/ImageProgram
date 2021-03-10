
namespace ImageProgram
{
    partial class ImageCollection
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
            this.NextImageButton = new System.Windows.Forms.Button();
            this.PreviousImageButton = new System.Windows.Forms.Button();
            this.LoadImageButton = new System.Windows.Forms.Button();
            this.PictureDisplay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // NextImageButton
            // 
            this.NextImageButton.Location = new System.Drawing.Point(388, 398);
            this.NextImageButton.Name = "NextImageButton";
            this.NextImageButton.Size = new System.Drawing.Size(100, 40);
            this.NextImageButton.TabIndex = 0;
            this.NextImageButton.Text = ">";
            this.NextImageButton.UseVisualStyleBackColor = true;
            // 
            // PreviousImageButton
            // 
            this.PreviousImageButton.Location = new System.Drawing.Point(12, 398);
            this.PreviousImageButton.Name = "PreviousImageButton";
            this.PreviousImageButton.Size = new System.Drawing.Size(100, 40);
            this.PreviousImageButton.TabIndex = 1;
            this.PreviousImageButton.Text = "<";
            this.PreviousImageButton.UseVisualStyleBackColor = true;
            // 
            // LoadImageButton
            // 
            this.LoadImageButton.Location = new System.Drawing.Point(201, 398);
            this.LoadImageButton.Name = "LoadImageButton";
            this.LoadImageButton.Size = new System.Drawing.Size(100, 40);
            this.LoadImageButton.TabIndex = 2;
            this.LoadImageButton.Text = "Load";
            this.LoadImageButton.UseVisualStyleBackColor = true;
            // 
            // PictureDisplay
            // 
            this.PictureDisplay.Location = new System.Drawing.Point(13, 13);
            this.PictureDisplay.Name = "PictureDisplay";
            this.PictureDisplay.Size = new System.Drawing.Size(475, 365);
            this.PictureDisplay.TabIndex = 3;
            this.PictureDisplay.TabStop = false;
            // 
            // ImageCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Controls.Add(this.PictureDisplay);
            this.Controls.Add(this.LoadImageButton);
            this.Controls.Add(this.PreviousImageButton);
            this.Controls.Add(this.NextImageButton);
            this.Name = "ImageCollection";
            this.Text = "Gallery";
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NextImageButton;
        private System.Windows.Forms.Button PreviousImageButton;
        private System.Windows.Forms.Button LoadImageButton;
        private System.Windows.Forms.PictureBox PictureDisplay;
    }
}