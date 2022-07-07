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
    /// (07/07/2022)
    /// </summary>
    class ImageData : IModel, IImageData, IEventPublisher
    {
        // DECLARE a Dictionary<string, string> to store fileNames and filePaths, call it _displayData:
        private IDictionary<string, string> _displayData;

        // DECLARE a Dictionary<string,DataElement> to store DataElements in, call it _imageElements:
        private IDictionary<string, DataElement> _imageElements;

        // DECLARE an IImageManipulator to store ImageManipulator in, call it _imageMan:
        private IImageManipulator _imageManipulator;

        // DECLARE an IServiceLocator for factories, call it _factoryLocator:
        private IServiceLocator _factoryLocator;

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
        /// Method - Retrieves DataElement associated with filename string.
        /// </summary>
        /// <param name="key">Filename paired with DataElement</param>
        /// <returns>DataElement associated with filename</returns>
        public IDataElement RetrieveItem(string key)
        {
            // Returns the DataElement associated with key:
           return _imageElements[key];

        }


        /// <summary>
        /// METHOD - Remove Item from list.
        /// </summary>
        /// <param name="key">Filename paired with DataElement</param>
        public void RemoveItem(string key) {
            _imageElements[key].Dispose();
            _imageElements.Remove(key);
        }
        #endregion

        #region Implementation of IEventPublisher
        public void Subscribe(string key, EventHandler<ImageEventArgs> listener)
        {
            (_imageElements[key] as IInternalEventPublisher).Subscribe(listener);
        }

        public void Unsubscribe(string key, EventHandler<ImageEventArgs> listener)
        {
            (_imageElements[key] as IInternalEventPublisher).Unsubscribe(listener);
        }
        #endregion

        /// <summary>
        /// METHOD - Injects ImageManipulator into this class for use on image.
        /// </summary>
        /// <param name="imageManipulator"></param>
        public void InjectManipulator(IImageManipulator imageManipulator) 
        {
            // SET _imageManipulator:
            _imageManipulator = imageManipulator;
        
        }

        /// <summary>
        /// METHOD - Injects FactoryLocator into this class.
        /// </summary>
        /// <param name="factoryLocator">Produces and keeps track of factories.</param>
        public void InjectFactoryLocator(IServiceLocator factoryLocator)
        {
            // SET _factoryLocator:
            _factoryLocator = factoryLocator;
        }

        #region Implementing IModel
        /// <summary>
        /// Method - Load the media items pointed to by 'pathfilenames' into the 'Model'
        /// </summary>
        /// <param name="pathfilenames">list of strings, each contains filename/path for loading</param>
        /// <returns>the unique identifiers of the images that have been loaded</returns>
        public IList<String> load(IList<String> pathfilenames)
        {
            // Create new list<String> to hold imageNames in:
            IList<String> imageNames = new List<String>();

            // Loop through the submitted filepaths and add them to the file dictionary, if they aren't already present!
            for (int i = 0; i < pathfilenames.Count; i++)
            {
                //Checks for new images and stores them in DataElements:
                if (!_imageElements.ContainsKey(Path.GetFileName(pathfilenames[i])))
                {
                    //Create new DataElement using FactoryLocator:
                    DataElement element = (_factoryLocator.Get<DataElement>() as IFactory<DataElement>).Create<DataElement>();

                    //Intialise DataElement with Image and ImageManipulator:
                    element.Initialise(Bitmap.FromFile(Path.GetFullPath(pathfilenames[i])), _imageManipulator);

                    //Add keypair of fileName string and DataElement to _imageElements: 
                    _imageElements.Add(Path.GetFileName(pathfilenames[i]), element);

                    //Add fileName string to list:
                    imageNames.Add(Path.GetFileName(pathfilenames[i]));
                }


            }

            //Return the full list of keys, that can be looped through to get the file names
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

            // Recieve image from dataElement associated with key so there is something to return and fulfill the interface:
            Image requestedImage = _imageElements[key].RetrieveImage();

            // Retrieve Image from dataElement associated with key at desired Size:
            _imageElements[key].RetrieveImage(new Size(frameWidth, frameHeight));

            //Produce thumbnail images for large images in small frames:
            if ((frameHeight < 300 || frameWidth < 300) && (requestedImage.Width > frameWidth || requestedImage.Height > frameHeight))
            {
                // Returns a thumbnail of the Image:
                ///THIS CODE WAS TAKEN FROM https://stackoverflow.com/users/132858/russell-troywest & https://stackoverflow.com/users/3195477/stayontarget///
                /// Link to WebPage : https://stackoverflow.com/questions/2808887/create-thumbnail-image ///
                return requestedImage.GetThumbnailImage(frameWidth, frameHeight, ()=>false, IntPtr.Zero);
                ///END OF CODE///
            }

            
            //By entering the file name, which is our key for our dictionary, we should get the full path.
            return requestedImage;
        }
        #endregion
    }
}
