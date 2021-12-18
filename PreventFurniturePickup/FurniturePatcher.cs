using System;
using HarmonyLib;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Objects;
using Microsoft.Xna.Framework;

namespace PreventFurniturePickup
{
    public class FurniturePatcher
    {
        private static IMonitor Monitor;
        private static ModConfig Config;
        private static ITranslationHelper I18n;

        // call this method from your Entry class
        public static void Initialize(IMonitor monitor, ModConfig config, ITranslationHelper translator)
        {
            Monitor = monitor;
            Config = config;
            I18n = translator;
        }

        // Method to apply harmony patch
        public static void Apply(Harmony harmony)
        {
            try
            {
                harmony.Patch(
                    original: AccessTools.Method(typeof(Furniture), nameof(Furniture.canBeRemoved)),
                    postfix: new HarmonyMethod(typeof(FurniturePatcher), nameof(FurniturePatcher.Furniture_canBeRemoved_Postfix))
                );
            }
            catch (Exception ex)
            {
                Monitor.Log($"Failed to add postfix to Furniture canBeRemoved with exception: {ex}", LogLevel.Error);
            }

            try
            {
                harmony.Patch(
                    original: AccessTools.Method(typeof(BedFurniture), nameof(BedFurniture.canBeRemoved)),
                    postfix: new HarmonyMethod(typeof(FurniturePatcher), nameof(FurniturePatcher.BedFurniture_canBeRemoved_Postfix))
                );
            }
            catch (Exception ex)
            {
                Monitor.Log($"Failed to add postfix to BedFurniture canBeRemoved with exception: {ex}", LogLevel.Error);
            }

        }

