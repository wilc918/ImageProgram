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
    public interface IImageManipulator
    {
        Image Resize(Image image, Size size);

        Image Rotate(Image image, int degrees);

        Image Flip(Image image, bool flipVertically);

        void SaveFile(Image image, string fileDestination );
    }
}
