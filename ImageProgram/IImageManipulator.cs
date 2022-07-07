using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessor;

namespace ImageProgram
{
    /// <summary>
    /// Interface for implementing methods for interacting with the ImageProcessor library.
    /// 
    /// Author (Calum Wilkinson)
    /// Version (07/07/2022)
    /// </summary>
    public interface IImageManipulator
    {
        /// <summary>
        /// Method - Resizes Image.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="size"></param>
        /// <returns>Resized Image</returns>
        Image Resize(Image image, Size size);

        /// <summary>
        /// Method - Rotates image.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="degrees">Amount to rotate</param>
        /// <returns>Rotated Image</returns>
        Image Rotate(Image image, int degrees);

        /// <summary>
        /// Method - Flips image along axis.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="flipVertically">Determines which axis the image is flipped</param>
        /// <returns>A flipped image.</returns>
        Image Flip(Image image, bool flipVertically);

        /// <summary>
        /// Method - Saves image file at fileDestination.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="fileDestination">FilePath string.</param>
        void SaveFile(Image image, string fileDestination );
    }
}
