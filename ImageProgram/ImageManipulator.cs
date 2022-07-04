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
    class ImageManipulator : IImageManipulator
    {
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

        public void SaveFile(Image image, string fileName, string fileDestination)
        {
            ImageFactory imageProc = new ImageFactory(false);

            //Debug.WriteLine("File name and path: "+Path.);
            imageProc.Load(image).Save(fileDestination);
            //imageProc.Save(fileDestination);
            imageProc.Dispose();
        }
    }
}
