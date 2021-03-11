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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void closeForm(object sender, EventArgs e)
        {
            //Disposes of this instance of ImageSelection
            this.Dispose();
        }

        private void collectImages(object sender, EventArgs e) 
        {

            /*for (var i = 0; i > listView1.SelectedItems.Count; i++) 
            {
                System.Diagnostics.Debug.WriteLine(i);
                //Log the selected items
                String text = listView1.SelectedItems[i].Text;
                String text2 = listView1.SelectedItems[i].SubItems[1].Text;
                System.Diagnostics.Debug.WriteLine("Name " + text + "Path" + text2);
            }*/
            //String text = listView1.SelectedItems[0].Text;
            //String text2 = listView1.SelectedItems[0].SubItems[1].Text;
            //System.Diagnostics.Debug.WriteLine("Name " + text + "Path" + text2);

            _selectedItems = new List<string>();
            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {

                System.Diagnostics.Debug.WriteLine("List item : " + listView1.SelectedItems[i].SubItems[1].Text);
                _selectedItems.Add(listView1.SelectedItems[i].SubItems[1].Text);
            }

            

            
            _ModelData.load(_selectedItems);

            /*for (int i = 0; i < _imageNames.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine("List item : " + _imageNames[i] + "File Name : " + Path.GetFileName(_imageNames[i]));
            }*/

        }

        /// <summary>
        /// This method fills the selection of the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageSelection_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Fills the list with image names from the FishAssets folder
        /// </summary>
        /// <param name="listItems">the items to go in the list</param>
        private void fillList(IList<String> listItems) 
        {
            for (int i = 0; i < listItems.Count; i++)
            {
                ListViewItem otem = new ListViewItem(Path.GetFileName(listItems[i]));
                otem.SubItems.Add(listItems[i]);
                listView1.Items.Add(otem);
            }
        }
    }
}
