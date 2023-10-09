namespace PaydayDecks.Cards.Skills;

using ModsPlus;

public class Surefire : SimpleCard
{
    public override CardDetails Details => new()
    {
        Title = "Surefire",
        Description = "Gun improvements allow for better reload speed & ammo cap. But bullets are heavy.",
        ModName = $"{PDDecks.ModInitials}",
        Rarity = CardInfo.Rarity.Uncommon,
        Theme = CardThemeColor.CardThemeColorType.FirepowerYellow,
        Stats = new []
        {
            new CardInfoStat
            {
                positive = true,
                stat = "Max AMMO",
                amount = "+15",
            },
            new CardInfoStat
            {
                positive = true,
                stat = "Reload Speed",
                amount = "-10%",
            },
            new CardInfoStat
            {
                positive = false,
                stat = "Movement Speed",
                amount = "-10%",
            },
        },
    };

    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        gun.reloadTime = 0.9f;
        gun.attackSpeed = 0.75f;
        statModifiers.movementSpeed = 0.90f;
    }

    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        gunAmmo.maxAmmo += 15;
    }
}