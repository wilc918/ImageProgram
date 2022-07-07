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
    /// Author (Calum Wilkinson)
    /// Version (07/07/2022)
    /// </summary>
    public partial class ImageCollection : Form
    {
        // DECLARE a Dictionary<PictureBox, string> to store imagePaths in, call it _images:
        private IDictionary<PictureBox, string> _imageWithin;

        // DECLARE a factory<DisplayView> to store factory in, call it _displayViewFactory:
        private IFactory<DisplayView> _displayViewFactory;

        // DECLARE an CollectionPictureBoxFactory for storing a CollectionPictureBoxFactory:
        private CollectionPictureBoxFactory _cPictureBoxFactory;

        //DECLARE a CreateDisplayViewDelegate for creating DisplayViews, call it _createDisplayView:
        private CreateDisplayViewDelegate _createDisplayView;

        //DECLARE an AddImageToCollectionDelegate for adding Images to this form, call it _addImageToCollection;
        private AddImageToCollectionDelegate _addImageToCollection;

        //DECLARE a RemoveImageFromCollectionDelegate for removing Images from this form, call it _removeImageFromCollection;
        private RemoveImageFromCollectionDelegate _removeImageFromCollection;


        /// <summary>
        /// CONSTRUCTOR - ImageCollection Form Object Constructor
        /// </summary>
        /// <param name="ImageData">Data about images</param>
        public ImageCollection(IDictionary<PictureBox, string> fileNameByPictBox,IPictureBoxFactory pictureBoxFactory, IFactory<DisplayView> displayViewFactory, CreateDisplayViewDelegate createDisplayView, AddImageToCollectionDelegate addImageCollection, RemoveImageFromCollectionDelegate removeImageFromCollection)
        {
            InitializeComponent();
            
            //Instantiate _cPictureBoxFactory, casting pictureBoxFactory as CollectionPictureBoxFactory:
            _cPictureBoxFactory = pictureBoxFactory as CollectionPictureBoxFactory;

            //Initialise the factory with all the eventHandlers, a contextMenu and the flowLayoutPanel I want the products to be added to:
            _cPictureBoxFactory.IntialiseFactory(new EventHandler(PresentPictureBox_Click), contextMenuStrip1, new EventHandler(AddDisplayView_DoubleClick), collectionflowLayoutPanel);

            //Instantiate _imageWithin:
            _imageWithin = fileNameByPictBox;

            //Instantiate _displayViewFactory:
            _displayViewFactory = displayViewFactory;

            //Instantiate _createDisplayView:
            _createDisplayView = createDisplayView;

            //Instantiate _addImageToCollection:
            _addImageToCollection = addImageCollection;

            //Instantiate _removeImageFromCollection:
            _removeImageFromCollection = removeImageFromCollection;
        }

        #region Private Methods

        /// <summary>
        /// Adds images to the collection, only one at a time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddImagesButtonClick(object sender, EventArgs e)
        {
            //Adds Images to collection:
            _addImageToCollection(_cPictureBoxFactory, _imageWithin);
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
                ///THIS CODE WAS TAKEN FROM https://stackoverflow.com/users/11343813/dan ///
                ///Link to Webpage : https://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on ///
                //Retrieve PictureBox from the selectedMenuItem using multiple casts to call getter methods to retrieve parent for each child.
                CollectionPictureBox entryToBeRemoved = ((ContextMenuStrip)((ToolStripItem)sender).Owner).SourceControl as CollectionPictureBox;
                ///END OF CODE///
                //Dispose of the entry:
                _removeImageFromCollection(entryToBeRemoved, _imageWithin);
            }
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
                //Create a DisplayView for the Image inside the selected pictureBox:
                _createDisplayView(_imageWithin[chosenPictureBox]);
            }

        }
        #endregion
    }
}
