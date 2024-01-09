using UnityEngine;

public class ExitButton : AbstractButton
{
    [SerializeField] private FullAds _fullVideo;

    public override void OnClick()
    {
        _fullVideo.Show();
    }
}