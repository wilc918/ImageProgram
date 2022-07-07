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
    /// Version (06/07/2022)
    /// </summary>
    public interface IImageData
    {
        /// <summary>
        /// Method - Returns the image from a dataElement according to the fileName.
        /// </summary>
        /// <param name="filename">Name of the image file.</param>
        /// <returns>DataElement containing the image file.</returns>
        IDataElement RetrieveItem(string filename);

        /// <summary>
        /// Method - Rotates the specified image by a specified amount.
        /// </summary>
        /// <param name="key">Image filename.</param>
        /// <param name="degrees">Amount to be rotated by.</param>
        void RotateImage(string key, int degrees);

        /// <summary>
        /// Method - Flip image along the selected axis.
        /// </summary>
        /// <param name="key">Name of the image to be flipped.</param>
        /// <param name="vertically">Boolean representing which axis the image is flipped.</param>
        void FlipImage(string key, bool vertically);

        /// <summary>
        /// Method - Resize Image according to scale.
        /// </summary>
        /// <param name="key">Name of image to be rescaled.</param>
        /// <param name="scale">The amount to be scaled by.</param>
        void ScaleImage(string key, int scale);
        
        /// <summary>
        /// Method - Resize Image according to width and heigh parameters.
        /// </summary>
        /// <param name="key">Name of image to be resized</param>
        /// <param name="width">Desired width</param>
        /// <param name="height">Desired height</param>
        void ResizeImage(string key, int width, int height);

        /// <summary>
        /// Method - Save Image at file destination.
        /// </summary>
        /// <param name="key">Name of image to be saved.</param>
        /// <param name="fileDestination">Name of destination image will be saved at.</param>
        void SaveImage(string key, string fileDestination);

        /// <summary>
        /// Method - Removes Item from list
        /// </summary>
        /// <param name="key">Name of Item to be removed</param>
        void RemoveItem(string key);

        /// <summary>
        /// Method - Inserts imageManipulator
        /// </summary>
        /// <param name="imageManipulator">ImageManipulator to inserted.</param>
        void InjectManipulator(IImageManipulator imageManipulator);

        /// <summary>
        /// Method - Inserts factoryLocator into imageData.
        /// </summary>
        /// <param name="factoryLocator">Allows for the production of factories.</param>
        void InjectFactoryLocator(IServiceLocator factoryLocator);

    }
}
