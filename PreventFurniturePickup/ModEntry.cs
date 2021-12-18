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
        public ITranslationHelper I18n;

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            // Read in config file and create if needed
            this.Config = this.Helper.ReadConfig<ModConfig>();

            // Initialize the i18n helper
            this.I18n = this.Helper.Translation;

            // Initialize the error logger in FurniturePatcher
            FurniturePatcher.Initialize(this.Monitor, this.Config);

            // Do the Harmony things
            var harmony = new Harmony(this.ModManifest.UniqueID);
            FurniturePatcher.Apply(harmony);
        }

        private void SetUpConfig(object sender, StardewModdingAPI.Events.GameLaunchedEventArgs e)
        {
            var configMenu = Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
            if (configMenu is null)
                return;

            configMenu.Register(
                mod: ModManifest,
                reset: () => Config = new ModConfig(),
                save: () => Helper.WriteConfig(Config)
                );

            // Put mod description on GMCM page
            configMenu.AddParagraph(
                mod: ModManifest,
                text: () => I18n.Get("mod.description")
                );

            // Put CanPickUpBed on GMCM page
            configMenu.AddBoolOption(
                mod: ModManifest,
                getValue: () => Config.CanPickUpBed,
                setValue: value => Config.CanPickUpBed = value,
                name: () => I18n.Get("CanPickUpBed.title")
                );

            // Put CanPickUpChair on GMCM page
            configMenu.AddBoolOption(
                mod: ModManifest,
                getValue: () => Config.CanPickUpChair,
                setValue: value => Config.CanPickUpChair = value,
                name: () => I18n.Get("CanPickUpChair.title")
                );

            // Put CanPickUpTable on GMCM page
            configMenu.AddBoolOption(
                mod: ModManifest,
                getValue: () => Config.CanPickUpTable,
                setValue: value => Config.CanPickUpTable = value,
                name: () => I18n.Get("CanPickUpTable.title")
                );

            // Put CanPickUpDresser on GMCM page
            configMenu.AddBoolOption(
                mod: ModManifest,
                getValue: () => Config.CanPickUpDresser,
                setValue: value => Config.CanPickUpDresser = value,
                name: () => I18n.Get("CanPickUpDresser.title")
                );

            // Put CanPickUpDecoration on GMCM page
            configMenu.AddBoolOption(
                mod: ModManifest,
                getValue: () => Config.CanPickUpDecoration,
                setValue: value => Config.CanPickUpDecoration = value,
                name: () => I18n.Get("CanPickUpDecoration.title")
                );

            // Put CanPickUpLamp on GMCM page
            configMenu.AddBoolOption(
                mod: ModManifest,
                getValue: () => Config.CanPickUpLamp,
                setValue: value => Config.CanPickUpLamp = value,
                name: () => I18n.Get("CanPickUpLamp.title")
                );

            // Put CanPickUpRug on GMCM page
            configMenu.AddBoolOption(
                mod: ModManifest,
                getValue: () => Config.CanPickUpRug,
                setValue: value => Config.CanPickUpRug = value,
                name: () => I18n.Get("CanPickUpRug.title")
                );

            // Put CanPickUpWindow on GMCM page
            configMenu.AddBoolOption(
                mod: ModManifest,
                getValue: () => Config.CanPickUpWindow,
                setValue: value => Config.CanPickUpWindow = value,
                name: () => I18n.Get("CanPickUpWindow.title")
                );

            // Put CanPickUpFireplace on GMCM page
            configMenu.AddBoolOption(
                mod: ModManifest,
                getValue: () => Config.CanPickUpFireplace,
                setValue: value => Config.CanPickUpFireplace = value,
                name: () => I18n.Get("CanPickUpFireplace.title")
                );

            // Put CanPickUpTorch on GMCM page
            configMenu.AddBoolOption(
                mod: ModManifest,
                getValue: () => Config.CanPickUpTorch,
                setValue: value => Config.CanPickUpTorch = value,
                name: () => I18n.Get("CanPickUpTorch.title")
                );

            // Put CanPickUpSconce on GMCM page
            configMenu.AddBoolOption(
                mod: ModManifest,
                getValue: () => Config.CanPickUpSconce,
                setValue: value => Config.CanPickUpSconce = value,
                name: () => I18n.Get("CanPickUpSconce.title")
                );
        }
    }
}