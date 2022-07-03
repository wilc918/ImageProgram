using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    /// Declare a delegate for retrieving listed of imageName, call it RetrieveImageList
    /// </summary>
    /// <param name="noteKey">Note Identifier</param>
    /// <returns>Associated note listItem</returns>
    public delegate String RetrieveImageListDelegate(int noteKey);

    /// <summary>
    /// Declare a delegate for retrieving stored imagePath, call it RetrieveImage
    /// </summary>
    /// <param name="ImageName">Name of the image to be retrieved</param>
    /// <returns>Associated file path to image</returns>
    public delegate Image RetrieveImageDelegate(string ImageName, int frameWidth, int frameHeight);


}
