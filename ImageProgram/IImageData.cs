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
    /// </summary>
    interface IImageData
    {
        /// <summary>
        /// Method - Adds Item To List
        /// </summary>
        /// <param name="Key">Used to identify item</param>
       void AddItem(int Key);

        /// <summary>
        /// Method - Removes Item From List
        /// </summary>
        /// <param name="Key">Used to identify item</param>
        void RemoveItem(int Key);

    }
}
