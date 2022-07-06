using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    /// Interface for implementing subscription methods for eventHandlers to a dictionary.
    /// </summary>
    public interface IEventPublisher
    {
        /// <summary>
        /// Subscribe a listener to displayViewEvents.
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Handler">Reference to the listener method</param>
        void Subscribe(string Key, EventHandler<DisplayEventArgs> Listener);

        /// <summary>
        /// Unsubscribe a listener to displayViewEvents.
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Handler"></param>
        void Unsubscribe(string Key, EventHandler<DisplayEventArgs> Listener);
    }
}
