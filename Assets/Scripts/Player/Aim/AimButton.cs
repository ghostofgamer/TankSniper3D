using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimButton : AbstractButton
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private TowerRotate _towerRotate;
    [SerializeField] private CameraAim _cameraAim;

    private Coroutine _coroutine;

    public bool IsZoom { get; private set; } = false;
    //[SerializeField] private AimInput _aimInput;
    public bool isPressed = false;

    private void Update()
    {
        if (!_weapon.IsReload)
        {
            if (isPressed)
            {
                _towerRotate.Rotate();
                IsZoom = true;
            }

            if (!isPressed&& IsZoom)
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
                }
            }
        }

        if (!IsZoom)
        {
            _towerRotate.ResetRotate();
        }
    }

    private void OnSetCameraPause()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(_cameraAim.SetCameraPause());
    }

    public override void OnClick()
    {
        _cameraAim.SetCamera();
    }

    public void OnDown()
    {
        Debug.Log("зажата");
        _cameraAim.SetCamera();
        isPressed = true;
    }

    public void OnUp()
    {
        Debug.Log("jn;fnf");
        isPressed = false;
    }
}
