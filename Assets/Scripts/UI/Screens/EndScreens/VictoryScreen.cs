using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryScreen : EndGame
{
    [SerializeField] private KilledInfo _killedInfo;

    private void OnEnable()
    {
        Reward = _levelConfig.RewardVictory;
        _killedInfo.AllEnemysDying += OnEndGame;
    }

    private void OnDisable()
    {
        _killedInfo.AllEnemysDying -= OnEndGame;
    }

    public void Init()
    {
        Reward = _levelConfig.RewardVictory;
        _rewardCountText.text = Reward.ToString();
    }
}
