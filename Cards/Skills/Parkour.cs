namespace PaydayDecks.Cards.Skills;

using ModsPlus;

public class Parkour : SimpleCard
{
    public override CardDetails Details => new()
    {
        Title = "Parkour",
        Description = "Move faster and double-jump because of training",
        ModName = $"{PDDecks.ModInitials}",
        Rarity = CardInfo.Rarity.Common,
        Theme = CardThemeColor.CardThemeColorType.MagicPink,
        Stats = new []
        {
            new CardInfoStat
            {
                positive = true,
                stat = "Movement Speed",
                amount = "+10%",
                simepleAmount = CardInfoStat.SimpleAmount.aLittleBitOf,
            },
            new CardInfoStat
            {
                positive = true,
                stat = "Jump",
                amount = "+1",
            },
        },
    };

    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        statModifiers.movementSpeed = 1.1f;
    }

    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        statModifiers.numberOfJumps += 1;
    }
}