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
    /// Version (07/07/2022)
    /// </summary>
    class Controller
    {
        /// <summary>
        /// DECLARE a FactoryLocator of type IServiceLocator, call it _factoryLocator:
        /// </summary>
        private IServiceLocator _factoryLocator;

        /// <summary>
        /// DECLARE an imageData of type IImageData, call it _imageData;
        /// </summary>
        private IImageData _imageData;

        /// <summary>
        /// DECLARE an imageData of type IModel, call it _modelData;
        /// </summary>
        private IModel _modelData;

        public Controller() {
            //Instantiate a factory locator:
            _factoryLocator = new FactoryLocator();

            //Instantiate an ImageData to store all the imageData in, store it as IImagedata and call it imageData:
            IImageData imageData = (_factoryLocator.Get<IImageData>() as IFactory<IImageData>).Create<ImageData>();

            //Set _imageData;
            _imageData = imageData;
            // Set _modelData, imageData as IModel:
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


            // Run the ImageCollectionForm
            Application.Run(new ImageCollection(imageCollection, (CollectionPictureBoxFactory)pictureBoxFactory, displayViewFactory, AddDisplayView, AddImageToCollection, RemoveImageFromCollection));
        }


        #region Implementation of Delegates
        /// <summary>
        /// METHOD - Executes given commands.
        /// </summary>
        /// <param name="command">The Command to be executed.</param>
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }

        /// <summary>
        /// METHOD - Adds a DisplayView to the program that displays the relevant image.
        /// </summary>
        /// <param name="key">FileName used to identify image.</param>
        public void AddDisplayView(string key)
        {
            DisplayView displayView = (_factoryLocator.Get<DisplayView>() as IFactory<DisplayView>).Create<DisplayView>();

            (_imageData as IEventPublisher).Subscribe(key, displayView.OnNewInput);

            displayView.Initialise(key,ExecuteCommand,_imageData.RetrieveItem(key).RetrieveImage, _imageData.RetrieveItem(key).RotateImage, _imageData.RetrieveItem(key).FlipImage, _imageData.RetrieveItem(key).SaveImage);
        }

        /// <summary>
        /// METHOD - Adds image to collection.
        /// </summary>
        /// <param name="collectionPictureBoxFactory">Factory for constructing the specific PictureBoxes used for this form.</param>
        /// <param name="imageWithin">Dictionary of PictureBox/FileName KeyPairs</param>
        public void AddImageToCollection(CollectionPictureBoxFactory collectionPictureBoxFactory,IDictionary<PictureBox, string> imageWithin)
        {
            // Open File Dialog enables the user to choose files from file explorer.
            OpenFileDialog galleryFile = new OpenFileDialog
            {

                // SET multiselect:
                Multiselect = true,

                // SET a filter which ensures that only .jpgs and .pngs are allowed:
                Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif;",

                // SET a title:
                Title = "Add image to gallery"
            };

            // If the user presses OK on the file explorer
            if (galleryFile.ShowDialog() == DialogResult.OK)
            {
                // Convert the chosen array of strings into a list:
                List<String> imagePaths = galleryFile.FileNames.ToList();

                // Create list of strings for storing imageNames:
                IList<String> imageNames = new List<String>();

                // Load the filepaths into into _ModelData and recieve the file names in a list:
                imageNames = _modelData.load(imagePaths);

                //For each image in the gallery, a collectionPictureBox is produced and an image fit for it is retrieved.
                foreach (string file in imageNames)
                {
                    // Create the collectionPictureBox used to display images within the collection:
                    CollectionPictureBox collectionPictureBox = (CollectionPictureBox)collectionPictureBoxFactory.MakePictureBox();

                    // Add a keypair of pictureBox and its corresponding file string to a dictionary:
                    imageWithin.Add(collectionPictureBox, file);

                    // Subscribe the pictureBox to the image:
                    (_imageData as IEventPublisher).Subscribe(file, collectionPictureBox.OnNewInput);

                    // Initialise the pictureBox.
                    collectionPictureBox.Initialise(file, _modelData.getImage);
                }

            }




        }

        /// <summary>
        /// METHOD - Removes all references to image and disposes of it.
        /// </summary>
        /// <param name="targetPictureBox"></param>
        /// <param name="imageWithin">Dictionary of PictureBox/FileName KeyPairs</param>
        public void RemoveImageFromCollection(CollectionPictureBox targetPictureBox, IDictionary<PictureBox, string> imageWithin)
        {
            // Unsubscribe the entry from image being referenced:
            (_imageData as IEventPublisher).Unsubscribe(imageWithin[targetPictureBox], targetPictureBox.OnNewInput);

            // Dispose of the Image being referenced:
            _imageData.RemoveItem(imageWithin[targetPictureBox]);

            // Dispose of the image within the PictureBox:
            targetPictureBox.Image.Dispose();
            
            // Dispose of the PictureBox itself:
            targetPictureBox.Dispose();
        }
        #endregion
    }
}
