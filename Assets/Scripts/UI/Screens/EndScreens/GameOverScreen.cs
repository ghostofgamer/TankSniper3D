using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : EndGame
{
    private Player _player;

    public void Init(Player player)
    {
        _player = player;
        Reward = _levelConfig.RewardGameOver;
        _rewardCountText.text = Reward.ToString();
    }

    private void OnEnable()
    {
        _player.Dying += OnEndGame;
    }

    private void OnDisable()
    {
        _player.Dying -= OnEndGame;
    }

    protected override void OnEndGame()
    {
        Open();
    }
}
