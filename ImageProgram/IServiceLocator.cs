using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    public interface IServiceLocator
    {
        /// <summary>
        /// Produces a factory for the type given.
        /// </summary>
        /// <typeparam name="T">Type: Interface or class required</typeparam>
        /// <returns>A factory for the given class or interface</returns>
        IService Get<T>() where T : class;
    }
}
