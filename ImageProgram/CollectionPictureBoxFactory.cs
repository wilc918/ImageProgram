using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ImageProgram
{
    public class CollectionPictureBoxFactory : PictureBoxFactory
    {
        PictureBox pictureBox;

        public override PictureBox MakePictureBox() {
            pictureBox = new collectionPictureBox();
            return pictureBox;
        }
    }
}
