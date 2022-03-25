using System.Text.Json.Serialization;
using Riders.Controller.Hook.PostProcess.Configuration.Implementation;
using Riders.Controller.Hook.PostProcess.Configuration.Structures;

namespace Riders.Controller.Hook.PostProcess.Configuration;

public class Config : Configurable<Config>
{
    public bool SimulateGameCubeAnalogControls { get; set; } = false;

    [JsonPropertyName("LeftStickXDeadzone")]
    public StickSettings LeftStickXSettings { get; set; } = new StickSettings();

    [JsonPropertyName("LeftStickYDeadzone")]
    public StickSettings LeftStickYSettings { get; set; } = new StickSettings();

    [JsonPropertyName("LeftTriggerDeadzone")]
    public TriggerSettings LeftTriggerSettings { get; set; } = new TriggerSettings();

    [JsonPropertyName("RightTriggerDeadzone")]
    public TriggerSettings RightTriggerSettings { get; set; } = new TriggerSettings();
}