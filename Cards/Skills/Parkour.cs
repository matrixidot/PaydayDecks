namespace PaydayDecks.Cards.Skills;

using ModsPlus;

public class Parkour : SimpleCard
{
    public override CardDetails Details => new()
    {
        Title = "Parkour",
        Description = "Move faster and double-jump because of TRAINING",
        ModName = $"{PDDecks.ModInitials}",
        Rarity = CardInfo.Rarity.Common,
        Theme = CardThemeColor.CardThemeColorType.MagicPink,
        Stats = new []
        {
            new CardInfoStat
            {
                positive = true,
                stat = "Movement Speed",
                amount = "1.1x",
            },
            new CardInfoStat
            {
                positive = true,
                stat = "Jump",
                amount = "+1",
            },
        },
    };
    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        characterStats.movementSpeed = 1.25f;
        characterStats.numberOfJumps = 1;
    }
}