using System;
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

        //DECLARE an int to act as a circular counter index into _imageNames:
        private int _cCounter = 0;

        public ImageData()
        {
            //_data = new Dictionary<int, DataElement>();
            //_imageNames = new List<String>(Directory.GetFiles(_imagePath));

            _displayData = new Dictionary<string, string>();

            //load(_imageNames);
        }

        #region Implementation of IImageData
        /// <summary>
        /// Add Item to dictionary
        /// </summary>
        /// <param name="Key">Key for identification</param>
        public void AddItem(int Key) 
        { 
            // Does Nothing at the moment
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
                if (!_displayData.ContainsKey(Path.GetFileName(pathfilenames[i])))
                {
                    //Add to the dictionary the file name and the file path.
                    _displayData.Add(Path.GetFileName(pathfilenames[i]), pathfilenames[i]);
                }
            }

            _imageNames = new List<String>(_displayData.Keys);

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
            //By entering the file name, which is our key for our dictionary, we should get the full path.
            return Bitmap.FromFile(Path.GetFullPath(_displayData[key]));
        }
        #endregion
    }
}
