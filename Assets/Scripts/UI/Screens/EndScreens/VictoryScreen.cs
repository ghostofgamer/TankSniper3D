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
    [SerializeField] private TMP_Text _enoughtAmountText;

    private Progress _progress;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.65f);

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
        StartCoroutine(OnActiveButton());
        //base.OnEndGame();
        _enoughtAmountText.text = Reward.ToString();
        _panelInfo.SetActive(false);
        int index = SceneManager.GetActiveScene().buildIndex;
        _save.SetData(Save.SceneNumber, ++index);
        _save.SetData(Save.Map, _progress.AddIndex());
    }

    public void ChangeRewardRoulette(int reward)
    {
        Reward = reward;
        //_rewardCountText.text = Reward.ToString();
    }

    private IEnumerator OnActiveButton()
    {
        yield return _waitForSeconds;
        Open();
        Time.timeScale = 1;
        yield return _waitForSeconds;
        _continueButton.gameObject.SetActive(true);
    }
}