using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardContinueButton : AbstractButton
{
    [SerializeField] private RewardVideo _rewardVideo;

    public override void OnClick()
    {
        Button.interactable = false;
        _rewardVideo.Show();
    }
}