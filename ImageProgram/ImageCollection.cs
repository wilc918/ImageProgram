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
        // DECLARE a to store image collection in:

        // DECLARE an IModel to access ModelStuff call it _ModelData:
        private IModel _ModelData;

        // DECLARE an IImageData to access ImageData, call it _imageData:
        private IImageData _imageData;

        // DECLARE a Dictionary<PictureBox, string> to store imagePaths in, call it _images:
        private IDictionary<PictureBox, string> _imageWithin;

        // DECLARE an IDictionary to store displayViews in, call it _displayViews:
        private IDictionary<int, DisplayView> _displayViews;

        // DECLARE a factory<DisplayView> to store factory in, call it _displayViewFactory:
        private IFactory<DisplayView> _displayViewFactory;

        // DECLARE an IPictureBoxFactory for storing a PictureBoxFactory
        private IPictureBoxFactory _pictureBoxFactory;

        // DECLARE a Dictionary<string, PictureBox> to store associate images with their picturebox
        private IImageManipulator _imageManipulator;

        // DECLARE an int to store the value for the next displayView, call it _displayKey, set to 0:
        private int _displayKey = 0;

        // DECLARE an int to act as a circular counter index into _images:
        private int _cCounter = 0;

        /// <summary>
        /// CONSTRUCTOR - ImageCollection Form Object Constructor
        /// </summary>
        /// <param name="ImageData">Data about images</param>
        public ImageCollection(IImageData ImageData, IImageManipulator imageManip, IDictionary<PictureBox, string> imageCollection,IPictureBoxFactory pictureBoxFactory, IFactory<DisplayView> displayViewFactory)
        {
            InitializeComponent();

            //Instantiate _imageData, casting ImageData as the type IImageData:
            _imageData = ImageData as IImageData;

            //Instantiate _ModelData, casting ImageData as the type IModel:
            _ModelData = ImageData as IModel;

            _pictureBoxFactory = pictureBoxFactory;

            _imageWithin = imageCollection;

            _imageManipulator = imageManip;

            _displayViews = new Dictionary<int, DisplayView>();

            _displayViewFactory = displayViewFactory;
        }

        #region Private Methods

        /// <summary>
        /// Adds images to the collection, only one at a time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddImagesButtonClick(object sender, EventArgs e)
        {
            //Open File Dialog enables the user to choose files from file explorer.
            OpenFileDialog galleryFile = new OpenFileDialog();

            galleryFile.Multiselect = true;
            // This filter ensures that only .jpgs and .pngs are allowed
            galleryFile.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif;";
            galleryFile.Title = "Add image to gallery";

            //If the user presses OK on the file explorer
            if (galleryFile.ShowDialog() == DialogResult.OK) 
            {
                //Convert the chosen array of strings into a list:
                List<String> imagePaths = galleryFile.FileNames.ToList();

                //Load the filepaths into into _ModelData and recieve the file names in a list:
                IList<String> imageNames = new List<String>();
                imageNames = _ModelData.load(imagePaths);
                
                //For each image in the gallery, a collectionPictureBox is produced and an image fit for it is retrieved.
                foreach (string file in imageNames) 
                {
                    
                    collectionPictureBox pictureBox = (collectionPictureBox)_pictureBoxFactory.MakePictureBox();
                    pictureBox.Image = _ModelData.getImage(file, pictureBox.Width,pictureBox.Height);
                    Debug.WriteLine("Image Filename: "+file);

                    pictureBox = pictureBox.setClick(new EventHandler(PresentPictureBox_Click))
                                            .setContextMenu(contextMenuStrip1)
                                            .setDoubleClick(new EventHandler(AddDisplayView_DoubleClick));

                    pictureBox.AccessibleName = file;

                    _imageWithin.Add(pictureBox, file);
                    collectionflowLayoutPanel.Controls.Add(pictureBox);
                }
                ResetPictureBoxes();

            }
        }
        /// <summary>
        /// Method - Removes Image and Disposes of PictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveImagesButtonsClick(object sender, EventArgs e) 
        {
            //Provide user with a dialog popup to safeguard accidental deletion.
            if (MessageBox.Show("Delete this image?", "Delete Image", MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                //Retrieve PictureBox from the selectedMenuItem using multiple casts to call getter methods to retrieve parent for each child.
                PictureBox entryToBeRemoved = ((ContextMenuStrip)((ToolStripItem)sender).Owner).SourceControl as PictureBox;
                //Dispose the entry
                DisposeEntry(entryToBeRemoved);
                //
                //ResetPictureBoxes();
            }
        }
        private void DisposeEntry(PictureBox target) 
        {
            _imageData.RemoveItem(_imageWithin[target]);
            target.Image.Dispose();
            target.Dispose();
        }

        /// <summary>
        /// Method - Changes pictureBoxes background color back to default.
        /// </summary>
        private void ResetPictureBoxes() {
            //For each entry in _pictureBoxes, change the PictureBox's colour to the default colour.
            foreach (KeyValuePair<PictureBox,string> entry in _imageWithin)
            {
                entry.Key.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        /// <summary>
        /// Method - Shows the user which PictureBox they are interacting with.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PresentPictureBox_Click(object sender, EventArgs e) {
            // Retrieve selected PictureBox
            PictureBox chosenPictureBox = (PictureBox)sender;
            // Reset all PictureBoxes to default.
            ResetPictureBoxes();
            // Changes the selected PictureBox background color to ActiveBorder.
            chosenPictureBox.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder);
        }

        /// <summary>
        /// Method - Creates displayView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDisplayView_DoubleClick(object sender, EventArgs e) {

            //Cast selected image as PictureBox so that I have access to the methods of PictureBox, call it chosenImage:
            PictureBox chosenPictureBox = (PictureBox)sender;
            //If the box contains an image, create a display view initialised with the image associated with this PictureBox
            if (chosenPictureBox.Image != null)
            {
                //DisplayView displayView = new DisplayView();
                DisplayView displayView = _displayViewFactory.Create<DisplayView>() as DisplayView;
                //Initialise the display View with the image filename, a delegate for retrieving image and imageManipulator
                displayView.Initialise(_imageWithin[chosenPictureBox],_ModelData.getImage, _imageManipulator);
                //Add to _displayViews and increment ready for next displayView
                _displayViews.Add(_displayKey, displayView);
                _displayKey++;
            }

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
