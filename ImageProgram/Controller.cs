using System;
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

            //Instantiate an ImageData to store all the imageData in, store it as IImagedata and call it imageData:
            IImageData imageData = (factoryLocator.Get<IImageData>() as IFactory<IImageData>).Create<ImageData>();

            //Instantiate an imageManipulator, store as IImageManipulator and call it imageManip:
            IImageManipulator imageManip = (factoryLocator.Get<IImageManipulator>() as IFactory<IImageManipulator>).Create<ImageManipulator>();

            //Inject imageManipulator into imageData
            imageData.InjectManipulator(imageManip);

            //Instantiate a Dictionary<PictureBox, string> for the UI to store fileNames in, store it as IDictionary and call it imageCollection:
            IDictionary<PictureBox, string> imageCollection = (factoryLocator.Get<IDictionary<PictureBox, string>>() as IFactory<IDictionary<PictureBox, string>>).Create<Dictionary<PictureBox, string>>();

            //Get a reference to CollectionPictureBoxFactory, call it pictureBoxFactory
            IPictureBoxFactory pictureBoxFactory = (factoryLocator.Get<IPictureBoxFactory>() as IFactory<IPictureBoxFactory>).Create<CollectionPictureBoxFactory>();

            //Get a reference to displayViewFactory, call it displayViewFactory.
            IFactory<DisplayView> displayViewFactory = factoryLocator.Get<DisplayView>() as IFactory<DisplayView>;


            

            // Run the ImageCollectionForm with imageData injected
            Application.Run(new ImageCollection(imageData, imageManip, imageCollection, pictureBoxFactory, displayViewFactory));
        }

        /// <summary>
        /// Implementation of ExecuteCommand Delegate
        /// </summary>
        /// <param name="command">The Command to be executed.</param>
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }


    }
}
