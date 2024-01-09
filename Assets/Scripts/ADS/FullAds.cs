using Agava.YandexGames;

namespace Tank3D
{
    public class FullAds : Ad
    {
        public override void Show()
        {
            if (YandexGamesSdk.IsInitialized)
                InterstitialAd.Show(OnOpen, OnClose);
        }
    }
}