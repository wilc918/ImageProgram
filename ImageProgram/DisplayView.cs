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
            DisplayViewImage.Image = _image;

            this.Show();
            DisplayViewImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void DisplayReturn(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImageRotateRight(object sender, EventArgs e) 
        {
            DisplayViewImage.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
        }
        private void ImageRotateLeft(object sender, EventArgs e)
        {
            DisplayViewImage.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
        }

        private void ImageFlip(object sender, EventArgs e)
        {
            DisplayViewImage.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
        }

        private void ImageScale(object sender, EventArgs e)
        {
            //DisplayViewImage.Image. = 200;
        }
    }
}
