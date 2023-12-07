using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : EndGame
{
    [SerializeField] private KilledInfo _killedInfo;
    [SerializeField] private Save _save;
    [SerializeField] private GameObject _panelInfo;

    private Progress _progress;

    private void OnEnable()
    {
        Reward = _levelConfig.RewardVictory;
        _killedInfo.AllEnemysDying += OnEndGame;
    }

    private void OnDisable()
    {
        _killedInfo.AllEnemysDying -= OnEndGame;
    }

    public void Init(Progress progress)
    {
        Reward = _levelConfig.RewardVictory;
        _rewardCountText.text = Reward.ToString();
        _progress = progress;
    }

    protected override void OnEndGame()
    {
        base.OnEndGame();
        _panelInfo.SetActive(false);
        int index = SceneManager.GetActiveScene().buildIndex;
        _save.SetData(Save.SceneNumber, ++index);
        _save.SetData(Save.Map, _progress.AddIndex());
    }
}
