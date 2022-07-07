using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    /// Interface - provides classes with methods regarding manipulation of Image Data contained within these DataElements.
    /// 
    /// Author (Calum Wilkinson)
    /// Version (07/07/2022)
    /// </summary>
    public interface IDataElement
    {
        /// <summary>
        /// Initialise this data with the required data
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="image">Image</param>
        void Initialise(Image image, IImageManipulator imageManipulator);

        /// <summary>
        /// Method - Retrieve the image.
        /// </summary>
        /// <returns>The image.</returns>
        Image RetrieveImage();

        /// <summary>
        /// Method - Retrieve the image, modified to size.
        /// </summary>
        /// <param name="size">Size of the image.</param>
        void RetrieveImage(Size size);

        /// <summary>
        /// Method - Flip the image ? vertically : horizontally .
        /// </summary>
        /// <param name="vertically">Determines whether the image is flipped vertically or horizontally.</param>
        void FlipImage(bool vertically);

        /// <summary>
        /// Method - Rotate the image by amount of degrees specified. 
        /// </summary>
        /// <param name="degrees">Rotation amount</param>
        void RotateImage(int degrees);

        /// <summary>
        /// Method - Replaces Image with parameter image.
        /// </summary>
        /// <param name="image">New Image to replace old Image.</param>
        void ChangeImage(Image image);

        /// <summary>
        /// Method - Saves image at fileDestination.
        /// </summary>
        /// <param name="fileDestination">FilePath string</param>
        void SaveImage(string fileDestination);

    }
}
