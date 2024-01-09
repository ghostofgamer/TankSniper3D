using Assets.Scripts.ADS;
using UnityEngine;

namespace Assets.Scripts.UI.Buttons
{
    public class ExitButton : AbstractButton
    {
        [SerializeField] private FullAds _fullVideo;

        public override void OnClick()
        {
            _fullVideo.Show();
        }
    }
}