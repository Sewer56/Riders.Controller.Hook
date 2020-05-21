using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Riders.Controller.Hook.PostProcess.Configuration.Structures
{
    public class TriggerSettings
    {
        public bool IsEnabled { get; set; }
        public float DeadzonePercent { get; set; }
        public float RadiusScale { get; set; } = 1.0f;
        public bool IsInverted   { get; set; } = false;

        
        public float GetMinimumPressure() => (DeadzonePercent / 100.0F) * byte.MaxValue;

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
            var scaled = stickValue * RadiusScale;
            if (scaled > byte.MaxValue)
                scaled = byte.MaxValue;

            return (byte)scaled;
        }

        public byte ApplyDeadzone(byte triggerValue)
        {
            if (triggerValue < GetMinimumPressure() && IsEnabled)
                return 0;

            return triggerValue;
        }

        public override string ToString() => $"Enabled: {IsEnabled}, Deadzone: {DeadzonePercent}, Invert: {IsInverted}";
    }
}
