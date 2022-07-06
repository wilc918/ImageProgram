using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    /// Interface - Provides access to methods related to the addition and removal of image data.
    /// 
    /// Author (Calum Wilkinson)
    /// Version (10/03/2020)
    /// </summary>
    public interface IImageData
    {
        /// <summary>
        /// Method - Removes Item from list
        /// </summary>
        /// <param name="Key">Name of Item to be removed</param>
        void RemoveItem(string Key);

        /// <summary>
        /// Method - Inserts imageManipulator
        /// </summary>
        /// <param name="imageManipulator">ImageManipulator to inserted.</param>
        void InjectManipulator(IImageManipulator imageManipulator);

    }
}
