namespace PaydayDecks;

using BepInEx;
using BepInEx.Logging;
using Cards;
using Cards.Skills;
using HarmonyLib;
using RarityLib.Utils;
using UnboundLib.Cards;
using UnityEngine;

[BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("com.willis.rounds.modsplus", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("root.rarity.lib", BepInDependency.DependencyFlags.HardDependency)]

[BepInPlugin(ModID, ModName, Version)]
[BepInProcess("Rounds.exe")]
public class PDDecks : BaseUnityPlugin
{
    public static ManualLogSource LOGGER { get => instance.Logger; }
    private const string ModID = "com.neo.rounds.PaydayDecks";
    private const string ModName = "Payday 2 Perk Cards";
    private const string Version = "1.0.3";
    public const string ModInitials = "Payday";
    public static PDDecks instance { get; private set; }
    
    public static readonly System.Random random = new();
    
    void Awake()
    {
        instance = this;
        //Assets.OnFinishedLoadingAssets += OnAssetsLoaded;
        var harmony = new Harmony(ModID);
        harmony.PatchAll();
        RarityUtils.AddRarity("Deck", 0.02f, new Color(1, 0, 1), new Color(0.8f, 0, 0.8f));
    }
    void Start()
    {
        CustomCard.BuildCard<Syphon>();
        CustomCard.BuildCard<Kingpin>();
        CustomCard.BuildCard<Stoic>();
        CustomCard.BuildCard<Akimbo>();
        CustomCard.BuildCard<DuckAndCover>();
        CustomCard.BuildCard<FullyLoaded>();
        CustomCard.BuildCard<IronMan>();
        CustomCard.BuildCard<NineLives>();
        CustomCard.BuildCard<Parkour>();
        CustomCard.BuildCard<Resilience>();
        CustomCard.BuildCard<ShockAndAwe>();
        CustomCard.BuildCard<Surefire>();
    }

    // private void OnAssetsLoaded()
    // {
    //     LOGGER.LogInfo("ASSETS DONE LOADING, REGISTERING CARDS...");
    // }
}