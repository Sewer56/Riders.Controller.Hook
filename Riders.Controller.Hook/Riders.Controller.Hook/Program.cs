using System;
using System.Diagnostics;
using Reloaded.Hooks.Definitions;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using Riders.Controller.Hook.Interfaces;
using Sewer56.SonicRiders;
using IReloadedHooks = Reloaded.Hooks.ReloadedII.Interfaces.IReloadedHooks;

namespace Riders.Controller.Hook
{
    public class Program : IMod, IExports
    {
        /// <summary>
        /// Used for writing text to the console window.
        /// </summary>
        private ILogger _logger;

        /// <summary>
        /// Provides access to the mod loader API.
        /// </summary>
        private IModLoader _modLoader;

        /// <summary>
        /// An interface to Reloaded's the function hooks/detours library.
        /// See: https://github.com/Reloaded-Project/Reloaded.Hooks
        ///      for documentation and samples. 
        /// </summary>
        private IReloadedHooks _hooks;
        private IReloadedHooksUtilities _hooksUtilities;

        /// <summary>
        /// Mod instance.
        /// </summary>
        private ControllerHook _hook;

        private FourPlayerPatch _fourPlayerPatch;

        /// <summary>
        /// Entry point for your mod.
        /// </summary>
        public void Start(IModLoaderV1 loader)
        {
            _modLoader = (IModLoader)loader;
            _logger = (ILogger)_modLoader.GetLogger();
            _modLoader.GetController<IReloadedHooks>().TryGetTarget(out _hooks);
            _modLoader.GetController<IReloadedHooksUtilities>().TryGetTarget(out _hooksUtilities);

            /* Your mod code starts here. */
            SDK.Init(_hooks);
            _hook = new ControllerHook(_hooks);
            _fourPlayerPatch = new FourPlayerPatch(_hooks, _hooksUtilities);
            _modLoader.AddOrReplaceController<IControllerHook>(this, _hook);
        }

        /* Mod loader actions. */
        public void Suspend()
        {
            _fourPlayerPatch.Suspend();
            _hook.Suspend();
        }

        public void Resume()
        {
            _fourPlayerPatch.Resume();
            _hook.Resume();
        }

        public void Unload() => Suspend();

        /*  If CanSuspend == false, suspend and resume button are disabled in Launcher and Suspend()/Resume() will never be called.
            If CanUnload == false, unload button is disabled in Launcher and Unload() will never be called.
        */
        public bool CanUnload()  => true;
        public bool CanSuspend() => true;

        /* Automatically called by the mod loader when the mod is about to be unloaded. */
        public Action Disposing { get; }

        /* This is a dummy for R2R (ReadyToRun) deployment.
           For more details see: https://github.com/Reloaded-Project/Reloaded-II/blob/master/Docs/ReadyToRun.md
        */
        public static void Main() { }
        public Type[] GetTypes() => new Type[] { typeof(IControllerHook) };
    }
}
