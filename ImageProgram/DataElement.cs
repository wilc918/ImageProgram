using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    /// Class - Used for the storage and retrieval of Images
    /// 
    /// (Calum Wilkinson)
    /// (10/03/2021)
    /// </summary>
    class DataElement : IDataElement
    {
        // DECLARE an Image to store images in, call it _image:
        private Image _image;

        #region IDataElement
        /// <summary>
        /// Stores Image inside of _image attribute
        /// </summary>
        /// <param name="image">Image to be stored</param>
        public void Initialise(Image image)
        {
            _image = image;
        }

        /// <summary>
        /// Retrieves the Image stored inside of the _image attribute
        /// </summary>
        /// <returns>Image inside of the _image attribute</returns>
        public Image RetrieveImage() 
        {
            return _image;
        }
        #endregion
    }
}
