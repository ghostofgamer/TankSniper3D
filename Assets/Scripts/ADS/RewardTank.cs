using Assets.Scripts.UI.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.ADS
{
    public class RewardTank : RewardVideo
    {
        [SerializeField] private BuyTank _button;
        [SerializeField] private RewardTankButton _rewardTankButton;

        public override void OnReward()
        {
            _button.OnClick();
        }

        protected override void OnClose()
        {
            base.OnClose();
            _rewardTankButton.GetComponent<Button>().interactable = true;
        }
    }
}