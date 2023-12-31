using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardContinueButton : AbstractButton
{
    [SerializeField] private RewardVideo _rewardVideo;
    [SerializeField] private Load _load;

    private int _startVolume = 1;

    public override void OnClick()
    {
        int volume = _load.Get(Save.Volume, _startVolume);
        Button.interactable = false;
        _rewardVideo.SetVolume(volume);
        _rewardVideo.Show();
    }
}