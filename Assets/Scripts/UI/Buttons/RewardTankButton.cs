using Assets.Scripts.ADS;
using Assets.Scripts.SaveLoad;
using UnityEngine;

namespace Assets.Scripts.UI.Buttons
{
    public class RewardTankButton : AbstractButton
    {
        [SerializeField] private RewardTank _rewardTank;
        [SerializeField] private Load _load;

        private int _startVolume = 1;

        public override void OnClick()
        {
#if UNITY_ANDROID && RUSTORE
            if (!AdsRustore.Instance.GetStatus())
                return;
#endif

            int volume = _load.Get(Save.Volume, _startVolume);
            Button.interactable = false;
            _rewardTank.SetVolume(volume);
            _rewardTank.Show();
        }
    }
}