using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class AimInputButton : AbstractButton
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private CameraAim _cameraAim;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private GameObject _imageReload;
    [SerializeField] private EventTrigger _eventTrigger;
    [SerializeField] private KilledInfo _killedInfo;
    [SerializeField] private VisibilityAim _visibilityAim;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private ButtonMover _buttonMover;
    [SerializeField] private HitPoint _hitPoint;
    [SerializeField] private TowerRotate _towerRotate;

    public bool IsZoom { get; private set; } = false;
    public bool isPressed = false;

    private void Update()
    {
        _eventTrigger.enabled = !_imageReload.activeSelf;

        if (!_weapon.IsReload)
        {
            _buttonMover.Move();

            if (isPressed)
            {
                DoZoom();
            }

            if (!isPressed && IsZoom)
            {
                DoShoot();
            }
        }

        if (!IsZoom)
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

    private void DoZoom()
    {
        //IsZoom = true;
        _hitPoint.MoveRotate();
        _cameraAim.CameraFovForward();
    }

    private void DoShoot()
    {
        IsZoom = false;
        int randomNumber = Random.Range(0, 2);
        _weapon.Shoot();
        //if (_killedInfo.IsLastEnemy && randomNumber == 0)
        //{
        //    LastShootActivated();
        //}
        //else
        //{
        //    _weapon.Shoot();
        //}

        _buttonMover.Up();
    }

    private void OnDown()
    {
        IsZoom = true;
        _buttonMover.Down();
        isPressed = true;
        _playerMover.Go();
        _cameraMover.Forward();
        _visibilityAim.OnFadeIn();
    }

    private void OnUp()
    {
        //IsZoom = false;
        isPressed = false;
        _playerMover.Hide();
        _cameraMover.Back();
        _visibilityAim.OnFadeOut();
    }

    public void LastShootActivated()
    {
        _cameraAim.OnCinemaMachine();
        _weapon.LastShoot();
    }
}