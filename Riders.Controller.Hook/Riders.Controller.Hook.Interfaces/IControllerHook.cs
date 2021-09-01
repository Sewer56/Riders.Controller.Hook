﻿using System;
using Riders.Controller.Hook.Interfaces.Structs;

namespace Riders.Controller.Hook.Interfaces
{
    public interface IControllerHook
    {
        /// <summary>
        /// If false, passes no inputs to the game.
        /// </summary>
        bool EnableInputs { get; set; }

        /// <summary>
        /// If true, requires the window to be focused to pass inputs to the game.
        /// </summary>
        bool RequireWindowFocus { get; set; }

        /// <summary>
        /// This event allows you to send inputs to be registered by the game.
        /// Simply edit the passed by reference Inputs structure.
        /// </summary>
        event InputEvent SetInputs;

        /// <summary>
        /// Same as <see cref="SetInputs"/> but executed after <see cref="SetInputs"/>.
        /// Intended use is to provide post processing of inputs supplied by other implementations.
        /// e.g. Flip axis, etc.
        /// </summary>
        event InputEvent PostProcessInputs;

        /// <summary>
        /// This event allows you to receive a copy of the inputs before they are sent to the game.
        /// </summary>
        event OnInputEvent OnInput;
    }

    /// <summary>
    /// Event used for manipulating the inputs sent to the game.
    /// </summary>
    /// <param name="inputs">The inputs structure to be sent to the game.</param>
    /// <param name="port">The controller port.</param>
    public delegate void InputEvent(ref IPlayerInput inputs, int port);

    /// <summary>
    /// Event used for reading the inputs sent to the game right before they are sent to the game.
    /// Modifying the inputs structure has no effect on the game.
    /// </summary>
    /// <param name="inputs">The inputs structure to be sent to the game.</param>
    /// <param name="port">The controller port to get the inputs from.</param>
    public delegate void OnInputEvent(IPlayerInput inputs, int port);
}
