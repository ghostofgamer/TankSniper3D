using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimInput : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private TowerRotate _towerRotate;
    [SerializeField] private CameraAim _cameraAim;

    private Coroutine _coroutine;

    public bool IsZoom { get; private set; } = false;

    private void Update()
    {
        if (!_weapon.IsReload)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _cameraAim.SetCamera();
            }

            if (Input.GetMouseButton(0))
            {
                _towerRotate.Rotate();
                IsZoom = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                IsZoom = false;

                if (_weapon.IsLastShoot)
                {
                    _cameraAim.SetCinemachinecamera();
                    _weapon.LastShoot();
                    //_cameraAim.OFFCinemachinecamera();
                    if (_coroutine != null)
                        StopCoroutine(_coroutine);

                    _coroutine = StartCoroutine(_cameraAim.SetCameraPause());
                }
                else
                {
                    _weapon.Shoot();

                    if (_coroutine != null)
                        StopCoroutine(_coroutine);

                    _coroutine = StartCoroutine(_cameraAim.SetCameraPause());
                }
            }
        }

        if (!IsZoom)
        {
            _towerRotate.ResetRotate();
        }
    }
}
