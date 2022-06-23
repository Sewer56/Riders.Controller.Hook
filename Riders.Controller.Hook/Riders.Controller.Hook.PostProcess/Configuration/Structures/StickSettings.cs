using System;
using System.ComponentModel;

namespace Riders.Controller.Hook.PostProcess.Configuration.Structures;

public class StickSettings
{
    public const sbyte MaxValue = 100;
    public const sbyte MinValue = -100;

    [DisplayName("Deadzone (Percent)")]
    [Description("When the stick is under this value (in percent), the value is reported to the game as 0.")]
    [DefaultValue(25.0f)]
    public float DeadzonePercent { get; set; } = 25.0F;

    [DisplayName("Stick Radius")]
    [Description("The radius of the stick in this axis.\n" +
                 "Example: A value of 50 means the game will only see the stick\n" +
                 "moved 50% of the way across when fully held in the direction.")]
    [DefaultValue(100f)]
    public float RadiusPercent { get; set; } = 100f;

    [DisplayName("Invert Stick")]
    [Description("Reverses the direction of the stick in this axis.")]
    [DefaultValue(false)]
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
        if (Math.Abs(stickValue) < DeadzonePercent)
            return 0;

        return stickValue;
    }

    public override string ToString() => $" Deadzone: {DeadzonePercent}, Invert: {IsInverted}";
}