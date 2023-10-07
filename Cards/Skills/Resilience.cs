namespace PaydayDecks.Cards.Skills;

using ModsPlus;

public class Resilience : SimpleCard
{
    public override CardDetails Details => new()
    {
        Title = "Resilience",
        Description = "Hehe block go brrrrrrr",
        ModName = $"{PDDecks.ModInitials}",
        Rarity = CardInfo.Rarity.Common,
        Theme = CardThemeColor.CardThemeColorType.DefensiveBlue,
        Stats = new []
        {
            new CardInfoStat
            {
                positive = true,
                stat = "Block Cooldown",
                amount = "-10%",
                simepleAmount = CardInfoStat.SimpleAmount.slightlyLower,
            },
        },
    };

    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        block.cdMultiplier = 0.9f;
    }
}