using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ImageProcessor;

namespace ImageProgram
{
    /// <summary>
    /// Facade for image processing.
    /// 
    /// Author (Calum Wilkinson)
    /// Version (07/07/2022)
    /// </summary>
    class ImageManipulator : IImageManipulator
    {
        /// <summary>
        /// Resizes image to the requested size.
        /// </summary>
        /// <param name="image">Image to be resized.</param>
        /// <param name="size">The requested size.</param>
        /// <returns>The image at the requested size</returns>
        public Image Resize(Image image, Size size)
        {
            //Instantiate an ImageFactory to do processing, call it imageProc:
            ImageFactory imageProc = new ImageFactory(false);

            //Create a Stream using System.IO to temporarily store processed image, call it imageStream:
            Stream imageStream = new MemoryStream();

            //Load Scale Save image using imageProcessor 
            imageProc.Load(image).Resize(size).Save(imageStream);

            //Dispose of imageProc to avoid memory leaks:
            imageProc.Dispose();

            // Return processed image:
            return Image.FromStream(imageStream);
        }

        /// <summary>
        /// Rotates image by the requested amount.
        /// </summary>
        /// <param name="image">The image to be rotated.</param>
        /// <param name="degrees">The amount to be rotated by.</param>
        /// <returns>Image rotated by requested amount.</returns>
        public Image Rotate(Image image, int degrees)
        {
            //Instantiate an ImageFactory to do processing, call it imageProc:
            ImageFactory imageProc = new ImageFactory(false);

            //Create a Stream using System.IO to temporarily store processed image, call it imageStream:
            Stream imageStream = new MemoryStream();

            //Load Rotate Save image using imageProcessor
            imageProc.Load(image).Rotate(degrees).Save(imageStream);

            //Dispose of imageProc to avoid memory leaks:
            imageProc.Dispose();

            // Return processed image:
            return Image.FromStream(imageStream);
        }

        /// <summary>
        /// Flips image either vertically or horizontally.
        /// </summary>
        /// <param name="image">The image to be flipped.</param>
        /// <param name="vertically">Boolean defining whether the image is flipped vertically or horizontally.</param>
        /// <returns>An image flipped along the requested axis.</returns>
        public Image Flip(Image image, bool vertically)
        {
            //Instantiate an ImageFactory to do processing, call it imageProc:
            ImageFactory imageProc = new ImageFactory(false);

            //Create a Stream using System.IO to temporarily store processed image, call it imageStream:
            Stream imageStream = new MemoryStream();

            //Load Flip and save image using imageProcessor
            imageProc.Load(image).Flip(vertically).Save(imageStream);

            //Dispose of imageProc to avoid memory leaks;
            imageProc.Dispose();

            // Return processed image:
            return Image.FromStream(imageStream);
        }

        /// <summary>
        /// Saves the image at the fileDestination.
        /// </summary>
        /// <param name="image">Image to be saved</param>
        /// <param name="fileDestination">FilePath for saving</param>
        public void SaveFile(Image image, string fileDestination)
        {
            //Instantiate an ImageFactory to do processing, call it imageProc:
            ImageFactory imageProc = new ImageFactory(false);

            //Load image into imageProcessor and save it at fileDestination:
            imageProc.Load(image).Save(fileDestination);

            //Dipsose of imageProc to avoid memory leaks;
            imageProc.Dispose();
        }
    }
}
