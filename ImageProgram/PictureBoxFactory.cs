using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProgram
{
    /// <summary>
    /// Abstract factory class for making pictureBoxes.
    /// 
    /// Author (Calum Wilkinson)
    /// Version (07/07/2022)
    /// </summary>
    abstract public class PictureBoxFactory : IPictureBoxFactory
    {
        /// <summary>
        /// Method - Virtual so it can be overridden by derived classes.
        /// </summary>
        /// <returns>PictureBox</returns>
        public virtual PictureBox MakePictureBox() 
        {
            PictureBox pictureBox = new PictureBox();

            return pictureBox;
        }
    }
}
