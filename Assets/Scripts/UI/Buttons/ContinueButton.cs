using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ContinueButton : AbstractButton
{
    [SerializeField] private FullAds _fullVideo;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private EndGame _endGameScreen;
    [SerializeField] private GameObject _moneyFly;
    [SerializeField] private GameObject _moneyFlyMobile;

    private const string MainMenu = "MainScene";

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

    public override void OnClick()
    {
        StartCoroutine(GetMoney());
    }

    private IEnumerator GetMoney()
    {
        if (Application.isMobilePlatform)
            _moneyFlyMobile.SetActive(true);
        else
        _moneyFly.SetActive(true);
        yield return _waitForSeconds; 
        _wallet.AddMoney(_endGameScreen.ViewReward);
        SceneManager.LoadScene(MainMenu);
    }
}