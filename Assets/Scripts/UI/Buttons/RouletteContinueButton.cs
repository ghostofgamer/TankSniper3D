using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RouletteContinueButton : AbstractButton
{
    [SerializeField] private Roulette _roulette;
    [SerializeField] private RewardVideo _rewardVideo;

    public override void OnClick()
    {
        _roulette.GetComponent<Animator>().enabled = false;
        _rewardVideo.Show();
    }
}