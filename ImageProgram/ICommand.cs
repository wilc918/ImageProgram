using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    /// Interface for implementing ICommand Execute method:
    /// 
    /// Author (Calum Wilkinson)
    /// Version (06/07/2022)
    /// </summary>
    public interface ICommand
    {
        void Execute();
    }
}
