using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardRevive : RewardVideo
{
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private PanelInfo _panelInfo;
    [SerializeField] private ReviewCamera _reviewCamera;

    public override void OnReward()
    {
        _gameOverScreen.Close();
        _panelInfo.Open();
        _reviewCamera.enabled = true;
        _gameOverScreen.Player.GetComponent<PlayerFire>().StewFire();
        _gameOverScreen.Player.Revive();
    }

    protected override void OnClose()
    {
        base.OnClose();
        GetComponent<Button>().interactable = true;
    }
}