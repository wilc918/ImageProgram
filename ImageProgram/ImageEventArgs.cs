using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    /// Class - Provides Image value for events.
    /// 
    /// Author (Calum Wilkinson)
    /// Version (07/07/2022)
    /// </summary>
    public class ImageEventArgs : EventArgs
    {
        /// <summary>
        /// Holds image
        /// </summary>
        public Image image { get; }

        /// <summary>
        /// Inserts image into variable.
        /// </summary>
        /// <param name="data">Image data to be held</param>
        public ImageEventArgs(Image data)
        {
            this.image = data;
        }

    }
}
