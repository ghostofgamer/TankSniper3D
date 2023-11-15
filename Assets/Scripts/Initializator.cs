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
    [SerializeField] private VictoryScreen _victoryScreen;
    [SerializeField] private PlayerHealthbar _playerHealthbar;
    [SerializeField] private AimInputButton[] _aimButton;
    [SerializeField] private FightScreen _fightScreen;
    [Header("Enemys")]
    [SerializeField] private Transform _enemysContainer;
    [Header("Other")]
    [SerializeField] private Alarm _alarm;
    [SerializeField] private Progress _progress;

    private Player _player;

    private void Awake()
    {
        Time.timeScale = 1;
        Init();
    }

    private void Init()
    {
        _player = GetPlayer(_indexPlayer);
        _playerHealthbar.Init(_player);
        EnemyInit(_player);
        _alarm.Init(_player.GetComponent<Weapon>());
        FightScreenInit();
        GameOverScreenInit();
        _victoryScreen.Init(_progress);
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
        _aimButton[index].gameObject.SetActive(true);
        return _players[index];
    }

    private void FightScreenInit()
    {
        _fightScreen.Init(_player.GetComponent<Weapon>());
        _fightScreen.gameObject.SetActive(true);
    }

    private void GameOverScreenInit()
    {
        _gameOverScreen.Init(_player);
        _gameOverScreen.gameObject.SetActive(true);
    }
}
