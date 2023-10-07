namespace PaydayDecks.Cards.Skills;

using ModsPlus;

public class IronMan : SimpleCard
{
    public override CardDetails Details => new()
    {
        Title = "Iron Man",
        Description = "Nanotech causes your block to regen faster and for you to be more healthy",
        ModName = $"{PDDecks.ModInitials}",
        Rarity = CardInfo.Rarity.Rare,
        Theme = CardThemeColor.CardThemeColorType.DefensiveBlue,
        Stats = new []
        {
            new CardInfoStat
            {
                positive = true,
                stat = "Block Cooldown",
                amount = "-20%",
            },
            new CardInfoStat
            {
                positive = true,
                stat = "Health",
                amount = "1.5x",
            },
        },
    };

    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        block.cdMultiplier = 0.80f;
    }

    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        data.maxHealth *= 1.5f;
    }
}