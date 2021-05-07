using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Riders.Controller.Hook.Interfaces.Structs;
using Riders.Controller.Hook.Interfaces.Structs.Enums;
using Riders.Controller.Hook.PostProcess.Configuration;
using Riders.Controller.Hook.PostProcess.Configuration.Implementation;

namespace Riders.Controller.Hook.PostProcess
{
    public class PostProcess
    {
        private Config[] _configurations;
        private Configurator _configurator;

        public PostProcess(string modFolder)
        {
            _configurator = new Configurator(modFolder);
            _configurations = new Config[_configurator.Configurations.Length];
            for (int x = 0; x < _configurations.Length; x++)
            {
                _configurations[x] = _configurator.GetConfiguration<Config>(x);

                // Self-updating Controller Bindings 
                var controllerId = x;
                _configurations[x].ConfigurationUpdated += configurable =>
                {
                    _configurations[controllerId] = (Config)configurable;
                    Program.Logger.WriteLine($"[PostProcess/Riders] Configuration for port {controllerId} updated.");
                };
            }
        }

        /// <summary>
        /// Sends inputs to the Inter Mod Communication's <see cref="Inputs"/> structure.
        /// </summary>
        public void PostProcessInputs(ref IPlayerInput inputs, int port)
        {
            var config = _configurations[port];

            inputs.AnalogStickX = config.LeftStickXSettings.ApplySettings(inputs.AnalogStickX);
            inputs.AnalogStickY = config.LeftStickYSettings.ApplySettings(inputs.AnalogStickY);
            inputs.LeftBumperPressure = config.LeftTriggerSettings.ApplySettings(inputs.LeftBumperPressure);
            inputs.RightBumperPressure = config.RightTriggerSettings.ApplySettings(inputs.RightBumperPressure);

            if (config.LeftTriggerSettings.IsSimulatingDigitalInput(inputs.LeftBumperPressure))
                inputs.Buttons |= Buttons.LeftDrift;

            if (config.RightTriggerSettings.IsSimulatingDigitalInput(inputs.RightBumperPressure))
                inputs.Buttons |= Buttons.RightDrift;

            if (config.SimulateGameCubeAnalogControls)
            {
                var vector     = new Vector2(inputs.AnalogStickX, inputs.AnalogStickY);
                var length     = vector.Length();
                var normalized = Vector2.Normalize(vector);
                inputs.AnalogStickX = (sbyte) (normalized.X * length);
                inputs.AnalogStickY = (sbyte) (normalized.Y * length);
            }
        }
    }
}
