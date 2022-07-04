using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    public class DisplayEventArgs : EventArgs
    {
        /// <summary>
        /// Holds image
        /// </summary>
        public Image image { get; }

        /// <summary>
        /// Inserts image into variable.
        /// </summary>
        /// <param name="data">Image data to be held</param>
        public DisplayEventArgs(Image data)
        {
            this.image = data;
        }

    }
}
