using Agava.YandexGames;

public class RewardVideo : Ad
{
    public override void Show()
    {
        if (YandexGamesSdk.IsInitialized)
            VideoAd.Show(OnOpen, OnReward, OnClose);
    }

    public virtual void OnReward() { }

    protected override void OnClose()
    {
        base.OnClose();
    }
}