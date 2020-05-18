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

#### Mods
Hook: *Provides support for sending and post processing inputs to the game.*

PostProcess: *Provides support for common input post processing effects such as deadzones, simulating gamecube .* (Requires Hook)

Custom: *Provides support for custom binding using DInput & XInput Controllers.* (Requires Hook)

XInput: *Provides support for XInput Controllers to be used by the game.* (Requires Hook)

#### Controllers (For Programmers)
Riders.Controller.Hook.Interfaces: *Provides support for other mods to set inputs, do input post processing, receive events on input.*

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

## How to Use
**A.** Install Reloaded Mods as usual. (Extract to mod directory)

**B.** Enable all mods and run the game. (This auto-generates the config files)

**C.** Adjust controller configurations. (if necessary)

Controller configurations can be found in each of the respective mod folders.

`PostProcess` will allow you to adjust individual deadzones for each axis as well as a few other features.
`XInput` will allow you to rebind all of the buttons for your Xbox or Xbox-like controller.
