using UnityEngine;

namespace Tank3D
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