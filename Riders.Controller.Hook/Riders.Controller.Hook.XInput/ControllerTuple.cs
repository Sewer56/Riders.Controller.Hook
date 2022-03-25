using Riders.Controller.Hook.XInput.Configuration;

namespace Riders.Controller.Hook.XInput;

public class ControllerTuple
{
    public SharpDX.XInput.Controller Controller { get; private set; }
    public Config Config { get; set; }

    public ControllerTuple(SharpDX.XInput.Controller controller, Config config)
    {
        Controller = controller;
        Config = config;
    }
}