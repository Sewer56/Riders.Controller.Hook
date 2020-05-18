using System;
using System.Collections.ObjectModel;
using System.IO;
using Reloaded.Input;
using Reloaded.Input.Configurator;
using Reloaded.Input.Configurator.WPF;
using Reloaded.Input.Structs;
using Riders.Controller.Hook.Custom.Enum;
using Riders.Controller.Hook.Interfaces.Structs;
using Riders.Controller.Hook.Interfaces.Structs.Enums;

namespace Riders.Controller.Hook.Custom
{
    public class Input
    {
            private string ModFolder;
        private VirtualController[] Controllers;

        public Input(string modFolder)
        {
            ModFolder = modFolder;
            Controllers = new VirtualController[8];
            for (int x = 0; x < Mappings.ControllerFiles.Length; x++)
                Controllers[x] = new VirtualController(Path.Combine(ModFolder, Mappings.ControllerFiles[x]));
        }

        public void SetInputs(ref IPlayerInput inputs, in int port)
        {
            if (port >= 0 && port < Controllers.Length)
            {
                var controller = Controllers[port];
                if (controller.GetButton((int) MappingEntries.Accept)) inputs.Buttons |= Buttons.Accept;
                if (controller.GetButton((int) MappingEntries.Decline)) inputs.Buttons |= Buttons.Decline;
                if (controller.GetButton((int) MappingEntries.DPadUp)) inputs.Buttons |= Buttons.DPadUp;
                if (controller.GetButton((int) MappingEntries.DPadDown)) inputs.Buttons |= Buttons.DPadDown;
                if (controller.GetButton((int) MappingEntries.DPadLeft)) inputs.Buttons |= Buttons.DPadLeft;
                if (controller.GetButton((int) MappingEntries.DPadRight)) inputs.Buttons |= Buttons.DPadRight;
                if (controller.GetButton((int) MappingEntries.Start)) inputs.Buttons |= Buttons.Start;
                if (controller.GetButton((int) MappingEntries.LeftDrift)) inputs.Buttons |= Buttons.LeftDrift;
                if (controller.GetButton((int) MappingEntries.RightDrift)) inputs.Buttons |= Buttons.RightDrift;
                if (controller.GetButton((int) MappingEntries.Tornado)) inputs.Buttons |= (Buttons.LeftDrift | Buttons.RightDrift);

                // Axis
                var leftStickX = controller.GetAxis((int) MappingEntries.LeftStickX);
                var leftStickY = controller.GetAxis((int) MappingEntries.LeftStickY);
                var leftBumper = controller.GetAxis((int) MappingEntries.LeftBumperPressure);
                var rightBumper = controller.GetAxis((int) MappingEntries.RightBumperPressure);
                inputs.AnalogStickX = AnalogToRidersRange(leftStickX);
                inputs.AnalogStickY = AnalogToRidersRange(leftStickY);

                if (controller.GetMapping((int)MappingEntries.LeftBumperPressure) != null)
                    inputs.LeftBumperPressure = TriggerToRidersRange(leftBumper);

                if (controller.GetMapping((int)MappingEntries.RightBumperPressure) != null)
                    inputs.RightBumperPressure = TriggerToRidersRange(rightBumper);

                // Button to Axis
                if (controller.GetButton((int)MappingEntries.Up)) inputs.AnalogStickY = 100;
                if (controller.GetButton((int)MappingEntries.Down)) inputs.AnalogStickY = -100;
                if (controller.GetButton((int)MappingEntries.Left)) inputs.AnalogStickX = -100;
                if (controller.GetButton((int)MappingEntries.Right)) inputs.AnalogStickX = 100;
            }
        }

        public void Configure()
        {
            // Make a new WPF Application
            var configurator = new Configurator();

            // Make the configurator inputs.
            var input = new ConfiguratorInput[Mappings.ControllerFiles.Length];
            for (int x = 0; x < input.Length; x++)
                input[x] = new ConfiguratorInput($"Controller {x}", Path.Combine(ModFolder, Mappings.ControllerFiles[x]), new ObservableCollection<MappingEntry>(Mappings.Entries));

            // Run the main window.
            configurator.Run(new ConfiguratorWindow(input));
        }


        private sbyte AnalogToRidersRange(float analogOriginal)
        {
            return (sbyte) (analogOriginal / 100.0f);
        }

        private byte TriggerToRidersRange(float analogOriginal)
        {
            return (byte) ((((analogOriginal + AxisSet.MaxValue) / 2) / AxisSet.MaxValue) * byte.MaxValue);
        }
    }
}
