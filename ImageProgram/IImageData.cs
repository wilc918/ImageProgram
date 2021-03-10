using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    interface IImageData
    {
        /// <summary>
        /// Retrieve an image associate with the imageKey
        /// </summary>
        /// <param name="imageKey">Key used for parsing dictionary</param>
        /// <returns>The Image associated with the key</returns>
        Image RetrieveImage(int imageKey);
    }
}
