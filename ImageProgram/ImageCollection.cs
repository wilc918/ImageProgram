using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProgram
{
    /// <summary>
    /// Class - This class represents the ImageCollection form.
    /// 
    /// (Calum Wilkinson)
    /// (10/03/2021)
    /// </summary>
    public partial class ImageCollection : Form
    {
        //DECLARE a to store image collection in:

        // DECLARE an IModel to access ModelStuff call it _ModelData:
        private IModel _ModelData;

        // DECLARE an IImageData to access ImageData, call it _imageData:
        private IImageData _imageData;

        // DECLARE a form for ImageSelection, call it _imageSelectForm:
        private Form _imageSelectForm;

        //DECLARE an int to store the value for the next imageKey, call it _imageKey, set to 0:
        int _imageKey = 0;

        //DECLARE a List<String> to contain the names of the images in the gallery, call it galleryImagesNames
        private IList<String> _galleryImageNames;

        //DECLARE a Dictionary<int, DataElement> to store images in, call it _images:
        private IDictionary<int, Image> _images;

        // DECLARE an int to act as a circular counter index into _images:
        private int _cCounter = 0;


        /// <summary>
        /// CONSTRUCTOR - ImageCollection Form Object Constructor
        /// </summary>
        /// <param name="ImageData">Data about images</param>
        public ImageCollection(IImageData ImageData, IDictionary<int, Image> imageContainer)
        {
            InitializeComponent();

            //Instantiate _imageData, casting ImageData as the type IImageData:
            _imageData = ImageData as IImageData;

            //Instantiate _ModelData, casting ImageData as the type IModel:
            _ModelData = ImageData as IModel;

            //Instantiate images Dictionary
            _images = imageContainer;

            //_galleryImageNames = new List<string>();
            //_galleryImageNames.Add("..\\..\\FishAssets\\Urchin.png");
            //_ModelData.load(_galleryImageNames);
        }


        /// <summary>
        /// Method - Launch the ImageSelection Form so that the user may choose what images to add to their collection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageCollection_AddImage(object sender, EventArgs e)
        {
            //Code to launch second form, but only if there isn't already one existing.
            if (_imageSelectForm == null || _imageSelectForm.IsDisposed)
            {
                _imageSelectForm = new ImageSelection(_imageData);
                _imageSelectForm.Show();
            }
        }

        /// <summary>
        /// Method - Retrieve and display the next image in the collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageCollection_Next(object sender, EventArgs e) 
        {
            _imageKey = CircularAdder(_images.Count, 1);
            PictureDisplay.Image = _images[_imageKey];

            /*
            if (_galleryImageNames != null)
            {


                if (_imageKey < (_galleryImageNames.Count - 1)) 
                {
                    //Increment key number
                    _imageKey++;
                    PictureDisplay.Image = _images[_imageKey];
                }
                
            }*/
                
            //Load Image
            //ImageLoad();
        }

        /// <summary>
        /// Method - Retrieve and display the previous image from the collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageCollection_Previous(object sender, EventArgs e) 
        {

            _imageKey = CircularAdder(_images.Count, -1);
            PictureDisplay.Image = _images[_imageKey];

            /*
            if (_imageKey != 0)
                {
                    _imageKey--;

                    PictureDisplay.Image = _images[_imageKey];
                 }*/

            //Load Image
            //ImageLoad();

        }

        #region Private Methods

        /// <summary>
        /// Loads an image according path associated with the _imageKey
        /// </summary>
        private void ImageLoad() 
        {

            //retrieveImageList
            _galleryImageNames = _imageData.GetCollectionList();
            
            if (_galleryImageNames != null) 
            {
                //Code to retrieve image name using imagekey.
                PictureDisplay.Image = _ModelData.getImage(_galleryImageNames[_imageKey], PictureDisplay.Width, PictureDisplay.Height);
                //PictureDisplay.Image = _images[_imageKey];
            }
        }
        #endregion

        private void AddImagesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog galleryFile = new OpenFileDialog();

            galleryFile.Filter = "Choose Image(*.jpg;*.png)|*.jpg;*.png;";

            if (galleryFile.ShowDialog() == DialogResult.OK) 
            {
                //PictureDisplay.Image = Image.FromFile(galleryFile.FileName);
                //_ModelData.load(_selectedItems);
                _images.Add(_imageKey, Image.FromFile(galleryFile.FileName));
                PictureDisplay.Image = _images[_imageKey];
                _imageKey++;

            }
        }

        #region Private Methods

        /// <summary>
        /// Method to control image file (as a Blob) that is instantiated as part of a note
        /// </summary>
        /// <param name="maxValue">The total number of image files in use</param>
        /// <returns></returns>
        private int CircularAdder(int maxValue, int amount)
        {
            _cCounter += amount;

            if (_cCounter == maxValue)

            {
                _cCounter = 0;
            }

            if (_cCounter == -1)

            {
                _cCounter = (maxValue - 1);
            }

            return _cCounter;
        }
        #endregion
    }
}
