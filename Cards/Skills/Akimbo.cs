namespace PaydayDecks.Cards.Skills;

using ModsPlus;

public class Akimbo : SimpleCard
{
    public override CardDetails Details => new()
    {
        Title = "Akimbo",
        Description = "Fire 2 times at once... Not because of TRAINING, you just have 2 guns now.",
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
        },
    };

    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        gun.numberOfProjectiles = 2;
    }

    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        gunAmmo.maxAmmo *= 2;
    }
}