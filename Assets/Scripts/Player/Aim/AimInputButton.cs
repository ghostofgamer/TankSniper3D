using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimInputButton : AbstractButton
{
    [SerializeField] private TowerRotate _towerRotate;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private CameraAim _cameraAim;
    [SerializeField] private PlayerMover _playerMover;

    private Coroutine _coroutine;

    public bool IsZoom { get; private set; } = false;
    public bool isPressed = false;

    private void Update()
    {
        if (!_weapon.IsReload)
        {
            if (isPressed)
            {
                _towerRotate.Rotate();
                //_playerMover.Go();
                IsZoom = true;
            }

            if (!isPressed && IsZoom)
            {
                IsZoom = false;

                if (_weapon.IsLastShoot)
                {
                    _cameraAim.SetCinemachineCamera();
                    _weapon.LastShoot();
                    OnSetCameraPause();
                }
                else
                {
                    _weapon.Shoot();
                    OnSetCameraPause();
                    //_playerMover.Hide();
                }
            }
        }

        if (!IsZoom)
            _towerRotate.ResetRotate();
    }

    private void OnSetCameraPause()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(_cameraAim.SetCameraPause());
    }

    public override void OnClick()
    {
    }

    public void OnDown()
    {
        _playerMover.Go();
        _cameraAim.SetCamera();
        isPressed = true;
    }

    public void OnUp()
    {
        isPressed = false;
        _playerMover.Hide();
    }

    public void Init(Weapon weapon,/* TowerRotate towerRotate, */CameraAim cameraAim)
    {
        _weapon = weapon;
        //_towerRotate = towerRotate;
        _cameraAim = cameraAim;
    }
}
