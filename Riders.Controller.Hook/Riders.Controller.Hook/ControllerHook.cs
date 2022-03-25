using System.Runtime.InteropServices;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using Riders.Controller.Hook.Interfaces;
using Riders.Controller.Hook.Interfaces.Structs;
using Riders.Controller.Hook.Structs;
using Sewer56.SonicRiders.API;
using IReloadedHooks = Reloaded.Hooks.ReloadedII.Interfaces.IReloadedHooks;

namespace Riders.Controller.Hook;

public class ControllerHook : IControllerHook
{
    private IReloadedHooks _hooks;
    private IHook<HandleInputs> _inputsHook;
    private Sewer56.SonicRiders.Structures.Input.PlayerInput[] _lastFrameInputs;
    private int _frameCounter = 0;

    public bool EnableInputs { get; set; } = true;
    public bool RequireWindowFocus { get; set; } = true;

    public ControllerHook(IReloadedHooks hooks)
    {
        _hooks = hooks;
        _inputsHook = _hooks.CreateHook<HandleInputs>(HandleInputsImpl, 0x00513B70).Activate();
        _lastFrameInputs = new Sewer56.SonicRiders.Structures.Input.PlayerInput[Player.MaxNumberOfPlayers];
    }

    private unsafe int HandleInputsImpl()
    {
        if (!EnableInputs)
        {
            ClearInputs();
            return 0;
        }

        bool isActivated = RequireWindowFocus ? Window.IsAnyWindowActivated() : true;
        if (isActivated)
        {
            _frameCounter += 1;
            if (SetInputs == null)
            {
                var result = _inputsHook.OriginalFunction();
                for (int x = 0; x < Player.MaxNumberOfPlayers; x++)
                    OnInput?.Invoke(PlayerInput.FromLibrary(ref Player.Inputs[x]), x);

                return result;
            }

            for (int x = 0; x < Player.MaxNumberOfPlayers; x++)
            {
                // Get inputs from player and convert to our format.
                IPlayerInput inputs = new PlayerInput();

                // Send inputs to other mods.
                SetInputs?.Invoke(ref inputs, x);

                // Post process inputs.
                PostProcessInputs?.Invoke(ref inputs, x);

                // Send copy of inputs to subscribers.
                OnInput?.Invoke(inputs, x);

                // Convert back to original struct and figure out some remaining members.
                var playerInputs = (PlayerInput)inputs;
                var libraryInputs = playerInputs.ToLibrary();

                // Add newly pressed and released buttons.
                libraryInputs.Finalize(ref _lastFrameInputs[x], _frameCounter);

                // Write inputs back to player.
                _lastFrameInputs[x] = libraryInputs;
                Player.Inputs[x] = libraryInputs;
            }

            // Handle menu.
            var playerOneInputs = Player.Inputs[0];
            *Player.MenuInputPress = playerOneInputs.ButtonsPressed;
            *Player.MenuInputHold = playerOneInputs.Flicker;

            if (_frameCounter >= Sewer56.SonicRiders.Structures.Input.PlayerInput.TickPeriodFrames)
                _frameCounter = 0;
        }
        else
        {
            ClearInputs();
        }

        return (0);
    }

    private unsafe void ClearInputs()
    {
        for (int x = 0; x < Player.MaxNumberOfPlayers; x++)
        {
            var libraryInputs = new Sewer56.SonicRiders.Structures.Input.PlayerInput();
            libraryInputs.Finalize(ref _lastFrameInputs[x], _frameCounter);
            Player.Inputs[x] = libraryInputs;
        }

        *Player.MenuInputPress = default;
        *Player.MenuInputHold = default;
    }

    /* Events */
    public void Unload() { }
    public void Suspend() => Unload();
    public void Resume() { }

    /* Function Definitions */
    [Function(CallingConventions.Cdecl)]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int HandleInputs();

    public event InputEvent SetInputs;
    public event InputEvent PostProcessInputs;
    public event OnInputEvent OnInput;
}