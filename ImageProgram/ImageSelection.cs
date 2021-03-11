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

        public ImageSelection()
        {
            InitializeComponent();
            //Instantiate and populate _imageNames:
            _imageNames = new List<String>(Directory.GetFiles(_imagePath));
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
            /*
            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine("List item : " + listView1.SelectedItems[i].Text);
            }*/

            for (int i = 0; i < _imageNames.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine("List item : " + _imageNames[i]);
            }

        }

        /// <summary>
        /// This method fills the selection of the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageSelection_Load(object sender, EventArgs e)
        {
            //Create a listviewitem and subitem and then add them to the list
            ListViewItem otem = new ListViewItem("Cake");
            otem.SubItems.Add("Path Directory");
            listView1.Items.Add(otem);
            ListViewItem otem2 = new ListViewItem("Cake2");
            otem2.SubItems.Add("Path Directory 2");
            listView1.Items.Add(otem2);
        }

        private void fillList() 
        {
            
        }
    }
}
