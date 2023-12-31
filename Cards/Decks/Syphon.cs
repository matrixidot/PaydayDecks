﻿namespace PaydayDecks.Cards;

using Abstracts;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using Extensions;
using ModsPlus;
using RarityLib.Utils;
using UnityEngine;
using Utils;

public class Syphon : CustomEffectCard<SyphonEffect>
{
    public override CardDetails Details => new()
    {
        Title = "Syphon",
        Description = "On block: Start Syphoning, Heal 40%.\n" +
                      "While Syphoning: INVINCIBLE, lose 10% HP getting hurt, heal 10% HP & block every 2 times hurting someone. Lasts 10s",
        ModName = $"{PDDecks.ModInitials}",
        Rarity = RarityUtils.GetRarity("Deck"),
        Theme = CardThemeColor.CardThemeColorType.DefensiveBlue,
        Stats = new []
        {
            new CardInfoStat
            {
                positive = true,
                stat = "Health",
                amount = "1.75x",
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
                amount = "25s",
            },
        },
    };
    
    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        cardInfo.allowMultiple = false;
        cardInfo.categories = new[] { CustomCardCategories.instance.CardCategory("Syphon") };
        cardInfo.blacklistedCategories = new[] { CustomCardCategories.instance.CardCategory("Stoic") };

    }

    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        data.maxHealth *= 1.75f;
    }
}

public class SyphonEffect : AbilityEffect
{
    public override float cooldown => 35f; // Starts counting immediately after used

    public override float duration => 10f;
    
    private int hitsLanded = 0;
    protected override void StartAbility()
    {
        data.healthHandler.HealPercent(data.maxHealth, 40f);
        data.stats.GetAdditionalData().syphoning = true;
    }

    protected override void EndAbility()
    {
        data.stats.GetAdditionalData().syphoning = false;
        hitsLanded = 0;
    }

    public override void OnDealtDamage(Vector2 damage, bool selfDamage)
    {
        if (!data.stats.GetAdditionalData().syphoning || !IsActive())
            return;
        if (selfDamage)
            return;
        
        hitsLanded++;
        if (hitsLanded % 2 == 0)
        {
            data.healthHandler.HealPercent(data.maxHealth, 10f);
        }
    }
}