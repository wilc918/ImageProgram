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
    /// (15/04/2021)
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

        //DECLARE a Dictionary<int, DataElement> to store images in, call it _images:
        private IDictionary<int, PictureBox> _pictureBoxes;

        // DECLARE an int to act as a circular counter index into _images:
        private int _cCounter = 0;


        /// <summary>
        /// CONSTRUCTOR - ImageCollection Form Object Constructor
        /// </summary>
        /// <param name="ImageData">Data about images</param>
        public ImageCollection(IImageData ImageData, IDictionary<int, Image> imageContainer, IDictionary<int, PictureBox> pictureBoxContainer)
        {
            InitializeComponent();

            //Instantiate _imageData, casting ImageData as the type IImageData:
            _imageData = ImageData as IImageData;

            //Instantiate _ModelData, casting ImageData as the type IModel:
            _ModelData = ImageData as IModel;

            //Instantiate images Dictionary
            _images = imageContainer;

            _pictureBoxes = pictureBoxContainer;

           _pictureBoxes[0] = PictureDisplay1;
           _pictureBoxes[1] = PictureDisplay2;
           _pictureBoxes[2] = PictureDisplay3;

            //_galleryImageNames = new List<string>();
            //_galleryImageNames.Add("..\\..\\FishAssets\\Urchin.png");
            //_ModelData.load(_galleryImageNames);
        }

        

        /// <summary>
        /// Method - Retrieve and display the next image in the collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageCollection_Next(object sender, EventArgs e) 
        {
            
            if (_images.Count > 0)
            {
                _imageKey = CircularAdder(_images.Count, 1);
                PictureDisplay1.Image = _images[_imageKey];
                /*
                if (_imageKey < (_galleryImageNames.Count - 1)) 
                {
                    //Increment key number
                    _imageKey++;
                    PictureDisplay.Image = _images[_imageKey];
                }
                */

            }

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

            if (_images.Count > 0)
            {
                _imageKey = CircularAdder(_images.Count, -1);
                /*
                for (int i = 0; i < 9; i++) 
                {
                    PictureDisplay[i]
                }*/
                PictureDisplay1.Image = _images[_imageKey];


                /*
                    _imageKey--;

                    PictureDisplay.Image = _images[_imageKey];
                */
            }

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
                PictureDisplay1.Image = _ModelData.getImage(_galleryImageNames[_imageKey], PictureDisplay1.Width, PictureDisplay1.Height);
                //PictureDisplay.Image = _images[_imageKey];
            }
        }
        #endregion

        /// <summary>
        /// Adds images to the collection, only one at a time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddImagesButton_Click(object sender, EventArgs e)
        {
            //Open File Dialog enables the user to choose files from file explorer.
            OpenFileDialog galleryFile = new OpenFileDialog();

            // This filter ensures that only .jpgs and .pngs are allowed
            galleryFile.Filter = "Choose Image(*.jpg;*.png)|*.jpg;*.png;";
            galleryFile.Title = "Add image to gallery";

            //If the user presses OK on the file explorer
            if (galleryFile.ShowDialog() == DialogResult.OK) 
            {
                //PictureDisplay.Image = Image.FromFile(galleryFile.FileName);
                //_ModelData.load(_selectedItems);
                _images.Add(_images.Count, Image.FromFile(galleryFile.FileName));
                PictureDisplay1.Image = _images[_images.Count-1];
                //_imageKey++;

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
