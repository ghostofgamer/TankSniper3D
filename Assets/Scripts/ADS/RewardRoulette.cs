using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardRoulette : RewardVideo
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Roulette _roulette;

    private const string MainMenu = "MainScene";

    public override void OnReward()
    {
        _wallet.AddMoney(_roulette.Win);
        SceneManager.LoadScene(MainMenu);
    }
}