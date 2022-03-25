using Riders.Controller.Hook.Interfaces.Structs;
using Riders.Controller.Hook.Interfaces.Structs.Enums;
using SDKInput = Sewer56.SonicRiders.Structures.Input.PlayerInput;


namespace Riders.Controller.Hook.Structs;

public struct PlayerInput : IPlayerInput
{
    public Buttons Buttons { get; set; }
    public Buttons ButtonsPressed { get; set; }
    public Buttons ButtonsReleased { get; set; }
    public sbyte AnalogStickX { get; set; }
    public sbyte AnalogStickY { get; set; }
    public byte LeftBumperPressure { get; set; }
    public byte RightBumperPressure { get; set; }

    /// <summary>
    /// Converts from the Sewer56 library format to the local format.
    /// </summary>
    public static PlayerInput FromLibrary(ref SDKInput source)
    {
        return new PlayerInput()
        {
            Buttons = (Buttons) source.Buttons,
            ButtonsPressed =  (Buttons) source.ButtonsPressed,
            ButtonsReleased = (Buttons) source.ButtonsReleased,
            AnalogStickX = source.AnalogStickX,
            AnalogStickY = source.AnalogStickY,
            LeftBumperPressure = source.LeftBumperPressure,
            RightBumperPressure = source.RightBumperPressure
        };
    }

    /// <summary>
    /// Converts from the local format to the Sewer56 library format.
    /// </summary>
    public SDKInput ToLibrary()
    {
        return new SDKInput()
        {
            Buttons = (Sewer56.SonicRiders.Structures.Input.Enums.Buttons) this.Buttons,
            ButtonsPressed = (Sewer56.SonicRiders.Structures.Input.Enums.Buttons) this.ButtonsPressed,
            ButtonsReleased = (Sewer56.SonicRiders.Structures.Input.Enums.Buttons) this.ButtonsReleased,
            AnalogStickX = this.AnalogStickX,
            AnalogStickY = this.AnalogStickY,
            LeftBumperPressure = this.LeftBumperPressure,
            RightBumperPressure = this.RightBumperPressure
        };
    }
}