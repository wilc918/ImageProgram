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
