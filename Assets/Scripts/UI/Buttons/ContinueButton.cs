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

    //private const string MainMenu = "MainScene";
    private const string MainMenu = "MainScene";

    public override void OnClick()
    {
        _wallet.AddMoney(_endGameScreen.ViewReward);
        //_fullVideo.Show();
        SceneManager.LoadScene(MainMenu);
    }
}
