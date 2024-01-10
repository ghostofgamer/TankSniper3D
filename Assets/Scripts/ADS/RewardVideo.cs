using Agava.YandexGames;

namespace Assets.Scripts.ADS
{
    public class RewardVideo : Ad
    {
        public override void Show()
        {
            if (YandexGamesSdk.IsInitialized)
                VideoAd.Show(OnOpen, OnReward, OnClose);
        }

        public virtual void OnReward() { }
    }
}