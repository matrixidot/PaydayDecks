namespace PaydayDecks.Patches;

using Extensions;
using HarmonyLib;

[HarmonyPatch(typeof(CharacterStatModifiers), "ResetStats")]
public class CharacterStatModifierPatchResetStats
{
    private static void Prefix(CharacterStatModifiers __instance)
    {
        __instance.GetAdditionalData().syphoning = false;
        __instance.GetAdditionalData().retaliating = false;
    }  
}