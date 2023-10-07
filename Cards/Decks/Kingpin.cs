namespace PaydayDecks.Cards;

using Abstracts;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using Extensions;
using ModsPlus;
using RarityLib.Utils;
using UnityEngine;

public class Kingpin : CustomEffectCard<KingpinEffect>
{
    public override CardDetails Details => new()
    {
        Title = "Kingpin",
        Description = "On block: Inject yourself with goods.\n" +
                      "While Injecting: Heal for 99% of damage taken. Lasts 10s",
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
                simepleAmount = CardInfoStat.SimpleAmount.aLotOf,
            },
            new CardInfoStat
            {
                positive = true,
                stat = "Damage",
                amount = "+20%",
                simepleAmount = CardInfoStat.SimpleAmount.aLittleBitOf,
            },
            new CardInfoStat
            {
                positive = true,
                stat = "Ability Duration",
                amount = "10s",
            },
            new CardInfoStat
            {
                positive = false,
                stat = "Ability Cooldown",
                amount = "30s",
            },
        },
    };
    
    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        cardInfo.allowMultiple = false;
        cardInfo.categories = new[] { CustomCardCategories.instance.CardCategory("Kingpin") };
        cardInfo.blacklistedCategories = new[] { CustomCardCategories.instance.CardCategory("Stoic"), CustomCardCategories.instance.CardCategory("Syphon") };
        gun.damage = 1.2f;
    }

    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        data.maxHealth *= 2f;
    }
}

public class KingpinEffect : AbilityEffect
{
    public override float cooldown => 30f;
    public override float duration => 10f;
    
    protected override void StartAbility()
    {
        data.stats.GetAdditionalData().kingpinActive = true;
    }

    protected override void EndAbility()
    {
        data.stats.GetAdditionalData().kingpinActive = false;
    }

    public override void OnTakeDamage(Vector2 damage, bool selfDamage)
    {
        if (IsActive() && data.stats.GetAdditionalData().kingpinActive)
            data.healthHandler.Heal(damage.magnitude * 0.99f);
    }
}