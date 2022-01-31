using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessor;

namespace ImageProgram
{
    public interface IImageManipulator
    {
        Image Resize(Image image, Size size);
    }
}
