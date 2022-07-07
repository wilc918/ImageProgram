using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProgram
{
    /// <summary>
    ///  Interface for enforcing PictureBoxFactory method MakePictureBox
    ///  
    ///  Author (Calum Wilkinson)
    ///  Version (07/07/2022)
    /// </summary>
    public interface IPictureBoxFactory
    {
        /// <summary>
        /// Instantiate a pictureBox according to specificaitons for ImageCollection
        /// </summary>
        /// <returns></returns>
        PictureBox MakePictureBox();
    }
}
