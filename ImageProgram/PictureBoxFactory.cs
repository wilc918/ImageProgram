using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ImageProgram
{
    public class PictureBoxFactory : IPictureBoxFactory
    {
        PictureBox pictureBox;

        public PictureBox MakePictureBox() {
            pictureBox = new collectionPictureBox();
            return pictureBox;
        }

        public PictureBox MakePictureBox(ContextMenuStrip contextMenuStrip) {
            pictureBox = new PictureBox();
            //pictureBox.Tag = _pictureBoxes.Count;
            pictureBox.Size = new Size(150, 111);
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            //pictureBox.ContextMenuStrip = contextMenuStrip1;
            //pictureBox.Click += new EventHandler(ImageClick);
            //pictureBox.DoubleClick += new EventHandler(ImageDoubleClick);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            //pictureBox.Image = Image.FromFile(_galleryImageNames[_galleryImageNames.Count - 1]);
            //pictureBox.Image = _images[_images.Count-1];
            pictureBox.Cursor = Cursors.Hand;
            //_pictureBoxes.Add(_pictureBoxes.Count, pictureBox);
            //collectionflowLayoutPanel.Controls.Add(pictureBox);
            return pictureBox;
        }

    }
}
