using System.ComponentModel;
using System.Text.Json.Serialization;
using Riders.Controller.Hook.XInput.Configuration.Implementation;
using SharpDX.XInput;

namespace Riders.Controller.Hook.XInput.Configuration;

public class Config : Configurable<Config>
{
    /*
        User Properties:
            - Please put all of your configurable properties here.
            - Tip: Consider using the various available attributes https://stackoverflow.com/a/15051390/11106111
    
        By default, configuration saves as "Config.json" in mod folder.    
        Need more config files/classes? See Configuration.cs
    */

    [Browsable(false)]
    [JsonIgnore]
    public int ControllerPort { get; set; } = -1;

    [DisplayName("Accept / Jump")]
    [DefaultValue(GamepadButtonFlags.A)]
    public GamepadButtonFlags Accept        { get; set; } = GamepadButtonFlags.A;

    [DisplayName("Decline / Boost")]
    [DefaultValue(GamepadButtonFlags.B)]
    public GamepadButtonFlags Decline       { get; set; } = GamepadButtonFlags.B;

    [DisplayName("Start")]
    [DefaultValue(GamepadButtonFlags.Start)]
    public GamepadButtonFlags Start         { get; set; } = GamepadButtonFlags.Start;

    [DisplayName("Left Drift")]
    [DefaultValue(GamepadButtonFlags.LeftShoulder)]
    public GamepadButtonFlags LeftDrift     { get; set; } = GamepadButtonFlags.LeftShoulder;

    [DisplayName("Right Drift")]
    [DefaultValue(GamepadButtonFlags.RightShoulder)]
    public GamepadButtonFlags RightDrift    { get; set; } = GamepadButtonFlags.RightShoulder;

    [DisplayName("DPAD: Up")]
    [DefaultValue(GamepadButtonFlags.DPadUp)]
    public GamepadButtonFlags DpadUp        { get; set; } = GamepadButtonFlags.DPadUp;

    [DisplayName("DPAD: Down")]
    [DefaultValue(GamepadButtonFlags.DPadDown)]
    public GamepadButtonFlags DpadDown      { get; set; } = GamepadButtonFlags.DPadDown;

    [DisplayName("DPAD: Left")]
    [DefaultValue(GamepadButtonFlags.DPadLeft)]
    public GamepadButtonFlags DpadLeft      { get; set; } = GamepadButtonFlags.DPadLeft;

    [DisplayName("DPAD: Right")]
    [DefaultValue(GamepadButtonFlags.DPadRight)]
    public GamepadButtonFlags DpadRight     { get; set; } = GamepadButtonFlags.DPadRight;
}