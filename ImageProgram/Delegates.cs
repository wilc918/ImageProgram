using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProgram
{
    /// <summary>
    /// Declare a delegate for retrieving stored imagePath, call it RetrieveImage:
    /// </summary>
    /// <param name="ImageName">Name of the image to be retrieved</param>
    /// <returns>Associated file path to image</returns>
    public delegate Image RetrieveImageDelegate(string imageName, int frameWidth, int frameHeight);

    /// <summary>
    /// Declare a delegate for rotating stored image, call it RotateImageDelegate:
    /// </summary>
    /// <param name="key"></param>
    /// <param name="degrees"></param>
    public delegate void RotateImageDelegate(string key, int degrees);

    /// <summary>
    /// Declare a delegate for flipping the image around the desired axis.
    /// </summary>
    /// <param name="key">Name of the image to be flipped.</param>
    /// <param name="vertically">Bool to determine which axis to flip around</param>
    public delegate void FlipImageDelegate(string key, bool vertically);

    /// <summary>
    /// Declare a delegate for saving the image.
    /// </summary>
    /// <param name="key">Name of the image to be saved.</param>
    /// <param name="fileDestination">Name of the destination it will be saved at.</param>
    public delegate void SaveImageDelegate(string key, string fileDestination);

    /// <summary>
    /// Declare a delegate for deleting item and call it DeleteItem:
    /// </summary>
    /// <param name="key">Key associated with item to be deleted</param>
    public delegate void DeleteItemDelegate(string key);

    /// <summary>
    /// Declare a delegate for issuing commands, call it ExecuteCommand:
    /// </summary>
    /// <param name="command">The command to be executed</param>
    public delegate void ExecuteCommandDelegate(ICommand command);

    /// <summary>
    /// Declare a delegate for creating a new DisplayView, call it CreateDisplayView:
    /// </summary>
    /// <param name="key"></param>
    public delegate void CreateDisplayViewDelegate(string key);
}
