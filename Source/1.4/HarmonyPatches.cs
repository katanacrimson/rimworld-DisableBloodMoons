using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using RimWorld;
using Verse;
using VanillaRacesExpandedSanguophage;

namespace DisableBloodMoons
{
    [StaticConstructorOnStartup]
    internal class HarmonyPatches
    {
        static HarmonyPatches()
        {
            var harmony = new Harmony("katana.disablebloodmoons");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            Log.Message("[DisableBloodMoons] Loaded");
        }

        [HarmonyPatch(typeof(VanillaRacesExpandedSanguophage.BloodMoon_MapComponent), "MapComponentTick")]
        static class Patch_Blood_Moons_MapComponent
        {
            [HarmonyPrefix]
            static bool MapComponentTick()
            {
                return false;
            }
        }
    }
}
