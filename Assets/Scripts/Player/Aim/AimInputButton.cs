using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class AimInputButton : AbstractButton
{
    [SerializeField] private TowerRotate _towerRotate;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private CameraAim _cameraAim;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private GameObject _imageReload;
    [SerializeField] private EventTrigger _eventTrigger;
    [SerializeField] private KilledInfo _killedInfo;

    private Coroutine _coroutine;

    public bool IsZoom { get; private set; } = false;
    public bool isPressed = false;

    private void Update()
    {
        _eventTrigger.enabled = !_imageReload.activeSelf;

        if (!_weapon.IsReload)
        {
            if (isPressed)
            {
                _towerRotate.Rotate();
                IsZoom = true;
            }

            if (!isPressed && IsZoom)
            {
                IsZoom = false;
                int randomNumber = Random.Range(0, 2);

                if (_killedInfo.IsLastEnemy && randomNumber == 0)
                {

                    LastShootActivated();
                }
                else
                {
                    _weapon.Shoot();
                    OnSetCameraPause();
                }

                //if (!_weapon.IsLastShoot)
                //{
                //    _weapon.Shoot();
                //    OnSetCameraPause();
                //}
                //else
                //{
                //    LastShootActivated();
                //}
            }
        }

        if (!IsZoom)
            _towerRotate.ResetRotate();
    }

    public override void OnClick()
    {
    }

    public void Init(Weapon weapon, TowerRotate towerRotate, CameraAim cameraAim)
    {
        _weapon = weapon;
        _towerRotate = towerRotate;
        _cameraAim = cameraAim;
    }

    private void OnSetCameraPause()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(_cameraAim.SetCameraPause());
    }

    private void OnDown()
    {
        _playerMover.Go();
        _cameraAim.SetCamera();
        isPressed = true;
    }

    private void OnUp()
    {
        isPressed = false;
        _playerMover.Hide();
    }

    private void LastShootActivated()
    {
        _cameraAim.SetCinemachineCamera();
        _weapon.LastShoot();
        OnSetCameraPause();
    }
}