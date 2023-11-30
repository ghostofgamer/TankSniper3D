using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimInput : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private TowerRotates _towerRotate;
    [SerializeField] private CameraAim _cameraAim;
    //[SerializeField] private AimButton _aimButton;

    private Coroutine _coroutine;

    public bool IsZoom { get; private set; } = false;
    //public bool IsButtonClick { get; private set; } = false;

    //private void Update()
    //{
    //    if (!_weapon.IsReload)
    //    {
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            //_cameraAim.SetCamera();
    //        }

    //        if (Input.GetMouseButton(0))
    //        {
    //            //_towerRotate.Rotate();
    //            IsZoom = true;
    //        }

    //        if (Input.GetMouseButtonUp(0))
    //        {
    //            //IsZoom = false;

    //            //if (_weapon.IsLastShoot)
    //            //{
    //            //    //_cameraAim.SetCinemachineCamera();
    //            //    _weapon.LastShoot();
    //            //    //OnSetCameraPause();

    //            //    //if (_coroutine != null)
    //            //    //    StopCoroutine(_coroutine);

    //            //    //_coroutine = StartCoroutine(_cameraAim.SetCameraPause());
    //            //}
    //            else
    //            {
    //                _weapon.Shoot();
    //                //OnSetCameraPause();
    //                //if (_coroutine != null)
    //                //    StopCoroutine(_coroutine);

    //                //_coroutine = StartCoroutine(_cameraAim.SetCameraPause());
    //            }
    //        }
    //    }

    //    if (!IsZoom)
    //    {
    //        _towerRotate.ResetRotate();
    //    }
    //}

    //private void OnSetCameraPause()
    //{
    //    if (_coroutine != null)
    //        StopCoroutine(_coroutine);

    //    _coroutine = StartCoroutine(_cameraAim.SetCameraPause());
    //}
}
