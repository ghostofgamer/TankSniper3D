using ADS.Rustore;
using UnityEngine;
#if UNITY_WEBGL
using Agava.YandexGames;
#endif

namespace Assets.Scripts.ADS
{
    public class FullAds : Ad
    {
        public override void Show()
        {
#if UNITY_WEBGL
 if (YandexGamesSdk.IsInitialized)
                InterstitialAd.Show(OnOpen, OnClose);

#elif UNITY_ANDROID && RUSTORE
            if (InterstitialRustore.Instance.GetStatus())
            {
                InterstitialRustore.Instance.Show();
            }
            else
            {
                OnClose(true);
                Debug.Log("Реклама ещё не готова");
            }
#endif
        }
    }
}