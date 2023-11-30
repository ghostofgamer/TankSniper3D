using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class Initializator : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Player[] _players;
    [Header("UI")]
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private VictoryScreen _victoryScreen;
    [SerializeField] private PlayerHealthbar _playerHealthbar;
    [SerializeField] private AimInputButton[] _aimButton;
    [SerializeField] private FightScreen _fightScreen;
    [SerializeField] private BulletsInfo _bulletsInfo;
    [SerializeField] private AimInputButton _aimInputButton;
    [Header("Enemys")]
    [SerializeField] private Transform _enemysContainer;
    [Header("Camera")]
    [SerializeField] private HitPoint _hitPoint;
    [Header("Other")]
    [SerializeField] private Alarm _alarm;
    [SerializeField] private Progress _progress;
    [SerializeField] private Load _load;
    [SerializeField] private MaterialContainer _materialContainer;

    private readonly int _startIndex = 0;

    [SerializeField] private int _indexPlayer;
    private Player _player;

    private void Awake()
    {
        Time.timeScale = 1;
        //_indexPlayer = _load.Get(Save.Tank, _startIndex);
        Init();
        YandexGamesSdk.GameReady();
    }

    private void Init()
    {
        _player = GetPlayer(_indexPlayer);
        _playerHealthbar.Init(_player);
        EnemyInit(_player);
        _hitPoint.Init(_player.GetComponent<TowerRotate>());

        _aimInputButton.Init(_player.GetComponent<Weapon>(), _player.GetComponent<TowerRotate>(),_player.GetComponent<CameraAim>(), _player.GetComponent<PlayerMover>());
        _aimInputButton.gameObject.SetActive(true);


        _alarm.Init(_player.GetComponent<Weapon>());

        _bulletsInfo.Init(_player.GetComponent<Weapon>());
        _bulletsInfo.gameObject.SetActive(true);

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
        //_aimButton[index].gameObject.SetActive(true);
        _players[index].GetComponent<ColoringChanger>().SetMaterial(_materialContainer.GetColor());
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
