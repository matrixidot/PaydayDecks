// namespace PaydayDecks;
//
// using System.Collections;
// using System.Reflection;
// using UnityEngine;
//
// public class Assets
// {
//     public static event Action OnFinishedLoadingAssets;
//
//     private static AssetBundle Bundle;
//
//     // public static GameObject SyphonArt;
//     // public static GameObject KingpinArt;
//     // public static GameObject StoicArt;
//     // public static GameObject AkimboArt;
//     // public static GameObject DACArt;
//     // public static GameObject FLArt;
//     // public static GameObject IronManArt;
//     // public static GameObject NineLivesArt;
//     // public static GameObject ParkourArt;
//     // public static GameObject ResilienceArt;
//     // public static GameObject SAAArt;
//     // public static GameObject SurefireArt;
//     
//     
//     static Assets()
//     {
//         UnboundLib.Unbound.Instance.StartCoroutine(LoadAssets());
//     }
//     
//     public static IEnumerator LoadAssetBundleFromResources(bool doAsync, string bundleName, Assembly resourceAssembly)
//     {
//         if (resourceAssembly == null)
//         {
//             throw new ArgumentNullException("Parameter resourceAssembly can not be null.");
//         }
//
//         string resourceName = null;
//         try
//         {
//             resourceName = resourceAssembly.GetManifestResourceNames().Single(str => str.EndsWith(bundleName));
//         }
//         catch (Exception) { }
//
//         if (resourceName == null)
//         {
//             PDDecks.LOGGER.LogError($"AssetBundle {bundleName} not found in assembly manifest");
//             yield break;
//         }
//
//         AssetBundleCreateRequest ret;
//         using (var stream = resourceAssembly.GetManifestResourceStream(resourceName))
//         {
//             if (doAsync)
//             {
//                 ret = AssetBundle.LoadFromStreamAsync(stream);
//                 yield return new WaitUntil(() => ret.isDone);
//                 Bundle = ret.assetBundle;
//             }
//             else
//             {
//                 Bundle = AssetBundle.LoadFromStream(stream);
//             }
//         }
//     }
//     
//     private static IEnumerator LoadAssets()
//     {
//         PDDecks.LOGGER.LogInfo("STARTED LOADING BUNDLE");
//
//         yield return LoadAssetBundleFromResources(false, "paydayassets", typeof(PDDecks).Assembly);
//
//         PDDecks.LOGGER.LogInfo("FINISHED LOADING BUNDLE");
//
//         // SyphonArt = Bundle.LoadAsset<GameObject>("C_SyphonCard");
//         // KingpinArt = Bundle.LoadAsset<GameObject>("C_KingpinCard");
//         // StoicArt = Bundle.LoadAsset<GameObject>("C_StoicCard");
//         // AkimboArt = Bundle.LoadAsset<GameObject>("C_AkimboCard");
//         // DACArt = Bundle.LoadAsset<GameObject>("C_DACCard");
//         // FLArt = Bundle.LoadAsset<GameObject>("C_FLCard");
//         // IronManArt = Bundle.LoadAsset<GameObject>("C_IronManCard");
//         // NineLivesArt = Bundle.LoadAsset<GameObject>("C_NineLivesCard");
//         // ParkourArt = Bundle.LoadAsset<GameObject>("C_ParkourCard");
//         // ResilienceArt = Bundle.LoadAsset<GameObject>("C_ResilienceCard");
//         // SAAArt = Bundle.LoadAsset<GameObject>("C_SAACard");
//         // SurefireArt = Bundle.LoadAsset<GameObject>("C_SurefireCard");
//
//         OnFinishedLoadingAssets?.Invoke();
//     }
// }