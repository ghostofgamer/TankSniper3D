using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class VictoryScreen : EndGame
{
    [SerializeField] private KilledInfo _killedInfo;
    [SerializeField] private Save _save;
    [SerializeField] private GameObject _panelInfo;
    [SerializeField] private TMP_Text _levelNumber;

    private Progress _progress;

    public event UnityAction ChangeReward;

    private void OnEnable()
    {
        Reward = _levelConfig.RewardVictory;
        _levelNumber.text = _levelConfig.LevelNumber.ToString();
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

    public void ChangeRewardRoulette(int reward)
    {
        Reward = reward;
        _rewardCountText.text = Reward.ToString();
    }
}
