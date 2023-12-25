using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardTank : RewardVideo
{
    [SerializeField] private BuyTank _button;

    public override void OnReward()
    {
        _button.OnClick();
    }
}