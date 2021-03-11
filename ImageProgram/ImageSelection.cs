using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProgram
{
    /// <summary>
    /// Class - Contains all methods and attributes relevant to imageSelection form.
    /// 
    /// (Calum Wilkinson)
    /// (11/03/2021)
    /// </summary>
    public partial class ImageSelection : Form
    {
        // DECLARE a string to store path for images on close button, call it _imagePath:
        private const string _imagePath = "..\\..\\FishAssets\\";

        //Declare list of keys for listView
        private IList<String> _selectedItems;

        // DECLARE a List<String> to store a list of path+filename for all available image assets, call it _imageName:
        private IList<String> _imageNames;

        //DECLARE a IList<ListViewItem> to store a list of listviewitems, call it _listEntries:
        private IList<ListViewItem> _listEntries;

        // DECLARE an IModel to access ModelStuff call it _ModelData:
        private IModel _ModelData;

        public ImageSelection()
        {
            InitializeComponent();
            //Instantiate and populate _imageNames:
            _imageNames = new List<String>(Directory.GetFiles(_imagePath));
        }

        public ImageSelection(IImageData ImageData)
        {
            InitializeComponent();
            //Instantiate and populate _imageNames:
            _imageNames = new List<String>(Directory.GetFiles(_imagePath));

            //Instantiate _ModelData, casting ImageData as the type IModel:
            _ModelData = ImageData as IModel;

            fillList(_imageNames);
        }

        /// <summary>
        /// Method - Dispose of the Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeForm(object sender, EventArgs e)
        {
            //Disposes of this instance of ImageSelection
            this.Dispose();
        }

        /// <summary>
        /// Method - loads selected images into collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void collectImages(object sender, EventArgs e) 
        {
            //Create a list for selected items
            _selectedItems = new List<string>();

            //loop through the selected items from ListView
            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                //Add the paths to the list
                _selectedItems.Add(listView1.SelectedItems[i].SubItems[1].Text);
            }
            //Load them into data
            _ModelData.load(_selectedItems);
            //Close the form
            this.Dispose();
        }

        /// <summary>
        /// Fills the list with image names from the FishAssets folder
        /// </summary>
        /// <param name="listItems">the items to go in the list</param>
        private void fillList(IList<String> listItems) 
        {
            //Loop through the amount of items, adding their file name and their file path to the listView.
            for (int i = 0; i < listItems.Count; i++)
            {
                ListViewItem otem = new ListViewItem(Path.GetFileName(listItems[i]));
                otem.SubItems.Add(listItems[i]);
                listView1.Items.Add(otem);
            }
        }
    }
}
