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
    /// Class - Used for producing CollectionPictureBoxes.
    /// 
    /// Author (Calum Wilkinson)
    /// Version (07/07/2022)
    /// </summary>
    public class CollectionPictureBoxFactory : PictureBoxFactory
    {
        // DECLARE a CollectionPictureBox, call it _pictureBox:
        private CollectionPictureBox _pictureBox;

        // DECLARE an EventHandler, call it _click:
        private EventHandler _click;

        // DECLARE an EventHandler, call it _doubleClick:
        private EventHandler _doubleClick;

        // DECLARE a ContextMenuStrip, call it _contextMenuStrip:
        private ContextMenuStrip _contextMenuStrip;

        // DECLARE a FlowLayoutPanel, call it _flowLayoutPanel:
        private FlowLayoutPanel _flowLayoutPanel;

        public override PictureBox MakePictureBox() {

            // Construct instance:
            _pictureBox = new CollectionPictureBox();

            // Method Chain for setting Events and contextMenu:
            _pictureBox.SetClick(_click).SetContextMenu(_contextMenuStrip).SetDoubleClick(_doubleClick);

            // Add instance to a FlowLayoutPanel:
            _flowLayoutPanel.Controls.Add(_pictureBox);

            // Return instance: 
            return _pictureBox;
        }

        /// <summary>
        /// METHOD - Intialises all the field variables ready for the factory to start making CollectionPictureBoxes.
        /// </summary>
        /// <param name="click"></param>
        /// <param name="contextMenuStrip"></param>
        /// <param name="doubleClick"></param>
        /// <param name="flowLayoutPanel"></param>
        public void IntialiseFactory(EventHandler click, ContextMenuStrip contextMenuStrip, EventHandler doubleClick, FlowLayoutPanel flowLayoutPanel) 
        {
            // Set field variables:
            _click = click;
            _contextMenuStrip = contextMenuStrip;
            _doubleClick = doubleClick;
            _flowLayoutPanel = flowLayoutPanel;
        }
    }
}
