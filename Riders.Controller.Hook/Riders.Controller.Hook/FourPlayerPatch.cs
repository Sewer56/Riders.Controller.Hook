using System;
using System.Runtime.InteropServices;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using Sewer56.SonicRiders.Functions;
using Sewer56.SonicRiders.Structures.Enums;
using Sewer56.SonicRiders.Utility;

namespace Riders.Controller.Hook
{
    public class FourPlayerPatch
    {
        private IReloadedHooks _hooks;
        private IReloadedHooksUtilities _hooksUtilities;
        private TaskTracker _taskTracker;
        private IHook<Functions.DefaultTaskFnWithReturn> _hook;

        public FourPlayerPatch(IReloadedHooks hooks, IReloadedHooksUtilities hooksUtilities)
        {
            _hooks = hooks;
            _hooksUtilities = hooksUtilities;
            _taskTracker = new TaskTracker();
            _hook = Functions.CharaSelectTask.Hook(CharacterSelectImpl).Activate();
        }

        private unsafe int CharacterSelectImpl()
        {
            if (_taskTracker.CharacterSelect != null && _taskTracker.TitleSequence != null)
            {
                var titleData = _taskTracker.TitleSequence->TaskData;
                var charaData = _taskTracker.CharacterSelect->TaskData;
                switch (titleData->RaceMode)
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
            }

            return _hook.OriginalFunction();
        }

        public void Resume()
        {
            _hook.Enable();
            _taskTracker.Enable();
        }

        public void Suspend()
        {
            _hook.Disable();
            _taskTracker.Disable();
        }
    }
}
