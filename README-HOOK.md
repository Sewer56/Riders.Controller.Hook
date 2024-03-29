# About Controller Hook

This is the base mod that allows for sending of inputs to Sonic Riders from other mods. It is used by mods like [PostProcess (Deadzones etc.)](https://github.com/Sewer56/Riders.Controller.Hook/blob/master/README-POSTPROCESS.md) and [Custom Mapping (DInput+XInput Support etc.)](https://github.com/Sewer56/Riders.Controller.Hook/blob/master/README-POSTPROCESS.md).

## Usage (for Programmers)  

Add dependency on `Riders Controller Hook` to your mod.  
Add project reference to `Riders.Controller.Hook.Interfaces`.  
Use `GetController<IControllerHook>`.  

If you are not familiar with using other mods from your Reloaded mod, please read [Dependency Injection](https://reloaded-project.github.io/Reloaded-II/DependencyInjection_Consumer/).

## Acknowledgements

[Controller by iconfield from Noun Project](https://thenounproject.com/browse/icons/term/controller/)  