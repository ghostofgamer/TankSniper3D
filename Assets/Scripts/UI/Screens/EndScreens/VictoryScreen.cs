using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : EndGame
{
    [SerializeField] private KilledInfo _killedInfo;
    [SerializeField] private Save _save; 

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

    protected override void OnEndGame()
    {
        base.OnEndGame();
        _save.SetScene(SceneManager.GetActiveScene().buildIndex);
    }
}
