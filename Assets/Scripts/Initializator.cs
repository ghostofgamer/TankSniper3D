using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializator : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Player[] _players;
    [SerializeField] private int _indexPlayer;
    [Header("UI")]
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private PlayerHealthbar _playerHealthbar;
    [Header("Enemys")]
    [SerializeField] private Transform _enemysContainer;
    [Header("Other")]
    [SerializeField] private Alarm _alarm;

    private Player _player;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _player = GetPlayer(_indexPlayer);
        EnemyInit(_player);
        _alarm.Init(_player.GetComponent<Weapon>());
        _gameOverScreen.Init(_player);
        _playerHealthbar.Init(_player);
    }

    private void EnemyInit(Player player)
    {
        for (int i = 0; i < _enemysContainer.childCount; i++)
            _enemysContainer.GetChild(i).GetComponent<Enemy>().Init(player);
    }

    private Player GetPlayer(int index)
    {
        foreach (Player player in _players)
            player.gameObject.SetActive(false);

        _players[index].gameObject.SetActive(true);
        return _players[index];
    }
}