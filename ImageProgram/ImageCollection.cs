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

        // DECLARE a factory<DisplayView> to store factory in, call it _displayViewFactory:
        private IFactory<DisplayView> _displayViewFactory;

        // DECLARE an IPictureBoxFactory for storing a PictureBoxFactory
        private IPictureBoxFactory _pictureBoxFactory;

        private CreateDisplayViewDelegate _createDisplayView;

        // DECLARE an int to act as a circular counter index into _images:
        private int _cCounter = 0;

        /// <summary>
        /// CONSTRUCTOR - ImageCollection Form Object Constructor
        /// </summary>
        /// <param name="ImageData">Data about images</param>
        public ImageCollection(IImageData ImageData, IDictionary<PictureBox, string> imageCollection,IPictureBoxFactory pictureBoxFactory, IFactory<DisplayView> displayViewFactory, CreateDisplayViewDelegate createDisplayView)
        {
            InitializeComponent();

            //Instantiate _imageData, casting ImageData as the type IImageData:
            _imageData = ImageData as IImageData;

            //Instantiate _ModelData, casting ImageData as the type IModel:
            _ModelData = ImageData as IModel;

            _pictureBoxFactory = pictureBoxFactory;

            _imageWithin = imageCollection;

            _displayViewFactory = displayViewFactory;

            _createDisplayView = createDisplayView;
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
                    //pictureBox.Image = _ModelData.getImage(file, pictureBox.Width,pictureBox.Height);
                    //_ModelData.getImage(file, pictureBox.Width, pictureBox.Height);
                    _imageWithin.Add(pictureBox, file);
                   // (_imageData as IEventPublisher).Subscribe(_imageWithin[pictureBox], pictureBox.OnNewInput);

                    (_imageData as IEventPublisher).Subscribe(file, pictureBox.OnNewInput);
                    pictureBox.Initialise(file, _ModelData.getImage);
                    Debug.WriteLine("Image Filename: "+file);

                    pictureBox = pictureBox.SetClick(new EventHandler(PresentPictureBox_Click))
                                            .SetContextMenu(contextMenuStrip1)
                                            .SetDoubleClick(new EventHandler(AddDisplayView_DoubleClick));

                    pictureBox.AccessibleName = file;

                    //(_imageData as IEventPublisher).Unsubscribe(file, pictureBox.OnNewInput);
                    collectionflowLayoutPanel.Controls.Add(pictureBox);
                }
                ResetPictureBoxes();

            }
        }

        private void AddPictureBox(PictureBox picturebox, string file) 
        {
            _imageWithin.Add(picturebox, file);
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
                collectionPictureBox entryToBeRemoved = ((ContextMenuStrip)((ToolStripItem)sender).Owner).SourceControl as collectionPictureBox;
                //Dispose the entry
                DisposeEntry(entryToBeRemoved);
                //ResetPictureBoxes();
            }
        }
        /// <summary>
        /// Method - Handles the disposal of the entry
        /// </summary>
        /// <param name="target">Entry to be disposed of</param>
        private void DisposeEntry(collectionPictureBox target) 
        {
            //Unsubscribe the entry from image being referenced:
            (_imageData as IEventPublisher).Unsubscribe(_imageWithin[target], target.OnNewInput);
            //Dispose of the Image being referenced:
            _imageData.RemoveItem(_imageWithin[target]);
            //Dispose of the image within the pictureBox and the pictureBox itself:
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
                _createDisplayView(_imageWithin[chosenPictureBox]);
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
