using HarmonyLib;
using UnityEngine;

namespace JuuQoLMod.Patches
{
    [HarmonyPatch(typeof(RoundManager))]
    internal class RoundManagerPatch
    {

        // Shotgun reload 2 ammo when landing
        [HarmonyPatch(nameof(RoundManager.LoadNewLevel))]
        [HarmonyPostfix]
        static void LoadNewLevelPatch(ref RoundManager __instance)
        {
            if(__instance.IsServer)
            {
                ReloadAllShotguns();
            }
        }


        private static void ReloadAllShotguns()
        {
            Debug.Log($"Finding shotguns to realod.");
            var shotguns = Object.FindObjectsOfType<ShotgunItem>();
            
            shotguns.Do(shotgun =>
            {
                Debug.Log($"Shotgun {shotgun.GetInstanceID()} is found and reloading.");
                shotgun.shellsLoaded = 2;
                shotgun.shotgunShellLeft.enabled = true;
                shotgun.shotgunShellRight.enabled = true;
            });
        }
    }
}
