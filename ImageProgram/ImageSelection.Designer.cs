
namespace ImageProgram
{
    partial class ImageSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageSelection));
            this.listView1 = new System.Windows.Forms.ListView();
            this.ColumnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.AddSelectionButton = new System.Windows.Forms.Button();
            this.ReturnToCollectionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnName,
            this.ColumnPath,
            this.ColumnIcon});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(68, 37);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(271, 287);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // ColumnName
            // 
            this.ColumnName.Tag = "";
            this.ColumnName.Text = "Name";
            this.ColumnName.Width = 112;
            // 
            // ColumnPath
            // 
            this.ColumnPath.Text = "Full Path";
            // 
            // ColumnIcon
            // 
            this.ColumnIcon.Text = "Icon";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "AnglerFish_Lit.png");
            this.imageList1.Images.SetKeyName(1, "AnglerFish_Unlit.png");
            this.imageList1.Images.SetKeyName(2, "AquariumBackground.png");
            this.imageList1.Images.SetKeyName(3, "JavaFish.png");
            this.imageList1.Images.SetKeyName(4, "OrangeFish.png");
            this.imageList1.Images.SetKeyName(5, "PiranhaGreen.png");
            this.imageList1.Images.SetKeyName(6, "PiranhaRed.png");
            this.imageList1.Images.SetKeyName(7, "Seahorse.png");
            this.imageList1.Images.SetKeyName(8, "Urchin.png");
            // 
            // AddSelectionButton
            // 
            this.AddSelectionButton.Location = new System.Drawing.Point(281, 384);
            this.AddSelectionButton.Name = "AddSelectionButton";
            this.AddSelectionButton.Size = new System.Drawing.Size(100, 50);
            this.AddSelectionButton.TabIndex = 1;
            this.AddSelectionButton.Text = "Add Selections";
            this.AddSelectionButton.UseVisualStyleBackColor = true;
            this.AddSelectionButton.Click += new System.EventHandler(this.collectImages);
            // 
            // ReturnToCollectionButton
            // 
            this.ReturnToCollectionButton.Location = new System.Drawing.Point(12, 384);
            this.ReturnToCollectionButton.Name = "ReturnToCollectionButton";
            this.ReturnToCollectionButton.Size = new System.Drawing.Size(100, 50);
            this.ReturnToCollectionButton.TabIndex = 2;
            this.ReturnToCollectionButton.Text = "Return to Gallery";
            this.ReturnToCollectionButton.UseVisualStyleBackColor = true;
            this.ReturnToCollectionButton.Click += new System.EventHandler(this.closeForm);
            // 
            // ImageSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 450);
            this.Controls.Add(this.ReturnToCollectionButton);
            this.Controls.Add(this.AddSelectionButton);
            this.Controls.Add(this.listView1);
            this.Name = "ImageSelection";
            this.Text = "Add images to gallery..";
            this.Load += new System.EventHandler(this.ImageSelection_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ColumnName;
        private System.Windows.Forms.ColumnHeader ColumnPath;
        private System.Windows.Forms.ColumnHeader ColumnIcon;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button AddSelectionButton;
        private System.Windows.Forms.Button ReturnToCollectionButton;
    }
}