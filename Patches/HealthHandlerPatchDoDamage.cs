namespace PaydayDecks.Patches;

using Extensions;
using HarmonyLib;
using UnityEngine;

[Serializable]
[HarmonyPatch(typeof(HealthHandler), "DoDamage")]
public class HealthHandlerPatchDoDamage
{
    private static void Prefix(HealthHandler __instance, ref Vector2 damage, Vector2 position, Color blinkColor, GameObject damagingWeapon, Player damagingPlayer, bool healthRemoval, ref bool lethal, bool ignoreBlock)
    {
        CharacterData data = (CharacterData)Traverse.Create(__instance).Field("data").GetValue();
        if (!data.isPlaying)
            return;
        if (data.dead)
            return;
        if (__instance.isRespawning)
            return;
        if (data.block.IsBlocking() && !ignoreBlock)
            return;
        
        if (data.stats.GetAdditionalData().syphoning && (lethal || data.health < damage.magnitude))
        {
            damage = Vector2.zero;
            lethal = false;
            data.health = Mathf.Max(0.1f, data.health - (0.1f * data.maxHealth));
        }
    }
}