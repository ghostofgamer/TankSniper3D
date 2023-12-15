using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame : AbstractScreen
{
    [SerializeField] protected Wallet _wallet;
    [SerializeField] protected LevelConfig _levelConfig;
    [SerializeField] protected TMP_Text _rewardCountText;
    [SerializeField] private ContinueButton _continueButton;

    protected int Reward;

    protected Coroutine _coroutine;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);

    public int ViewReward => Reward;

    protected virtual void OnEndGame()
    {
        Debug.Log("ONENDGAME");
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        StartCoroutine(OpenScreen());
    }

    private IEnumerator OpenScreen()
    {
        yield return _waitForSeconds;
        Open();
    }

    //public void AddReward() 
    //{
    //    _wallet.AddMoney(Reward);
    //}
}