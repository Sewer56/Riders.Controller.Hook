using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Riders.Controller.Hook.Interfaces.Structs;
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

            inputs.AnalogStickX = config.LeftStickXDeadzone.ApplyDeadzone(inputs.AnalogStickX);
            inputs.AnalogStickY = config.LeftStickYDeadzone.ApplyDeadzone(inputs.AnalogStickY);
            inputs.LeftBumperPressure = config.LeftTriggerDeadzone.ApplyDeadzone(inputs.LeftBumperPressure);
            inputs.RightBumperPressure = config.RightTriggerDeadzone.ApplyDeadzone(inputs.RightBumperPressure);

            if (config.SimulateGameCubeAnalogControls)
            {
                var vector = new Vector2(inputs.AnalogStickX, inputs.AnalogStickY);
                var normalized = Vector2.Normalize(vector);
                inputs.AnalogStickX = (sbyte) (normalized.X * 100);
                inputs.AnalogStickY = (sbyte) (normalized.Y * 100);
            }
        }
    }
}