        // Method that is used to postfix for most furniture types
        private static void Furniture_canBeRemoved_Postfix(Farmer who, Furniture __instance, ref bool __result)
        {
            try
            {
                Vector2 position = ((!Game1.wasMouseVisibleThisFrame) ? Game1.player.GetToolLocation() : new Vector2(Game1.getOldMouseX() + Game1.viewport.X, Game1.getOldMouseY() + Game1.viewport.Y));

                switch ((int)__instance.furniture_type)
                {
                    case 0:
                        // For type chair, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpChair)
                        {
                            Monitor.Log($"Preventing player from picking up chair", LogLevel.Trace);
                            Game1.showRedMessage(I18n.Get("CanPickUpChair.error"));
                            __result = false;
                            return;
                        }
                        break;
                    case 1:
                        // For type bench, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpChair)
                        {
                            Monitor.Log($"Preventing player from picking up bench", LogLevel.Trace);
                            Game1.showRedMessage(I18n.Get("CanPickUpChair.error"));
                            __result = false;
                            return;
                        }
                        break;
                    case 2:
                        // For type couch, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpChair)
                        {
                            Monitor.Log($"Preventing player from picking up couch", LogLevel.Trace);
                            Game1.showRedMessage(I18n.Get("CanPickUpChair.error"));
                            __result = false;
                            return;
                        }
                        break;
                    case 3:
                        // For type armchair, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpChair)
                        {
                            Monitor.Log($"Preventing player from picking up armchair", LogLevel.Trace);
                            Game1.showRedMessage(I18n.Get("CanPickUpChair.error"));
                            __result = false;
                            return;
                        }
                        break;
                    case 4:
                        // For type dresser, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpDresser)
                        {
                            Monitor.Log($"Preventing player from picking up dresser", LogLevel.Trace);
                            Game1.showRedMessage(I18n.Get("CanPickUpDresser.error"));
                            __result = false;
                            return;
                        }
                        break;
                    case 5:
                        // For type longTable, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpTable)
                        {
                            Monitor.Log($"Preventing player from picking up long table", LogLevel.Trace);
                            Game1.showRedMessage(I18n.Get("CanPickUpTable.error"));
                            __result = false;
                            return;
                        }
                        break;
                    case 6:
                        // For type painting, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpDecoration)
                        {
                            // Need to check that we're actually trying to pick up this painting
                            if (__instance.boundingBox.Value.Contains(position.X, position.Y))
                            {
                                Monitor.Log($"Preventing player from picking up painting", LogLevel.Trace);
                                Game1.showRedMessage(I18n.Get("CanPickUpDecoration.error"));
                                __result = false;
                                return;
                            }
                        }
                        break;
                    case 7:
                        // For type lamp, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpLamp)
                        {
                            Monitor.Log($"Preventing player from picking up lamp", LogLevel.Trace);
                            Game1.showRedMessage(I18n.Get("CanPickUpLamp.error"));
                            __result = false;
                            return;
                        }
                        break;
                    case 8:
                        // For type decor, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpDecoration)
                        {
                            Monitor.Log($"Preventing player from picking up decor", LogLevel.Trace);
                            Game1.showRedMessage(I18n.Get("CanPickUpDecoration.error"));
                            __result = false;
                            return;
                        }
                        break;
                    case 9:
                        // For type other, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpDecoration)
                        {
                            Monitor.Log($"Preventing player from picking up other furniture", LogLevel.Trace);
                            Game1.showRedMessage(I18n.Get("CanPickUpDecoration.error"));
                            __result = false;
                            return;
                        }
                        break;
                    case 10:
                        // For type bookcase, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpDecoration)
                        {
                            Monitor.Log($"Preventing player from picking up bookcase", LogLevel.Trace);
                            Game1.showRedMessage(I18n.Get("CanPickUpDecoration.error"));
                            __result = false;
                            return;
                        }
                        break;
                    case 11:
                        // For type table, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpTable)
                        {
                            Monitor.Log($"Preventing player from picking up table", LogLevel.Trace);
                            Game1.showRedMessage(I18n.Get("CanPickUpTable.error"));
                            __result = false;
                            return;
                        }
                        break;
                    case 12:
                        // For type rug, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpRug)
                        {
                            Monitor.Log($"Preventing player from picking up rug", LogLevel.Trace);
                            Game1.showRedMessage(I18n.Get("CanPickUpRug.error"));
                            __result = false;
                            return;
                        }
                        break;
                    case 13:
                        // For type window, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpWindow)
                        {
                            // Need to check that we're actually trying to pick up this window
                            if (__instance.boundingBox.Value.Contains(position.X, position.Y))
                            {
                                Monitor.Log($"Preventing player from picking up window", LogLevel.Trace);
                                Game1.showRedMessage(I18n.Get("CanPickUpWindow.error"));
                                __result = false;
                                return;
                            }
                        }
                        break;
                    case 14:
                        // For type fireplace, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpFireplace)
                        {
                            Monitor.Log($"Preventing player from picking up fireplace", LogLevel.Trace);
                            Game1.showRedMessage(I18n.Get("CanPickUpFireplace.error"));
                            __result = false;
                            return;
                        }
                        break;
                    case 15:
                        // For type bed, need to postfix BedFurniture canBeRemoved() specifically
                        break;
                    case 16:
                        // For type torch, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpTorch)
                        {
                            Monitor.Log($"Preventing player from picking up torch", LogLevel.Trace);
                            Game1.showRedMessage(I18n.Get("CanPickUpTorch.error"));
                            __result = false;
                            return;
                        }
                        break;
                    case 17:
                        // For type sconce, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpSconce)
                        {
                            // Need to check that we're actually trying to pick up this sconce
                            if (__instance.boundingBox.Value.Contains(position.X, position.Y))
                            {
                                Monitor.Log($"Preventing player from picking up sconce", LogLevel.Trace);
                                Game1.showRedMessage(I18n.Get("CanPickUpSconce.error"));
                                __result = false;
                                return;
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Monitor.Log($"Failed to change furniture removal behavior with exception: {ex}", LogLevel.Error);
            }

            return;
        }
        // Method that is used to postfix beds specifically
        private static void BedFurniture_canBeRemoved_Postfix(Farmer who, Furniture __instance, ref bool __result)
        {
            try
            {
                // For type bed, change the result if it would be picked up but the config says not to
                if (__result && !Config.CanPickUpBed)
                {
                    Monitor.Log($"Preventing player from picking up bed", LogLevel.Trace);
                    Game1.showRedMessage(I18n.Get("CanPickUpBed.error"));
                    __result = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                Monitor.Log($"Failed to change bed removal behavior with exception: {ex}", LogLevel.Error);
            }
        }
    }
}
