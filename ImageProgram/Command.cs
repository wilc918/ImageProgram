using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    ///Class - Stores and calls Actions.
    /// 
    /// Author (Calum Wilkinson)
    /// Version (06/07/2022)
    /// </summary>
    public class Command : ICommand
    {
        //Declare an Action to be executed by this command, call it _action:
        private Action _action;

        /// <summary>
        /// Constructor for Command
        /// </summary>
        /// <param name="action">The action to be stored ready for execution by this command.</param>
        public Command(Action action)
        {
            _action = action;
        }

        /// <summary>
        /// Execute the stored action:
        /// </summary>
        public void Execute()
        {
            _action();
        }
    }

    public class Command<T> : ICommand
    {
        private Action<T> _action;

        private T _value;

        /// <summary>
        /// Constructor for command where Action<typeparamref name="T"/>
        /// </summary>
        /// <param name="action">Action to executed.</param>
        /// <param name="value">The parameter for the action.</param>
        public Command(Action<T> action, T value)
            {
                _action = action;
                _value  = value;
            }
        /// <summary>
        /// Execute the stored action on the stored parameter:
        /// </summary>
        public void Execute() 
        {
            _action(_value);
        }
    }
}
