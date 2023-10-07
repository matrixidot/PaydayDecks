namespace PaydayDecks.Cards.Skills;

using ModsPlus;

public class Resilience : SimpleCard
{
    public override CardDetails Details => new()
    {
        Title = "Resilience",
        Description = "Hehe block go brrrrrrr",
        ModName = $"{PDDecks.ModInitials}",
        Rarity = CardInfo.Rarity.Uncommon,
        Theme = CardThemeColor.CardThemeColorType.DefensiveBlue,
        Stats = new []
        {
            new CardInfoStat
            {
                positive = true,
                stat = "Block Cooldown",
                amount = "0.85x",
            },
        },
    };

    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        block.cdMultiplier = 0.85f;
    }
}