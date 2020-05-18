using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Riders.Controller.Hook.Interfaces.Structs;
using Riders.Controller.Hook.Interfaces.Structs.Enums;
using Riders.Controller.Hook.XInput.Configuration;
using SharpDX.XInput;

namespace Riders.Controller.Hook.XInput.Utilities
{
    public static class Converter
    {
        public static void ToPlayerInput(ref State state, ref IPlayerInput inputs, Config configuration)
        {
            // Buttons
            if (XInputButtonPressed(ref state, configuration.Accept)) inputs.Buttons |= Buttons.Accept;
            if (XInputButtonPressed(ref state, configuration.Decline)) inputs.Buttons |= Buttons.Decline;

            if (XInputButtonPressed(ref state, configuration.LeftDrift)) inputs.Buttons |= Buttons.LeftDrift;
            if (XInputButtonPressed(ref state, configuration.RightDrift)) inputs.Buttons |= Buttons.RightDrift;
            if (XInputButtonPressed(ref state, configuration.Start)) inputs.Buttons |= Buttons.Start;
            
            if (XInputButtonPressed(ref state, configuration.DpadUp)) inputs.Buttons |= Buttons.DPadUp;
            if (XInputButtonPressed(ref state, configuration.DpadDown)) inputs.Buttons |= Buttons.DPadDown;
            if (XInputButtonPressed(ref state, configuration.DpadLeft)) inputs.Buttons |= Buttons.DPadLeft;
            if (XInputButtonPressed(ref state, configuration.DpadRight)) inputs.Buttons |= Buttons.DPadRight;

            // Triggers.
            inputs.AnalogStickX = (sbyte) XInputRangeToRidersRange(state.Gamepad.LeftThumbX);
            inputs.AnalogStickY = (sbyte) XInputRangeToRidersRange(state.Gamepad.LeftThumbY);

            inputs.LeftBumperPressure = state.Gamepad.LeftTrigger;
            inputs.RightBumperPressure = state.Gamepad.RightTrigger;
        }

        /* XInput Utility Functions */
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool XInputButtonPressed(ref State state, GamepadButtonFlags flag)
        {
            return (state.Gamepad.Buttons & flag) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float XInputRangeToRidersRange(float value)
        {
            return (value / short.MaxValue) * 100;
        }
    }
}
