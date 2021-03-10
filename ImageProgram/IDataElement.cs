using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    /// Interface - provides classes with methods regarding the retrieval and initialisation of images.
    /// 
    /// (Calum Wilkinson)
    /// Version (10/03/2021)
    /// </summary>
    public interface IDataElement
    {
        /// <summary>
        /// Initialise this data with the required data
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="image">Image</param>
        void Initialise(String text, Image image);

        /// <summary>
        /// Retrieve the image.
        /// </summary>
        /// <returns>The image.</returns>
        Image RetrieveImage();
    }
}
