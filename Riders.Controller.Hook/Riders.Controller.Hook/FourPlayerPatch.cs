using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using Sewer56.SonicRiders.Fields;
using Sewer56.SonicRiders.Structures.Enums;

namespace Riders.Controller.Hook
{
    public class FourPlayerPatch
    {
        private IReloadedHooks _hooks;
        private IReloadedHooksUtilities _hooksUtilities;
        private IHook<sub_00462000> _characterSelectHook;

        public FourPlayerPatch(IReloadedHooks hooks, IReloadedHooksUtilities hooksUtilities)
        {
            _hooks = hooks;
            _hooksUtilities = hooksUtilities;
            _characterSelectHook = _hooks.CreateHook<sub_00462000>(CharacterSelectImpl, 0x462000).Activate();
        }

        private unsafe void CharacterSelectImpl()
        {
            Menus.Refresh();
            var characterSelect = Menus.CharacterSelectMenu;
            var mainMenu = Menus.MainMenu;

            switch (mainMenu->RaceMode)
            {
                case RaceMode.TimeTrial:
                    characterSelect->MaximumPlayerCount = 1;
                    break;
                case RaceMode.GrandPrix:
                    characterSelect->MaximumPlayerCount = 2;
                    break;
                default:
                    characterSelect->MaximumPlayerCount = 4;
                    break;
            }

            _characterSelectHook.OriginalFunction();
        }

        public void Resume()
        {
            _characterSelectHook.Enable();
        }

        public void Suspend()
        {
            _characterSelectHook.Disable();
        }

        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void sub_00462000();
    }
}
