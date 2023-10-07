namespace PaydayDecks.Cards.Skills;

using ModsPlus;

public class NineLives : SimpleCard
{
    public override CardDetails Details => new()
    {
        Title = "Nine Lives",
        Description = "Come back after dying because of TRAINING",
        ModName = $"{PDDecks.ModInitials}",
        Rarity = CardInfo.Rarity.Rare,
        Theme = CardThemeColor.CardThemeColorType.MagicPink,
        Stats = new []
        {
            new CardInfoStat
            {
                positive = true,
                stat = "Lives",
                amount = "+1",
            },
        },
    };

    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        statModifiers.respawns = 1;
    }
}