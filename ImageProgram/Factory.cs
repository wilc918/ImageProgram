using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    /// Implementation of a factory that returns a class object implementing E as its interface.
    /// 
    /// (Calum Wilkinson)
    /// (10/03/2021)
    /// </summary>
    /// <typeparam name="E">The interface</typeparam>
    public class Factory<E> :IFactory<E>
    {
        /// <summary>
        /// Instatiate and return an object that supports the interface E
        /// </summary>
        /// <typeparam name="T">The class to be instatiated</typeparam>
        /// <returns>A new instance of type T</returns>
        public E Create<T>() where T : E, new() 
        {
            return new T();
        }
    }
}
