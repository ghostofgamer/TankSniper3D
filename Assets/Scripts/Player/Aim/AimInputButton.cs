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
    [SerializeField] private ButtonScaler _buttonScaler;
    [SerializeField] private HitPoint _hitPoint;
    [SerializeField] private TowerRotate _towerRotate;
    [SerializeField] private CancelShootButton _cancelShoot;
    [SerializeField] private FightScreen _fightScreen;

    private WaitForSeconds _waitForPauzeZoom = new WaitForSeconds(0.65f);
    private WaitForSeconds _waitForReload = new WaitForSeconds(3f);
    private WaitForSeconds _waitForReturnButton = new WaitForSeconds(1f);
    private bool _isPressed = false;

    public bool IsZoom { get; private set; } = false;

    private void Update()
    {
        if (_killedInfo.AllDie)
            _eventTrigger.enabled = false;

        _eventTrigger.enabled = !_reloadSlider.gameObject.activeSelf;

        if (!_weapon.IsReload)
        {
            if (_isPressed)
                DoZoom();
        }

        if (!_isPressed && IsZoom)
        {
            DoZoomOff();
        }

        if (!IsZoom || _weapon.IsReload)
        {
            _towerRotate.ResetRotate();
            _cameraAim.CameraFovBack();
        }
    }

    public override void OnClick() { }

    public void Init(Weapon weapon, TowerRotate towerRotate, CameraAim cameraAim, PlayerMover playerMover)
    {
        _weapon = weapon;
        _towerRotate = towerRotate;
        _cameraAim = cameraAim;
        _playerMover = playerMover;
    }

    public void ReturnHide()
    {
        _isPressed = false;
        _playerMover.Hide();
        _visibilityAim.OnFadeOut();
    }

    private void OnDown()
    {
        IsZoom = true;
        _fightScreen.OnSetScreen();
        _buttonScaler.Down();
        _isPressed = true;
        _playerMover.Go();
        _visibilityAim.OnFadeIn();
        _cancelShoot.gameObject.SetActive(true);
    }

    private void OnUp()
    {
        ReturnHide();

        if (!_cancelShoot.IsCancel && !_playerMover.GetComponent<Player>().IsDead)
            _weapon.Shoot();

        _cancelShoot.gameObject.SetActive(false);
        StartCoroutine(ReturnButton());
    }

    private void DoZoom()
    {
        _hitPoint.MoveRotate();
        _cameraAim.CameraFovForward();
    }

    private void DoZoomOff()
    {
        StartCoroutine(ZoomOff());
    }

    private IEnumerator ZoomOff()
    {
        yield return _waitForPauzeZoom;
        IsZoom = false;
    }

    private IEnumerator ReturnButton()
    {
        yield return _waitForReturnButton;

        if (_reloadSlider.gameObject.activeSelf)
            yield return _waitForReload;

        _buttonScaler.Up();
    }
}