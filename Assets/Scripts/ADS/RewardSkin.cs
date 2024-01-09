using UnityEngine;

namespace Tank3D
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