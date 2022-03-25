using Reloaded.Input.Configurator;
using Reloaded.Input.Structs;
using Riders.Controller.Hook.Custom.Enum;

namespace Riders.Controller.Hook.Custom;

public static class Mappings
{
    public static string[] ControllerFiles =
    {
        "Controller1.json",
        "Controller2.json",
        "Controller3.json",
        "Controller4.json",
        "Controller5.json",
        "Controller6.json",
        "Controller7.json",
        "Controller8.json"
    };

    public static MappingEntry[] Entries = new MappingEntry[]
    {
        new MappingEntry("Jump / Accept", (int) MappingEntries.Accept, MappingType.Button),
        new MappingEntry("Boost / Decline", (int) MappingEntries.Decline, MappingType.Button),
        new MappingEntry("Start", (int) MappingEntries.Start, MappingType.Button),
        new MappingEntry("Left Drift", (int) MappingEntries.LeftDrift, MappingType.Button),
        new MappingEntry("Right Drift", (int) MappingEntries.RightDrift, MappingType.Button),
        new MappingEntry("Tornado", (int) MappingEntries.Tornado, MappingType.Button),

        new MappingEntry("DPad Up", (int) MappingEntries.DPadUp, MappingType.Button),
        new MappingEntry("DPad Down", (int) MappingEntries.DPadDown, MappingType.Button),
        new MappingEntry("DPad Left", (int) MappingEntries.DPadLeft, MappingType.Button),
        new MappingEntry("DPad Right", (int) MappingEntries.DPadRight, MappingType.Button),

        // Button Axis
        new MappingEntry("Up (Button)", (int) MappingEntries.Up, MappingType.Button),
        new MappingEntry("Down (Button)", (int) MappingEntries.Down, MappingType.Button),
        new MappingEntry("Left (Button)", (int) MappingEntries.Left, MappingType.Button),
        new MappingEntry("Right (Button)", (int) MappingEntries.Right, MappingType.Button),

        // Button Axis
        new MappingEntry("Analog Stick X", (int) MappingEntries.LeftStickX, MappingType.Axis),
        new MappingEntry("Analog Stick Y", (int) MappingEntries.LeftStickY, MappingType.Axis),
        new MappingEntry("Left Trigger", (int) MappingEntries.LeftBumperPressure, MappingType.Axis),
        new MappingEntry("Right Trigger", (int) MappingEntries.RightBumperPressure, MappingType.Axis),
    };
}