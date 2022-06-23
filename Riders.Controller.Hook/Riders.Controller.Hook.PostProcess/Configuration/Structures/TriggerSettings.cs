using System.ComponentModel;

namespace Riders.Controller.Hook.PostProcess.Configuration.Structures;

public class TriggerSettings
{
    [DisplayName("Trigger Deadzone")]
    [Description("When the trigger is under this value (in percent), the value is reported to the game as 0.")]
    [DefaultValue(10f)]
    public float DeadzonePercent { get; set; } = 10f;

    [DisplayName("Trigger Radius")]
    [Description("The radius of the trigger.\n" +
                 "Example: A value of 50 means the game will only see the trigger\n" +
                 "moved 50% of the way across when fully pressed.")]
    [DefaultValue(100f)]
    public float RadiusPercent { get; set; } = 100f;

    [DisplayName("Inverted?")]
    [Description("Inverts the readings from the triggers.\n" +
                 "i.e. The game will think the trigger is fully pressed when it is not pressed at all.")]
    [DefaultValue(false)]
    public bool IsInverted   { get; set; } = false;

    [DisplayName("Simulate Digital Input")]
    [Description($"Simulates a full trigger press if this is enabled and trigger exceeds {nameof(SimulateDigitalPercent)}.")]
    [DefaultValue(false)]
    public bool SimulateDigitalInput    { get; set; } = false;

    [DisplayName("Simulate Digital %")]
    [Description("Percentage under which trigger has to be held in to simulate a full trigger press.\n" +
                 $"Enabled using {nameof(SimulateDigitalInput)}")]
    [DefaultValue(90f)]
    public float SimulateDigitalPercent { get; set; } = 90f;

    public float ScaleTriggerValue(float percent) => (percent / 100.0F) * byte.MaxValue;

    public byte ApplySettings(byte stickValue)
    {
        stickValue = ApplyDeadzone(stickValue);
        stickValue = ScaleValue(stickValue);
        if (IsInverted)
            stickValue = (byte) (byte.MaxValue - stickValue);

        return stickValue;
    }

    public byte ScaleValue(byte stickValue)
    {
        var scaled = stickValue * (RadiusPercent / 100.0f);
        if (scaled > byte.MaxValue)
            scaled = byte.MaxValue;

        return (byte)scaled;
    }

    public byte ApplyDeadzone(byte triggerValue)
    {
        if (triggerValue < ScaleTriggerValue(DeadzonePercent))
            return 0;

        return triggerValue;
    }

    public bool IsSimulatingDigitalInput(byte triggerValue)
    {
        return SimulateDigitalInput && ApplyDeadzone(triggerValue) < ScaleTriggerValue(SimulateDigitalPercent);
    }

    public override string ToString() => $"Deadzone: {DeadzonePercent}, Invert: {IsInverted}";
}