using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ImageProgram
{
    /// <summary>
    /// Class - Represents the functionality of a PictureBox designed specifically for ImageCollection form.
    /// 
    /// Author (Calum Wilkinson)
    /// Version (07/07/2022)
    /// </summary>
    public class CollectionPictureBox : PictureBox, IEventListener
    {
        //DECLARE a string for storing file names, name it _fileName;
        private string _fileName;


        public CollectionPictureBox() 
        {
            // SET this PictureBoxes properties:
           this.BorderStyle = BorderStyle.FixedSingle;
           this.SizeMode = PictureBoxSizeMode.Zoom;
           this.Cursor = Cursors.Hand;
           this.Size = new Size(150, 111);
           
        }

        /// <summary>
        /// METHOD - Sets the variables and properties of this PictureBox that couldn't be done on construction.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="retrieveImage">Delegate that when called sets the image.</param>
        public void Initialise(string fileName, RetrieveImageDelegate retrieveImage) 
        {
            //SET fileName:
            _fileName = fileName;

            //SET AccessibleName:
            this.AccessibleName = fileName;

            //SET image
            retrieveImage(_fileName, this.Width, this.Height);

        }

        /// <summary>
        /// METHOD - Sets click property with an event.
        /// </summary>
        /// <param name="ev"></param>
        /// <returns>This CollectionPictureBox with a Click Event</returns>
        public CollectionPictureBox SetClick(EventHandler ev) 
        {
            this.Click += ev;
            return this;
        }

        /// <summary>
        /// METHOD - Sets DoubleClick property with an event.
        /// </summary>
        /// <param name="ev"></param>
        /// <returns>This CollectionPictureBox with a DoubleClick Event</returns>
        public CollectionPictureBox SetDoubleClick(EventHandler ev) 
        {
            this.DoubleClick += ev;
            return this;
        }

        /// <summary>
        /// METHOD - Sets ContextMenuStrip property.
        /// </summary>
        /// <param name="ev"></param>
        /// <returns>This CollectionPictureBox with a ContextMenuStrip</returns>
        public CollectionPictureBox SetContextMenu(ContextMenuStrip contextMenuStrip) 
        { 
            this.ContextMenuStrip = contextMenuStrip;
            return this;
        }

        #region Implementation of IEventListener
        /// <summary>
        /// Method - Updates this.Image in response to new inputs.
        /// </summary>
        /// <param name="sender">The DataElement sending the new input</param>
        /// <param name="args">The new input</param>
        public void OnNewInput(object sender, ImageEventArgs args)
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
