namespace PaydayDecks.Cards.Skills;

using ModsPlus;

public class DuckAndCover : SimpleCard
{
    public override CardDetails Details => new()
    {
        Title = "Duck And Cover",
        Description = "You move faster because of TRAINING.",
        ModName = $"{PDDecks.ModInitials}",
        Rarity = CardInfo.Rarity.Common,
        Theme = CardThemeColor.CardThemeColorType.MagicPink,
        Stats = new []
        {
            new CardInfoStat
            {
                positive = true,
                stat = "Movement Speed",
                amount = "+25%",
                simepleAmount = CardInfoStat.SimpleAmount.Some,
            },
        },
    };

    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        statModifiers.movementSpeed = 1.25f;
    }
}