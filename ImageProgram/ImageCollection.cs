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


            //Problem is that picture boxes aren't in any ordered list, how do I know that it won't add the same box?
            /*for (int i = 0; i < 10; i++) {
                //_pictureBoxes.Add(i, );
                Debug.WriteLine(this.Controls.OfType<PictureBox>().Count());
            }*/

            //Problem is that picture boxes aren't in any ordered list, how do I get the key for the dicitonary?
            /*int l = 0;
            foreach (PictureBox pB in this.Controls.OfType<PictureBox>())
            {
                //_pictureBoxes.Add(l, pB);
                Debug.WriteLine("PBNum: " + l +" PB: "+ pB);
                l++;
                
                //Debug.WriteLine("ImageNum: " + entry.Key);
            }*/

           /* _pictureBoxes[0] = PictureDisplay1;
           _pictureBoxes[1] = PictureDisplay2;
           _pictureBoxes[2] = PictureDisplay3;
            _pictureBoxes[3] = PictureDisplay4;
            _pictureBoxes[4] = PictureDisplay5;
            _pictureBoxes[5] = PictureDisplay6;
            _pictureBoxes[6] = PictureDisplay7;
            _pictureBoxes[7] = PictureDisplay8;
            _pictureBoxes[8] = PictureDisplay9;*/

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
                PictureDisplay9.Image = _images[_imageKey];

                /*
                if (_imageKey < (_galleryImageNames.Count - 1)) 
                {
                    //Increment key number
                    _imageKey++;
                    PictureDisplay.Image = _images[_imageKey];
                }
                */

            }

            if (_images.Count > 9)
            {
                /*_setKey = _setKey + 9;

                   for (int i = 0; i < 9; i++) 
                   {
                     _pictureBoxes[i].Image = _images[i + _setKey];
                     //Debug.WriteLine("PDIsp: " + _pictureBoxes[i].Image);
                     Debug.WriteLine("PDIsp: " + _images[i].Tag);
                 }*/

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
                //_pictureBoxes[8].ImageLocation = _images[_imageKey];

                
                    _imageKey--;

                    PictureDisplay9.Image = _images[_imageKey];
                
            }

            if (_images.Count > 9)
            {
                /*_setKey = _setKey - 9;

                   for (int i = 0; i < 9; i++) 
                   {
                     _pictureBoxes[i].Image = _images[i + _setKey];
                     //Debug.WriteLine("PDIsp: " + _pictureBoxes[i].Image);
                     Debug.WriteLine("PDIsp: " + _images[i].Tag);
                 }*/

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
                PictureDisplay9.Image = _ModelData.getImage(_galleryImageNames[_imageKey], PictureDisplay9.Width, PictureDisplay9.Height);
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
                //_images.Add(_images.Count, galleryFile.FileName);
                //PictureDisplay1.Image = _images[_images.Count-1];

                //Place images into picture boxes
                foreach (KeyValuePair<int, Image> entry in _images) 
                {
                    //if associated picture box is empty then insert image
                    //_pictureBoxes[entry.Key].ImageLocation = _images[entry.Key];
                    if (entry.Key < 9) {
                        _pictureBoxes[entry.Key].Image = _images[entry.Key];
                        Debug.WriteLine("ImageNum: " + entry.Key + entry.Value);
                    }
                    
                       // Debug.WriteLine("No more picture boxes for " + entry.Key + " " + entry.Value + "!");
                    
                }
                //Debug.WriteLine("ImageNum: " + _images.Count);

                //PictureDisplay2.Image = _images[_images.Count-2];
                //Debug.WriteLine("Send to debug output." + _images[_images.Count-2]);
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
