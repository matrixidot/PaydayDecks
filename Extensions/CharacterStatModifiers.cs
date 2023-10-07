namespace PaydayDecks.Extensions;

using System.Runtime.CompilerServices;

// ADD FIELDS TO CHARACTERSTATMODIFIERS
[Serializable]
public class CharacterStatModifiersAdditionalData
{
    public bool syphoning;
    public bool kingpinActive;
    public CharacterStatModifiersAdditionalData()
    {
        syphoning = false;
        kingpinActive = false;
    }
}
public static class CharacterStatModifiersExtension
{
    public static readonly ConditionalWeakTable<CharacterStatModifiers, CharacterStatModifiersAdditionalData> data =
        new ();

    public static CharacterStatModifiersAdditionalData GetAdditionalData(this CharacterStatModifiers characterstats)
    {
        return data.GetOrCreateValue(characterstats);
    }

    public static void AddData(this CharacterStatModifiers characterstats, CharacterStatModifiersAdditionalData value)
    {
        try
        {
            data.Add(characterstats, value);
        }
        catch (Exception) { }
    }

}
