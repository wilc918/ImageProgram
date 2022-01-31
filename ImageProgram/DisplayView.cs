using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProgram
{
    /// <summary>
    /// Class to represent the functionality of a displayView
    /// (Calum Wilkinson)
    /// (28/04/2021)
    /// </summary>
    public partial class DisplayView : Form
    {

        // Declare an Image to store image in, call it _image:
        private Image _image;

        /// <summary>
        /// Constructor
        /// </summary>
        public DisplayView(Image currentImage)
        {
            InitializeComponent();
            Debug.WriteLine("DisplayView Launched!");

            //SET image to image to be edited:
            _image = currentImage;

            //Set the displayViewImage to show the image we are editing:
            //Creating a clone of the image so we can make changes without consequence.
            DisplayViewImage.Image = (Image)_image.Clone();



            this.Show();
            DisplayViewImage.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void DisplayReturn(object sender, EventArgs e)
        {
            //Dispose of the image before closing the form
            //DisplayViewImage.Image.Dispose();
            this.Close();
        }

        private void ImageRotateRight(object sender, EventArgs e) 
        {
            DisplayViewImage.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            DisplayViewImage.Refresh();
        }
        private void ImageRotateLeft(object sender, EventArgs e)
        {
            DisplayViewImage.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            DisplayViewImage.Refresh();
        }

        private void ImageFlip(object sender, EventArgs e)
        {
            // Thumbnail does not update, image contained within however is updated despite the cancel button being clicked.
            // I should make the display view create a new instance rather than use a direct reference to the original
            // The save button will then apply this clone to the original image which can be seen in the thumbnail.
            DisplayViewImage.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            DisplayViewImage.Refresh();
        }

        private void ImageScale(object sender, EventArgs e)
        {
            //DisplayViewImage.Image. = 200;
        }

        private void DisplayView_FormClosed(object sender, FormClosedEventArgs e)
        {
            //DisplayReturn(sender, e);
        }
    }
}
