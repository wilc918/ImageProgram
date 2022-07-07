using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    /// Enforce implementation of event handler
    /// 
    /// Author (Calum Wilkinson)
    /// Version (07/07/2022)
    /// </summary>
    interface IEventListener
    {
        /// <summary>
        /// EventHandler Method
        /// </summary>
        /// <param name="source">Source of the call.</param>
        /// <param name="args">The event.</param>
        void OnNewInput(object source, ImageEventArgs args);
    }
}
