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
    /// 
    /// (Calum Wilkinson)
    /// (07/07/2022)
    /// </summary>
    public partial class DisplayView : Form, IEventListener, IDisplayView
    {
        // DECLARE a string to store fileName in
        private string _fileName;

        // DECLARE an ExecuteCommandDelegate to store the delegate used for executing commands:
        private ExecuteCommandDelegate _execute;

        // DECLARE an Action<int> for rotateImage, call it _rotateImageAction:
        private Action<int> _rotateImageAction;

        // DECLARE an Action<Size> for retrievingImage, call it _retrieveImageAction:
        private Action<Size> _retrieveImageAction;

        // DECLARE an Action<bool> for flippingImage, call it _flipImageAction:
        private Action<bool> _flipImageAction;

        // DECLARE an Action<string> for savingImage, call it _saveImageAction:
        private Action<string> _saveImageAction;

        public DisplayView()
        {
            InitializeComponent();
            Debug.WriteLine("DisplayView Launched!");
            RemoveNumericArrows();
            this.Show();
        }

        /// <summary>
        ///  METHOD - For instantiating variables required for the class to function.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="execute"></param>
        /// <param name="retrieveImage"></param>
        /// <param name="rotateImageAction"></param>
        /// <param name="flipImageAction"></param>
        /// <param name="saveImageAction">Action that saves the Image</param>
        public void Initialise(string fileName, ExecuteCommandDelegate execute, Action<Size> retrieveImage ,Action<int> rotateImageAction,  Action<bool> flipImageAction, Action<string> saveImageAction)
        {
            //SET _fileName:
            _fileName = fileName;

            //SET _execute to the ExecuteCommandDelegate:
            _execute = execute;
            //SET _retrieveImageAction:
            _retrieveImageAction = retrieveImage;
            //SET _rotateImageAction:
            _rotateImageAction = rotateImageAction;
            //SET _flipImageAction:
            _flipImageAction = flipImageAction;
            //SET _saveImageAction:
            _saveImageAction = saveImageAction;


            //Create a retrieveImage command according to the display dimensions:
            ICommand summonImage = new Command<Size>(_retrieveImageAction, new Size(this.DisplayViewImage.Width, this.DisplayViewImage.Height));

            //Execute the command:
            _execute(summonImage);

        }

        #region ImageTransformationMethods
        /// <summary>
        /// METHOD - For rotating image clockwise 90 degrees.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageRotateRight(object sender, EventArgs e) 
        {
            //Instatiate a new rotateImage command:
            ICommand rotateRight = new Command<int>(_rotateImageAction, 90);

            //Execute the command:
            _execute(rotateRight);
        }
        /// <summary>
        /// Method - For rotating image anti-clockwise 90 degrees.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageRotateLeft(object sender, EventArgs e)
        {
            //Instatiate a new rotateImage command:
            ICommand rotateLeft = new Command<int>(_rotateImageAction, -90);

            //Execute the command:
            _execute(rotateLeft);
        }
        /// <summary>
        /// Method - Flips image along the vertical axis.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageFlip(object sender, EventArgs e)
        {
            //Instantiate a new flipImage command:
            ICommand flip = new Command<bool>(_flipImageAction, false);

            //Execute the command:
            _execute(flip);
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
                //TryCatch block in case user enters 0:
                try
                {
                    // Retrieve apply scaling to the dimensions of the image, round to an int for Size object:
                    int newWidth = (int)Math.Round(DisplayViewImage.Width * scaleAmount);
                    int newHeight = (int)Math.Round(DisplayViewImage.Height * scaleAmount);

                    // Instantiate a new retrieveImage command:
                    ICommand scaleImage = new Command<Size>(_retrieveImageAction,new Size(newWidth, newHeight));

                    //Execute the command:
                    _execute(scaleImage);
                }
                catch (Exception ex)
                {
                    // Write exception in debug:
                    Debug.WriteLine(ex.Message);

                    // Produce MessageBox to inform the user:
                    MessageBox.Show("Please do not enter 0!");
                }
            }
            else 
            {
                // Produce MessageBox to warn user:
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
                ICommand resizeImage = new Command<Size>(_retrieveImageAction, new Size((int)WidthNumeric.Value, (int)HeightNumeric.Value));
                _execute(resizeImage);
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
            //Create new SaveFileDialog which enables the user to choose where to save their image.
            SaveFileDialog dlg = new SaveFileDialog
            {
                Filter = "JPEG (*.jpg;)|*.jpg|PNG (*.png)|*.png|GIF (*.gif)|*.gif",
                Title = "Save an Image file"
            };

            //When the user decides to save, check that a filename has been chosen and use _imageManipulator to save image at desination.
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.FileName != "") 
                {
                    ICommand saveImage = new Command<string>(_saveImageAction, dlg.FileName);
                    _execute(saveImage);
                }
            }
        }
        #endregion

        #region personalMethods
        /// <summary>
        /// Method to remove arrows from numericUpDown controls
        /// </summary>
        private void RemoveNumericArrows()
        {
            //Sets the visiblity of the NumericArrows to false:
            ///THIS CODE WAS TAKEN FROM https://stackoverflow.com/users/3750325/user3750325 ///
            /// Link to WebPage : https://stackoverflow.com/questions/29450844/how-to-hide-arrows-on-numericupdown-control-in-win-forms ///
            HeightNumeric.Controls[0].Visible = false;
            WidthNumeric.Controls[0].Visible = false;
            ///END OF CODE///
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
        public void OnNewInput(object sender, ImageEventArgs args)
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
