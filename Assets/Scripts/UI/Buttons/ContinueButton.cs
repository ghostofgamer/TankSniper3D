using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : AbstractButton
{
    [SerializeField] private VictoryScreen _victoryScreen;
    [SerializeField] private Wallet _wallet;

    private const string MainMenu = "MainScene";

    public override void OnClick()
    {
        _wallet.AddMoney(_victoryScreen.Reward);
        SceneManager.LoadScene(MainMenu);
    }
}
