using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProgram
{

    /// <summary>
    /// Class - Controls all the attributes required to run the ImageProgram.
    /// 
    /// Author (Calum Wilkinson)
    /// Version (10/03/2020)
    /// </summary>
    class Controller
    {
        /// <summary>
        /// CONSTRUCTOR - runs the ImageCollection Application.
        /// </summary>
        public Controller() {

           // IImageData imageData = ();




            Application.Run(new ImageCollection());
        }


    }
}
