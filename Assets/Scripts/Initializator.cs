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
    //[SerializeField] private AimInputButton[] _aimButton;
    [SerializeField] private FightScreen _fightScreen;
    [SerializeField] private BulletsInfo[] _bulletsInfo;
    [SerializeField] private AimInputButton[] _aimInputButton;
    [Header("Enemys")]
    [SerializeField] private Transform _enemysContainer;
    [Header("Camera")]
    [SerializeField] private HitPoint _hitPoint;
    [Header("Other")]
    [SerializeField] private Alarm _alarm;
    [SerializeField] private Progress _progress;
    [SerializeField] private Load _load;
    [SerializeField] private MaterialContainer _materialContainer;
    [SerializeField] private ScreenFocus _screenFocus;

    private readonly int _startIndex = 0;

    //[SerializeField] private int _indexPlayer;
    private int _indexPlayer;
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


        AimInputButtonInit();
        //AimInputButtonPCInit();

        _alarm.Init(_player.GetComponent<Weapon>());
        //BulletsInfoInit();
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
        //_aimButton[index].gameObject.SetActive(true);
        _players[index].GetComponent<ColoringChanger>().SetMaterial(_materialContainer.GetColor());
        return _players[index];
    }

    private void FightScreenInit()
    {
        _fightScreen.Init(_player.GetComponent<Weapon>());
        //_fightScreen.gameObject.SetActive(true);
        _gameObjects.Add(_fightScreen.gameObject);
    }

    private void GameOverScreenInit()
    {
        _gameOverScreen.Init(_player);
        //_gameOverScreen.gameObject.SetActive(true);
        _gameObjects.Add(_gameOverScreen.gameObject);
    }

    private void AimInputButtonInit()
    {
        foreach (var item in _aimInputButton)
        {
            item.Init(_player.GetComponent<Weapon>(), _player.GetComponent<TowerRotate>(), _player.GetComponent<CameraAim>(), _player.GetComponent<PlayerMover>());
        }

        if (Application.isMobilePlatform)
        {
            _aimInputButton[0].gameObject.SetActive(true);
            _player.GetComponent<CameraAim>().Init(_aimInputButton[0]);
            _killedInfo.Init(_aimInputButton[0].GetComponent<ButtonMover>());
            _bulletsInfo[0].Init(_player.GetComponent<Weapon>());
            _gameObjects.Add(_bulletsInfo[0].gameObject);
            _screenFocus.Init(_aimInputButton[0]);
        }
        else
        {
            _aimInputButton[1].gameObject.SetActive(true);
            _player.GetComponent<CameraAim>().Init(_aimInputButton[1]);
            _killedInfo.Init(_aimInputButton[1].GetComponent<ButtonMover>());
            _bulletsInfo[1].Init(_player.GetComponent<Weapon>());
            _gameObjects.Add(_bulletsInfo[1].gameObject);
            _screenFocus.Init(_aimInputButton[1]);
        }


        //_aimInputButton.Init(_player.GetComponent<Weapon>(), _player.GetComponent<TowerRotate>(), _player.GetComponent<CameraAim>(), _player.GetComponent<PlayerMover>());
        //_aimInputButton.gameObject.SetActive(true);
        //_gameObjects.Add(_aimInputButton.gameObject);
    }

    //private void BulletsInfoInit()
    //{
    //    _bulletsInfo.Init(_player.GetComponent<Weapon>());
    //    //_bulletsInfo.gameObject.SetActive(true);
    //    _gameObjects.Add(_bulletsInfo.gameObject);
    //}

    private void SetActive()
    {
        foreach (GameObject gameObject in _gameObjects)
            gameObject.SetActive(true);
    }
}