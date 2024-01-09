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
    [SerializeField] private TMP_Text _rewardCountText;
    [SerializeField] private Load _load;
    [SerializeField] private ReviewCamera _reviewCamera;
    [SerializeField] private ContinueButton _continueButton;

    private Player _player;
    private Progress _progress;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.65f);
    private int _firstLevel = 1;
    private int _currentLevel;
    private int _factor = 500;
    private int _zero = 0;

    public event UnityAction ChangeReward;

    private void OnEnable()
    {
        int levelNumber = _load.Get(Save.LevelComplited, _firstLevel);
        _killedInfo.AllEnemysDying += OnEndGame;
    }

    private void OnDisable()
    {
        _killedInfo.AllEnemysDying -= OnEndGame;
    }

    public void Init(Progress progress, Player player)
    {
        Reward = _load.Get(Save.Reward, _zero) + _factor;
        _rewardCountText.text = Reward.ToString();
        _progress = progress;
        _player = player;
    }

    protected override void OnEndGame()
    {
        _reviewCamera.enabled = false;

        if (!_player.IsDead)
        {
            _currentLevel = _load.Get(Save.LevelComplited, _firstLevel);
            _levelNumber.text = _currentLevel.ToString();
            _currentLevel++;
            _save.SetData(Save.LevelComplited, _currentLevel);
            StartCoroutine(OnActiveButton());
            _enoughtAmountText.text = Reward.ToString();
            _panelInfo.SetActive(false);
            int index = SceneManager.GetActiveScene().buildIndex;
            _save.SetData(Save.SceneNumber, ++index);
            _save.SetData(Save.Map, _progress.AddIndex());
            _save.SetData(Save.Reward, Reward);
        }
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