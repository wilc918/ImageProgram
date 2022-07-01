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
        public collectionPictureBox() 
        {
           this.BorderStyle = BorderStyle.FixedSingle;
           this.SizeMode = PictureBoxSizeMode.Zoom;
           this.Cursor = Cursors.Hand;
           this.Size = new Size(150, 111);
        }

        public void setClick(EventHandler ev) 
        {
            this.Click += ev;
        }

        public void setDoubleClick(EventHandler ev) 
        {
            this.DoubleClick += ev;
        }
        public void setContextMenu(ContextMenuStrip contextMenuStrip) 
        { 
            this.ContextMenuStrip = contextMenuStrip;
        }

        public void setImage(String image)
        {
            this.ImageLocation = image;
        }

    }
}
