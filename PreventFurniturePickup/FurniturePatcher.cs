using System;
using HarmonyLib;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Objects;

namespace PreventFurniturePickup
{
    public class FurniturePatcher
    {
        private static IMonitor Monitor;
        private static ModConfig Config;

        // call this method from your Entry class
        public static void Initialize(IMonitor monitor, ModConfig config)
        {
            Monitor = monitor;
            Config = config;
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
                Monitor.Log($"Failed to add postfix to furniture canBeRemoved with exception: {ex}", LogLevel.Error);
            }

        }

        // Method that is used to postfix
        private static bool Furniture_canBeRemoved_Postfix(Farmer who, Furniture __instance, ref bool __result)
        {
            try
            {
                switch ((int)__instance.furniture_type)
                {
                    case 0:
                        // For type chair, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpChair)
                        {
                            Monitor.Log($"Preventing player from picking up chair", LogLevel.Debug);
                            return false;
                        }
                        break;
                    case 1:
                        // For type bench, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpChair)
                        {
                            Monitor.Log($"Preventing player from picking up bench", LogLevel.Debug);
                            return false;
                        }
                        break;
                    case 2:
                        // For type couch, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpChair)
                        {
                            Monitor.Log($"Preventing player from picking up couch", LogLevel.Debug);
                            return false;
                        }
                        break;
                    case 3:
                        // For type armchair, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpChair)
                        {
                            Monitor.Log($"Preventing player from picking up armchair", LogLevel.Debug);
                            return false;
                        }
                        break;
                    case 4:
                        // For type dresser, change the result if it would be picked up but the config says not to
                        // Note that this likely has no effect due to the StorageFurniture subclass overriding canBeRemoved
                        if (__result && !Config.CanPickUpDresser)
                        {
                            Monitor.Log($"Preventing player from picking up dresser", LogLevel.Debug);
                            return false;
                        }
                        break;
                    case 5:
                        // For type longTable, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpTable)
                        {
                            Monitor.Log($"Preventing player from picking up long table", LogLevel.Debug);
                            return false;
                        }
                        break;
                    case 6:
                        // For type painting, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpDecoration)
                        {
                            Monitor.Log($"Preventing player from picking up painting", LogLevel.Debug);
                            return false;
                        }
                        break;
                    case 7:
                        // For type lamp, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpLamp)
                        {
                            Monitor.Log($"Preventing player from picking up lamp", LogLevel.Debug);
                            return false;
                        }
                        break;
                    case 8:
                        // For type decor, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpDecoration)
                        {
                            Monitor.Log($"Preventing player from picking up decor", LogLevel.Debug);
                            return false;
                        }
                        break;
                    case 9:
                        // For type other, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpDecoration)
                        {
                            Monitor.Log($"Preventing player from picking up other furniture", LogLevel.Debug);
                            return false;
                        }
                        break;
                    case 10:
                        // For type bookcase, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpDecoration)
                        {
                            Monitor.Log($"Preventing player from picking up bookcase", LogLevel.Debug);
                            return false;
                        }
                        break;
                    case 11:
                        // For type table, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpTable)
                        {
                            Monitor.Log($"Preventing player from picking up table", LogLevel.Debug);
                            return false;
                        }
                        break;
                    case 12:
                        // For type rug, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpRug)
                        {
                            Monitor.Log($"Preventing player from picking up rug", LogLevel.Debug);
                            return false;
                        }
                        break;
                    case 13:
                        // For type window, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpWindow)
                        {
                            Monitor.Log($"Preventing player from picking up window", LogLevel.Debug);
                            return false;
                        }
                        break;
                    case 14:
                        // For type fireplace, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpFireplace)
                        {
                            Monitor.Log($"Preventing player from picking up fireplace", LogLevel.Debug);
                            return false;
                        }
                        break;
                    case 15:
                        // For type bed, change the result if it would be picked up but the config says not to
                        // Note that this likely has no effect due to the Bed subclass overriding canBeRemoved
                        if (__result && !Config.CanPickUpBed)
                        {
                            Monitor.Log($"Preventing player from picking up bed", LogLevel.Debug);
                            return false;
                        }
                        break;
                    case 16:
                        // For type torch, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpTorch)
                        {
                            Monitor.Log($"Preventing player from picking up torch", LogLevel.Debug);
                            return false;
                        }
                        break;
                    case 17:
                        // For type sconce, change the result if it would be picked up but the config says not to
                        if (__result && !Config.CanPickUpSconce)
                        {
                            Monitor.Log($"Preventing player from picking up sconce", LogLevel.Debug);
                            return false;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Monitor.Log($"Failed to change furniture removal behavior with exception: {ex}", LogLevel.Error);
            }

            // Default to not changing anything
            return __result;
        }
    }
}
