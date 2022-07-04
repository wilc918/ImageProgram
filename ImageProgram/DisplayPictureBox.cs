using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProgram
{
    internal class DisplayPictureBox : PictureBox
    {
        public DisplayPictureBox()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.SizeMode = PictureBoxSizeMode.Zoom;
            this.Size = new Size(516, 271);
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Location = new Point(12, 12);
            this.Name = "DisplayViewImage";
        }

        public void setImage(String image)
        {
            this.ImageLocation = image;
        }
    }
}
