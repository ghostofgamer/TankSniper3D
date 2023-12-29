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

    private int _startVolume = 1;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.65f);

    public override void OnClick()
    {
        StartCoroutine(OnVictory());
    }

    private IEnumerator OnVictory()
    {
        if (Application.isMobilePlatform)
            _moneyFlyMobile.SetActive(true);
        else
            _moneyMove.SetActive(true);

        int volume = _load.Get(Save.Volume, _startVolume);
        _roulette.GetComponent<Animator>().enabled = false;
        Button.interactable = false;
        yield return _waitForSeconds;
        _rewardVideo.SetVolume(volume);
        _rewardVideo.Show();
    }
}