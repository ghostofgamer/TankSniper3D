using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardContinueButton : AbstractButton
{
    [SerializeField] private FullAds _fullVideo;
    //[SerializeField] private Player _player;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private PanelInfo _panelInfo;

    private const string MainMenu = "MainScene";

    public override void OnClick()
    {
        //_fullVideo.Show();
        _panelInfo.Open();
        _gameOverScreen._player.Revive();
        _gameOverScreen.Close();
    }
}