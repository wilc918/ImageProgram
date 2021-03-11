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

        //DECLARE a Dictionary<int,DataElement> to store data in, call it _data:
        private IDictionary<string, IDataElement> _data;

        //DECLARE an int to act as a circular counter index into _imageNames:
        private int _cCounter = 0;

        public ImageData()
        {
            //_data = new Dictionary<int, DataElement>();
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
        #endregion

        #region Implementing IModel
        /// <summary>
        /// Load the media items pointed to by 'pathfilenames' into the 'Model'
        /// </summary>
        /// <param name="pathfilenames">list of strings, each contains filename/path for loading</param>
        /// <returns>the unique identifiers of the images that have been loaded</returns>
        public IList<String> load(IList<String> pathfilenames) 
        {
             
            //Returns a list containing all of the file names f
            return new List<String>(Directory.GetFiles(_imagePath));
        }

        public Image getImage(String key, int frameWidth, int frameHeight) {

            return Bitmap.FromFile(Path.GetFullPath(_imageNames[CircularCounter(_imageNames.Count)]));
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Method - to allow for cycling through the images after we grab them in bulk
        /// </summary>
        /// <param name="maxCount">The total number of files grabbed</param>
        /// <returns></returns>
        private int CircularCounter(int maxCount)
        {
            _cCounter++;
            if (_cCounter == maxCount)
            {
                _cCounter = 0;
            }
            return _cCounter;

        }
        #endregion
    }
}
