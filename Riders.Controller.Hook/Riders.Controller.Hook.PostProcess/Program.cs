using System;
using System.Diagnostics;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using Riders.Controller.Hook.Interfaces;
using Riders.Controller.Hook.Interfaces.Structs;
using Riders.Controller.Hook.PostProcess.Configuration.Implementation;

namespace Riders.Controller.Hook.PostProcess
{
    public class Program : IMod
    {
        /// <summary>
        /// Your mod if from ModConfig.json, used during initialization.
        /// </summary>
        private const string MyModId = "Riders.Controller.Hook.PostProcess";
        private const string HookModId = "Riders.Controller.Hook";

        /// <summary>
        /// Used for writing text to the console window.
        /// </summary>
        public static ILogger Logger;

        /// <summary>
        /// Provides access to the mod loader API.
        /// </summary>
        private IModLoader _modLoader;

        /// <summary>
        /// Provides post-processing for controller inputs.
        /// </summary>
        private PostProcess _postProcess;

        /// <summary>
        /// The controller hook used to manipulate game inputs.
        /// </summary>
        private WeakReference<IControllerHook> _controllerHook;

        /// <summary>
        /// Entry point for your mod.
        /// </summary>
        public void Start(IModLoaderV1 loader)
        {
            _modLoader = (IModLoader)loader;
            Logger = (ILogger)_modLoader.GetLogger();

            _postProcess = new PostProcess(_modLoader.GetDirectoryForModId(MyModId));
            _modLoader.ModLoaded += ModLoaded;
            SetupController();
        }

        private void ModLoaded(IModV1 modInstance, IModConfigV1 modConfig)
        {
            if (modConfig.ModId == HookModId)
                SetupController();
        }

        private void SetupController()
        {
            _controllerHook = _modLoader.GetController<IControllerHook>();
            if (_controllerHook.TryGetTarget(out var target))
                target.PostProcessInputs += TargetOnPostProcessInputs;
        }

        private void TearDownController()
        {
            if (_controllerHook.TryGetTarget(out var target))
                target.PostProcessInputs -= TargetOnPostProcessInputs;
        }

        private void TargetOnPostProcessInputs(ref IPlayerInput inputs, int port)
        {
            _postProcess.PostProcessInputs(ref inputs, port);
        }

        /* Mod loader actions. */
        public void Suspend() => TearDownController();
        public void Resume() => SetupController();
        public void Unload() => TearDownController();

        public bool CanUnload() => true;
        public bool CanSuspend() => true;

        /* Automatically called by the mod loader when the mod is about to be unloaded. */
        public Action Disposing { get; }

        /* This is a dummy for R2R (ReadyToRun) deployment.
           For more details see: https://github.com/Reloaded-Project/Reloaded-II/blob/master/Docs/ReadyToRun.md
        */
        public static void Main() { }
    }
}
