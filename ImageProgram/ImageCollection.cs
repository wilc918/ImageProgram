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
       // private Form _imageSelectForm;

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

        //private FlowLayoutPanel collectionflowLayoutPanel;

        //DECLARE a Dictionary<int, DataElement> to store images in, call it _images:
        private IDictionary<int, PictureBox> _pictureBoxes;

        private IImageManipulator _imageManipulator;

        // DECLARE an int to act as a circular counter index into _images:
        private int _cCounter = 0;

        //Declare an IPictureBoxFactory for storing a PictureBoxFactory
        private IPictureBoxFactory _pictureBoxFactory;

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

            //Instantiate images Dictionary
            _images = imageContainer;

            _pictureBoxFactory = pictureBoxFactory;

            _pictureBoxes = pictureBoxContainer;

            //_pictureBoxes = new Dictionary<int, PictureBox>();

            _imageManipulator = imageManip;

            _galleryImageNames = new List<string>();

            
            //Adding FlowLayoutPanel
           // collectionflowLayoutPanel = new FlowLayoutPanel();
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
                //collectionflowLayoutPanel.Controls[1].Visible = false;
                //int visibleBtns = collectionflowLayoutPanel.Controls.Count;
                //Debug.WriteLine("visibleButtons = " + visibleBtns);
            }

        }

            

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
                List<String> imageNames = galleryFile.FileNames.ToList();

                _galleryImageNames = _ModelData.load(imageNames);
                
                foreach (string file in _galleryImageNames) 
                {
                    collectionPictureBox pictureBox = (collectionPictureBox)_pictureBoxFactory.MakePictureBox();
                    pictureBox.Image = _ModelData.getImage(file, pictureBox.Width,pictureBox.Height);

                    pictureBox.setClick(new EventHandler(ImageClick));
                    pictureBox.setContextMenu(contextMenuStrip1);
                    pictureBox.setDoubleClick(new EventHandler(ImageDoubleClick));
                    pictureBox.Tag = _pictureBoxes.Count;

                    _pictureBoxes.Add(_pictureBoxes.Count, pictureBox);
                    collectionflowLayoutPanel.Controls.Add(pictureBox);
                }


                
                /*
                foreach (String file in galleryFile.FileNames)
                {
                    try
                    {
                        String fileString = file;
                        _galleryImageNames.Add(fileString);
                        Debug.WriteLine("Image filepath: " + fileString);
                        //_images.Add(_images.Count, Image.FromFile(file));
                        collectionPictureBox pictureBox = (collectionPictureBox)_pictureBoxFactory.MakePictureBox();
                        _ModelData.load(_galleryImageNames);
                        //PictureBox pictureBox = new PictureBox();
                        pictureBox.Tag = _pictureBoxes.Count;
                        //pictureBox.Size = new Size(150, 111);
                        pictureBox.setClick(new EventHandler(ImageClick));
                        pictureBox.ContextMenuStrip = contextMenuStrip1;
                        //pictureBox.Click += new EventHandler(ImageClick);
                        pictureBox.DoubleClick += new EventHandler(ImageDoubleClick);
                       // pictureBox.Image = _ModelData.getImage(_ModelData);
                        pictureBox.Image = Image.FromFile(_galleryImageNames[_galleryImageNames.Count-1]);
                        //pictureBox.Image = _images[_images.Count-1];

                        _pictureBoxes.Add(_pictureBoxes.Count, pictureBox);
                        collectionflowLayoutPanel.Controls.Add(pictureBox);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Key not found"+ex);
                    }
                }*/
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
                pbDelete.Image.Dispose();
                pbDelete.Dispose();
                RefreshImages();
            }
        }

        /// <summary>
        /// Method - Retrieve images from image list and inserts them into their associated picturebox.
        /// </summary>
        private void RefreshImages() {

            Debug.WriteLine("Imagecount is" + _images.Count);
            for (int j = 0; j < _pictureBoxes.Count; j++) {
                _pictureBoxes[j].BackColor = Color.FromKnownColor(KnownColor.Control);
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


            Debug.WriteLine("Image clicked is: " + chosenImage.BackColor);
            if (chosenImage.Image != null)
            {
                Debug.WriteLine("Image clicked is: " + chosenImage.Image);
                DisplayView displayImage = new DisplayView(chosenImage.Image, _imageManipulator);
              
                
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

        private void PictureDisplay1_MouseDown(object sender, MouseEventArgs e)
        {
            ImageClick(sender, e);
        }
    }
}
