using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

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

        //DECLARE an int to store the set number, call it _setKey, set to 0:
        int _setKey = 0;

        //DECLARE a List<String> to contain the names of the images in the gallery, call it galleryImagesNames
        private IList<String> _galleryImageNames;

        //DECLARE a Dictionary<int, DataElement> to store images in, call it _images:
        private IDictionary<int, Image> _images;
        // Image Location String
        //private IDictionary<int, String> _images;

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

            // Creates array of PictureBoxes
            PictureBox[] boxCollection = this.Controls.OfType<PictureBox>().ToArray();
            // Moves them into Dictionary
            for (int i = 0; i < boxCollection.Length; i++) 
            {
                _pictureBoxes.Add(i, boxCollection[i]);
                Debug.WriteLine(i +" " + _pictureBoxes[i].Name);
            }

            Debug.WriteLine("PBCount: " + _pictureBoxes.Count);
        }

        #region Private Methods

        /// <summary>
        /// Method - Retrieve and display the next image in the collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageCollectionNext(object sender, EventArgs e) 
        {
            //Checks if there are images to fill the next set
            if (_images.Count > (_setKey + 9))
            {
                // Increase set
                _setKey = _setKey + 9;
                Debug.WriteLine("imageCount: " + _images.Count + " Set Key: " + _setKey);
                RefreshImages();

            }

        }

        /// <summary>
        /// Method - Retrieve and display the previous image from the collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageCollectionPrevious(object sender, EventArgs e) 
        {
            if (_images.Count > 9 & _setKey > 0)
            {
                _setKey = _setKey - 9;

                RefreshImages();

            }

        }

            

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
                PictureDisplay9.Image = _ModelData.getImage(_galleryImageNames[_imageKey], PictureDisplay9.Width, PictureDisplay9.Height);
                //PictureDisplay.Image = _images[_imageKey];
            }
        }


        /// <summary>
        /// Adds images to the collection, only one at a time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddImagesButtonClick(object sender, EventArgs e)
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

                RefreshImages();

            }
        }

        private void RefreshImages() {
            for (int i = 0; i < _pictureBoxes.Count; i++)
            {
                if (_images.ContainsKey(i + _setKey))
                {
                    _pictureBoxes[i].Image = _images[i + _setKey];
                    _pictureBoxes[i].Cursor = Cursors.Hand;
                    //_pictureBoxes[i].BackColor = Color.Beige;
                }
                else
                {
                    _pictureBoxes[i].Image = null;
                    _pictureBoxes[i].Cursor = Cursors.Default;
                }

                //Debug.WriteLine("PDIsp: " + _pictureBoxes[i].Image);
                //Debug.WriteLine("PDIsp: " + i + " Set Key: " + _setKey);
            }
        }

        private void ImageDoubleClick(object sender, EventArgs e) {
            
            //Cast selected image as PictureBox so that I have access to the methods of PictureBox, call it chosenImage:
            PictureBox chosenImage = (PictureBox)sender;


            Debug.WriteLine("Image clicked is: " + chosenImage.BackColor);
            if (chosenImage.Image != null)
            {
                Debug.WriteLine("Image clicked is: " + chosenImage.Image);
                DisplayView displayImage = new DisplayView(chosenImage.Image);
            }
            
            //Create display view using chosenImage, call it displayImage:
           // DisplayView displayImage = new DisplayView(chosenImage.Image);
            //displayImage.Show();
        }
        #endregion
        #region Circular Adder

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
