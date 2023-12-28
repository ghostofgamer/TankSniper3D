using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : EndGame
{
    [SerializeField] private PanelInfo _panelInfo;
    [SerializeField] private ReviewCamera _reviewCamera;

    private AimInputButton _aimInputButton;

    public Player Player { get; private set; }

    public void Init(Player player, AimInputButton aimInputButton)
    {
        Player = player;
        Reward = _levelConfig.RewardGameOver;
        _rewardCountText.text = Reward.ToString();
        _aimInputButton = aimInputButton;
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
        base.OnEndGame();
        _reviewCamera.enabled = false;
    }
}