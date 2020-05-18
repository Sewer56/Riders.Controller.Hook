using System.ComponentModel;
using Riders.Controller.Hook.PostProcess.Configuration.Implementation;
using Riders.Controller.Hook.PostProcess.Configuration.Structures;

namespace Riders.Controller.Hook.PostProcess.Configuration
{
    public class Config : Configurable<Config>
    {
        public bool SimulateGameCubeAnalogControls { get; set; } = false;

        public StickDeadzone LeftStickXDeadzone { get; set; } = new StickDeadzone();
        public StickDeadzone LeftStickYDeadzone { get; set; } = new StickDeadzone();

        public TriggerDeadzone LeftTriggerDeadzone { get; set; } = new TriggerDeadzone();
        public TriggerDeadzone RightTriggerDeadzone { get; set; } = new TriggerDeadzone();
    }
}
