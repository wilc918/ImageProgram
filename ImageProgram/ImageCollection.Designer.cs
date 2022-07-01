
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
            this.components = new System.ComponentModel.Container();
            this.AddImagesButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageCollectPanel = new System.Windows.Forms.Panel();
            this.collectionflowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStrip1.SuspendLayout();
            this.ImageCollectPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddImagesButton
            // 
            this.AddImagesButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AddImagesButton.Location = new System.Drawing.Point(203, 398);
            this.AddImagesButton.Name = "AddImagesButton";
            this.AddImagesButton.Size = new System.Drawing.Size(100, 40);
            this.AddImagesButton.TabIndex = 4;
            this.AddImagesButton.Text = "Add new Image";
            this.AddImagesButton.UseVisualStyleBackColor = true;
            this.AddImagesButton.Click += new System.EventHandler(this.AddImagesButtonClick);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.Location = new System.Drawing.Point(229, 377);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Page 1/1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteImageToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(144, 26);
            // 
            // deleteImageToolStripMenuItem
            // 
            this.deleteImageToolStripMenuItem.Name = "deleteImageToolStripMenuItem";
            this.deleteImageToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.deleteImageToolStripMenuItem.Text = "Delete Image";
            this.deleteImageToolStripMenuItem.Click += new System.EventHandler(this.RemoveImagesButtonsClick);
            // 
            // ImageCollectPanel
            // 
            this.ImageCollectPanel.Controls.Add(this.collectionflowLayoutPanel);
            this.ImageCollectPanel.Location = new System.Drawing.Point(12, 12);
            this.ImageCollectPanel.Name = "ImageCollectPanel";
            this.ImageCollectPanel.Size = new System.Drawing.Size(476, 356);
            this.ImageCollectPanel.TabIndex = 14;
            // 
            // collectionflowLayoutPanel
            // 
            this.collectionflowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.collectionflowLayoutPanel.AutoScroll = true;
            this.collectionflowLayoutPanel.AutoSize = true;
            this.collectionflowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.collectionflowLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.collectionflowLayoutPanel.Name = "collectionflowLayoutPanel";
            this.collectionflowLayoutPanel.Size = new System.Drawing.Size(475, 375);
            this.collectionflowLayoutPanel.TabIndex = 0;
            // 
            // ImageCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 557);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddImagesButton);
            this.Controls.Add(this.ImageCollectPanel);
            this.Name = "ImageCollection";
            this.Text = "CollectionView";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ImageCollectPanel.ResumeLayout(false);
            this.ImageCollectPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AddImagesButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteImageToolStripMenuItem;
        private System.Windows.Forms.Panel ImageCollectPanel;
        private System.Windows.Forms.FlowLayoutPanel collectionflowLayoutPanel;
    }
}