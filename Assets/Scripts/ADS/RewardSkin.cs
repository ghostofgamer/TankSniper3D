using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSkin : RewardVideo
{
    [SerializeField] private BuyButton buyButton;

    public override void OnReward()
    {
        buyButton.OffActive();
    }
}
