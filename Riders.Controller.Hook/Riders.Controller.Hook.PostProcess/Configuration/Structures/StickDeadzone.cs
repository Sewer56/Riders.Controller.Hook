using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Riders.Controller.Hook.PostProcess.Configuration.Structures
{
    public class StickDeadzone
    {
        public bool IsEnabled { get; set; } = true;
        public float DeadzonePercent { get; set; } = 25.0F;

        /// <summary>
        /// Applies the deadzone to the provided stick value.
        /// If the value is in the deadzone and the deadzone is enabled, returns 0, otherwise returns original value.
        /// </summary>
        /// <param name="stickValue">Value between 0 and 1.0.</param>
        public sbyte ApplyDeadzone(sbyte stickValue)
        {
            if (Math.Abs(stickValue) < DeadzonePercent && IsEnabled)
                return 0;

            return stickValue;
        }

        public override string ToString() => $"Enabled: {IsEnabled}, DeadzonePercent: {DeadzonePercent}";
    }
}
