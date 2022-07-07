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
    /// Author (Calum Wilkinson)
    /// Version (07/07/2022)
    /// </summary>
    class DataElement : IDataElement, IInternalEventPublisher, IDisposable
    {
        // DECLARE an image of type Image, call it _image:
        private Image _image;

        // DECLARE an EventHandler of type EventHandler<ImageEventArgs>, call it _displayEvent:
        private event EventHandler<ImageEventArgs> _displayEvent;

        // DECLARE an imageManipulator of type IImageManipulator, call it _imageManipulator:
        private IImageManipulator _imageManipulator;

        #region IDataElement
        /// <summary>
        /// METHOD - Stores Image inside of _image attribute
        /// </summary>
        /// <param name="image">Image to be stored</param>
        public void Initialise(Image image, IImageManipulator imageMan)
        {
            _image = image;
            _imageManipulator = imageMan;
        }

        /// <summary>
        /// METHOD - Retrieves the Image stored inside of the _image attribute and returns it.
        /// </summary>
        /// <returns>Image inside of the _image attribute</returns>
        public Image RetrieveImage() 
        {
            return _image;
        }

        /// <summary>
        /// METHOD - RetireveImageAccording to size
        /// </summary>
        /// <param name="rqdImageSize">Size of the image to retrieve.</param>
        public void RetrieveImage(Size rqdImageSize)
        {
            // Retrieves the Image at the required size:
            OnNewImageInput(_imageManipulator.Resize(_image, rqdImageSize));
        }

        /// <summary>
        /// METHOD - Changes the image to be flipped.
        /// </summary>
        /// <param name="vertically">Determines whether the image is flipped vertically or horzontally.</param>
        public void FlipImage(bool vertically)
        {
            // The image is replaced by a flipped version:
            ChangeImage(_imageManipulator.Flip(_image, vertically));
        }

        /// <summary>
        /// METHOD - Changes the image to be rotated.
        /// </summary>
        /// <param name="degrees">The amount the image is to be rotated by.</param>
        public void RotateImage(int degrees)
        {
            // The image is replaced by a rotated version:
            ChangeImage(_imageManipulator.Rotate(_image, degrees));
        }

        /// <summary>
        /// METHOD - Takes a new image and replaces the old image.
        /// </summary>
        /// <param name="newImage"></param>
        public void ChangeImage(Image newImage)
        {
            // SET _image with new image:
            _image = newImage;

            //Notifies the subscribers:
            OnNewImageInput(_image);
        }

        /// <summary>
        /// METHOD - Saves the image at fileDestination.
        /// </summary>
        /// <param name="fileDestination">Where the image is to be saved.</param>
        public void SaveImage(string fileDestination)
        {
            //Use imageManipulator to save file at destination:
            _imageManipulator.SaveFile(_image, fileDestination);
        }

        #endregion
        #region Implementation of IInternalEventPublisher

        /// <summary>
        /// Subscribe listener to ImageEvents.
        /// </summary>
        /// <param name="listener"></param>
        public void Subscribe(EventHandler<ImageEventArgs> listener)
        {
            _displayEvent += listener;
        }

        /// <summary>
        /// Unsubscribe listener from ImageEvents.
        /// </summary>
        /// <param name="listener"></param>
        public void Unsubscribe(EventHandler<ImageEventArgs> listener)
        {
            _displayEvent -= listener;
        }

        #endregion

        #region Implementation of IDisposable

        /// <summary>
        /// Call dispose on the image;
        /// </summary>
        public void Dispose()
        {
            _image.Dispose();
        }
        #endregion

        /// <summary>
        /// Called when new image is recieved.
        /// </summary>
        /// <param name="data">New Image</param>
        private void OnNewImageInput(Image data) 
        {
            // Create an ImageEventArgs containing Image:
            ImageEventArgs imageArgs = new ImageEventArgs(data);

            // Update subscribers to this DataElement on new Image.
            _displayEvent(this, imageArgs);
        }
    }
}
