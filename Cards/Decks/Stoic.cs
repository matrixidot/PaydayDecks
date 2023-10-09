namespace PaydayDecks.Cards;

using Abstracts;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using HarmonyLib;
using ModsPlus;
using RarityLib.Utils;
using UnityEngine;

public class Stoic : CustomEffectCard<StoicEffect>
{
    public override CardDetails Details => new()
    {
        Title = "Stoic",
        Description = "All DoT is stored. When you block you heal for 50% of stored DoT and cancel the rest.",
        ModName = $"{PDDecks.ModInitials}",
        Rarity = RarityUtils.GetRarity("Deck"),
        Theme = CardThemeColor.CardThemeColorType.DefensiveBlue,
        Stats = new []
        {
            new CardInfoStat
            {
                positive = true,
                stat = "Health",
                amount = "2x",
            },
            new CardInfoStat
            {
                positive = true,
                stat = "DoT Kickback",
                amount = "50%",
            },
            new CardInfoStat
            {
                positive = true,
                stat = "Damage Taken Over",
                amount = "12s"
            },
            new CardInfoStat
            {
                positive = false,
                stat = "Ability Cooldown",
                amount = "10s",
            },
        },
    };
    
    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        cardInfo.allowMultiple = false;
        cardInfo.categories = new[] { CustomCardCategories.instance.CardCategory("Stoic") };
        cardInfo.blacklistedCategories = new[] { CustomCardCategories.instance.CardCategory("Syphon") };
        statModifiers.secondsToTakeDamageOver = 12f;
    }

    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        data.maxHealth *= 2f;
    }
}

public class StoicEffect : AbilityEffect
{
    public override float cooldown => 10f;
    public override float duration => 0.01f;

    private static float damageStored = 0f;
    public override void OnTakeDamage(Vector2 damage, bool selfDamage)
    {
        if (!selfDamage)
        {
            damageStored += damage.magnitude;
        }
    }

    protected override void StartAbility()
    {
        data.healthHandler.Heal(damageStored * 0.5f);
        damageStored = 0f;
        DamageOverTime dot = (DamageOverTime)Traverse.Create(health).Field("dot").GetValue();
        dot.StopAllCoroutines();
    }

    protected override void Reset()
    {
        damageStored = 0f;
    }
}