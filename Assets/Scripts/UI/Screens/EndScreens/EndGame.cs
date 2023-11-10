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

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);

    protected virtual void OnEndGame()
    {
        StartCoroutine(OpenScreen());
    }

    private IEnumerator OpenScreen()
    {
        yield return _waitForSeconds;
        Open();
    }

    public void AddReward() 
    {
        _wallet.AddMoney(Reward);
    }
}
