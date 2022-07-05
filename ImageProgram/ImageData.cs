using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    /// Class - Handles the storage and retrieval of Image data.
    /// 
    /// (Calum Wilkinson)
    /// (10/03/2021)
    /// </summary>
    class ImageData : IModel, IImageData
    {
        //DECLARE a Dictionary<int,DataElement> to store images to be displayed in, call it _displayData:
        private IDictionary<string, string> _displayData;

        //Declare a Dictionary<int,DataElement> to store DataElements in, call it _dataElements:
        private IDictionary<string, DataElement> _imageElements;

        /// <summary>
        /// Constructor for objects of type ImageData
        /// </summary>
        public ImageData()
        {
            //Instantiate _displayData:
            _displayData = new Dictionary<string, string>();
            //Instantiate _imageElements:
            _imageElements = new Dictionary<string, DataElement>();
        }

        #region Implementation of IImageData
        /// <summary>
        /// Removes Image;
        /// </summary>
        /// <param name="Key">The file name.</param>
        public void RemoveItem(string Key) {
            _imageElements.Remove(Key);
        }
        #endregion

        #region Implementing IModel
        /// <summary>
        /// Load the media items pointed to by 'pathfilenames' into the 'Model'
        /// </summary>
        /// <param name="pathfilenames">list of strings, each contains filename/path for loading</param>
        /// <returns>the unique identifiers of the images that have been loaded</returns>
        public IList<String> load(IList<String> pathfilenames)
        {
            IList<String> imageNames = new List<String>();

            // Loop through the submitted filepaths and add them to the file dictionary, if they aren't already present!
            for (int i = 0; i < pathfilenames.Count; i++)
            {
                //Checks for new images and stores them in DataElements:
                if (!_imageElements.ContainsKey(Path.GetFileName(pathfilenames[i])))
                {

                    DataElement element = new DataElement();
                    element.Initialise(Bitmap.FromFile(Path.GetFullPath(pathfilenames[i])));

                    _imageElements.Add(Path.GetFileName(pathfilenames[i]), element);

                    imageNames.Add(Path.GetFileName(pathfilenames[i]));
                }


            }

            //We return the full list of keys, that we can loop through to get the file names
            return imageNames;
        }

        /// <summary>
        /// Retrieve the appropiate image
        /// </summary>
        /// <param name="key">Filename</param>
        /// <param name="frameWidth">width of the container for the image</param>
        /// <param name="frameHeight">height of the container for the image</param>
        /// <returns></returns>
        public Image getImage(String key, int frameWidth, int frameHeight) {
            Image requestedImage = _imageElements[key].RetrieveImage();
            //Produce thumbnail images for large images in small frames:
            if ((frameHeight < 300 || frameWidth < 300) && (requestedImage.Width > frameWidth || requestedImage.Height > frameHeight))
            {
                return requestedImage.GetThumbnailImage(frameWidth, frameHeight, ()=>false, IntPtr.Zero);
            }
            //By entering the file name, which is our key for our dictionary, we should get the full path.
            return requestedImage;
        }
        #endregion
    }
}
