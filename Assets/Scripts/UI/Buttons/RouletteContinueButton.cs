using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RouletteContinueButton : AbstractButton
{
    //[SerializeField] private VictoryScreen _victoryScreen;
    [SerializeField] private Roulette _roulette;
    [SerializeField] private Wallet _wallet;

    private const string MainMenu = "MainTestScene";

    public override void OnClick()
    {
        //_victoryScreen.ChangeRewardRoulette(_roulette.Win);
        SceneManager.LoadScene(MainMenu);
        _wallet.AddMoney(_roulette.Win);
    }
}