using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardRevive : RewardVideo
{
    [SerializeField] private GameOverScreen _gameOverScreen;

    public override void OnReward()
    {
        _gameOverScreen.Player.Revive();
    }
}