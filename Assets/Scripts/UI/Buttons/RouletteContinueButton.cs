using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RouletteContinueButton : AbstractButton
{
    //[SerializeField] private VictoryScreen _victoryScreen;
    [SerializeField] private Roulette _roulette;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private FullAds _fullVideo;

    private const string MainMenu = "MainTestScene";

    public override void OnClick()
    {
        //Time.timeScale = 0;
        _roulette.GetComponent<Animator>().enabled = false;
        _wallet.AddMoney(_roulette.Win);
        _fullVideo.Show();

        //_victoryScreen.ChangeRewardRoulette(_roulette.Win);
        //SceneManager.LoadScene(MainMenu);
    }
}