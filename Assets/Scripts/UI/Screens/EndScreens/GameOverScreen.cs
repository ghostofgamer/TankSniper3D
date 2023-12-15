using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : EndGame
{
    public Player _player { get; private set; }

    [SerializeField] private AimInputButton _aimInputButton;
    [SerializeField] private PanelInfo _panelInfo;

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
        _aimInputButton.ReturnHide();
        _panelInfo.Close();
        //Open();
        base.OnEndGame();
    }
    //protected override void OnEndGame()
    //{
    //    Open();
    //}
}