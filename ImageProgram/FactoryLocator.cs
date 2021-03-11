using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    /// Class - For producing and keeping track of factories.
    /// </summary>
    public class FactoryLocator : IServiceLocator
    {

        //DECLARE an IDictionary for references to IService objects according to the type used to instantiate it
        private IDictionary<Type, IService> _factoryRegister;

        /// <summary>
        /// Constructor - Stores dictionary inside attribute.
        /// </summary>
        public FactoryLocator()
        {
            _factoryRegister = new Dictionary<Type, IService>();
        }

        /// <summary>
        /// Method - Retrieves the type, 
        /// compares it against register, 
        /// stores it if missing along a factory of said type,
        /// returns the factory
        /// </summary>
        /// <typeparam name="T">Type associated with class</typeparam>
        /// <returns>Factory of the type</returns>
        public IService Get<T>() where T : class
        {
            // Register factory if a factory of that type cannot be found
            if (!_factoryRegister.ContainsKey(typeof(T)))
            {
                //Add to the register the type and the factory of that type
                _factoryRegister.Add(typeof(T), new Factory<T>());
            }

            //We are returning the stored factory of the corresponding type
            return _factoryRegister[typeof(T)];
        }
    }
}
