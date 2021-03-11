using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    /// Declare a delegate for selecting an item, call it SelectItem
    /// </summary>
    /// <param name="key">Key that identifies selection</param>
    public delegate void SelectItemDelegate(int key);

    /// <summary>
    /// Declare a delegate for retrieving listed of imageName, call it RetrieveImageList
    /// </summary>
    /// <param name="noteKey">Note Identifier</param>
    /// <returns>Associated note listItem</returns>
    public delegate String RetrieveImageListDelegate(int noteKey);
}
