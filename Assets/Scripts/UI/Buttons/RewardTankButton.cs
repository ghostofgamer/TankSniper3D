using UnityEngine;

namespace Tank3D
{
    public class RewardTankButton : AbstractButton
    {
        [SerializeField] private RewardTank _rewardTank;
        [SerializeField] private Load _load;

        private int _startVolume = 1;

        public override void OnClick()
        {
            int volume = _load.Get(Save.Volume, _startVolume);
            Button.interactable = false;
            _rewardTank.SetVolume(volume);
            _rewardTank.Show();
        }
    }
}