using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }

}
