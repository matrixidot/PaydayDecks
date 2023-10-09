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
                stat = "Max AMMO",
                amount = "2x",
            },
            new CardInfoStat
            {
                positive = false,
                stat = "Reload Speed",
                amount = "+75%",
            },
        },
    };

    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        gun.reloadTime = 1.75f;
    }

    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        gunAmmo.maxAmmo *= 2;
    }
}