using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    /// Interface for implementing methods used on a DisplayView.
    /// 
    /// Author (Calum Wilkinson)
    /// Version (07/07/2022)
    /// </summary>
    interface IDisplayView
    {
        /// <summary>
        /// Method - For instantiating variables required for the class to function.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="execute"></param>
        /// <param name="retrieveImage"></param>
        /// <param name="rotateImageAction"></param>
        /// <param name="flipImageAction"></param>
        /// <param name="saveImageAction"></param>
        void Initialise(string fileName,ExecuteCommandDelegate execute,Action<Size> retrieveImage, Action<int> rotateImageAction ,Action<bool> flipImageAction, Action<string> saveImageAction);
    }


}
