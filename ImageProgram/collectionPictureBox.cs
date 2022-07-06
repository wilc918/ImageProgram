using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ImageProgram
{
    public class collectionPictureBox : PictureBox, IEventListener
    {
        //DECLARE a string for storing file names, name it _fileName;
        private string _fileName;

        ContextMenuStrip _menuStrip;


        public collectionPictureBox() 
        {
           this.BorderStyle = BorderStyle.FixedSingle;
           this.SizeMode = PictureBoxSizeMode.Zoom;
           this.Cursor = Cursors.Hand;
           this.Size = new Size(150, 111);
        }

        public void Initialise(string fileName, RetrieveImageDelegate retrieveImage) 
        {
            //SET fileName:
            _fileName = fileName;

            //SET image
            retrieveImage(_fileName, this.Width, this.Height);

        }

        public collectionPictureBox SetClick(EventHandler ev) 
        {
            this.Click += ev;
            return this;
        }

        public collectionPictureBox SetDoubleClick(EventHandler ev) 
        {
            this.DoubleClick += ev;
            return this;
        }
        public collectionPictureBox SetContextMenu(ContextMenuStrip contextMenuStrip) 
        { 
            this.ContextMenuStrip = contextMenuStrip;
            return this;
        }

        public collectionPictureBox SetImage(String image)
        {
            this.ImageLocation = image;
            return this;
        }

        #region Implementation of IEventListener
        /// <summary>
        /// Method - Updates this.Image in response to new inputs.
        /// </summary>
        /// <param name="sender">The DataElement sending the new input</param>
        /// <param name="args">The new input</param>
        public void OnNewInput(object sender, DisplayEventArgs args)
        {
            if (args.image != null)
            {
                this.Image = args.image;
                System.Diagnostics.Debug.WriteLine("CollectionPictureBox.OnNewInput Executed!");
            }
        }
        #endregion

    }
}
