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

        //DECLARE a List<String> to contain the names of the images in the gallery, call it galleryImagesNames
        private IList<String> _galleryImageNames;

        //private FlowLayoutPanel collectionflowLayoutPanel;

        //DECLARE a Dictionary<int, DataElement> to store images in, call it _images:
        private IDictionary<int, PictureBox> _pictureBoxes;
        private IDictionary<string, PictureBox> _pictureBoxes2;
        private IDictionary<PictureBox, string> _pictureBoxes3;

        //DECLARE a Dictionary<string, PictureBox> to store associate images with their picturebox

        private IImageManipulator _imageManipulator;

        // DECLARE an int to act as a circular counter index into _images:
        private int _cCounter = 0;

        //Declare an IPictureBoxFactory for storing a PictureBoxFactory
        private IPictureBoxFactory _pictureBoxFactory;

        //DECLARE an IDictionary to store displayViews in, call it _displayViews:
        private IDictionary<int, DisplayView> _displayViews;

        //DECLARE an int to store the value for the next displayView, call it _displayKey, set to 0:
        private int _displayKey = 0;

        /// <summary>
        /// CONSTRUCTOR - ImageCollection Form Object Constructor
        /// </summary>
        /// <param name="ImageData">Data about images</param>
        public ImageCollection(IImageData ImageData, IDictionary<int, Image> imageContainer, IDictionary<int, PictureBox> pictureBoxContainer, IImageManipulator imageManip, IPictureBoxFactory pictureBoxFactory)
        {
            InitializeComponent();

            //Instantiate _imageData, casting ImageData as the type IImageData:
            _imageData = ImageData as IImageData;

            //Instantiate _ModelData, casting ImageData as the type IModel:
            _ModelData = ImageData as IModel;

            _pictureBoxFactory = pictureBoxFactory;

            _pictureBoxes = pictureBoxContainer;

            _pictureBoxes2 = new Dictionary<string, PictureBox>();

            _pictureBoxes3 = new Dictionary<PictureBox, string>();

            _imageManipulator = imageManip;

            _galleryImageNames = new List<string>();

            _displayViews = new Dictionary<int, DisplayView>();
            
            //Adding FlowLayoutPanel
            collectionflowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            collectionflowLayoutPanel.Name = "CollectionLayout";
            ImageCollectPanel.Controls.Add(collectionflowLayoutPanel);
            collectionflowLayoutPanel.Location = new Point(12, 12);
            collectionflowLayoutPanel.Size = new Size(475, 375);
            collectionflowLayoutPanel.WrapContents = true;
            collectionflowLayoutPanel.SendToBack();
            ImageCollectPanel.SendToBack();
            collectionflowLayoutPanel.AutoScroll = true;
            collectionflowLayoutPanel.AutoSize = true;
            collectionflowLayoutPanel.Dock = DockStyle.Fill;
            ImageCollectPanel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            collectionflowLayoutPanel.VerticalScroll.Visible = false;
            collectionflowLayoutPanel.HorizontalScroll.Visible = false;

            collectionflowLayoutPanel.BorderStyle = BorderStyle.FixedSingle;
            Debug.WriteLine("Margin: "+ collectionflowLayoutPanel.AutoScrollMargin);
        }

        #region Private Methods



            /// <summary>
            /// Loads an image according path associated with the _imageKey
            /// </summary>
            private void ImageLoad() 
        {

            //retrieveImageList
            //_galleryImageNames = _imageData.GetCollectionList();
            
            if (_galleryImageNames != null) 
            {
                //Code to retrieve image name using imagekey.
               // PictureDisplay9.Image = _ModelData.getImage(_galleryImageNames[_imageKey], PictureDisplay9.Width, PictureDisplay9.Height);
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

            galleryFile.Multiselect = true;
            // This filter ensures that only .jpgs and .pngs are allowed
            galleryFile.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif;";
            galleryFile.Title = "Add image to gallery";

            //If the user presses OK on the file explorer
            if (galleryFile.ShowDialog() == DialogResult.OK) 
            {
                //Convert the chosen array of strings into a list:
                List<String> imagePaths = galleryFile.FileNames.ToList();

                //Load the filepaths into into _ModelData and recieve the file names:
                _galleryImageNames = _ModelData.load(imagePaths);
                
                //For each image in the gallery, a collectionPictureBox is produced and an image fit for it is retrieved.
                foreach (string file in _galleryImageNames) 
                {
                    
                    collectionPictureBox pictureBox = (collectionPictureBox)_pictureBoxFactory.MakePictureBox();
                    pictureBox.Image = _ModelData.getImage(file, pictureBox.Width,pictureBox.Height);
                    Debug.WriteLine("Image Filename: "+file);

                    pictureBox.setClick(new EventHandler(ImageClick));
                    pictureBox.setContextMenu(contextMenuStrip1);
                    pictureBox.setDoubleClick(new EventHandler(ImageDoubleClick));
                    pictureBox.Tag = file;
                    pictureBox.AccessibleName = file;

                    _pictureBoxes.Add(_pictureBoxes.Count, pictureBox);
                    _pictureBoxes2.Add(file, pictureBox);
                    _pictureBoxes3.Add(pictureBox, file);
                    collectionflowLayoutPanel.Controls.Add(pictureBox);
                }
                RefreshImages();

            }
        }

        private void RemoveImagesButtonsClick(object sender, EventArgs e) 
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            Debug.WriteLine(sender);
            //MessageBox.Show("File menu item clicked"+pbMenu.SourceControl.Tag);
            ;
            if (menuItem != null && MessageBox.Show("Delete this image?", "Delete Image", MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                ContextMenuStrip pbMenu = menuItem.Owner as ContextMenuStrip;
                PictureBox pbDelete = pbMenu.SourceControl as PictureBox;
                _imageData.RemoveItem(pbDelete.Tag.ToString());
                pbDelete.Image.Dispose();
                pbDelete.Dispose();
                RefreshImages();
            }
        }

        /// <summary>
        /// Method - Changes pictureBoxes background color back to default.
        /// </summary>
        private void RefreshImages() {
            //For each entry in _pictureBoxes, change the PictureBox's colour to the default color.
            foreach (KeyValuePair<PictureBox,string> entry in _pictureBoxes3)
            {
                entry.Key.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void ImageClick(object sender, EventArgs e) {

            PictureBox chosenImage = (PictureBox)sender;
            RefreshImages();
            chosenImage.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder);
            Debug.WriteLine("This Picture Box Key is: " + chosenImage.Tag);
            //Debug.WriteLine("Image filepath: " + _galleryImageNames[(int)chosenImage.Tag]); Commented out because _galleryImageNames isn't used in this manner anymore.

        }

        private void ImageDoubleClick(object sender, EventArgs e) {

            //Cast selected image as PictureBox so that I have access to the methods of PictureBox, call it chosenImage:
            PictureBox chosenImage = (PictureBox)sender;
            Debug.WriteLine("ImageLocation is: " + chosenImage.ImageLocation);

            Debug.WriteLine("Image clicked is: " + chosenImage.BackColor);
            if (chosenImage.Image != null)
            {
                Debug.WriteLine("Image clicked is: " + chosenImage.Image);
                Debug.WriteLine("PictureBox.Tag is: " + chosenImage.Tag);
                
                DisplayView displayView = new DisplayView();
                displayView.Initialise(_pictureBoxes3[chosenImage],_ModelData.getImage, chosenImage.Tag.ToString(), _imageManipulator);

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
