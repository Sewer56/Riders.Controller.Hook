using System.Text.Json.Serialization;
using Riders.Controller.Hook.XInput.Configuration.Implementation;
using SharpDX.XInput;

namespace Riders.Controller.Hook.XInput.Configuration
{
    public class Config : Configurable<Config>
    {
        /*
            User Properties:
                - Please put all of your configurable properties here.
                - Tip: Consider using the various available attributes https://stackoverflow.com/a/15051390/11106111
        
            By default, configuration saves as "Config.json" in mod folder.    
            Need more config files/classes? See Configuration.cs
        */


        [JsonIgnore]
        public int ControllerPort { get; set; } = -1;

        public GamepadButtonFlags Accept        { get; set; } = GamepadButtonFlags.A;
        public GamepadButtonFlags Decline       { get; set; } = GamepadButtonFlags.B;
        public GamepadButtonFlags Start         { get; set; } = GamepadButtonFlags.Start;
        public GamepadButtonFlags LeftDrift     { get; set; } = GamepadButtonFlags.LeftShoulder;
        public GamepadButtonFlags RightDrift    { get; set; } = GamepadButtonFlags.RightShoulder;
        public GamepadButtonFlags DpadUp        { get; set; } = GamepadButtonFlags.DPadUp;
        public GamepadButtonFlags DpadDown      { get; set; } = GamepadButtonFlags.DPadDown;
        public GamepadButtonFlags DpadLeft      { get; set; } = GamepadButtonFlags.DPadLeft;
        public GamepadButtonFlags DpadRight     { get; set; } = GamepadButtonFlags.DPadRight;
    }
}
