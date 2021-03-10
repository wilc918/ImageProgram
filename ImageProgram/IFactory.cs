using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    /// IFactory contains all the data required for a factory.
    /// 
    /// (Calum Wilkinson)
    /// (10/03/2021)
    /// </summary>
    /// <typeparam name="E">E is the interface used for instantiating an object, must be compatible with the class</typeparam>
    public interface IFactory<E>
    {
        /// <summary>
        /// Instantiate the class of T where interface E applies. E is described when the factory is called.
        /// </summary>
        /// <typeparam name="T">The class to be instantiated</typeparam>
        /// <returns>The an instance of T</returns>
        E Create<T>() where T : E, new();

    }
   
}
