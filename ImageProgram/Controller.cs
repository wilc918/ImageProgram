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
        /// 
        private IServiceLocator _factoryLocator;

        private IImageData _imageData;

        private IModel _modelData;

        public Controller() {
            //Instantiate a factory locator:
            _factoryLocator = new FactoryLocator();

            //Instantiate an ImageData to store all the imageData in, store it as IImagedata and call it imageData:
            IImageData imageData = (_factoryLocator.Get<IImageData>() as IFactory<IImageData>).Create<ImageData>();

            _imageData = imageData;
            _modelData = imageData as IModel;

            //Instantiate an imageManipulator, store as IImageManipulator and call it imageManip:
            IImageManipulator imageManip = (_factoryLocator.Get<IImageManipulator>() as IFactory<IImageManipulator>).Create<ImageManipulator>();

            //Inject imageManipulator into imageData
            imageData.InjectManipulator(imageManip);
            //Inject FactoryLocator into imageData
            imageData.InjectFactoryLocator(_factoryLocator);

            //Instantiate a Dictionary<PictureBox, string> for the UI to store fileNames in, store it as IDictionary and call it imageCollection:
            IDictionary<PictureBox, string> imageCollection = (_factoryLocator.Get<IDictionary<PictureBox, string>>() as IFactory<IDictionary<PictureBox, string>>).Create<Dictionary<PictureBox, string>>();

            //Get a reference to CollectionPictureBoxFactory, call it pictureBoxFactory
            IPictureBoxFactory pictureBoxFactory = (_factoryLocator.Get<IPictureBoxFactory>() as IFactory<IPictureBoxFactory>).Create<CollectionPictureBoxFactory>();

            //Get a reference to displayViewFactory, call it displayViewFactory.
            IFactory<DisplayView> displayViewFactory = _factoryLocator.Get<DisplayView>() as IFactory<DisplayView>;


            

            // Run the ImageCollectionForm with imageData injected
            Application.Run(new ImageCollection(imageData, imageCollection, pictureBoxFactory, displayViewFactory, AddDisplayView));
        }


        #region Implementation of Delegates
        /// <summary>
        /// Implementation of ExecuteCommand Delegate
        /// </summary>
        /// <param name="command">The Command to be executed.</param>
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }

        public void AddDisplayView(string key)
        {
            DisplayView displayView = (_factoryLocator.Get<DisplayView>() as IFactory<DisplayView>).Create<DisplayView>();

            //_imageData.RetrieveItem(key).RetrieveImage;

            (_imageData as IEventPublisher).Subscribe(key, displayView.OnNewInput);

            displayView.Initialise(key,ExecuteCommand,_imageData.RetrieveItem(key).RetrieveImage, _modelData.getImage, _imageData.RetrieveItem(key).RotateImage, _imageData.RotateImage, _imageData.RetrieveItem(key).FlipImage,_imageData.FlipImage, _imageData.RetrieveItem(key).SaveImage,_imageData.SaveImage);
        }

        #endregion
    }
}
