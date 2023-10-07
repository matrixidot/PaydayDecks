namespace PaydayDecks.Utils;

public static class HealthUtils
{
    public static void HealPercent(this HealthHandler handler, float maxHealth, float percent)
    {
        handler.Heal(maxHealth * (percent / 100f));
    }
}