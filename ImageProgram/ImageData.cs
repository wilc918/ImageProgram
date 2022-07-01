using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    /// Class - Contains information relating to the images
    /// 
    /// (Calum Wilkinson)
    /// (10/03/2021)
    /// </summary>
    class ImageData : IModel, IImageData
    {
        //DECLARE a string to store the path for images, call it _imagePath:
        private const string _imagePath = "..\\..\\FishAssets\\";

        //DECLARE a List<String> to store a list of path+filename for all available image files, called _imageNameList:
        private IList<String> _imageNames;

        //DECLARE a Dictionary<int,DataElement> to store images to be displayed in, call it _displayData:
        private IDictionary<string, string> _displayData;

        // DECLARE a Disctionary<int,DataElement> to store images in, call it _data:
        private IDictionary<int, DataElement> _data;

        private ConcurrentDictionary<int, string> _conDisplayData;

        IList<String> _pathfilenames;

        public ImageData()
        {
            //Instantiate _displayData
            _displayData = new Dictionary<string, string>();

            _conDisplayData = new ConcurrentDictionary<int, string>();

            // Instantiate _data:
            _imageNames = new List<String>();
        }

        #region Implementation of IImageData
        /// <summary>
        /// Add Item to dictionary
        /// </summary>
        /// <param name="Key">Key for identification</param>
        public void AddItem(int Key) 
        {
            // Create DataElement, call it element:
            //DataElement element = new DataElement();

            // Store image into element
            //element.Initialise(Bitmap.FromFile);
        }

        /// <summary>
        /// Remove Item from dictionary
        /// </summary>
        /// <param name="Key">Key for identification</param>
        public void RemoveItem(int Key) 
        {
        
        }
        
        /// <summary>
        /// Method - Getter, retrieve _imageNames list.
        /// </summary>
        /// <returns>Names of images</returns>
        public IList<String> GetCollectionList()
        {
            //Return ImageNames
            return _imageNames;
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
            //The key is the file name, value is the file path.
            // Loop through the submitted filepaths and add them to the file dictionary, if they aren't already present!
            for (int i = 0; i < pathfilenames.Count; i++)
            {
                
                if (!_displayData.ContainsKey(Path.GetFileName((pathfilenames[i])))) //check for key
                {
                    //_displayData.TryGetValue
                    //Add to the dictionary the file name and the file path.
                    _displayData.Add(Path.GetFileName(pathfilenames[i]), pathfilenames[i]);
                }


            }

            _imageNames = new List<String>(_displayData.Keys);

            //We return the full list of keys, that we can loop through to get the file names
            return _imageNames;
        }
        //public IList<String> load(IList<String> pathfilenames)
        //{
        //    _pathfilenames = pathfilenames;
        //    for (int i=0; i<_pathfilenames.Count; i++) 
        //    {
        //        //Create new DataElement, call it element:
        //        DataElement element = new DataElement();
        //        //Store image into element:
        //        element.Initialise(Bitmap.FromFile(Path.GetFullPath(_pathfilenames[i])));
        //        // Add element to _data with key:
        //        _data.Add(i, element);
        //    }

        //    _imageNames = new List<String>(_data.Keys);

        //    return ima
        //}

        /// <summary>
        /// Retrieve the appropiate image
        /// </summary>
        /// <param name="key">Filename</param>
        /// <param name="frameWidth">width of the container for the image</param>
        /// <param name="frameHeight">height of the container for the image</param>
        /// <returns></returns>
        public Image getImage(String key, int frameWidth, int frameHeight) {
            Image requestedImage = Bitmap.FromFile(Path.GetFullPath(_displayData[key]));
            if (requestedImage.Height > frameHeight || requestedImage.Width > frameWidth)
            {
                return requestedImage.GetThumbnailImage(frameWidth, frameHeight, ()=>false, IntPtr.Zero);
            }
            //By entering the file name, which is our key for our dictionary, we should get the full path.
            return requestedImage;
        }
        #endregion
    }
}
