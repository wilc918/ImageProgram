using System;
using System.Collections.Concurrent;
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
        private IList<String> _imageNames2;

        //DECLARE a Dictionary<int,DataElement> to store images to be displayed in, call it _displayData:
        private IDictionary<string, string> _displayData;

        private ConcurrentDictionary<int, string> _conDisplayData;

        //Declare a Dictionary<int,DataElement> to store DataElements in, call it _dataElements:
        private IDictionary<string, DataElement> _imageElements;

        public ImageData()
        {
            //Instantiate _displayData
            _displayData = new Dictionary<string, string>();

            _conDisplayData = new ConcurrentDictionary<int, string>();

            // Instantiate _data:
            _imageNames = new List<String>();
            _imageNames2 = new List<String>();

            _imageElements = new Dictionary<string, DataElement>();
        }

        #region Implementation of IImageData

        public void AddItem(string Key) {
            DataElement element = new DataElement();
            element.Initialise(Bitmap.FromFile(Path.GetFullPath(_imageNames2)));// Change the _imageNames2[Key] placeholder

            _imageElements.Add(Key, element);
        }

        /// <summary>
        /// Removes Image from 
        /// </summary>
        /// <param name="Key"></param>
        public void RemoveItem(string Key) {
            _imageElements.Remove(Key);
            _displayData.Remove(Key);
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

            _imageNames.Clear();
            //The key is the file name, value is the file path.
            // Loop through the submitted filepaths and add them to the file dictionary, if they aren't already present!
            for (int i = 0; i < pathfilenames.Count; i++)
            {

                if (!_displayData.ContainsKey(Path.GetFileName((pathfilenames[i])))) //check for key
                {
                    DataElement element = new DataElement();
                    element.Initialise(Bitmap.FromFile(Path.GetFullPath(pathfilenames[i])));// Change the _imageNames2[Key] placeholder

                    _imageElements.Add(Path.GetFileName(pathfilenames[i]), element);

                    //Add to the dictionary the file name and the file path.
                    _displayData.Add(Path.GetFileName(pathfilenames[i]), pathfilenames[i]);
                    _imageNames.Add(Path.GetFileName(pathfilenames[i]));
                    //_imageNames2.Add(Path.GetFileName(pathfilenames[i]));
                }
                //Check that the image isn't already contained to prevent duplicates:
                if (!_imageNames2.Contains(Path.GetFileName(pathfilenames[i])))
                {
                    _imageNames2.Add(Path.GetFileName(pathfilenames[i]));
                    //Debug.WriteLine("Contains doesn't search values");
                }


            }

            //We return the full list of keys, that we can loop through to get the file names
            return _imageNames;
        }

        /// <summary>
        /// Retrieve the appropiate image
        /// </summary>
        /// <param name="key">Filename</param>
        /// <param name="frameWidth">width of the container for the image</param>
        /// <param name="frameHeight">height of the container for the image</param>
        /// <returns></returns>
        public Image getImage(String key, int frameWidth, int frameHeight) {
            Image requestedImage = Bitmap.FromFile(Path.GetFullPath(_displayData[key]));
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
