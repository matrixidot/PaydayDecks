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
                amount = "1.25x",
            },
        },
    };
    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        characterStats.movementSpeed = 1.25f;
    }
}