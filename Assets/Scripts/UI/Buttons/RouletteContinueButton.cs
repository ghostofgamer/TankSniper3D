using Assets.Scripts.ADS;
using Assets.Scripts.PlayerWallet;
using Assets.Scripts.SaveLoad;
using UnityEngine;

namespace Assets.Scripts.UI.Buttons
{
    public class RouletteContinueButton : AbstractButton
    {
        [SerializeField] private Roulette _roulette;
        [SerializeField] private RewardVideo _rewardVideo;
        [SerializeField] private Load _load;

        private int _startVolume = 1;

        public override void OnClick()
        {
            EnableVictory();
        }

        public void SetActive()
        {
            _roulette.GetComponent<Animator>().enabled = false;
            Button.interactable = false;
        }

        private void EnableVictory()
        {
            int volume = _load.Get(Save.Volume, _startVolume);
            SetActive();
            _rewardVideo.SetVolume(volume);
            _rewardVideo.Show();
        }
    }
}