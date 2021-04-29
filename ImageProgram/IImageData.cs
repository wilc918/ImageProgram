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
        /// Method - Adds Item To List
        /// </summary>
        /// <param name="Key">Used to identify item</param>
       void AddItem(int Key);

        /// <summary>
        /// Method - Removes Item From List
        /// </summary>
        /// <param name="Key">Used to identify item</param>
        void RemoveItem(int Key);

        //Loads an image
        //Image LoadImage(Image image);

        /// <summary>
        /// Method - Retrieves the imageList.
        /// </summary>
        /// <returns>List of images for the gallery</returns>
        IList<String> GetCollectionList();

    }
}
