using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimInput : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private TowerRotate _towerRotate;
    [SerializeField] private CameraAim _cameraAim;

    private Coroutine _coroutine;

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
            }

            if (Input.GetMouseButtonUp(0))
            {
                _weapon.Shoot();
                _towerRotate.ResetRotate();

                if (_coroutine != null)
                    StopCoroutine(_coroutine);

                _coroutine = StartCoroutine(_cameraAim.SetCameraPause());
            }
        }
    }
}
