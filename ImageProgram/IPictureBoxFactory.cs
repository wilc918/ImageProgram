using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProgram
{
    public interface IPictureBoxFactory
    {
        /// <summary>
        /// Instantiate a pictureBox according to specificaitons for ImageCollection
        /// </summary>
        /// <returns></returns>
        PictureBox MakePictureBox();
    }
}
