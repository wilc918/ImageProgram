using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    /// Class - Used for the storage, modification, retrieval and disposal of individual Images.
    /// 
    /// (Calum Wilkinson)
    /// (06/07/2022)
    /// </summary>
    class DataElement : IDataElement, IInternalEventPublisher, IDisposable
    {
        // DECLARE an Image to store images in, call it _image:
        private Image _image;

        // DECLARE an event for storing display event handlers, call it _displayEvent:
        private event EventHandler<DisplayEventArgs> _displayEvent;

        private IImageManipulator _imageManipulator;

        #region IDataElement
        /// <summary>
        /// Stores Image inside of _image attribute
        /// </summary>
        /// <param name="image">Image to be stored</param>
        public void Initialise(Image image, IImageManipulator imageMan)
        {
            _image = image;
            _imageManipulator = imageMan;
        }

        /// <summary>
        /// Retrieves the Image stored inside of the _image attribute
        /// </summary>
        /// <returns>Image inside of the _image attribute</returns>
        public Image RetrieveImage() 
        {
            return _image;
        }
        /// <summary>
        /// Retrieve image.
        /// </summary>
        public void RetrieveImage2(Size rqdImageSize)
        {
            //OnNewImageInput(_image);
            OnNewImageInput(_imageManipulator.Resize(_image, rqdImageSize));
        }


        public void FlipImage(bool vertically)
        {
            ChangeImage(_imageManipulator.Flip(_image, vertically));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="degrees">The amount the image is to be rotated by.</param>
        public void RotateImage(int degrees)
        {
            ChangeImage(_imageManipulator.Rotate(_image, degrees));
        }

        public void ChangeImage(Image newImage)
        {
            _image = newImage;

            OnNewImageInput(_image);
        }

        public void SaveImage(string fileDestination)
        {
            _imageManipulator.SaveFile(_image, fileDestination);
        }

        #endregion

        public void Subscribe(EventHandler<DisplayEventArgs> listener)
        {
            _displayEvent += listener;
        }

        public void Unsubscribe(EventHandler<DisplayEventArgs> listener)
        {
            _displayEvent -= listener;
        }

        #region Implementation of IDisposable
        /// <summary>
        /// Call dispose on the image;
        /// </summary>
        public void Dispose()
        {
            _image.Dispose();
        }
        #endregion

        private void OnNewImageInput(Image data) 
        {
            DisplayEventArgs imageArgs = new DisplayEventArgs(data);
            _displayEvent(this, imageArgs);
        }
    }
}
