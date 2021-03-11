﻿using System;
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
        private List<String> _galleryImageNames;

        /// <summary>
        /// CONSTRUCTOR - ImageCollection Form Object Constructor
        /// </summary>
        /// <param name="ImageData">Data about images</param>
        public ImageCollection(IImageData ImageData)
        {
            InitializeComponent();

            //Instantiate _imageData, casting ImageData as the type IImageData:
            _imageData = ImageData as IImageData;

            //Instantiate _ModelData, casting ImageData as the type IModel:
            _ModelData = ImageData as IModel;

            //_galleryImageNames = new List<string>();
            //_galleryImageNames.Add("..\\..\\FishAssets\\Urchin.png");
            //_ModelData.load(_galleryImageNames);
        }

        private void ImageCollection_Load(object sender, EventArgs e)
        {
            //PictureDisplay.Image = Image.FromFile("..\\..\\FishAssets\\Urchin.png");

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
            //Code to increment
            _imageKey++;
            //Code to retrieve image name using imagekey.
            PictureDisplay.Image = _ModelData.getImage("Urchin.png", PictureDisplay.Width, PictureDisplay.Height);
        }

        /// <summary>
        /// Method - Retrieve and display the previous image from the collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageCollection_Previous(object sender, EventArgs e) 
        {
            //Code to decrement
            _imageKey--;
            //
            System.Diagnostics.Debug.WriteLine("List item : " + );
            //Code to retrieve image name using imagekey.
            PictureDisplay.Image = _ModelData.getImage("Urchin.png", PictureDisplay.Width, PictureDisplay.Height);
        }

        private void ImageCollection_Display() {
            // Code to display image using image name
        }
    }
}
