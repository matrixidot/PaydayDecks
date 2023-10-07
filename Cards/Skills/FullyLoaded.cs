namespace PaydayDecks.Cards.Skills;

using ModsPlus;

public class FullyLoaded : SimpleCard
{
    public override CardDetails Details => new()
    {
        Title = "Fully Loaded",
        Description = "Dont have enough AMMO? Here is the solution",
        ModName = $"{PDDecks.ModInitials}",
        Rarity = CardInfo.Rarity.Uncommon,
        Theme = CardThemeColor.CardThemeColorType.DestructiveRed,
        Stats = new []
        {
            new CardInfoStat
            {
                positive = true,
                stat = "AMMO",
                amount = "2x",
            },
        },
    };
    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        gunAmmo.maxAmmo *= 2;
    }
}