using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardTankButton : AbstractButton
{
    [SerializeField] private RewardTank _rewardTank;

    public override void OnClick()
    {
        Button.interactable = false;
        _rewardTank.Show();
    }
}