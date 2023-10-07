namespace PaydayDecks.Cards.Skills;

using ModsPlus;

public class NineLives : SimpleCard
{
    public override CardDetails Details => new()
    {
        Title = "\"Nine Lives\"",
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
            new CardInfoStat
            {
                positive = false,
                stat = "Health",
                amount = "0.5x",
                simepleAmount = CardInfoStat.SimpleAmount.lower,
            },
            new CardInfoStat
            {
                positive = false,
                stat = "Movement Speed",
                amount = "-20%",
                simepleAmount = CardInfoStat.SimpleAmount.slightlyLower,
            },
        },
    };

    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        statModifiers.respawns = 1;
        statModifiers.movementSpeed = 0.80f;
    }

    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        data.maxHealth *= 0.5f;
    }
}