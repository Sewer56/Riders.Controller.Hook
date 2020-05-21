using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Riders.Controller.Hook.PostProcess.Configuration.Structures
{
    public class StickSettings
    {
        public bool IsEnabled { get; set; } = true;
        public float DeadzonePercent { get; set; } = 25.0F;
        public float RadiusScale { get; set; } = 1.0f;
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
            var scaled = stickValue * RadiusScale;
            if (scaled > sbyte.MaxValue)
                scaled = sbyte.MaxValue;

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
}
