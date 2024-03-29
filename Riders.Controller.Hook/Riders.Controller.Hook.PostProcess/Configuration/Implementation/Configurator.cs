﻿using Reloaded.Mod.Interfaces;

namespace Riders.Controller.Hook.PostProcess.Configuration.Implementation;

public class Configurator : IConfiguratorV2
{
    /// <summary>
    /// The folder where the modification files are stored.
    /// </summary>
    public string ModFolder { get; private set; }

    /// <summary>
    /// Full path to the config folder.
    /// </summary>
    public string ConfigFolder { get; private set; }

    /// <summary>
    /// Returns a list of configurations.
    /// </summary> 
    public IUpdatableConfigurable[] Configurations => _configurations ?? MakeConfigurations();
    private IUpdatableConfigurable[] _configurations;

    private IUpdatableConfigurable[] MakeConfigurations()
    {
        _configurations = new IUpdatableConfigurable[]
        {
            // Add more configurations here if needed.
            Configurable<Config>.FromFile(Path.Combine(ConfigFolder, "Controller0.json"), "Controller Port 0"),
            Configurable<Config>.FromFile(Path.Combine(ConfigFolder, "Controller1.json"), "Controller Port 1"),
            Configurable<Config>.FromFile(Path.Combine(ConfigFolder, "Controller2.json"), "Controller Port 2"),
            Configurable<Config>.FromFile(Path.Combine(ConfigFolder, "Controller3.json"), "Controller Port 3"),
            Configurable<Config>.FromFile(Path.Combine(ConfigFolder, "Controller4.json"), "Controller Port 4"),
            Configurable<Config>.FromFile(Path.Combine(ConfigFolder, "Controller5.json"), "Controller Port 5"),
            Configurable<Config>.FromFile(Path.Combine(ConfigFolder, "Controller6.json"), "Controller Port 6"),
            Configurable<Config>.FromFile(Path.Combine(ConfigFolder, "Controller7.json"), "Controller Port 7")
        };

        // Add self-updating to configurations.
        for (int x = 0; x < Configurations.Length; x++)
        {
            var xCopy = x;
            Configurations[x].ConfigurationUpdated += configurable =>
            {
                Configurations[xCopy] = configurable;
            };
        }

        return _configurations;
    }

    public Configurator() { }
    public Configurator(string configDirectory) : this()
    {
        ConfigFolder = configDirectory;
    }

    /* Configurator V2 */

    /// <summary>
    /// Migrates from the old config location to the newer config location.
    /// </summary>
    /// <param name="oldDirectory">Old directory containing the mod configs.</param>
    /// <param name="newDirectory">New directory pointing to user config folder.</param>
    public void Migrate(string oldDirectory, string newDirectory)
    {
        // Uncomment and Modify if needed if migrating from older version.
        TryMoveFile("Controller0.json");
        TryMoveFile("Controller1.json");
        TryMoveFile("Controller2.json");
        TryMoveFile("Controller3.json");
        TryMoveFile("Controller4.json");
        TryMoveFile("Controller5.json");
        TryMoveFile("Controller6.json");
        TryMoveFile("Controller7.json");

        void TryMoveFile(string fileName)
        {
            try { File.Move(Path.Combine(oldDirectory, fileName), Path.Combine(newDirectory, fileName), true); }
            catch (Exception) { /* Ignored */ }
        }
    }

    /* Configurator */

    /// <summary>
    /// Gets an individual user configuration.
    /// </summary>
    public TType GetConfiguration<TType>(int index) => (TType)Configurations[index];

    /* IConfigurator. */

    /// <summary>
    /// Sets the config directory for the Configurator.
    /// </summary>
    public void SetConfigDirectory(string configDirectory) => ConfigFolder = configDirectory;

    /// <summary>
    /// Returns a list of user configurations.
    /// </summary>
    public IConfigurable[] GetConfigurations() => Configurations;

    /// <summary>
    /// Allows for custom launcher/configurator implementation.
    /// If you have your own configuration program/code, run that code here and return true, else return false.
    /// </summary>
    public bool TryRunCustomConfiguration() => false;

    /// <summary>
    /// Sets the mod directory for the Configurator.
    /// </summary>
    public void SetModDirectory(string modDirectory) { ModFolder = modDirectory; }
}