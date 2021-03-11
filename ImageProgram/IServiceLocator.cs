using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    /// Interface - IServiceLocator 
    /// Author (Calum Wilkinson)
    /// Version (10/03/2020)
    /// </summary>
    public interface IServiceLocator
    {
        /// <summary>
        /// Interface - For Get<T>() Method
        /// </summary>
        /// <typeparam name="T">The type associated with the class</typeparam>
        /// <returns></returns>
        IService Get<T>() where T : class;
    }
}
