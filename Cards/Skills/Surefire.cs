namespace PaydayDecks.Cards.Skills;

using ModsPlus;

public class Surefire : SimpleCard
{
    public override CardDetails Details => new()
    {
        Title = "Surefire",
        Description = "Mag space efficiency improvements allow for 15 more AMMO per mag. You also reload faster because of TRAINING",
        ModName = $"{PDDecks.ModInitials}",
        Rarity = CardInfo.Rarity.Rare,
        Theme = CardThemeColor.CardThemeColorType.FirepowerYellow,
        Stats = new []
        {
            new CardInfoStat
            {
                positive = true,
                stat = "AMMO",
                amount = "+15",
            },
            new CardInfoStat
            {
                positive = true,
                stat = "Reload Speed",
                amount = "0.9x",
            },
        },
    };

    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        gun.reloadTime = 0.9f;
    }

    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        gunAmmo.maxAmmo += 15;
    }
}