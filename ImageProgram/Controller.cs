using System;
using System.Collections.Generic;
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

            //Instantiate an ImageData to store all the imageData in, store it as IImagedata and call it imageData:
            IImageData imageData = (factoryLocator.Get<IImageData>() as IFactory<IImageData>).Create<ImageData>();


           // IImageData imageData = IFactory<IImageData>.create<ImageData>();
           //IFactory<IImageData> dataFactory = 




            Application.Run(new ImageCollection(imageData));
        }


    }
}
