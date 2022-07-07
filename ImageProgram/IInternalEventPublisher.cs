using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    /// Enforce the implementation of subscription methods for direct data handling with event listeners
    /// 
    /// Author (Calum Wilkinson)
    /// Version (07/07/2022)
    /// </summary>
    public interface IInternalEventPublisher
    {
        /// <summary>
        /// Subscribe a listener to Image events
        /// </summary>
        /// <param name="listener">Reference to listener method</param>
        void Subscribe(EventHandler<ImageEventArgs> listener);

        /// <summary>
        /// Unsubscribe a listener from Image events
        /// </summary>
        /// <param name="listener">Reference to listener method</param>
        void Unsubscribe(EventHandler<ImageEventArgs> listener);
    }
}
