using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : EndGame
{
    public Player Player { get; private set; }

    [SerializeField] private AimInputButton _aimInputButton;
    [SerializeField] private PanelInfo _panelInfo;

    public void Init(Player player)
    {
        Player = player;
        Reward = _levelConfig.RewardGameOver;
        _rewardCountText.text = Reward.ToString();
    }

    private void OnEnable()
    {
        Player.Dying += OnEndGame;
    }

    private void OnDisable()
    {
        Player.Dying -= OnEndGame;
    }

    protected override void OnEndGame()
    {
        _aimInputButton.ReturnHide();
        _panelInfo.Close();
        //Open();
        base.OnEndGame();
    }
}