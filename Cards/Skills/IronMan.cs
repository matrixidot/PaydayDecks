namespace PaydayDecks.Cards.Skills;

using ModsPlus;

public class IronMan : SimpleCard
{
    public override CardDetails Details => new()
    {
        Title = "Iron Man",
        Description = "Nanotech causes your block to regen faster and for you to be more healthy. It is pretty heavy though.",
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
            new CardInfoStat
            {
                positive = false,
                stat = "Movement Speed",
                amount = "-10%",
            },
            new CardInfoStat
            {
                positive = false,
                stat = "Jump Height",
                amount = "-10%",
            },
        },
    };

    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        block.cdMultiplier = 0.80f;
        statModifiers.movementSpeed = 0.90f;
        statModifiers.jump = 0.90f;
    }

    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        data.maxHealth *= 1.5f;
    }
}