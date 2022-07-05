using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ImageProgram
{
    public class collectionPictureBox : PictureBox
    {
        ContextMenuStrip _menuStrip;
        public collectionPictureBox() 
        {
           this.BorderStyle = BorderStyle.FixedSingle;
           this.SizeMode = PictureBoxSizeMode.Zoom;
           this.Cursor = Cursors.Hand;
           this.Size = new Size(150, 111);
        }

        public collectionPictureBox intialise() {
            

            return this;
        }

        public collectionPictureBox setClick(EventHandler ev) 
        {
            this.Click += ev;
            return this;
        }

        public collectionPictureBox setDoubleClick(EventHandler ev) 
        {
            this.DoubleClick += ev;
            return this;
        }
        public collectionPictureBox setContextMenu(ContextMenuStrip contextMenuStrip) 
        { 
            this.ContextMenuStrip = contextMenuStrip;
            return this;
        }

        public collectionPictureBox setImage(String image)
        {
            this.ImageLocation = image;
            return this;
        }

    }
}
