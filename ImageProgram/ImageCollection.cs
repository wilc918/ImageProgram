using System;
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

        // DECLARE an IModel to access ImageData, call it _ModelData:
        private IImageData _imageData;

        //DECLARE an int to store the value for the next imageKey, call it _imageKey, set to 0:
        int _imageKey = 0;

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
        }

        private void ImageCollection_Load(object sender, EventArgs e)
        {
    

            PictureDisplay.Image = Image.FromFile("..\\..\\FishAssets\\Urchin.png");
        }

        private void ImageCollection_AddImage(object sender, EventArgs e)
        {
            //Code to launch second form
            Form newForm = new ImageSelection();
            newForm.Show();
        }

        private void ImageCollection_Next(object sender, EventArgs e) 
        {
            //Code to increment
            _imageKey++;
            System.Diagnostics.Debug.WriteLine("This is a log");
        }

        private void ImageCollection_Previous(object sender, EventArgs e) 
        {
            //Code to decrement
            _imageKey--;
        }
    }
}
