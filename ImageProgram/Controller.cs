﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProgram
{

    /// <summary>
    /// Class - Controls all the attributes required to run the ImageProgram.
    /// 
    /// Author (Calum Wilkinson)
    /// Version (10/03/2020)
    /// </summary>
    class Controller
    {
        /// <summary>
        /// CONSTRUCTOR - runs the ImageCollection Application.
        /// </summary>
        public Controller() {
            //Instantiate a factory locator:
            IServiceLocator factoryLocator = new FactoryLocator();

            //Instantiate a Dictionary<int, Image> for the program gallery to store its images in, store it as an IDictionary and call it galleryItems:
            // IDictionary<int, Image> galleryItems = new Dictionary<int, Image>();
            IDictionary<int, Image> galleryItems = (factoryLocator.Get<IDictionary<int, Image>>() as IFactory<IDictionary<int, Image>>).Create<Dictionary<int, Image>>();

            //Instantiate a Dictionary<int, Image> for the program gallery to store its images in, store it as an IDictionary and call it galleryItems:
            IDictionary<int, PictureBox> galleryPictureBoxes = (factoryLocator.Get<IDictionary<int, PictureBox>>() as IFactory<IDictionary<int, PictureBox>>).Create<Dictionary<int, PictureBox>>();

            //Instantiate an ImageData to store all the imageData in, store it as IImagedata and call it imageData:
            IImageData imageData = (factoryLocator.Get<IImageData>() as IFactory<IImageData>).Create<ImageData>();

            // Run the ImageCollectionForm with imageData injected
            Application.Run(new ImageCollection(imageData, galleryItems, galleryPictureBoxes));
        }


    }
}
