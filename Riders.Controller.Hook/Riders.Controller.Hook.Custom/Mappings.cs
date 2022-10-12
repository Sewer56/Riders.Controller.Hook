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
        new("Jump / Accept", (int) MappingEntries.Accept, MappingType.Button, "Makes the character jump."),
        new("Boost / Decline", (int) MappingEntries.Decline, MappingType.Button, "Makes the character boost."),
        new("Start", (int) MappingEntries.Start, MappingType.Button, "Pauses the game."),
        new("Left Drift", (int) MappingEntries.LeftDrift, MappingType.Button, "Makes the player drift."),
        new("Right Drift", (int) MappingEntries.RightDrift, MappingType.Button, "Makes the character drift (alternative)."),
        new("Tornado", (int) MappingEntries.Tornado, MappingType.Button, "Places a tornado down (macro for both drift buttons)."),

        new("DPad Up", (int) MappingEntries.DPadUp, MappingType.Button),
        new("DPad Down", (int) MappingEntries.DPadDown, MappingType.Button),
        new("DPad Left", (int) MappingEntries.DPadLeft, MappingType.Button),
        new("DPad Right", (int) MappingEntries.DPadRight, MappingType.Button),

        // Button Axis
        new("Up (Button)", (int) MappingEntries.Up, MappingType.Button, "Button that emulates analog stick up (use with Keyboard etc.)."),
        new("Down (Button)", (int) MappingEntries.Down, MappingType.Button, "Button that emulates analog stick down (use with Keyboard etc.)."),
        new("Left (Button)", (int) MappingEntries.Left, MappingType.Button, "Button that emulates analog stick left (use with Keyboard etc.)."),
        new("Right (Button)", (int) MappingEntries.Right, MappingType.Button, "Button that emulates analog stick right (use with Keyboard etc.)."),

        // Button Axis
        new("Analog Stick X", (int) MappingEntries.LeftStickX, MappingType.Axis, "Horizontal movement of the left analog stick."),
        new("Analog Stick Y", (int) MappingEntries.LeftStickY, MappingType.Axis, "Vertical movement of the left analog stick."),
        new("Left Trigger", (int) MappingEntries.LeftBumperPressure, MappingType.Axis, "Makes you drift."),
        new("Right Trigger", (int) MappingEntries.RightBumperPressure, MappingType.Axis, "Makes you drift."),
    };
}