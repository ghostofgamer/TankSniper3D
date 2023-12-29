using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AimInputButton : AbstractButton
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private CameraAim _cameraAim;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private GameObject _imageReload;
    [SerializeField] private ReloadSlider _reloadSlider;
    [SerializeField] private EventTrigger _eventTrigger;
    [SerializeField] private KilledInfo _killedInfo;
    [SerializeField] private VisibilityAim _visibilityAim;
    [SerializeField] private ButtonMover _buttonMover;
    [SerializeField] private HitPoint _hitPoint;
    [SerializeField] private TowerRotate _towerRotate;
    [SerializeField] private CancelShoot _cancelShoot;
    [SerializeField] private FightScreen _fightScreen;

    public bool IsZoom { get; private set; } = false;
    public bool isPressed = false;

    public event UnityAction ButtonMove;

    private void Update()
    {
        if (_killedInfo.AllDie)
            _eventTrigger.enabled = false;

        _eventTrigger.enabled = !_reloadSlider.gameObject.activeSelf;

        if (!_weapon.IsReload)
        {
            if (isPressed)
                DoZoom();
        }

        if (!isPressed && IsZoom)
        {
            DoShoot();
        }

        if (!IsZoom || _weapon.IsReload)
        {
            _towerRotate.ResetRotate();
            _cameraAim.CameraFovBack();
        }
    }

    public override void OnClick()
    {
    }

    public void Init(Weapon weapon, TowerRotate towerRotate, CameraAim cameraAim, PlayerMover playerMover)
    {
        _weapon = weapon;
        _towerRotate = towerRotate;
        _cameraAim = cameraAim;
        _playerMover = playerMover;
    }

    public void LastShootActivated()
    {
        _cameraAim.OnCinemaMachine();
        _weapon.LastShoot();
    }

    public void ReturnHide()
    {
        isPressed = false;
        _playerMover.Hide();
        _visibilityAim.OnFadeOut();
    }

    private void OnDown()
    {
        IsZoom = true;
        _fightScreen.OnFirstShootAlarm();
        _buttonMover.Down();
        isPressed = true;
        _playerMover.Go();
        _visibilityAim.OnFadeIn();
        _cancelShoot.gameObject.SetActive(true);
    }

    private void OnUp()
    {
        ReturnHide();

        if (!_cancelShoot.IsCancelShoot && !_playerMover.GetComponent<Player>().IsDead)
        {
            _weapon.Shoot();
        }

        _cancelShoot.gameObject.SetActive(false);
        StartCoroutine(ReturnButton());
    }

    private void DoZoom()
    {
        _hitPoint.MoveRotate();
        _cameraAim.CameraFovForward();
    }

    private void DoShoot()
    {
        StartCoroutine(PauseZoomOff());
    }

    private IEnumerator PauseZoomOff()
    {
        yield return new WaitForSeconds(0.65f);
        IsZoom = false;
    }

    private IEnumerator ReturnButton()
    {
        float delay = 1f;
        yield return new WaitForSeconds(delay);

        if (_reloadSlider.gameObject.activeSelf)
        {
            delay = 3f;
            yield return new WaitForSeconds(delay);
        }

        _buttonMover.Up();
    }
}