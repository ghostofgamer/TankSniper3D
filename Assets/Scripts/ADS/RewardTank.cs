using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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