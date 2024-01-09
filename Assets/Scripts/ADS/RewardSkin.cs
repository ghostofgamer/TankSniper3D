using Assets.Scripts.UI.Buttons;
using UnityEngine;

namespace Assets.Scripts.ADS
{
    public class RewardSkin : RewardVideo
    {
        [SerializeField] private BuyButton buyButton;

        public override void OnReward()
        {
            buyButton.OffActive();
        }
    }
}