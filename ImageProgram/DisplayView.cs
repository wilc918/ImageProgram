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
        // Declare an int _id, stores the ID given to this view:
        private int _id = 0;
        // Declare an Image to store image in, call it _image:
        private Image _image;
        // Declare a string to store fileName in
        private string _fileName;
        // Declare an IImageManipulator to store the ImageManipulator class, call it _imageManipulator
        private IImageManipulator _imageManipulator;
        // Declare a RetrieveImageDelegate for the delegate to be called to retrieve Image, call it _getImage
        private RetrieveImageDelegate _getImage;


        /// <summary>
        /// Constructor
        /// </summary>
        public DisplayView(Image currentImage, IImageManipulator imageManip)
        {
            InitializeComponent();
            Debug.WriteLine("DisplayView Launched!");

            //SET image to image to be edited:
            _image = currentImage;
            //SET _imageManipulator to the imageManipulator we are going to use:
            _imageManipulator = imageManip;

            //Set the displayViewImage to show the image we are editing:
            //Creating a clone of the image so we can make changes without consequence.
            DisplayViewImage.Image = (Image)_image.Clone();



            this.Show();
            DisplayViewImage.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public DisplayView()
        {
            InitializeComponent();
            Debug.WriteLine("DisplayView Launched!");
            this.Show();
        }

        public void Initialise(string fileName, RetrieveImageDelegate retrieveImage, string imageName, IImageManipulator imageManip)
        {
            _fileName = fileName;
            Debug.WriteLine("This Display View is displaying: " + fileName);
            //SET _getImagePath to retrieveImage
            _getImage += retrieveImage;
            //INSERT image retrieved from imagePath
            _image = _getImage(imageName, DisplayViewImage.Width, DisplayViewImage.Height);
            this.DisplayViewImage.Image = _image;

            //SET _imageManipulator to the imageManipulator we are going to use:
            _imageManipulator = imageManip;
        }

        public void Intialise(Image image, IImageManipulator imageManip)
        {
            //INSERT image retrieved from imagePath
            this.DisplayViewImage.Image = _image;

            //SET _imageManipulator to the imageManipulator we are going to use:
            _imageManipulator = imageManip;
        }

        private void DisplayReturn(object sender, EventArgs e)
        {
            //Dispose of the image before closing the form
            //DisplayViewImage.Image.Dispose();
            this.Close();
        }

        private void ImageRotateRight(object sender, EventArgs e) 
        {
            //DisplayViewImage.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            DisplayViewImage.Image = _imageManipulator.Rotate(DisplayViewImage.Image, 90);
            DisplayViewImage.Refresh();
        }
        private void ImageRotateLeft(object sender, EventArgs e)
        {
            //DisplayViewImage.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            DisplayViewImage.Image = _imageManipulator.Rotate(DisplayViewImage.Image, -90);
            DisplayViewImage.Refresh();
        }

        private void ImageFlip(object sender, EventArgs e)
        {
            // Thumbnail does not update, image contained within however is updated despite the cancel button being clicked.
            // I should make the display view create a new instance rather than use a direct reference to the original
            // The save button will then apply this clone to the original image which can be seen in the thumbnail.
            //DisplayViewImage.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            DisplayViewImage.Image = _imageManipulator.Flip(DisplayViewImage.Image, false);
            DisplayViewImage.Refresh();
        }

        private void ImageScale(object sender, EventArgs e)
        {
            //double scaleAmount = Int32.Parse(ScaleInput.Text);
            double scaleAmount = ((double)numericUpDown1.Value/100);
            Debug.WriteLine("ScaleAmount: " + scaleAmount + "/n ImageWidth: " + (DisplayViewImage.Image.Width*scaleAmount) + "/n ImageHeight: " + (DisplayViewImage.Image.Height*scaleAmount));
            try
            {
                int newWidth = (int)Math.Round((double) DisplayViewImage.Width*scaleAmount);
                int newHeight = (int)Math.Round((double) DisplayViewImage.Height*scaleAmount);
                DisplayViewImage.Image = _imageManipulator.Resize(DisplayViewImage.Image, new Size(newWidth, newHeight));
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("PLease do not enter a number below 0!");
            }
            
        }

        private void ImageSave(object sender, EventArgs e) 
        {
            Debug.WriteLine("Image filepath: "+DisplayViewImage.ImageLocation);
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "JPEG (*.jpg;)|*.jpg|PNG (*.png)|*.png|GIF (*.gif)|*.gif";
            dlg.Title = "Save an Image file";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.FileName != "") 
                {
                    _imageManipulator.SaveFile(DisplayViewImage.Image, dlg.FileName);
                }

                Debug.WriteLine("Save filepath: " + dlg.FileName);
            }
        }
    }
}
