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
    /// Class - Handles a collection of Image data.
    /// 
    /// (Calum Wilkinson)
    /// (10/03/2021)
    /// </summary>
    class ImageData : IModel, IImageData, IEventPublisher
    {
        //DECLARE a Dictionary<int,DataElement> to store images to be displayed in, call it _displayData:
        private IDictionary<string, string> _displayData;

        //Declare a Dictionary<int,DataElement> to store DataElements in, call it _dataElements:
        private IDictionary<string, DataElement> _imageElements;

        //DECLARE an IImageManipulator to store ImageManipulator in, call it _imageMan:
        private IImageManipulator _imageManipulator;
       

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
        /// Call rotateImage on the selected item.
        /// </summary>
        /// <param name="key">Name of the item.</param>
        /// <param name="degrees">The amount to rotate by.</param>
        public void RotateImage(string key, int degrees)
        {
            _imageElements[key].RotateImage(degrees);
        }

        public void FlipImage(string key, bool vertically)
        {
            _imageElements[key].FlipImage(vertically);
        }

        public void ScaleImage(string key, int scale)
        {
            _imageElements[key].RetrieveImage2(new Size(scale, scale));
        }

        public void ResizeImage(string key, int width, int height)
        {
            _imageElements[key].RetrieveImage2(new Size((int)width, (int)height));
        }

        public void SaveImage(string key, string fileDestination)
        {
            _imageElements[key].SaveImage(fileDestination);
        }

        /// <summary>
        /// Remove Item from list.
        /// </summary>
        /// <param name="key"></param>
        public void RemoveItem(string key) {
            _imageElements[key].Dispose();
            _imageElements.Remove(key);
        }
        #endregion

        #region Implementation of IEventPublisher
        public void Subscribe(string key, EventHandler<DisplayEventArgs> listener)
        {
            (_imageElements[key] as IInternalEventPublisher).Subscribe(listener);
        }

        public void Unsubscribe(string key, EventHandler<DisplayEventArgs> listener)
        {
            (_imageElements[key] as IInternalEventPublisher).Unsubscribe(listener);
        }
        #endregion

        public void InjectManipulator(IImageManipulator imageManipulator) 
        {
            _imageManipulator = imageManipulator;
        
        }

        #region Implementing IModel
        /// <summary>
        /// Method - Load the media items pointed to by 'pathfilenames' into the 'Model'
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
                    element.Initialise(Bitmap.FromFile(Path.GetFullPath(pathfilenames[i])), _imageManipulator);

                    _imageElements.Add(Path.GetFileName(pathfilenames[i]), element);

                    imageNames.Add(Path.GetFileName(pathfilenames[i]));
                }


            }

            //We return the full list of keys, that we can loop through to get the file names
            return imageNames;
        }

        /// <summary>
        /// Method - Return a copy of the image specified by 'key', scaled according to the dimentsions of the visual container (ie frame) it will be viewed in.
        /// </summary>
        /// <param name="key">the unique identifier for the image to be returned</param>
        /// <param name="frameWidth">the width (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="frameHeight">the height (in pixles) of the 'frame' it is to occupy</param>
        /// <returns>the Image pointed identified by key</returns>
        public Image getImage(String key, int frameWidth, int frameHeight) {
            Image requestedImage = _imageElements[key].RetrieveImage();
            _imageElements[key].RetrieveImage2(new Size(frameWidth, frameHeight));
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
