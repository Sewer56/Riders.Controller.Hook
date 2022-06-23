using System.ComponentModel;
using System.Text.Json.Serialization;
using Riders.Controller.Hook.PostProcess.Configuration.Implementation;
using Riders.Controller.Hook.PostProcess.Configuration.Structures;

namespace Riders.Controller.Hook.PostProcess.Configuration;

public class Config : Configurable<Config>
{
    [DisplayName("GameCube Style Analog")]
    [Description("Makes the analog stick behave like in console ports of the game.\n" +
                 "This setting makes your stick range a Circle [GameCube] as opposed to a Square [Vanilla PC].")]
    [DefaultValue(false)]
    public bool SimulateGameCubeAnalogControls { get; set; } = false;

    [DisplayName("Left Stick (Horizontal) Settings")]
    [JsonPropertyName("LeftStickXDeadzone")]
    public StickSettings LeftStickXSettings { get; set; } = new StickSettings();

    [DisplayName("Left Stick (Vertical) Settings")]
    [JsonPropertyName("LeftStickYDeadzone")]
    public StickSettings LeftStickYSettings { get; set; } = new StickSettings();

    [DisplayName("Left Trigger Settings")]
    [JsonPropertyName("LeftTriggerDeadzone")]
    public TriggerSettings LeftTriggerSettings { get; set; } = new TriggerSettings();

    [DisplayName("Right Trigger Settings")]
    [JsonPropertyName("RightTriggerDeadzone")]
    public TriggerSettings RightTriggerSettings { get; set; } = new TriggerSettings();
}