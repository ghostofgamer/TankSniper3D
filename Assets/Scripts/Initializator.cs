using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class Initializator : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Player[] _players;
    [Header("UI")]
    [SerializeField] private KilledInfo _killedInfo;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private VictoryScreen _victoryScreen;
    [SerializeField] private PlayerHealthbar _playerHealthbar;
    [SerializeField] private FightScreen _fightScreen;
    [SerializeField] private BulletsInfo[] _bulletsInfo;
    [SerializeField] private AimInputButton[] _aimInputButton;
    [Header("Enemys")]
    [SerializeField] private Transform _enemysContainer;
    [Header("Camera")]
    [SerializeField] private HitPoint _hitPoint;
    [SerializeField] private ReviewCamera _reviewCamera;
    [Header("Other")]
    [SerializeField] private Alarm _alarm;
    [SerializeField] private Progress _progress;
    [SerializeField] private Load _load;
    [SerializeField] private MaterialContainer _materialContainer;
    [SerializeField] private ScreenFocus _screenFocus;

    private readonly int _startIndex = 0;

    //[SerializeField] private int _indexPlayer;
    private int _indexPlayer;
    private int _mobileIndex = 0;
    private int _pcIndex = 1;
    private Player _player;
    private List<GameObject> _gameObjects;

    private void Awake()
    {
        Time.timeScale = 1;
        _gameObjects = new List<GameObject>();
        _indexPlayer = _load.Get(Save.Tank, _startIndex);
        Init();
        YandexGamesSdk.GameReady();
    }

    private void Init()
    {
        _player = GetPlayer(_indexPlayer);
        _playerHealthbar.Init(_player);
        EnemyInit(_player);
        _hitPoint.Init(_player.GetComponent<TowerRotate>());
        PlatformInit();
        _alarm.Init(_player.GetComponent<Weapon>());
        FightScreenInit();
        GameOverScreenInit();
        _victoryScreen.Init(_progress);
        SetActive();
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
        _players[index].GetComponent<ColoringChanger>().SetMaterial(_materialContainer.GetColor());
        return _players[index];
    }

    private void FightScreenInit()
    {
        _fightScreen.Init(_player.GetComponent<Weapon>());
        _gameObjects.Add(_fightScreen.gameObject);
    }

    private void GameOverScreenInit()
    {
        //_gameOverScreen.Init(_player);
        //_gameObjects.Add(_gameOverScreen.gameObject);
    }

    private void PlatformInit()
    {
        foreach (AimInputButton aimInputButton in _aimInputButton)
            aimInputButton.Init(_player.GetComponent<Weapon>(), _player.GetComponent<TowerRotate>(), _player.GetComponent<CameraAim>(), _player.GetComponent<PlayerMover>());

        if (Application.isMobilePlatform)
            SetObject(_mobileIndex);
        else
            SetObject(_pcIndex);
    }

    private void SetObject(int index)
    {
        _aimInputButton[index].gameObject.SetActive(true);
        _player.GetComponent<CameraAim>().Init(_aimInputButton[index]);
        _killedInfo.Init(_aimInputButton[index].GetComponent<ButtonMover>());
        _bulletsInfo[index].Init(_player.GetComponent<Weapon>());
        _gameObjects.Add(_bulletsInfo[index].gameObject);
        _screenFocus.Init(_aimInputButton[index]);
        _reviewCamera.Init(_aimInputButton[index]);
        _gameOverScreen.Init(_player, _aimInputButton[index]);
        _gameObjects.Add(_gameOverScreen.gameObject);
    }

    private void SetActive()
    {
        foreach (GameObject gameObject in _gameObjects)
            gameObject.SetActive(true);
    }
}