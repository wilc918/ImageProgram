
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
            this.PictureDisplay9 = new System.Windows.Forms.PictureBox();
            this.AddImagesButton = new System.Windows.Forms.Button();
            this.PictureDisplay8 = new System.Windows.Forms.PictureBox();
            this.PictureDisplay7 = new System.Windows.Forms.PictureBox();
            this.PictureDisplay6 = new System.Windows.Forms.PictureBox();
            this.PictureDisplay5 = new System.Windows.Forms.PictureBox();
            this.PictureDisplay4 = new System.Windows.Forms.PictureBox();
            this.PictureDisplay3 = new System.Windows.Forms.PictureBox();
            this.PictureDisplay2 = new System.Windows.Forms.PictureBox();
            this.PictureDisplay1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplay9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplay8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplay7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplay6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplay5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplay4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplay3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplay2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplay1)).BeginInit();
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
            this.NextImageButton.Click += new System.EventHandler(this.ImageCollectionNext);
            // 
            // PreviousImageButton
            // 
            this.PreviousImageButton.Location = new System.Drawing.Point(12, 398);
            this.PreviousImageButton.Name = "PreviousImageButton";
            this.PreviousImageButton.Size = new System.Drawing.Size(100, 40);
            this.PreviousImageButton.TabIndex = 1;
            this.PreviousImageButton.Text = "<";
            this.PreviousImageButton.UseVisualStyleBackColor = true;
            this.PreviousImageButton.Click += new System.EventHandler(this.ImageCollectionPrevious);
            // 
            // PictureDisplay9
            // 
            this.PictureDisplay9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureDisplay9.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureDisplay9.Location = new System.Drawing.Point(338, 257);
            this.PictureDisplay9.Name = "PictureDisplay9";
            this.PictureDisplay9.Size = new System.Drawing.Size(150, 111);
            this.PictureDisplay9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureDisplay9.TabIndex = 3;
            this.PictureDisplay9.TabStop = false;
            this.PictureDisplay9.DoubleClick += new System.EventHandler(this.ImageDoubleClick);
            // 
            // AddImagesButton
            // 
            this.AddImagesButton.Location = new System.Drawing.Point(203, 398);
            this.AddImagesButton.Name = "AddImagesButton";
            this.AddImagesButton.Size = new System.Drawing.Size(100, 40);
            this.AddImagesButton.TabIndex = 4;
            this.AddImagesButton.Text = "Add new Image";
            this.AddImagesButton.UseVisualStyleBackColor = true;
            this.AddImagesButton.Click += new System.EventHandler(this.AddImagesButtonClick);
            // 
            // PictureDisplay8
            // 
            this.PictureDisplay8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureDisplay8.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureDisplay8.Location = new System.Drawing.Point(175, 257);
            this.PictureDisplay8.Name = "PictureDisplay8";
            this.PictureDisplay8.Size = new System.Drawing.Size(150, 111);
            this.PictureDisplay8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureDisplay8.TabIndex = 5;
            this.PictureDisplay8.TabStop = false;
            this.PictureDisplay8.DoubleClick += new System.EventHandler(this.ImageDoubleClick);
            // 
            // PictureDisplay7
            // 
            this.PictureDisplay7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureDisplay7.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureDisplay7.Location = new System.Drawing.Point(13, 257);
            this.PictureDisplay7.Name = "PictureDisplay7";
            this.PictureDisplay7.Size = new System.Drawing.Size(150, 111);
            this.PictureDisplay7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureDisplay7.TabIndex = 6;
            this.PictureDisplay7.TabStop = false;
            this.PictureDisplay7.DoubleClick += new System.EventHandler(this.ImageDoubleClick);
            // 
            // PictureDisplay6
            // 
            this.PictureDisplay6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureDisplay6.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureDisplay6.Location = new System.Drawing.Point(338, 134);
            this.PictureDisplay6.Name = "PictureDisplay6";
            this.PictureDisplay6.Size = new System.Drawing.Size(150, 111);
            this.PictureDisplay6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureDisplay6.TabIndex = 7;
            this.PictureDisplay6.TabStop = false;
            this.PictureDisplay6.DoubleClick += new System.EventHandler(this.ImageDoubleClick);
            // 
            // PictureDisplay5
            // 
            this.PictureDisplay5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureDisplay5.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureDisplay5.Location = new System.Drawing.Point(175, 134);
            this.PictureDisplay5.Name = "PictureDisplay5";
            this.PictureDisplay5.Size = new System.Drawing.Size(150, 111);
            this.PictureDisplay5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureDisplay5.TabIndex = 8;
            this.PictureDisplay5.TabStop = false;
            this.PictureDisplay5.DoubleClick += new System.EventHandler(this.ImageDoubleClick);
            // 
            // PictureDisplay4
            // 
            this.PictureDisplay4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureDisplay4.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureDisplay4.Location = new System.Drawing.Point(12, 134);
            this.PictureDisplay4.Name = "PictureDisplay4";
            this.PictureDisplay4.Size = new System.Drawing.Size(150, 111);
            this.PictureDisplay4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureDisplay4.TabIndex = 9;
            this.PictureDisplay4.TabStop = false;
            this.PictureDisplay4.DoubleClick += new System.EventHandler(this.ImageDoubleClick);
            // 
            // PictureDisplay3
            // 
            this.PictureDisplay3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.PictureDisplay3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureDisplay3.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureDisplay3.Location = new System.Drawing.Point(338, 12);
            this.PictureDisplay3.Name = "PictureDisplay3";
            this.PictureDisplay3.Size = new System.Drawing.Size(150, 111);
            this.PictureDisplay3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureDisplay3.TabIndex = 10;
            this.PictureDisplay3.TabStop = false;
            this.PictureDisplay3.DoubleClick += new System.EventHandler(this.ImageDoubleClick);
            // 
            // PictureDisplay2
            // 
            this.PictureDisplay2.BackColor = System.Drawing.SystemColors.Info;
            this.PictureDisplay2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureDisplay2.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureDisplay2.Location = new System.Drawing.Point(175, 12);
            this.PictureDisplay2.Name = "PictureDisplay2";
            this.PictureDisplay2.Size = new System.Drawing.Size(150, 111);
            this.PictureDisplay2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureDisplay2.TabIndex = 11;
            this.PictureDisplay2.TabStop = false;
            this.PictureDisplay2.DoubleClick += new System.EventHandler(this.ImageDoubleClick);
            // 
            // PictureDisplay1
            // 
            this.PictureDisplay1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PictureDisplay1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureDisplay1.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureDisplay1.Location = new System.Drawing.Point(12, 12);
            this.PictureDisplay1.Name = "PictureDisplay1";
            this.PictureDisplay1.Size = new System.Drawing.Size(150, 111);
            this.PictureDisplay1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureDisplay1.TabIndex = 12;
            this.PictureDisplay1.TabStop = false;
            this.PictureDisplay1.DoubleClick += new System.EventHandler(this.ImageDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 377);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Page 1/1";
            // 
            // ImageCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PictureDisplay1);
            this.Controls.Add(this.PictureDisplay2);
            this.Controls.Add(this.PictureDisplay3);
            this.Controls.Add(this.PictureDisplay4);
            this.Controls.Add(this.PictureDisplay5);
            this.Controls.Add(this.PictureDisplay6);
            this.Controls.Add(this.PictureDisplay7);
            this.Controls.Add(this.PictureDisplay8);
            this.Controls.Add(this.AddImagesButton);
            this.Controls.Add(this.PictureDisplay9);
            this.Controls.Add(this.PreviousImageButton);
            this.Controls.Add(this.NextImageButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ImageCollection";
            this.Text = "CollectionView";
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplay9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplay8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplay7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplay6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplay5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplay4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplay3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplay2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDisplay1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NextImageButton;
        private System.Windows.Forms.Button PreviousImageButton;
        private System.Windows.Forms.PictureBox PictureDisplay9;
        private System.Windows.Forms.Button AddImagesButton;
        private System.Windows.Forms.PictureBox PictureDisplay8;
        private System.Windows.Forms.PictureBox PictureDisplay7;
        private System.Windows.Forms.PictureBox PictureDisplay6;
        private System.Windows.Forms.PictureBox PictureDisplay5;
        private System.Windows.Forms.PictureBox PictureDisplay4;
        private System.Windows.Forms.PictureBox PictureDisplay3;
        private System.Windows.Forms.PictureBox PictureDisplay2;
        private System.Windows.Forms.PictureBox PictureDisplay1;
        private System.Windows.Forms.Label label1;
    }
}