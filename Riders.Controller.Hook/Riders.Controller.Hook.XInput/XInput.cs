using Riders.Controller.Hook.Interfaces.Structs;
using Riders.Controller.Hook.XInput.Configuration;
using Riders.Controller.Hook.XInput.Configuration.Implementation;
using Riders.Controller.Hook.XInput.Utilities;
using SharpDX.XInput;

namespace Riders.Controller.Hook.XInput;

public class XInput
{
    private Dictionary<int, ControllerTuple> _controllers = new Dictionary<int, ControllerTuple>();

    /// <param name="modFolder">Path to the mod folder.</param>
    /// <param name="configFolder">Path to the config.</param>
    public XInput(string modFolder, string configFolder)
    {
        var configurator = new Configurator(configFolder);
        configurator.Migrate(modFolder, configFolder);
        int numConfigurations = configurator.Configurations.Length;

        for (int x = 0; x < numConfigurations; x++)
        {
            var config = configurator.GetConfiguration<Config>(x);
            if (config.ControllerPort == -1)
                config.ControllerPort = x;

            // Self-updating Controller Bindings 
            var controllerId = x;
            config.ConfigurationUpdated += configurable =>
            {
                _controllers[controllerId].Config = (Config)configurable;
                Program.Logger.WriteLine($"[XInput/Riders] Configuration for port {controllerId} updated.");
            };

            _controllers[config.ControllerPort] = new ControllerTuple(new SharpDX.XInput.Controller((UserIndex)x), config);
        }
    }

    public void SetInputs(ref IPlayerInput inputs, in int port)
    {
        if (_controllers.TryGetValue(port, out var controllerTuple))
        {
            var controller  = controllerTuple.Controller;
            var config      = controllerTuple.Config;

            if (!controller.IsConnected)
                return;

            controller.GetState(out State state);
            Converter.ToPlayerInput(ref state, ref inputs, config);
        }
    }
}