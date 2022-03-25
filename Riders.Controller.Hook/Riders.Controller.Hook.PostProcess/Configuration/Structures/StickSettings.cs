using System;

namespace Riders.Controller.Hook.PostProcess.Configuration.Structures;

public class StickSettings
{
    public const sbyte MaxValue = 100;
    public const sbyte MinValue = -100;

    public bool IsEnabled { get; set; } = true;
    public float DeadzonePercent { get; set; } = 25.0F;
    public float RadiusPercent { get; set; } = 100f;
    public bool  IsInverted  { get; set; } = false;

    public sbyte ApplySettings(sbyte stickValue)
    {
        stickValue = ApplyDeadzone(stickValue);
        stickValue = ScaleValue(stickValue);
        if (IsInverted)
            stickValue *= -1;

        return stickValue;
    }

    public sbyte ScaleValue(sbyte stickValue)
    {
        var scaled = stickValue * (RadiusPercent / 100.0f);
        if (scaled > MaxValue)
            scaled = MaxValue;

        if (scaled < MinValue)
            scaled = MinValue;

        return (sbyte) scaled;
    }

    public sbyte ApplyDeadzone(sbyte stickValue)
    {
        if (Math.Abs(stickValue) < DeadzonePercent && IsEnabled)
            return 0;

        return stickValue;
    }

    public override string ToString() => $"Enabled: {IsEnabled}, Deadzone: {DeadzonePercent}, Invert: {IsInverted}";
}