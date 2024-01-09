using Agava.YandexGames;

public class FullAds : Ad
{
    public override void Show()
    {
        if (YandexGamesSdk.IsInitialized)
            InterstitialAd.Show(OnOpen, OnClose);
    }
}