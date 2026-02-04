#if UNITY_WEBGL
using Agava.YandexGames;
#endif

namespace Assets.Scripts.ADS
{
    public class RewardVideo : Ad
    {
        public override void Show()
        {
#if UNITY_WEBGL && YANDEX_PLATFORM
            if (YandexGamesSdk.IsInitialized)
                VideoAd.Show(OnOpen, OnReward, OnClose);

#elif UNITY_ANDROID && RUSTORE
            AdsRustore.Instance.Show(OnReward, OnClose, OnError);
#endif
        }

        public virtual void OnReward()
        {
        }
    }
}