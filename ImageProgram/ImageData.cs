using System;
using System.Collections.Generic;
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
    class ImageData
    {
        //DECLARE a string to store the path for images, call it _imagePath:
        private const string _imagePath = "..\\..\\FishAssets\\";

        //DECLARE an int to act as a circular counter index into _imageNames:
        private int _cCounter = 0;

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
