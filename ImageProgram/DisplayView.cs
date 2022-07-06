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
    public partial class DisplayView : Form, IEventListener
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

        // Declare an ExecuteCommandDelegate to store the delegate used for executing commands:
        private ExecuteCommandDelegate _execute;

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




            DisplayViewImage.SizeMode = PictureBoxSizeMode.Zoom;
            Debug.WriteLine("HeightNumeric Value: "+HeightNumeric.Value);
            //HeightNumeric.Controls[0].Visible = false;
            this.Show();
        }

        public DisplayView()
        {
            InitializeComponent();
            Debug.WriteLine("DisplayView Launched!");
            removeNumericArrows();
            this.Show();
        }

        //public void Initialise(string fileName, RetrieveImageDelegate retrieveImage, IImageManipulator imageManip)
        //{
        //    //Set _fileName to the fileName of the image being loaded
        //    _fileName = fileName;
        //    Debug.WriteLine("This Display View is displaying: " + fileName);
        //    //SET _getImagePath to retrieveImage
        //    _getImage += retrieveImage;
        //    //INSERT image retrieved from imagePath
        //    _image = _getImage(fileName, DisplayViewImage.Width, DisplayViewImage.Height);
        //    //Set Numeric Values to the images equivelant for user reference.
        //    HeightNumeric.Value = _image.Height;
        //    WidthNumeric.Value = _image.Width;
        //    //Display Image on the DisplayViewImage PictureBox
        //    this.DisplayViewImage.Image = _image;

        //    //SET _imageManipulator to the imageManipulator we are going to use:
        //    _imageManipulator = imageManip;
        //}

        public void Initialise(string fileName, RetrieveImageDelegate retrieveImage, IImageManipulator imageManip)
        {
            _fileName = fileName;

            //SET image:
            retrieveImage(_fileName, this.DisplayViewImage.Width, this.DisplayViewImage.Height);

            //SET _imageManipulator to the imageManipulator we are going to use:
            _imageManipulator = imageManip;
        }

        //public void Initialise(string fileName, ExecuteCommandDelegate execute, Action retrieveImage, IImageManipulator imageManip)
        //{
        //    _fileName = fileName;
        //    _execute = execute;

        //    ICommand getImage = new Command(retrieveImage);
        //    _execute(getImage);

        //    //SET _imageManipulator to the imageManipulator we are going to use:
        //    _imageManipulator = imageManip;
        //}



        #region ImageTransformationMethods
        /// <summary>
        /// Method - For rotating image clockwise 90 degrees.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageRotateRight(object sender, EventArgs e) 
        {
            DisplayViewImage.Image = _imageManipulator.Rotate(DisplayViewImage.Image, 90);
            DisplayViewImage.Refresh();
        }
        /// <summary>
        /// Method - For rotating image anti-clockwise 90 degrees.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageRotateLeft(object sender, EventArgs e)
        {
            DisplayViewImage.Image = _imageManipulator.Rotate(DisplayViewImage.Image, -90);
            DisplayViewImage.Refresh();
        }
        /// <summary>
        /// Method - Flips image along the vertical axis.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageFlip(object sender, EventArgs e)
        {
            DisplayViewImage.Image = _imageManipulator.Flip(DisplayViewImage.Image, false);
            DisplayViewImage.Refresh();
        }
        /// <summary>
        /// Method - Scales image according to amount inputed into PercentageNumeric
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageScale(object sender, EventArgs e)
        {
            //For the scaleAmount the value is divided by 100 to get the percentage and cast to a double as numerics provide decimals too
            double scaleAmount = ((double)PercentageNumeric.Value / 100);
            // Check that scale amount is more than 0.001 because while Resize doesn't allow 0 it does allow negative numbers and that isn't desired.
            if (scaleAmount > 0.001)
            {
                Debug.WriteLine("ScaleAmount: " + scaleAmount + "/n ImageWidth: " + (DisplayViewImage.Image.Width * scaleAmount) + "/n ImageHeight: " + (DisplayViewImage.Image.Height * scaleAmount));
                try
                {
                    int newWidth = (int)Math.Round((double)DisplayViewImage.Width * scaleAmount);
                    int newHeight = (int)Math.Round((double)DisplayViewImage.Height * scaleAmount);
                    DisplayViewImage.Image = _imageManipulator.Resize(DisplayViewImage.Image, new Size(newWidth, newHeight));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    MessageBox.Show("Please do not enter 0!");
                }
            }
            else 
            {
                MessageBox.Show("PLease do not enter a number less or equal to 0!");
            }

        }
        /// <summary>
        /// Method - Resizes image according to values inputed to Numeric controls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageResize(object sender, EventArgs e)
        {
            try
            {
                DisplayViewImage.Image = _imageManipulator.Resize(DisplayViewImage.Image, new Size((int)WidthNumeric.Value, (int)HeightNumeric.Value));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: "+ex);
            }
        }
        /// <summary>
        /// Method for saving image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageSave(object sender, EventArgs e) 
        {
            Debug.WriteLine("Image filepath: "+DisplayViewImage.ImageLocation);
            //Create new SaveFileDialog which enables the user to choose where to save their image.
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "JPEG (*.jpg;)|*.jpg|PNG (*.png)|*.png|GIF (*.gif)|*.gif";
            dlg.Title = "Save an Image file";
            //When the user decides to save, check that a filename has been chosen and use _imageManipulator to save image at desination.
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.FileName != "") 
                {
                    _imageManipulator.SaveFile(DisplayViewImage.Image, dlg.FileName);
                }

                Debug.WriteLine("Save filepath: " + dlg.FileName);
            }
        }
        #endregion
        #region personalMethods
        /// <summary>
        /// Method to remove ugly arrows from numericUpDown controls
        /// </summary>
        private void removeNumericArrows()
        {
            HeightNumeric.Controls[0].Visible = false;
            WidthNumeric.Controls[0].Visible = false;
        }

        /// <summary>
        /// Method for closing this displayView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayReturn(object sender, EventArgs e)
        {
            //CODE THAT unsubscribes the displayView HERE
            this.Close();
        }

        #endregion

        #region Implementation of IEventListener
        /// <summary>
        /// Method - Updates DisplayViewImage in response to new inputs.
        /// </summary>
        /// <param name="sender">The DataElement sending the new input</param>
        /// <param name="args">The new input</param>
        public void OnNewInput(object sender, DisplayEventArgs args)
        {
            if (args.image != null)
            {
                this.DisplayViewImage.Image = args.image;
                HeightNumeric.Value = this.DisplayViewImage.Image.Height;
                WidthNumeric.Value = this.DisplayViewImage.Image.Width;
            }
        }

        #endregion
    }
}
