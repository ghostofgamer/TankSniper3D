using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : AbstarctScreen
{
    [SerializeField] private Player _player;

    public void Init(Player player)
    {
        _player = player;
    }

    private void OnEnable()
    {
        _player.Dying += OnDying;
    }

    private void OnDisable()
    {
        _player.Dying -= OnDying;
    }

    private void OnDying()
    {
        Open();
    }
}
