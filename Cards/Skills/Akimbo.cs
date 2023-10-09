namespace PaydayDecks.Cards.Skills;

using ModsPlus;

public class Akimbo : SimpleCard
{
    public override CardDetails Details => new()
    {
        Title = "Akimbo?",
        Description = "Fire once more each time... Not because of training, you just have an extra gun.",
        ModName = $"{PDDecks.ModInitials}",
        Rarity = CardInfo.Rarity.Rare,
        Theme = CardThemeColor.CardThemeColorType.FirepowerYellow,
        Stats = new []
        {
            new CardInfoStat
            {
                positive = true,
                stat = "AMMO",
                amount = "2x",
            },
            new CardInfoStat
            {
                positive = true,
                stat = "Bullets",
                amount = "+1",
            },
            new CardInfoStat
            {
                positive = false,
                stat = "Reload Speed",
                amount = "+50%",
            },
        },
    };

    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        gun.numberOfProjectiles = 1;
        gun.reloadTime = 1.5f;
    }

    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        gunAmmo.maxAmmo *= 2;
    }
}