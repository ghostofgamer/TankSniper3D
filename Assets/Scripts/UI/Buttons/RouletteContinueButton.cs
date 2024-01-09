using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RouletteContinueButton : AbstractButton
{
    [SerializeField] private Roulette _roulette;
    [SerializeField] private RewardVideo _rewardVideo;
    [SerializeField] private Load _load;
    [SerializeField] private GameObject _moneyMove;
    [SerializeField] private GameObject _moneyFlyMobile;
    [SerializeField] private Wallet _wallet;

    private int _startVolume = 1;

    public override void OnClick()
    {
        OnVictory();
    }

    public void SetActive()
    {
        _roulette.GetComponent<Animator>().enabled = false;
        Button.interactable = false;
    }

    private void OnVictory()
    {
        int volume = _load.Get(Save.Volume, _startVolume);
        SetActive();
        _rewardVideo.SetVolume(volume);
        _rewardVideo.Show();
    }
}