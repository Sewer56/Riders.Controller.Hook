using System.Runtime.InteropServices;
using Riders.Controller.Hook.Interfaces.Structs.Enums;

namespace Riders.Controller.Hook.Interfaces.Structs
{
    public interface IPlayerInput
    {
        /// <summary>
        /// The currently pressed buttons.
        /// </summary>
        Buttons Buttons { get; set; }

        /// <summary>
        /// Buttons that were newly pressed this frame.
        /// </summary>
        Buttons ButtonsPressed { get; set; }

        /// <summary>
        /// Buttons that were released this frame.
        /// </summary>
        Buttons ButtonsReleased { get; set; }

        /// <summary>
        /// Range = -100 to 100
        /// </summary>
        sbyte AnalogStickX { get; set; }

        /// <summary>
        /// Range = -100 to 100
        /// </summary>
        sbyte AnalogStickY { get; set; }

        /// <summary>
        /// Range = 0 - 255
        /// </summary>
        byte LeftBumperPressure { get; set; }

        /// <summary>
        /// Range = 0 - 255
        /// </summary>
        byte RightBumperPressure { get; set; }
    }
}
