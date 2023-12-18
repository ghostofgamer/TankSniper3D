using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardRevive : RewardVideo
{
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private PanelInfo _panelInfo;

    public override void OnReward()
    {
        _gameOverScreen.Close();
        _panelInfo.Open();
        _gameOverScreen.Player.Revive();
    }
}