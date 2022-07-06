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
        // DECLARE an int _id, stores the ID given to this view:
        private int _id = 0;
        // DECLARE an Image to store image in, call it _image:
        private Image _image;
        // DECLARE a string to store fileName in
        private string _fileName;

        // DECLARE an IImageManipulator to store the ImageManipulator class, call it _imageManipulator
        private IImageManipulator _imageManipulator;

        // DECLARE an ExecuteCommandDelegate to store the delegate used for executing commands:
        private ExecuteCommandDelegate _execute;

        //DECLARE an RetrieveImageDelegate to store the delegate used for retrieving images:
        private RetrieveImageDelegate _retrieveImage;

        // DECLARE an RotateImageDelegate to call Rotation on the image:
        private RotateImageDelegate _rotateImage;

        //DECLARE a FlipImageDelegate to call Flip on the image:
        private FlipImageDelegate _flipImage;

        //DECLARE a SaveImageDelegate to call Save on the image:
        private SaveImageDelegate _saveImage;

        public DisplayView()
        {
            InitializeComponent();
            Debug.WriteLine("DisplayView Launched!");
            removeNumericArrows();
            this.Show();
        }

        public void Initialise(string fileName, RetrieveImageDelegate retrieveImage, RotateImageDelegate rotateImage, FlipImageDelegate flipImage, SaveImageDelegate saveImage)
        {
            _fileName = fileName;

            _retrieveImage = retrieveImage;

            //SET image:
            //Retrieve image according to the display size:
            retrieveImage(_fileName, this.DisplayViewImage.Width, this.DisplayViewImage.Height);
            //SET _rotateImage to the RotateImageDelegate:
            _rotateImage = rotateImage;
            //SET _flipImage to the FlipImageDelegate:
            _flipImage = flipImage;
            //SET _saveImage to the SaveImageDelegate:
            _saveImage = saveImage;
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
            _rotateImage(_fileName, 90);
            DisplayViewImage.Refresh();
        }
        /// <summary>
        /// Method - For rotating image anti-clockwise 90 degrees.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageRotateLeft(object sender, EventArgs e)
        {
            _rotateImage(_fileName, -90);
            DisplayViewImage.Refresh();
        }
        /// <summary>
        /// Method - Flips image along the vertical axis.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageFlip(object sender, EventArgs e)
        {
            _flipImage(_fileName, false);
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
                    _retrieveImage(_fileName, newWidth, newHeight);
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
                _retrieveImage(_fileName, (int)WidthNumeric.Value, (int)HeightNumeric.Value);
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
            //Debug.WriteLine("Image filepath: "+DisplayViewImage.ImageLocation);
            //Create new SaveFileDialog which enables the user to choose where to save their image.
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "JPEG (*.jpg;)|*.jpg|PNG (*.png)|*.png|GIF (*.gif)|*.gif";
            dlg.Title = "Save an Image file";
            //When the user decides to save, check that a filename has been chosen and use _imageManipulator to save image at desination.
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.FileName != "") 
                {
                    _saveImage(_fileName, dlg.FileName);
                    //_imageManipulator.SaveFile(DisplayViewImage.Image, dlg.FileName);
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
