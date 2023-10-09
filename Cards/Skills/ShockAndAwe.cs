namespace PaydayDecks.Cards.Skills;

using ModsPlus;

public class ShockAndAwe : SimpleCard
{
    public override CardDetails Details => new()
    {
        Title = "Shock And Awe",
        Description = "Block improved, bullets also feel cold for some reason.",
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
            },
            new CardInfoStat
            {
                positive = false,
                stat = "Reload Speed",
                amount = "-20%",
            },
        },
    };

    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        block.cdMultiplier = 0.75f;
        block.additionalBlocks = 1;
        gun.slow = 0.20f;
        gun.reloadTime = 1.2f;
    }
}