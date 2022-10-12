<div align="center">
	<h1>Riders Essentials: Controller Hook</h1>
	<img src="https://i.imgur.com/BjPn7rU.png" width="150" align="center" />
	<br/> <br/>
	<strong>Same Game, New Controllers</strong>
    <p>Let's be honest, default input support kinda sucks.<br/></p>
<b>Id: Riders.Controller.Hook</b>
</div>

# Table of Contents
- [About This Project](#about-this-project)
  - [Inside This Repository](#inside-this-repository)
      - [Mods](#mods)
      - [Controllers (For Programmers)](#controllers-for-programmers)
  - [New Features](#new-features)
  - [How to Use](#how-to-use)

# About This Project

This project is a set of mods for [Reloaded II](https://github.com/Reloaded-Project/Reloaded-II) Mod Loader that provide support for sending and post processing of inputs that get sent to the game.

## Inside This Repository

[Hook](https://github.com/Sewer56/Riders.Controller.Hook/blob/master/README-HOOK.md): *Base mod. Provides support for other mods to send inputs to the game.*  
[PostProcess](https://github.com/Sewer56/Riders.Controller.Hook/blob/master/README-POSTPROCESS.md): *Provides support for common input post processing effects such as deadzones, swapping triggers.*  
[Custom](https://github.com/Sewer56/Riders.Controller.Hook/blob/master/README-POSTPROCESS.md): *Adds controller remapping support for both DInput & XInput Controllers.*  
[XInput](https://github.com/Sewer56/Riders.Controller.Hook/blob/master/README-XINPUT.md): *If Custom doesn't work for you, use this for basic 360/XInput controller support.*  
 
(Click one of these links to read the individual mod README(s))

## New Features
- Simulate GameCube Controls.
	- People using controllers might notice that the PC version behaves a bit differently with controllers.
	- The `Post Process` mod has an option to simulate GameCube-like control

- Support 3P, 4P inputs.
	- The game is 4 player, the developers were kinda silly to only restrict the PC version to 2 controllers.
	
	- With some extra hacking (I'll make a mod soon!), 4 player races work perfectly fine.
	
- Full button remapping:
	- The game normally only lets you remap some buttons.
	- This is no longer the case.

## Controllers (For Programmers)
`Riders.Controller.Hook.Interfaces`: *Provides support for other mods to set inputs, do input post processing, receive events on input.* (`IControllerHook`)

## Acknowledgements

[Controller by iconfield from Noun Project](https://thenounproject.com/browse/icons/term/controller/)  