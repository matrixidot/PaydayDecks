namespace PaydayDecks.Cards.Skills;

using ModsPlus;

public class Surefire : SimpleCard
{
    public override CardDetails Details => new()
    {
        Title = "Surefire",
        Description = "Gun improvements allow for better attack and reload speed. You also add 15 More bullets to your mag because of TRAINING",
        ModName = $"{PDDecks.ModInitials}",
        Rarity = CardInfo.Rarity.Uncommon,
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
                amount = "-10%",
                simepleAmount = CardInfoStat.SimpleAmount.aLittleBitOf,
            },
            new CardInfoStat
            {
                positive = true,
                stat = "ATKSPD",
                amount = "+25%",
                simepleAmount = CardInfoStat.SimpleAmount.Some,
            },
        },
    };

    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        gun.reloadTime = 0.9f;
        gun.attackSpeed = 0.75f;
    }

    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        gunAmmo.maxAmmo += 15;
    }
}