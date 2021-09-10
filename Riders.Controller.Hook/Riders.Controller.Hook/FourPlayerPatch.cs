using System;
using System.Runtime.InteropServices;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using Sewer56.SonicRiders.API;
using Sewer56.SonicRiders.Functions;
using Sewer56.SonicRiders.Structures.Enums;
using Sewer56.SonicRiders.Structures.Tasks;
using Sewer56.SonicRiders.Structures.Tasks.Base;
using Sewer56.SonicRiders.Structures.Tasks.Enums.States;
using Sewer56.SonicRiders.Utility;

namespace Riders.Controller.Hook
{
    public class FourPlayerPatch
    {
        private IReloadedHooks _hooks;
        private IReloadedHooksUtilities _hooksUtilities;

        private IHook<Functions.CdeclReturnByteFn> _titleHook;
        private IHook<Functions.CdeclReturnByteFn> _charaSelectHook;
        private RaceMode _mode;

        public FourPlayerPatch(IReloadedHooks hooks, IReloadedHooksUtilities hooksUtilities)
        {
            _hooks = hooks;
            _hooksUtilities = hooksUtilities;
            _titleHook = Functions.TitleSequenceTask.Hook(TitleSequenceImpl).Activate();
            _charaSelectHook = Functions.CharaSelectTask.Hook(CharacterSelectImpl).Activate();
        }

        private unsafe byte TitleSequenceImpl()
        {
            var task = (Task<TitleSequence, TitleSequenceTaskState>*)(*State.CurrentTask);
            _mode = task->TaskData->RaceMode;
            return _titleHook.OriginalFunction();
        }

        private unsafe byte CharacterSelectImpl()
        {
            var task = (Task<CharacterSelect, CharacterSelectTaskState>*)(*State.CurrentTask);
            var charaData = task->TaskData;

            switch (_mode)
            {
                case RaceMode.TimeTrial:
                    charaData->MaximumPlayerCount = 1;
                    break;
                case RaceMode.GrandPrix:
                    charaData->MaximumPlayerCount = 2;
                    break;
                default:
                    charaData->MaximumPlayerCount = 4;
                    break;
            }

            return _charaSelectHook.OriginalFunction();
        }

        public void Resume()
        {
            _charaSelectHook.Enable();
            _titleHook.Enable();
        }

        public void Suspend()
        {
            _charaSelectHook.Disable();
            _titleHook.Disable();
        }
    }
}
