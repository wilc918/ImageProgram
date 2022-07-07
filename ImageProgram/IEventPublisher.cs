using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    /// Interface for implementing subscription methods for eventHandlers to a dictionary.
    /// 
    /// Author (Calum Wilkinson)
    /// Version (06/07/2022)
    /// </summary>
    public interface IEventPublisher
    {
        /// <summary>
        /// Subscribe a listener to displayViewEvents.
        /// </summary>
        /// <param name="Key">Represents what the listener wants to subscribe to.</param>
        /// <param name="Handler">Reference to the listener method</param>
        void Subscribe(string key, EventHandler<ImageEventArgs> listener);

        /// <summary>
        /// Unsubscribe a listener from displayViewEvents.
        /// </summary>
        /// <param name="key">Represents what the listener wants to unsubscribe from.</param>
        /// <param name="listener">Reference to the listener method</param>
        void Unsubscribe(string key, EventHandler<ImageEventArgs> listener);
    }
}
