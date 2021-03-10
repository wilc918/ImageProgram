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
    public partial class ImageCollection : Form
    {
        //DECLARE a to store image collection in:

        //DECLARE a IDictionary to store new images in, call it _images

        //DECLARE an int to store the value for the next imageKey, call it _imageKey, set to 0:
        int _imageKey = 0;

        /// <summary>
        /// CONSTRUCTOR - ImageCollection Form Object Constructor
        /// </summary>
        public ImageCollection()
        {
            InitializeComponent();
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
        }

        private void ImageCollection_Previous(object sender, EventArgs e) 
        {
            //Code to decrement
            _imageKey--;
        }
    }
}
