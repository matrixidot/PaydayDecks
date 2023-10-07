namespace PaydayDecks.Cards.Skills;

using ModsPlus;

public class ShockAndAwe : SimpleCard
{
    public override CardDetails Details => new()
    {
        Title = "Shock And Awe",
        Description = "Gain blocks faster and block an extra time because of improvements to shield tech. Bullets also slow enemies because they are cool.",
        ModName = $"{PDDecks.ModInitials}",
        Rarity = CardInfo.Rarity.Rare,
        Theme = CardThemeColor.CardThemeColorType.DefensiveBlue,
        Stats = new []
        {
            new CardInfoStat
            {
                positive = true,
                stat = "Block Cooldown",
                amount = "-25%",
                simepleAmount = CardInfoStat.SimpleAmount.lower,
            },
            new CardInfoStat
            {
                positive = true,
                stat = "Blocks",
                amount = "+1",
            },
            new CardInfoStat
            {
                positive = true,
                stat = "Bullet Slow",
                amount = "+20%",
                simepleAmount = CardInfoStat.SimpleAmount.aLittleBitOf,
            },
        },
    };

    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        block.cdMultiplier = 0.75f;
        block.additionalBlocks = 1;
        gun.slow = 0.20f;
    }
}