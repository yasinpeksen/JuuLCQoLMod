using HarmonyLib;
using System;
using UnityEngine;


namespace JuuQoLMod.Patches
{
    [HarmonyPatch(typeof(SprayPaintItem))]
    internal class SprayPaintItemPatch
    {

        // Infinite Spray
        [HarmonyPatch(nameof(SprayPaintItem.ItemActivate))]
        [HarmonyPostfix]
        static void ItemActivateFix(ref float ___sprayCanTank)
        {
            ___sprayCanTank = 1f;
        }

        // Color Change
        [HarmonyPatch(nameof(SprayPaintItem.ItemInteractLeftRight))]
        [HarmonyPostfix]
        static void ItemInteractLeftRightFix(bool right, ref SprayPaintItem __instance, ref int ___sprayCanMatsIndex)
        {
            if (right && !(__instance.playerHeldBy == null))
            {
                ___sprayCanMatsIndex++;
                if (___sprayCanMatsIndex >= __instance.sprayCanMats.Length) ___sprayCanMatsIndex = 0;

                Debug.Log($"Color Index {___sprayCanMatsIndex}!");
                __instance.sprayParticle.GetComponent<ParticleSystemRenderer>().material = __instance.particleMats[___sprayCanMatsIndex];
                __instance.sprayCanNeedsShakingParticle.GetComponent<ParticleSystemRenderer>().material = __instance.particleMats[___sprayCanMatsIndex];
            }
        }


        // Lower Audio Volume
        [HarmonyPatch(nameof(SprayPaintItem.Start))]
        [HarmonyPostfix]
        static void StartFix(ref SprayPaintItem __instance)
        {
            __instance.sprayAudio.volume = 0.25f;
        }


    }
}
