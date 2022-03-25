namespace Riders.Controller.Hook.PostProcess.Configuration.Structures;

public class TriggerSettings
{
    public float DeadzonePercent { get; set; }
    public float RadiusPercent { get; set; } = 100f;
    public bool IsInverted   { get; set; } = false;
    public bool SimulateDigitalInput    { get; set; } = false;
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
        if (SimulateDigitalInput || triggerValue < ScaleTriggerValue(SimulateDigitalPercent))
            return false;

        return true;
    }

    public override string ToString() => $"Deadzone: {DeadzonePercent}, Invert: {IsInverted}";
}