using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using HarmonyLib;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace PreventFurniturePickup
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        // Add a config
        private ModConfig Config;

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            // Read in config file and create if needed
            this.Config = this.Helper.ReadConfig<ModConfig>();

            // Initialize the error logger in FurniturePatcher
            FurniturePatcher.Initialize(this.Monitor, this.Config);

            // Do the Harmony things
            var harmony = new Harmony(this.ModManifest.UniqueID);
            FurniturePatcher.Apply(harmony);
        }


        /*********
        ** Private methods
        *********/

        
    }
}