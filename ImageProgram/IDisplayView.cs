using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    interface IDisplayView
    {
        void Initialise(string fileName,ExecuteCommandDelegate execute,Action<Size> retrieveImage2, RetrieveImageDelegate retrieveImage,Action<int> rotateImageAction , RotateImageDelegate rotateImage,Action<bool> flipImageAction, FlipImageDelegate flipImage, Action<string> saveImageAction, SaveImageDelegate saveImage);
    }
}
