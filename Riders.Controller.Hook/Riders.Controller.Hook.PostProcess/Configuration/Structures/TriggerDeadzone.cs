using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Riders.Controller.Hook.PostProcess.Configuration.Structures
{
    public class TriggerDeadzone
    {
        public bool IsEnabled { get; set; }
        public float DeadzonePercent { get; set; }

        [JsonIgnore]
        public float MinimumPressure => (DeadzonePercent / 100.0F) * byte.MaxValue;

        /// <summary>
        /// Applies the deadzone to the provided trigger value.
        /// If the value is in the deadzone and the deadzone is enabled, returns 0, otherwise returns original value.
        /// </summary>
        /// <param name="triggerValue">Value between 0 and 255.</param>
        public byte ApplyDeadzone(byte triggerValue)
        {
            if (triggerValue < MinimumPressure && IsEnabled)
                return 0;

            return triggerValue;
        }

        public override string ToString() => $"Enabled: {IsEnabled}, DeadzonePercent: {DeadzonePercent}";
    }
}
