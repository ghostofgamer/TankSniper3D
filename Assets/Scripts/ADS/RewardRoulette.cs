using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardRoulette : RewardVideo
{
    private const string MainMenu = "MainScene";

    [SerializeField] private Wallet _wallet;
    [SerializeField] private Roulette _roulette;
    [SerializeField] private GameObject _moneyMove;
    [SerializeField] private GameObject _moneyFlyMobile;

    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.65f);

    public override void OnReward()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Victory());
    }

    private IEnumerator Victory()
    {
        if (Application.isMobilePlatform)
            _moneyFlyMobile.SetActive(true);
        else
            _moneyMove.SetActive(true);

        _wallet.AddMoney(_roulette.Win);
        yield return _waitForSeconds;
        SceneManager.LoadScene(MainMenu);
    }
}